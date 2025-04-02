using UnityEngine;

public class LightGroupAtTime : FacepunchBehaviour
{
	public float IntensityOverride = 1f;

	public AnimationCurve IntensityScaleOverTime = new AnimationCurve
	{
		keys = new Keyframe[5]
		{
			new Keyframe(0f, 1f),
			new Keyframe(8f, 0f),
			new Keyframe(12f, 0f),
			new Keyframe(19f, 1f),
			new Keyframe(24f, 1f)
		}
	};

	public Transform SearchRoot;

	[Header("Power Settings")]
	public bool requiresPower;

	[Tooltip("Can NOT be entity, use new blank gameobject!")]
	public Transform powerOverrideTransform;

	public LayerMask checkLayers = 1235288065;

	public GameObject enableWhenLightsOn;

	public float timeBetweenPowerLookup = 10f;
}
