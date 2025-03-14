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
		NONE = 64
	}

	public CanvasGroup group;

	public static Dictionary<blackoutType, UIBlackoutOverlay> instances;

	public blackoutType overlayType = blackoutType.NONE;
}
