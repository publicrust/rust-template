using UnityEngine;

public class PatternFireworkShell : FireworkShell
{
	public GameObjectRef StarPrefab;

	public AnimationCurve StarCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public float Duration = 3f;

	public float Scale = 5f;

	[MinMax(0f, 1f)]
	[Header("Random Design")]
	public MinMax RandomSaturation = new MinMax(0f, 0.5f);

	[MinMax(0f, 1f)]
	public MinMax RandomValue = new MinMax(0.5f, 0.75f);
}
