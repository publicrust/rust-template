using System;
using Rust.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class MissionsHUDToDo : BaseMonoBehaviour
{
	private static readonly Memoized<string, (float Current, float Target)> FormatProgres = new Memoized<string, (float, float)>((Func<(float, float), string>)delegate((float Current, float Target) d)
	{
		float num = Mathf.Min(d.Current, d.Target);
		return $" ({num:0.#}/{d.Target:0.#})";
	});

	public RustText text;

	public RectTransform checkIcon;

	public RectTransform checkBox;

	public Phrase optionalPrefix;

	public CanvasGroup group;

	[FormerlySerializedAs("AliveColor")]
	public Color DefaultColor;

	[FormerlySerializedAs("DeadColor")]
	public Color CompletedColor;

	[FormerlySerializedAs("HighlightColor")]
	public Color CompletedHighlightColor;

	public Color FailedColor;

	public Color FailedHighlightColor;

	public PingWidget PingWidget;
}
