#define UNITY_ASSERTIONS
using System;
using ConVar;
using Facepunch.Rust;
using Network;
using Oxide.Core;
using UnityEngine;
using UnityEngine.Assertions;

public class Deployer : HeldEntity
{
	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("Deployer.OnRpcMessage"))
		{
			if (rpc == 3001117906u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - DoDeploy "));
				}
				using (TimeWarning.New("DoDeploy"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.IsActiveItem.Test(3001117906u, "DoDeploy", this, player))
						{
							return true;
						}
					}
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg2 = rPCMessage;
							DoDeploy(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in DoDeploy");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public ItemModDeployable GetModDeployable()
	{
		ItemDefinition ownerItemDefinition = GetOwnerItemDefinition();
		if (ownerItemDefinition == null)
		{
			return null;
		}
		return ownerItemDefinition.GetComponent<ItemModDeployable>();
	}

	public Deployable GetDeployable()
	{
		ItemModDeployable modDeployable = GetModDeployable();
		if (modDeployable == null)
		{
			return null;
		}
		return modDeployable.GetDeployable(this);
	}

	public Quaternion GetDeployedRotation(Vector3 normal, Vector3 placeDir)
	{
		return Quaternion.LookRotation(normal, placeDir) * Quaternion.Euler(90f, 0f, 0f);
	}

	public bool IsPlacementAngleAcceptable(Vector3 pos, Quaternion rot)
	{
		Vector3 lhs = rot * Vector3.up;
		if (Mathf.Acos(Vector3.Dot(lhs, Vector3.up)) <= 0.61086524f)
		{
			return true;
		}
		return false;
	}

	public bool CheckPlacement(Deployable deployable, Ray ray, float fDistance)
	{
		using (TimeWarning.New("Deploy.CheckPlacement"))
		{
			if (!UnityEngine.Physics.Raycast(ray, out var hitInfo, fDistance, 1235288065))
			{
				return false;
			}
			DeployVolume[] volumes = PrefabAttribute.server.FindAll<DeployVolume>(deployable.prefabID);
			Vector3 point = hitInfo.point;
			Quaternion deployedRotation = GetDeployedRotation(hitInfo.normal, ray.direction);
			if (DeployVolume.Check(point, deployedRotation, volumes))
			{
				return false;
			}
			if (!IsPlacementAngleAcceptable(hitInfo.point, deployedRotation))
			{
				return false;
			}
		}
		return true;
	}

	[RPC_Server]
	[RPC_Server.IsActiveItem]
	private void DoDeploy(RPCMessage msg)
	{
		if (!msg.player.CanInteract())
		{
			return;
		}
		Deployable deployable = GetDeployable();
		if (deployable == null)
		{
			return;
		}
		Ray ray = msg.read.Ray();
		NetworkableId networkableId = msg.read.EntityID();
		if (Interface.CallHook("CanDeployItem", msg.player, this, networkableId) == null)
		{
			if (deployable.toSlot)
			{
				DoDeploy_Slot(deployable, ray, networkableId);
			}
			else
			{
				DoDeploy_Regular(deployable, ray);
			}
		}
	}

	public void DoDeploy_Slot(Deployable deployable, Ray ray, NetworkableId entityID)
	{
		if (!HasItemAmount())
		{
			return;
		}
		BasePlayer ownerPlayer = GetOwnerPlayer();
		if (!ownerPlayer)
		{
			return;
		}
		if (!ownerPlayer.CanBuild())
		{
			ownerPlayer.ChatMessage("Building is blocked at player position!");
			return;
		}
		BaseEntity baseEntity = BaseNetworkable.serverEntities.Find(entityID) as BaseEntity;
		if (baseEntity == null || !baseEntity.HasSlot(deployable.slot) || baseEntity.GetSlot(deployable.slot) != null)
		{
			return;
		}
		if (ownerPlayer.Distance(baseEntity) > 3f)
		{
			ownerPlayer.ChatMessage("Too far away!");
			return;
		}
		if (!ownerPlayer.CanBuild(baseEntity.WorldSpaceBounds()))
		{
			ownerPlayer.ChatMessage("Building is blocked at placement position!");
			return;
		}
		Item ownerItem = GetOwnerItem();
		ItemModDeployable modDeployable = GetModDeployable();
		BaseEntity baseEntity2 = GameManager.server.CreateEntity(modDeployable.entityPrefab.resourcePath);
		if (baseEntity2 != null)
		{
			baseEntity2.skinID = ownerItem.skin;
			baseEntity2.SetParent(baseEntity, baseEntity.GetSlotAnchorName(deployable.slot));
			baseEntity2.OwnerID = ownerPlayer.userID;
			baseEntity2.OnDeployed(baseEntity, ownerPlayer, ownerItem);
			baseEntity2.Spawn();
			baseEntity.SetSlot(deployable.slot, baseEntity2);
			if (deployable.placeEffect.isValid)
			{
				Effect.server.Run(deployable.placeEffect.resourcePath, baseEntity.transform.position, Vector3.up);
			}
		}
		modDeployable.OnDeployed(baseEntity2, ownerPlayer);
		Interface.CallHook("OnItemDeployed", this, baseEntity, baseEntity2);
		Facepunch.Rust.Analytics.Azure.OnEntityBuilt(baseEntity2, ownerPlayer);
		UseItemAmount(1);
	}

	public void DoDeploy_Regular(Deployable deployable, Ray ray)
	{
		if (!HasItemAmount())
		{
			return;
		}
		BasePlayer ownerPlayer = GetOwnerPlayer();
		if (!ownerPlayer)
		{
			return;
		}
		if (!ownerPlayer.CanBuild())
		{
			ownerPlayer.ChatMessage("Building is blocked at player position!");
		}
		else if (ConVar.AntiHack.objectplacement && ownerPlayer.TriggeredAntiHack())
		{
			ownerPlayer.ChatMessage("AntiHack!");
		}
		else
		{
			if (!CheckPlacement(deployable, ray, 8f) || !UnityEngine.Physics.Raycast(ray, out var hitInfo, 8f, 1235288065))
			{
				return;
			}
			Vector3 point = hitInfo.point;
			Quaternion deployedRotation = GetDeployedRotation(hitInfo.normal, ray.direction);
			Item ownerItem = GetOwnerItem();
			ItemModDeployable modDeployable = GetModDeployable();
			if (ownerPlayer.Distance(point) > 3f)
			{
				ownerPlayer.ChatMessage("Too far away!");
				return;
			}
			if (!ownerPlayer.CanBuild(point, deployedRotation, deployable.bounds))
			{
				ownerPlayer.ChatMessage("Building is blocked at placement position!");
				return;
			}
			BaseEntity baseEntity = GameManager.server.CreateEntity(modDeployable.entityPrefab.resourcePath, point, deployedRotation);
			if (!baseEntity)
			{
				Debug.LogWarning("Couldn't create prefab:" + modDeployable.entityPrefab.resourcePath);
				return;
			}
			baseEntity.skinID = ownerItem.skin;
			baseEntity.SendMessage("SetDeployedBy", ownerPlayer, SendMessageOptions.DontRequireReceiver);
			baseEntity.OwnerID = ownerPlayer.userID;
			baseEntity.Spawn();
			modDeployable.OnDeployed(baseEntity, ownerPlayer);
			Interface.CallHook("OnItemDeployed", this, modDeployable, baseEntity);
			Facepunch.Rust.Analytics.Azure.OnEntityBuilt(baseEntity, ownerPlayer);
			UseItemAmount(1);
		}
	}
}
