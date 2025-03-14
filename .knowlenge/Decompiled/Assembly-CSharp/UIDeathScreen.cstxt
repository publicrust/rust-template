using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDeathScreen : SingletonComponent<UIDeathScreen>, IUIScreen
{
	[Serializable]
	public struct RespawnColourScheme
	{
		public Color BackgroundColour;

		public Color CircleRimColour;

		public Color CircleFillColour;
	}

	public LifeInfographic previousLifeInfographic;

	public Animator screenAnimator;

	public bool fadeIn;

	public Button ReportCheatButton;

	public MapView View;

	public List<SleepingBagButton> sleepingBagButtons = new List<SleepingBagButton>();

	public GameObject loadingIndicator;

	public RespawnColourScheme[] RespawnColourSchemes;

	public GameObject RespawnScrollGradient;

	public ScrollRect RespawnScrollRect;

	public ExpandedLifeStats ExpandedStats;

	public GameObject OpenStatsButton;

	public CanvasGroup StreamerModeContainer;

	public GameObject SafeZoneInfo;

	public Image FadeImage;
}
