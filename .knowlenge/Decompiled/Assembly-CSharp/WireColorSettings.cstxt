using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/IO/Wire Color Settings")]
public class WireColorSettings : BaseScriptableObject
{
	[Serializable]
	public struct WireColor
	{
		public WireTool.WireColour type;

		public Color color;

		public GameObjectRef prefab;

		public Translate.Phrase name;

		public Translate.Phrase desc;

		public bool requireCreativeMode;
	}

	private static readonly List<WireColorSettings> settings = new List<WireColorSettings>();

	public IOEntity.IOType ioType;

	public WireColor[] WireColors;

	public static WireColorSettings Get(IOEntity.IOType type)
	{
		foreach (WireColorSettings setting in settings)
		{
			if (setting.ioType == type)
			{
				return setting;
			}
		}
		WireColorSettings wireColorSettings = FileSystem.Load<WireColorSettings>($"Assets/Prefabs/Tools/Wire/{type} Color Settings.asset");
		settings.Add(wireColorSettings);
		return wireColorSettings;
	}

	public GameObjectRef GetPrefabRef(WireTool.WireColour wireColor)
	{
		WireColor[] wireColors = WireColors;
		for (int i = 0; i < wireColors.Length; i++)
		{
			WireColor wireColor2 = wireColors[i];
			if (wireColor2.type == wireColor)
			{
				return wireColor2.prefab;
			}
		}
		return null;
	}
}
