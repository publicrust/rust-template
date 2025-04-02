using System;
using Rust.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
public class PieMenu : UIBehaviour
{
	[Serializable]
	public class MenuOption
	{
		public struct ColorMode
		{
			public enum PieMenuSpriteColorOption
			{
				CustomColor,
				SpriteColor
			}

			public PieMenuSpriteColorOption Mode;

			public Color CustomColor;
		}

		public Translate.Phrase name;

		public Translate.Phrase desc;

		public string requirements;

		public Sprite sprite;

		public bool disabled;

		public int order;

		public ColorMode? overrideColorMode;

		public bool showOverlay;

		public float time;

		public BasePlayer.PingType? showTutorialHighlight;

		public float sizeRatio = 1f;

		public float iconScale = 1f;

		[NonSerialized]
		public Action<BasePlayer> action;

		[NonSerialized]
		public Action<BasePlayer> actionDisabled;

		[NonSerialized]
		public Action<BasePlayer> actionPrev;

		[NonSerialized]
		public Action<BasePlayer> actionNext;

		[NonSerialized]
		public PieOption option;

		[NonSerialized]
		public bool selected;

		[NonSerialized]
		public bool allowMerge;
	}

	public static PieMenu Instance;

	public Image middleBox;

	public PieShape pieBackgroundBlur;

	public PieShape pieBackground;

	public PieShape pieSelection;

	public GameObject pieOptionPrefab;

	public GameObject optionsCanvas;

	public MenuOption[] options;

	public GameObject scaleTarget;

	public GameObject arrowLeft;

	public GameObject arrowRight;

	public float sliceGaps = 10f;

	[Range(0f, 1f)]
	public float outerSize = 1f;

	[Range(0f, 1f)]
	public float innerSize = 0.5f;

	[Range(0f, 1f)]
	public float iconSize = 0.8f;

	[Range(0f, 360f)]
	public float startRadius;

	[Range(0f, 360f)]
	public float radiusSize = 360f;

	public Image middleImage;

	public RustText middleTitle;

	public RustText middleDesc;

	public RustText middleRequired;

	public Color colorIconActive;

	public Color colorIconHovered;

	public Color colorIconDisabled;

	public Color colorBackgroundDisabled;

	public SoundDefinition clipOpen;

	public SoundDefinition clipCancel;

	public SoundDefinition clipChanged;

	public SoundDefinition clipSelected;

	public MenuOption defaultOption;

	public Material IconMaterial;

	public bool IsOpen { get; private set; }
}
