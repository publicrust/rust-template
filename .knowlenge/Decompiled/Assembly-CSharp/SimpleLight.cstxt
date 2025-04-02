public class SimpleLight : IOEntity
{
	public override void ResetIOState()
	{
		base.ResetIOState();
		if (IsOn())
		{
			SetFlag(Flags.On, b: false, recursive: false, networkupdate: false);
			SendNetworkUpdate_Flags();
		}
	}

	public override void IOStateChanged(int inputAmount, int inputSlot)
	{
		base.IOStateChanged(inputAmount, inputSlot);
		bool num = IsOn();
		bool flag = IsPowered();
		if (num != flag)
		{
			SetFlag(Flags.On, flag, recursive: false, networkupdate: false);
			SendNetworkUpdate_Flags();
		}
	}
}
