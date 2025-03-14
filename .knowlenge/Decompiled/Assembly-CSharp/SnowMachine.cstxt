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
		tempTrigger.gameObject.SetActive(value: true);
	}

	public override void FinishFogging()
	{
		base.FinishFogging();
		tempTrigger.gameObject.SetActive(value: false);
	}
}
