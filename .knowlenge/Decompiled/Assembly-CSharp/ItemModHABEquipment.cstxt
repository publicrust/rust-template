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

	public Phrase MenuOptionTitle;

	public Phrase MenuOptionDesc;

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
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (hab.isServer && CanEquipToHAB(hab) && Prefab.isValid)
		{
			HotAirBalloonEquipment hotAirBalloonEquipment = GameManager.server.CreateEntity(Prefab.resourcePath, ((Component)hab).transform.position, ((Component)hab).transform.rotation) as HotAirBalloonEquipment;
			if (Object.op_Implicit((Object)(object)hotAirBalloonEquipment))
			{
				hotAirBalloonEquipment.SetParent(hab, worldPositionStays: true);
				hotAirBalloonEquipment.Spawn();
				hotAirBalloonEquipment.DelayNextUpgradeOnRemoveDuration = DelayNextUpgradeOnRemoveDuration;
			}
		}
	}
}
