using Facepunch;
using ProtoBuf;
using UnityEngine;

public class PlayerCorpse : LootableCorpse
{
	public Buoyancy buoyancy;

	public const Flags Flag_Buoyant = Flags.Reserved6;

	public uint underwearSkin;

	public bool IsBuoyant()
	{
		return HasFlag(Flags.Reserved6);
	}

	public override bool OnStartBeingLooted(BasePlayer baseEntity)
	{
		if (baseEntity.InSafeZone() && baseEntity.userID != playerSteamID)
		{
			return false;
		}
		return base.OnStartBeingLooted(baseEntity);
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if (buoyancy == null)
		{
			Debug.LogWarning("Player corpse has no buoyancy assigned, searching at runtime :" + base.name);
			buoyancy = GetComponent<Buoyancy>();
		}
		if (buoyancy != null)
		{
			buoyancy.SubmergedChanged = BuoyancyChanged;
			buoyancy.forEntity = this;
		}
	}

	public void BuoyancyChanged(bool isSubmerged)
	{
		if (!IsBuoyant())
		{
			SetFlag(Flags.Reserved6, isSubmerged, recursive: false, networkupdate: false);
			SendNetworkUpdate_Flags();
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.msg.lootableCorpse != null)
		{
			info.msg.lootableCorpse.underwearSkin = underwearSkin;
		}
		if (base.isServer && containers != null && containers.Length > 1 && !info.forDisk)
		{
			info.msg.storageBox = Pool.Get<StorageBox>();
			info.msg.storageBox.contents = containers[1].Save();
		}
	}

	public override string Categorize()
	{
		return "playercorpse";
	}
}
