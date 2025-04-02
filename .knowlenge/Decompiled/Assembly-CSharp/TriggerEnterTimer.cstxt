public class TriggerEnterTimer : TriggerBase
{
	public TimeSince EnterTime { get; private set; }

	internal override void OnEntityEnter(BaseEntity ent)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		bool hasAnyEntityContents = base.HasAnyEntityContents;
		base.OnEntityEnter(ent);
		if (!hasAnyEntityContents && base.HasAnyEntityContents)
		{
			EnterTime = TimeSince.op_Implicit(0f);
		}
	}
}
