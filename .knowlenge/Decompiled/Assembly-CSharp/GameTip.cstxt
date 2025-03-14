using System;
using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class GameTip : SingletonComponent<GameTip>
{
	public enum Styles
	{
		Blue_Normal,
		Red_Normal,
		Blue_Long,
		Blue_Short,
		Server_Event
	}

	[Serializable]
	public struct Theme
	{
		public Icons Icon;

		public Color BackgroundColor;

		public Color ForegroundColor;

		public float duration;
	}

	public CanvasGroup canvasGroup;

	public RustIcon icon;

	public Image background;

	public RustText text;

	public Theme[] themes;
}
