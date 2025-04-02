using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TimelineConvarController : PlayableAsset, ITimelineClipAsset
{
	public string convarName = string.Empty;

	public TimelineConvarPlayable template = new TimelineConvarPlayable();

	public ClipCaps clipCaps => (ClipCaps)2;

	public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		ScriptPlayable<TimelineConvarPlayable> val = ScriptPlayable<TimelineConvarPlayable>.Create(graph, template, 0);
		val.GetBehaviour().convar = convarName;
		return ScriptPlayable<TimelineConvarPlayable>.op_Implicit(val);
	}
}
