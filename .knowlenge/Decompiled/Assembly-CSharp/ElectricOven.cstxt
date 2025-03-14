using Facepunch;
using ProtoBuf;
using Rust;
using UnityEngine;

public class ElectricOven : BaseOven
{
	public GameObjectRef IoEntity;

	public Transform IoEntityAnchor;

	public EntityRef<IOEntity> spawnedIo;

	public bool resumeCookingWhenPowerResumes;

	public override bool CanRunWithNoFuel
	{
		get
		{
			if (spawnedIo.IsValid(serverside: true))
			{
				return spawnedIo.Get(serverside: true).IsPowered();
			}
			return false;
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if (!Rust.Application.isLoadingSave)
		{
			SpawnIOEnt();
		}
	}

	public void SpawnIOEnt()
	{
		if (IoEntity.isValid && IoEntityAnchor != null)
		{
			IOEntity iOEntity = GameManager.server.CreateEntity(IoEntity.resourcePath, IoEntityAnchor.position, IoEntityAnchor.rotation) as IOEntity;
			iOEntity.SetParent(this, worldPositionStays: true);
			iOEntity.Spawn();
			spawnedIo.Set(iOEntity);
		}
	}

	public void OnIOEntityFlagsChanged(Flags old, Flags next)
	{
		if (!next.HasFlag(Flags.Reserved8) && IsOn())
		{
			StopCooking();
			resumeCookingWhenPowerResumes = true;
		}
		else if (next.HasFlag(Flags.Reserved8) && !IsOn() && resumeCookingWhenPowerResumes)
		{
			StartCooking();
			resumeCookingWhenPowerResumes = false;
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.msg.simpleUID == null)
		{
			info.msg.simpleUID = Pool.Get<SimpleUID>();
		}
		info.msg.simpleUID.uid = spawnedIo.uid;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.simpleUID != null)
		{
			spawnedIo.uid = info.msg.simpleUID.uid;
		}
	}

	protected override bool CanPickupOven()
	{
		return children.Count == 1;
	}
}
