using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Gestures/Gesture Collection")]
public class GestureCollection : ScriptableObject
{
	public GestureConfig[] AllGestures;

	public float GestureVmInDuration = 0.25f;

	public AnimationCurve GestureInCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public float GestureVmOutDuration = 0.25f;

	public AnimationCurve GestureOutCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public float GestureViewmodelDeployDelay = 0.25f;

	public GestureConfig IdToGesture(uint id)
	{
		GestureConfig[] allGestures = AllGestures;
		foreach (GestureConfig gestureConfig in allGestures)
		{
			if (gestureConfig.gestureId == id)
			{
				return gestureConfig;
			}
		}
		return null;
	}

	public GestureConfig StringToGesture(string gestureName)
	{
		GestureConfig[] allGestures = AllGestures;
		foreach (GestureConfig gestureConfig in allGestures)
		{
			if (gestureConfig.convarName == gestureName)
			{
				return gestureConfig;
			}
		}
		return null;
	}
}
