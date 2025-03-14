using Facepunch;
using ProtoBuf;
using UnityEngine;

public class CargoShipContainer : BaseEntity
{
	public GameObject[] DressingVariants;

	public const Flags Descending = Flags.Reserved1;

	public const Flags Targeted = Flags.Reserved2;

	private int dressingVariant;

	public override float MaxVelocity()
	{
		return 1f;
	}

	public override void PreInitShared()
	{
		base.PreInitShared();
		AssignVariant();
	}

	public override void ServerInit()
	{
		base.ServerInit();
		UpdateDressingVariant();
	}

	public override void PostMapEntitySpawn()
	{
		base.PostMapEntitySpawn();
		UpdateDressingVariant();
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.cargoShipContainer = Pool.Get<ProtoBuf.CargoShipContainer>();
		info.msg.cargoShipContainer.dressingVariant = dressingVariant;
	}

	private void AssignVariant()
	{
		dressingVariant = Random.Range(0, DressingVariants.Length);
	}

	public void ToggleHurtCollider(bool state)
	{
		SetFlag(Flags.Reserved1, state);
	}

	public void SetTargeted(bool state)
	{
		SetFlag(Flags.Reserved2, state);
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.cargoShipContainer != null)
		{
			dressingVariant = info.msg.cargoShipContainer.dressingVariant;
		}
		UpdateDressingVariant();
	}

	private void UpdateDressingVariant()
	{
		for (int i = 0; i < DressingVariants.Length; i++)
		{
			DressingVariants[i].SetActive(dressingVariant == i);
		}
	}
}
