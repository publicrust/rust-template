using System.Collections.Generic;
using UnityEngine;

public class UIBlackoutOverlay : MonoBehaviour
{
	public enum blackoutType
	{
		FULLBLACK = 0,
		BINOCULAR = 1,
		SCOPE = 2,
		HELMETSLIT = 3,
		SNORKELGOGGLE = 4,
		NVG = 5,
		FULLWHITE = 6,
		SUNGLASSES = 7,
		PRISONERHOOD = 8,
		DEATH = 9,
		NONE = 64
	}

	public CanvasGroup group;

	public static Dictionary<blackoutType, UIBlackoutOverlay> instances;

	public blackoutType overlayType = blackoutType.NONE;

	public bool overrideCanvasScaling;

	public float referenceScale = 1f;
}
