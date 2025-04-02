using UnityEngine;

public class ItemModHABEquipment : ItemMod
{
	public enum SlotType
	{
		Basic,
		Armor
	}

	public SlotType slot;

	public GameObjectRef Prefab;

	public int MaxEquipCount = 1;

	public bool GroundEquipOnly = true;

	public float DelayNextUpgradeOnRemoveDuration = 60f;

	public Translate.Phrase MenuOptionTitle;

	public Translate.Phrase MenuOptionDesc;

	public bool CanEquipToHAB(HotAirBalloon hab)
	{
		if (!hab.CanModifyEquipment())
		{
			return false;
		}
		if (hab.GetEquipmentCount(this) >= MaxEquipCount)
		{
			return false;
		}
		if (GroundEquipOnly && !hab.Grounded)
		{
			return false;
		}
		if (hab.NextUpgradeTime > Time.time)
		{
			return false;
		}
		return true;
	}

	public void ApplyToHAB(HotAirBalloon hab)
	{
		if (hab.isServer && CanEquipToHAB(hab) && Prefab.isValid)
		{
			HotAirBalloonEquipment hotAirBalloonEquipment = GameManager.server.CreateEntity(Prefab.resourcePath, hab.transform.position, hab.transform.rotation) as HotAirBalloonEquipment;
			if ((bool)hotAirBalloonEquipment)
			{
				hotAirBalloonEquipment.SetParent(hab, worldPositionStays: true);
				hotAirBalloonEquipment.Spawn();
				hotAirBalloonEquipment.DelayNextUpgradeOnRemoveDuration = DelayNextUpgradeOnRemoveDuration;
			}
		}
	}
}
