using System.Collections.Generic;
using ConVar;
using Facepunch;
using UnityEngine;

public class GroundWatch : BaseMonoBehaviour, IServerComponent
{
	public Vector3 groundPosition = Vector3.zero;

	public LayerMask layers = 27328512;

	public float radius = 0.1f;

	private int fails;

	private void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(groundPosition, radius);
	}

	public static void PhysicsChanged(GameObject obj)
	{
		Collider component = obj.GetComponent<Collider>();
		if (!component)
		{
			return;
		}
		Bounds bounds = component.bounds;
		List<BaseEntity> obj2 = Facepunch.Pool.GetList<BaseEntity>();
		Vis.Entities(bounds.center, bounds.extents.magnitude + 1f, obj2, 2263296);
		foreach (BaseEntity item in obj2)
		{
			if (!item.IsDestroyed && !item.isClient && !(item is BuildingBlock))
			{
				item.BroadcastMessage("OnPhysicsNeighbourChanged", SendMessageOptions.DontRequireReceiver);
			}
		}
		Facepunch.Pool.FreeList(ref obj2);
	}

	private void OnPhysicsNeighbourChanged()
	{
		if (!OnGround())
		{
			fails++;
			if (fails >= ConVar.Physics.groundwatchfails)
			{
				base.transform.root.BroadcastMessage("OnGroundMissing", SendMessageOptions.DontRequireReceiver);
				return;
			}
			if (ConVar.Physics.groundwatchdebug)
			{
				Debug.Log("GroundWatch retry: " + fails);
			}
			Invoke(OnPhysicsNeighbourChanged, ConVar.Physics.groundwatchdelay);
		}
		else
		{
			fails = 0;
		}
	}

	private bool OnGround()
	{
		BaseEntity component = GetComponent<BaseEntity>();
		if ((bool)component)
		{
			Construction construction = PrefabAttribute.server.Find<Construction>(component.prefabID);
			if ((bool)construction)
			{
				Socket_Base[] allSockets = construction.allSockets;
				for (int i = 0; i < allSockets.Length; i++)
				{
					SocketMod[] socketMods = allSockets[i].socketMods;
					for (int j = 0; j < socketMods.Length; j++)
					{
						SocketMod_AreaCheck socketMod_AreaCheck = socketMods[j] as SocketMod_AreaCheck;
						if ((bool)socketMod_AreaCheck && socketMod_AreaCheck.wantsInside && !socketMod_AreaCheck.DoCheck(component.transform.position, component.transform.rotation))
						{
							if (ConVar.Physics.groundwatchdebug)
							{
								Debug.Log("GroundWatch failed: " + socketMod_AreaCheck.hierachyName);
							}
							return false;
						}
					}
				}
			}
		}
		List<Collider> obj = Facepunch.Pool.GetList<Collider>();
		Vis.Colliders(base.transform.TransformPoint(groundPosition), radius, obj, layers);
		foreach (Collider item in obj)
		{
			BaseEntity baseEntity = GameObjectEx.ToBaseEntity(item.gameObject);
			if (!baseEntity || (!(baseEntity == component) && !baseEntity.IsDestroyed && !baseEntity.isClient))
			{
				DecayEntity decayEntity = component as DecayEntity;
				DecayEntity decayEntity2 = baseEntity as DecayEntity;
				if (!decayEntity || decayEntity.buildingID == 0 || !decayEntity2 || decayEntity2.buildingID == 0 || decayEntity.buildingID == decayEntity2.buildingID)
				{
					Facepunch.Pool.FreeList(ref obj);
					return true;
				}
			}
		}
		if (ConVar.Physics.groundwatchdebug)
		{
			Debug.Log("GroundWatch failed: Legacy radius check");
		}
		Facepunch.Pool.FreeList(ref obj);
		return false;
	}
}
