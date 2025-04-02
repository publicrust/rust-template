using UnityEngine;

public class SnowMachine : FogMachine
{
	public AdaptMeshToTerrain snowMesh;

	public TriggerTemperature tempTrigger;

	public override bool MotionModeEnabled()
	{
		return false;
	}

	public override void EnableFogField()
	{
		base.EnableFogField();
		((Component)tempTrigger).gameObject.SetActive(true);
	}

	public override void FinishFogging()
	{
		base.FinishFogging();
		((Component)tempTrigger).gameObject.SetActive(false);
	}
}
