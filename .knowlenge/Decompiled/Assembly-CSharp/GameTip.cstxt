using System;
using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class GameTip : SingletonComponent<GameTip>
{
	[Serializable]
	public struct Theme
	{
		public Icons Icon;

		public Color BackgroundColor;

		public Color ForegroundColor;
	}

	public CanvasGroup canvasGroup;

	public RustIcon icon;

	public Image background;

	public RustText text;

	public Theme[] themes;
}
