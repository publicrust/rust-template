using UnityEngine;

public class SocketMod_InWater : SocketMod
{
	public bool wantsInWater = true;

	public bool excludeArtificialWater;

	protected override Translate.Phrase ErrorPhrase
	{
		get
		{
			if (!wantsInWater)
			{
				return ConstructionErrors.InWater;
			}
			if (!excludeArtificialWater)
			{
				return ConstructionErrors.WantsWater;
			}
			return ConstructionErrors.WantsWaterBody;
		}
	}

	public override bool DoCheck(Construction.Placement place)
	{
		WaterLevel.WaterInfo waterInfo = WaterLevel.GetWaterInfo(place.position + place.rotation * worldPosition - new Vector3(0f, 0.1f, 0f), waves: true, volumes: true);
		bool isValid = waterInfo.isValid;
		bool artificalWater = waterInfo.artificalWater;
		if (isValid == wantsInWater)
		{
			if (artificalWater)
			{
				return !excludeArtificialWater;
			}
			return true;
		}
		return false;
	}
}
