using System;
using Rust.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ServerBrowserItem : MonoBehaviour
{
	[Serializable]
	public struct PremiumGameObject
	{
		public GameObject GameObject;

		public bool ShowIfEligible;
	}

	public TextMeshProUGUI serverName;

	public RustFlexText mapName;

	public TextMeshProUGUI playerCount;

	public TextMeshProUGUI ping;

	public TextMeshProUGUI pendingPing;

	public Toggle favourited;

	public ServerBrowserTagList serverTagList;

	public Color pingColor;

	public Color pingWarningColor;

	public Tooltip pingWarningTooltip;

	public PremiumGameObject[] PremiumOptions;
}
