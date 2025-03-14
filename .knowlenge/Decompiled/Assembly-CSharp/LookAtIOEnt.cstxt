using System;
using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class LookAtIOEnt : MonoBehaviour
{
	[Serializable]
	public struct HandleSet
	{
		public IOEntity.IOType ForIO;

		public GameObjectRef handlePrefab;

		public GameObjectRef handleOccupiedPrefab;

		public GameObjectRef selectedHandlePrefab;

		public GameObjectRef pluggedHandlePrefab;
	}

	public RustText objectTitle;

	public RectTransform slotToolTip;

	public Text slotTitle;

	public RustText slotConnectionText;

	public RustText slotPowerText;

	public RustText powerText;

	public RustText passthroughText;

	public RustText chargeLeftText;

	public RustText capacityText;

	public RustText maxOutputText;

	public RustText activeOutputText;

	public RustText turretInterferenceText;

	public RustText creativeModeText;

	public IOEntityUISlotEntry[] inputEntries;

	public IOEntityUISlotEntry[] outputEntries;

	public Color NoPowerColor;

	public GameObject ShortCircuitWarning;

	public GameObject GravityWarning;

	public GameObject DistanceWarning;

	public GameObject LineOfSightWarning;

	public GameObject TooManyInputsWarning;

	public GameObject TooManyOutputsWarning;

	public GameObject BuildPrivilegeWarning;

	public GameObject InfinitePowerText;

	public CanvasGroup group;

	public HandleSet[] handleSets;

	public RectTransform clearNotification;

	public CanvasGroup wireInfoGroup;

	public RustText wireLengthText;

	public RustText wireClipsText;

	public RustText errorReasonTextTooFar;

	public RustText errorReasonTextNoSurface;

	public RawImage ConnectionTypeIcon;

	public Texture ElectricSprite;

	public Texture FluidSprite;

	public Texture IndustrialSprite;

	public GameObject IndustrialIcon;
}
