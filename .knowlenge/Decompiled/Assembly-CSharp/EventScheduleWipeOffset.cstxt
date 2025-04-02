using UnityEngine;

public class EventScheduleWipeOffset : EventSchedule
{
	[ServerVar(Name = "event_hours_before_wipe")]
	public static float hoursBeforeWipeRealtime = 24f;

	public override void RunSchedule()
	{
		if (!((Object)(object)WipeTimer.serverinstance == (Object)null) && !(WipeTimer.serverinstance.GetTimeSpanUntilWipe().TotalHours > (double)hoursBeforeWipeRealtime))
		{
			base.RunSchedule();
		}
	}
}
