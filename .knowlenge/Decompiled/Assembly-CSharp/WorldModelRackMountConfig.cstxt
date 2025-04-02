using System;
using System.Collections.Generic;
using UnityEngine;

public class WorldModelRackMountConfig : MonoBehaviour
{
	[Serializable]
	public class CustomPosition
	{
		public WeaponRack.SpecialRackType RackType;

		public Vector3 CenterOffset;

		public Vector3 Rotation;
	}

	public List<WeaponRack.RackType> ExcludedRackTypes = new List<WeaponRack.RackType>();

	public Vector3 CenterOffsfet;

	public Vector3 LeftOffset;

	public Vector3 VerticalMountLocalRotation;

	public Vector3 VerticalMountLocalOffset;

	public int XSize = 3;

	public int YSize = 2;

	public int ZSize = 1;

	public List<PegConfig> Pegs = new List<PegConfig>();

	public List<PegConfig> VerticalPegs = new List<PegConfig>();

	public bool OverrideScale;

	public Vector3 Scale = Vector3.one;

	public bool UseManualRenderBounds;

	public Bounds ManualRenderBounds;

	public bool CanReloadOnWeaponRack = true;

	[Header("Special Rack Types")]
	public List<CustomPosition> CustomPositions = new List<CustomPosition>();

	public static WorldModelRackMountConfig GetForItemDef(ItemDefinition itemDef)
	{
		GameObjectRef worldModelPrefab = itemDef.worldModelPrefab;
		if (!worldModelPrefab.isValid)
		{
			return null;
		}
		return worldModelPrefab.Get().GetComponent<WorldModelRackMountConfig>();
	}

	public void ApplyTransformDefaults(Transform displayItem)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)displayItem == (Object)null))
		{
			if (OverrideScale)
			{
				displayItem.localScale = Scale;
			}
			displayItem.localPosition = VerticalMountLocalOffset;
			displayItem.localEulerAngles = VerticalMountLocalRotation;
		}
	}

	public CustomPosition FindCustomRackPosition(WeaponRack.SpecialRackType rackType)
	{
		if (CustomPositions == null)
		{
			return null;
		}
		foreach (CustomPosition customPosition in CustomPositions)
		{
			if (customPosition.RackType == rackType)
			{
				return customPosition;
			}
		}
		return null;
	}
}
