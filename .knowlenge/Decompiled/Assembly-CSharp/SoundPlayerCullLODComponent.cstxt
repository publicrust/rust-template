using UnityEngine;

public class SoundPlayerCullLODComponent : LODComponent
{
	public float Distance = 100f;

	public SoundPlayer TargetSoundPlayer;

	private void OnValidate()
	{
		if ((Object)(object)TargetSoundPlayer == (Object)null)
		{
			TargetSoundPlayer = ((Component)this).GetComponent<SoundPlayer>();
		}
	}
}
