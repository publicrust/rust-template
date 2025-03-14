using UnityEngine;

public class SocketMod_WaterDepth : SocketMod
{
	public float MinimumWaterDepth = 2f;

	public float MaximumWaterDepth = 4f;

	public bool BlockArtificialWaterVolumes;

	private Translate.Phrase lastError = new Translate.Phrase();

	private float lastDepth;

	protected override Translate.Phrase ErrorPhrase => lastError;

	public override string GetDebugErrorMessage()
	{
		return base.GetDebugErrorMessage() + $" {lastDepth}m";
	}

	public override bool DoCheck(Construction.Placement place)
	{
		Vector3 pos = place.position + place.rotation * worldPosition;
		pos.y -= 0.2f;
		WaterLevel.WaterInfo waterInfo = WaterLevel.GetWaterInfo(pos, waves: false, volumes: true);
		if (BlockArtificialWaterVolumes && waterInfo.artificalWater)
		{
			return false;
		}
		if (waterInfo.overallDepth > MinimumWaterDepth && waterInfo.overallDepth < MaximumWaterDepth)
		{
			return true;
		}
		lastError = ((waterInfo.overallDepth <= MinimumWaterDepth) ? ConstructionErrors.TooShallow : ConstructionErrors.TooDeep);
		return false;
	}
}
