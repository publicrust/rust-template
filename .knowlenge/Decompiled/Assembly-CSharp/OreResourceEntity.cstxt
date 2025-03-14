using Facepunch.Rust;
using Network;
using UnityEngine;

public class OreResourceEntity : StagedResourceEntity
{
	public GameObjectRef bonusPrefab;

	public GameObjectRef finishEffect;

	public GameObjectRef bonusFailEffect;

	public OreHotSpot _hotSpot;

	public SoundPlayer bonusSound;

	private int bonusesKilled;

	public int bonusesSpawned;

	public Vector3 lastNodeDir = Vector3.zero;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("OreResourceEntity.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void UpdateNetworkStage()
	{
		int num = stage;
		base.UpdateNetworkStage();
		if (stage != num && (bool)_hotSpot)
		{
			DelayedBonusSpawn();
		}
	}

	public void CleanupBonus()
	{
		if ((bool)_hotSpot)
		{
			_hotSpot.Kill();
		}
		_hotSpot = null;
	}

	public override void DestroyShared()
	{
		base.DestroyShared();
		CleanupBonus();
	}

	public override void OnKilled(HitInfo info)
	{
		CleanupBonus();
		Analytics.Server.OreKilled(this, info);
		base.OnKilled(info);
	}

	public override void ServerInit()
	{
		base.ServerInit();
		Invoke(InitialSpawnBonusSpot, 0f);
	}

	private void InitialSpawnBonusSpot()
	{
		if (!base.IsDestroyed)
		{
			_hotSpot = SpawnBonusSpot(Vector3.zero);
		}
	}

	public void FinishBonusAssigned()
	{
		Effect.server.Run(finishEffect.resourcePath, base.transform.position, base.transform.up);
	}

	public override void OnAttacked(HitInfo info)
	{
		if (base.isClient)
		{
			base.OnAttacked(info);
			return;
		}
		if (!info.DidGather && info.gatherScale > 0f)
		{
			Jackhammer jackhammer = info.Weapon as Jackhammer;
			if ((bool)_hotSpot || (bool)jackhammer)
			{
				if (_hotSpot == null)
				{
					_hotSpot = SpawnBonusSpot(lastNodeDir);
				}
				if (Vector3.Distance(info.HitPositionWorld, _hotSpot.transform.position) <= _hotSpot.GetComponent<SphereCollider>().radius * 1.5f || jackhammer != null)
				{
					float num = ((jackhammer == null) ? 1f : jackhammer.HotspotBonusScale);
					bonusesKilled++;
					info.gatherScale = 1f + Mathf.Clamp((float)bonusesKilled * 0.5f, 0f, 2f * num);
					_hotSpot.FireFinishEffect();
					ClientRPC(null, "PlayBonusLevelSound", bonusesKilled, _hotSpot.transform.position);
				}
				else if (bonusesKilled > 0)
				{
					bonusesKilled = 0;
					Effect.server.Run(bonusFailEffect.resourcePath, base.transform.position, base.transform.up);
				}
				if (bonusesKilled > 0)
				{
					CleanupBonus();
				}
			}
		}
		if (_hotSpot == null)
		{
			DelayedBonusSpawn();
		}
		base.OnAttacked(info);
	}

	public void DelayedBonusSpawn()
	{
		CancelInvoke(RespawnBonus);
		Invoke(RespawnBonus, 0.25f);
	}

	public void RespawnBonus()
	{
		CleanupBonus();
		_hotSpot = SpawnBonusSpot(lastNodeDir);
	}

	public OreHotSpot SpawnBonusSpot(Vector3 lastDirection)
	{
		if (base.isClient)
		{
			return null;
		}
		if (!bonusPrefab.isValid)
		{
			return null;
		}
		_ = Random.insideUnitCircle.normalized;
		Vector3 zero = Vector3.zero;
		MeshCollider stageComponent = GetStageComponent<MeshCollider>();
		Vector3 vector = base.transform.InverseTransformPoint(stageComponent.bounds.center);
		if (lastDirection == Vector3.zero)
		{
			Vector3 vector2 = RandomCircle();
			lastNodeDir = vector2.normalized;
			Vector3 vector3 = base.transform.TransformDirection(vector2.normalized);
			vector2 = base.transform.position + base.transform.up * (vector.y + 0.5f) + vector3.normalized * 2.5f;
			zero = vector2;
		}
		else
		{
			Vector3 vector4 = Vector3.Cross(lastNodeDir, Vector3.up);
			float num = Random.Range(0.25f, 0.5f);
			float num2 = ((Random.Range(0, 2) == 0) ? (-1f) : 1f);
			Vector3 direction = (lastNodeDir = (lastNodeDir + vector4 * num * num2).normalized);
			zero = base.transform.position + base.transform.TransformDirection(direction) * 2f;
			float num3 = Random.Range(1f, 1.5f);
			zero += base.transform.up * (vector.y + num3);
		}
		bonusesSpawned++;
		Vector3 normalized = (stageComponent.bounds.center - zero).normalized;
		if (stageComponent.Raycast(new Ray(zero, normalized), out var hitInfo, 10f))
		{
			OreHotSpot obj = GameManager.server.CreateEntity(bonusPrefab.resourcePath, hitInfo.point - normalized * 0.025f, Quaternion.LookRotation(hitInfo.normal, Vector3.up)) as OreHotSpot;
			obj.Spawn();
			obj.SendMessage("OreOwner", this);
			return obj;
		}
		return null;
	}

	public Vector3 RandomCircle(float distance = 1f, bool allowInside = false)
	{
		Vector2 vector = (allowInside ? Random.insideUnitCircle : Random.insideUnitCircle.normalized);
		return new Vector3(vector.x, 0f, vector.y);
	}

	public Vector3 RandomHemisphereDirection(Vector3 input, float degreesOffset, bool allowInside = true, bool changeHeight = true)
	{
		degreesOffset = Mathf.Clamp(degreesOffset / 180f, -180f, 180f);
		Vector2 vector = (allowInside ? Random.insideUnitCircle : Random.insideUnitCircle.normalized);
		Vector3 vector2 = new Vector3(vector.x * degreesOffset, changeHeight ? (Random.Range(-1f, 1f) * degreesOffset) : 0f, vector.y * degreesOffset);
		return (input + vector2).normalized;
	}

	public Vector3 ClampToHemisphere(Vector3 hemiInput, float degreesOffset, Vector3 inputVec)
	{
		degreesOffset = Mathf.Clamp(degreesOffset / 180f, -180f, 180f);
		Vector3 normalized = (hemiInput + Vector3.one * degreesOffset).normalized;
		Vector3 normalized2 = (hemiInput + Vector3.one * (0f - degreesOffset)).normalized;
		for (int i = 0; i < 3; i++)
		{
			inputVec[i] = Mathf.Clamp(inputVec[i], normalized2[i], normalized[i]);
		}
		return inputVec;
	}

	public static Vector3 RandomCylinderPointAroundVector(Vector3 input, float distance, float minHeight = 0f, float maxHeight = 0f, bool allowInside = false)
	{
		Vector2 vector = (allowInside ? Random.insideUnitCircle : Random.insideUnitCircle.normalized);
		Vector3 result = new Vector3(vector.x, 0f, vector.y).normalized * distance;
		result.y = Random.Range(minHeight, maxHeight);
		return result;
	}

	public Vector3 ClampToCylinder(Vector3 localPos, Vector3 cylinderAxis, float cylinderDistance, float minHeight = 0f, float maxHeight = 0f)
	{
		return Vector3.zero;
	}
}
