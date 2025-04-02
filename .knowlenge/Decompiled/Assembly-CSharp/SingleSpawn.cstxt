using System;

public class SingleSpawn : SpawnGroup
{
	public override bool WantsInitialSpawn()
	{
		return false;
	}

	public void FillDelay(float delay)
	{
		((FacepunchBehaviour)this).Invoke((Action)Fill, delay);
	}
}
