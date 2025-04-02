using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RCMenu : ComputerMenu
{
	public Image backgroundOpaque;

	public InputField newBookmarkEntryField;

	public NeedsCursor needsCursor;

	public float hiddenOffset = -256f;

	public RectTransform devicesPanel;

	private Vector3 initialDevicesPosition;

	public static bool isControllingCamera;

	public CanvasGroup overExposure;

	public CanvasGroup interference;

	public float interferenceFadeDuration = 0.2f;

	public float rangeInterferenceScale = 10000f;

	public Text timeText;

	public Text watchedDurationText;

	public Text deviceNameText;

	public Text noSignalText;

	public Text healthText;

	public GameObject healthBarParent;

	public RectTransform healthBarBackground;

	public RectTransform healthBarFill;

	public SoundDefinition bookmarkPressedSoundDef;

	public GameObject[] hideIfStatic;

	public GameObject readOnlyIndicator;

	[FormerlySerializedAs("crosshair")]
	public GameObject aimCrosshair;

	public GameObject generalCrosshair;

	public float fogOverrideDensity = 0.1f;

	public float autoTurretFogDistance = 30f;

	public float autoTurretDotBaseScale = 2f;

	public float autoTurretDotGrowScale = 4f;

	public PingManager PingManager;

	public ScrollRectSettable scrollRect;

	public Translate.Phrase Phrase_NoSignal = new Translate.Phrase("no_signal", "No Signal");

	public Translate.Phrase Phrase_CameraDisabled = new Translate.Phrase("weak_signal", "Weak Signal");
}
