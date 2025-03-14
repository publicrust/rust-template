using System.Collections.Generic;
using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class UICompass : MonoBehaviour
{
	public RawImage compassStrip;

	public CanvasGroup compassGroup;

	public List<CompassMapMarker> CompassMarkers;

	public List<CompassMapMarker> TeamCompassMarkers;

	public List<CompassMissionMarker> MissionMarkers;

	public CompassMapMarker DeathMarker;

	public static readonly Translate.Phrase IslandInfoPhrase = new Translate.Phrase("nexus.compass.island_info", "Continue for {distance} to travel to {zone}");

	public RectTransform IslandInfoContainer;

	public RustText IslandInfoText;

	public float IslandInfoDistanceThreshold = 250f;

	public float IslandLookThreshold = -0.8f;

	public RectTransform IslandInfoFullContainer;

	public List<CompassMapMarker> LocalPings;

	public List<CompassMapMarker> TeamPings;

	public Image LeftPingPulse;

	public Image RightPingPulse;
}
