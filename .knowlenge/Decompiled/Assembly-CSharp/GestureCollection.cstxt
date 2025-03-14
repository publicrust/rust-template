using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Gestures/Gesture Collection")]
public class GestureCollection : BaseScriptableObject
{
	public static uint HeavyLandingId = 3204230781u;

	private static GestureCollection _instance = null;

	public GestureConfig[] AllGestures;

	public float GestureVmInDuration = 0.25f;

	public AnimationCurve GestureInCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public float GestureVmOutDuration = 0.25f;

	public AnimationCurve GestureOutCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public float GestureViewmodelDeployDelay = 0.25f;

	public Sprite EmptyGestureSlotSprite;

	public Translate.Phrase EmptySlotTitle;

	public Translate.Phrase EmptySlotDescription;

	public static GestureCollection Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FileSystem.Load<GestureCollection>("assets/prefabs/player/gestures/gesturecollection.asset");
			}
			return _instance;
		}
	}

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
		if (string.IsNullOrEmpty(gestureName))
		{
			return null;
		}
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
