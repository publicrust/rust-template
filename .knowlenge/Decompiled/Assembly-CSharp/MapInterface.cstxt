using System;
using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class MapInterface : SingletonComponent<MapInterface>
{
	[Serializable]
	public struct PointOfInterestSpriteConfig
	{
		public Sprite inner;

		public Sprite outer;
	}

	public static bool IsOpen;

	public Image cameraPositon;

	public ScrollRectEx scrollRect;

	public ScrollRectZoom scrollRectZoom;

	public RustButton showGridToggle;

	public RustButton FocusButton;

	public CanvasGroup CanvasGroup;

	public SoundDefinition PlaceMarkerSound;

	public SoundDefinition ClearMarkerSound;

	public MapView View;

	public UINexusMap NexusMap;

	public GameObject NexusButtonGroup;

	public RustButton NexusToggle;

	public Color[] PointOfInterestColours;

	public PointOfInterestSpriteConfig[] PointOfInterestSprites;

	public Sprite PingBackground;

	public bool DebugStayOpen;

	public GameObject MarkerListSection;

	public GameObject ControlsRoot;

	public GameObjectRef MarkerListPrefab;

	public GameObject MarkerHeader;

	public Transform LocalPlayerMarkerListParent;

	public Transform TeamMarkerListParent;

	public GameObject TeamLeaderHeader;

	public GameObject MissionListHeader;

	public Transform MissionListContent;

	public GameObjectRef MissionListPrefab;

	public VendorList VendorList;

	public RustButton HideTeamLeaderMarkersToggle;

	public CanvasGroup TeamMarkersCanvas;

	public RustImageButton ShowSleepingBagsButton;

	public RustImageButton ShowVendingMachinesButton;

	public RustImageButton ShowMissionProvidersButton;

	public UIEscapeCapture EscapeCapture;
}
