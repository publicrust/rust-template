public class SoundPlayerCullLODComponent : LODComponent
{
	public float Distance = 100f;

	public SoundPlayer TargetSoundPlayer;

	private void OnValidate()
	{
		if (TargetSoundPlayer == null)
		{
			TargetSoundPlayer = GetComponent<SoundPlayer>();
		}
	}
}
