public class MobileInventoryEntity : BaseEntity
{
	public SoundDefinition ringingLoop;

	public SoundDefinition silentLoop;

	public const Flags Ringing = Flags.Reserved1;

	public static Flags Flag_Silent = Flags.Reserved2;

	public void ToggleRinging(bool state)
	{
		SetFlag(Flags.Reserved1, state);
	}

	public void SetSilentMode(bool wantsSilent)
	{
		SetFlag(Flag_Silent, wantsSilent);
	}
}
