public class FuseBox : IOEntity
{
	public override void IOStateChanged(int inputAmount, int inputSlot)
	{
		base.IOStateChanged(inputAmount, inputSlot);
		SetFlag(Flags.On, IsPowered());
	}
}
