using System;
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

	public Text objectTitle;

	public RectTransform slotToolTip;

	public Text slotTitle;

	public Text slotConnection;

	public Text slotPower;

	public Text powerText;

	public Text passthroughText;

	public Text chargeLeftText;

	public Text capacityText;

	public Text maxOutputText;

	public Text activeOutputText;

	public IOEntityUISlotEntry[] inputEntries;

	public IOEntityUISlotEntry[] outputEntries;

	public Color NoPowerColor;

	public GameObject GravityWarning;

	public GameObject DistanceWarning;

	public GameObject LineOfSightWarning;

	public GameObject TooManyInputsWarning;

	public GameObject TooManyOutputsWarning;

	public GameObject BuildPrivilegeWarning;

	public CanvasGroup group;

	public HandleSet[] handleSets;

	public RectTransform clearNotification;

	public CanvasGroup wireInfoGroup;

	public Text wireLengthText;

	public Text wireClipsText;

	public Text errorReasonTextTooFar;

	public Text errorReasonTextNoSurface;

	public Text errorShortCircuit;

	public RawImage ConnectionTypeIcon;

	public Texture ElectricSprite;

	public Texture FluidSprite;

	public Texture IndustrialSprite;
}
