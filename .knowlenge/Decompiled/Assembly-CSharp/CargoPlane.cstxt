using Facepunch;
using Oxide.Core;
using ProtoBuf;
using UnityEngine;

public class CargoPlane : BaseEntity
{
	public GameObjectRef prefabDrop;

	public SpawnFilter filter;

	public Vector3 startPos;

	public Vector3 endPos;

	public float secondsToTake;

	public float secondsTaken;

	public bool dropped;

	public Vector3 dropPosition = Vector3.zero;

	public override void ServerInit()
	{
		base.ServerInit();
		Initialize();
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		if (dropPosition == Vector3.zero)
		{
			Initialize();
		}
	}

	private void Initialize()
	{
		if (dropPosition == Vector3.zero)
		{
			dropPosition = RandomDropPosition();
		}
		UpdateDropPosition(dropPosition);
	}

	public void InitDropPosition(Vector3 newDropPosition)
	{
		dropPosition = newDropPosition;
		dropPosition.y = 0f;
	}

	public Vector3 RandomDropPosition()
	{
		Vector3 zero = Vector3.zero;
		float num = 100f;
		float x = TerrainMeta.Size.x;
		do
		{
			zero = Vector3Ex.Range(0f - x / 3f, x / 3f);
		}
		while (filter.GetFactor(zero) == 0f && (num -= 1f) > 0f);
		zero.y = 0f;
		return zero;
	}

	public void UpdateDropPosition(Vector3 newDropPosition)
	{
		float x = TerrainMeta.Size.x;
		float y = TerrainMeta.HighestPoint.y + 250f;
		startPos = Vector3Ex.Range(-1f, 1f);
		startPos.y = 0f;
		startPos.Normalize();
		startPos *= x * 2f;
		startPos.y = y;
		endPos = startPos * -1f;
		endPos.y = startPos.y;
		startPos += newDropPosition;
		endPos += newDropPosition;
		secondsToTake = Vector3.Distance(startPos, endPos) / 50f;
		secondsToTake *= UnityEngine.Random.Range(0.95f, 1.05f);
		base.transform.position = startPos;
		base.transform.rotation = Quaternion.LookRotation(endPos - startPos);
		dropPosition = newDropPosition;
		Interface.CallHook("OnAirdrop", this, newDropPosition);
	}

	private void Update()
	{
		if (!base.isServer)
		{
			return;
		}
		secondsTaken += Time.deltaTime;
		float num = Mathf.InverseLerp(0f, secondsToTake, secondsTaken);
		if (!dropped && num >= 0.5f)
		{
			dropped = true;
			BaseEntity baseEntity = GameManager.server.CreateEntity(prefabDrop.resourcePath, base.transform.position);
			if ((bool)baseEntity)
			{
				baseEntity.globalBroadcast = true;
				baseEntity.Spawn();
				Interface.CallHook("OnSupplyDropDropped", baseEntity, this);
			}
		}
		base.transform.position = Vector3.Lerp(startPos, endPos, num);
		base.transform.hasChanged = true;
		if (num >= 1f)
		{
			Kill();
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (base.isServer && info.forDisk)
		{
			info.msg.cargoPlane = Pool.Get<ProtoBuf.CargoPlane>();
			info.msg.cargoPlane.startPos = startPos;
			info.msg.cargoPlane.endPos = endPos;
			info.msg.cargoPlane.secondsToTake = secondsToTake;
			info.msg.cargoPlane.secondsTaken = secondsTaken;
			info.msg.cargoPlane.dropped = dropped;
			info.msg.cargoPlane.dropPosition = dropPosition;
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (base.isServer && info.fromDisk && info.msg.cargoPlane != null)
		{
			startPos = info.msg.cargoPlane.startPos;
			endPos = info.msg.cargoPlane.endPos;
			secondsToTake = info.msg.cargoPlane.secondsToTake;
			secondsTaken = info.msg.cargoPlane.secondsTaken;
			dropped = info.msg.cargoPlane.dropped;
			dropPosition = info.msg.cargoPlane.dropPosition;
		}
	}
}
