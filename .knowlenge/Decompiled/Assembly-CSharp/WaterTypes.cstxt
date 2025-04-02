using UnityEngine;

public static class WaterTypes
{
	private static ItemDefinition _waterItemDef;

	private static ItemDefinition _saltWaterItemDef;

	private static ItemDefinition _radioactiveWaterItemDef;

	public static ItemDefinition WaterItemDef
	{
		get
		{
			if ((Object)(object)_waterItemDef == (Object)null)
			{
				_waterItemDef = ItemManager.FindItemDefinition("water");
			}
			return _waterItemDef;
		}
	}

	public static ItemDefinition SaltWaterItemDef
	{
		get
		{
			if ((Object)(object)_saltWaterItemDef == (Object)null)
			{
				_saltWaterItemDef = ItemManager.FindItemDefinition("water.salt");
			}
			return _saltWaterItemDef;
		}
	}

	public static ItemDefinition RadioactiveWaterItemDef
	{
		get
		{
			if ((Object)(object)_radioactiveWaterItemDef == (Object)null)
			{
				_radioactiveWaterItemDef = ItemManager.FindItemDefinition("water.radioactive");
			}
			return _radioactiveWaterItemDef;
		}
	}
}
