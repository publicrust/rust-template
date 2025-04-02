public class TriggerEnterTimer : TriggerBase
{
	public TimeSince EnterTime { get; private set; }

	internal override void OnEntityEnter(BaseEntity ent)
	{
		bool hasAnyEntityContents = base.HasAnyEntityContents;
		base.OnEntityEnter(ent);
		if (!hasAnyEntityContents && base.HasAnyEntityContents)
		{
			EnterTime = 0f;
		}
	}
}
