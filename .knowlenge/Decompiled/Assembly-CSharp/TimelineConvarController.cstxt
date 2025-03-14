using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TimelineConvarController : PlayableAsset, ITimelineClipAsset
{
	public string convarName = string.Empty;

	public TimelineConvarPlayable template = new TimelineConvarPlayable();

	public ClipCaps clipCaps => ClipCaps.Extrapolation;

	public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
	{
		ScriptPlayable<TimelineConvarPlayable> scriptPlayable = ScriptPlayable<TimelineConvarPlayable>.Create(graph, template);
		scriptPlayable.GetBehaviour().convar = convarName;
		return scriptPlayable;
	}
}
