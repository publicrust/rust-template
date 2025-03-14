using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class SocketMod_WaterDepth : SocketMod
{
	public float MinimumWaterDepth = 2f;

	public float MaximumWaterDepth = 4f;

	public bool AllowWaterVolumes;

	public static Translate.Phrase TooDeepPhrase = new Translate.Phrase("error_toodeep", "Water is too deep");

	public static Translate.Phrase TooShallowPhrase = new Translate.Phrase("error_shallow", "Water is too shallow");

	public override bool DoCheck(Construction.Placement place)
	{
		Vector3 vector = place.position + place.rotation * worldPosition;
		if (!AllowWaterVolumes)
		{
			List<WaterVolume> obj = Pool.GetList<WaterVolume>();
			Vis.Components(vector, 0.5f, obj, 262144);
			int count = obj.Count;
			Pool.FreeList(ref obj);
			if (count > 0)
			{
				Construction.lastPlacementError = "Failed Check: WaterDepth_VolumeCheck (" + hierachyName + ")";
				return false;
			}
		}
		vector.y = WaterSystem.GetHeight(vector) - 0.1f;
		float overallWaterDepth = WaterLevel.GetOverallWaterDepth(vector, waves: false);
		if (overallWaterDepth > MinimumWaterDepth && overallWaterDepth < MaximumWaterDepth)
		{
			return true;
		}
		if (overallWaterDepth <= MinimumWaterDepth)
		{
			Construction.lastPlacementError = TooShallowPhrase.translated;
		}
		else
		{
			Construction.lastPlacementError = TooDeepPhrase.translated;
		}
		return false;
	}
}
