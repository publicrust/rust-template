using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;
using UnityEngine;

public static class AIDesigns
{
	public const string DesignFolderPath = "cfg/ai/";

	private static Dictionary<string, ProtoBuf.AIDesign> designs = new Dictionary<string, ProtoBuf.AIDesign>();

	public static ProtoBuf.AIDesign GetByNameOrInstance(string designName, ProtoBuf.AIDesign entityDesign)
	{
		if (entityDesign != null)
		{
			return entityDesign;
		}
		ProtoBuf.AIDesign byName = GetByName(designName + "_custom");
		if (byName != null)
		{
			return byName;
		}
		return GetByName(designName);
	}

	public static void RefreshCache(string designName, ProtoBuf.AIDesign design)
	{
		if (designs.ContainsKey(designName))
		{
			designs[designName] = design;
		}
	}

	private static ProtoBuf.AIDesign GetByName(string designName)
	{
		designs.TryGetValue(designName, out var value);
		if (value != null)
		{
			return value;
		}
		string text = "cfg/ai/" + designName;
		if (!File.Exists(text))
		{
			return null;
		}
		try
		{
			using FileStream stream = File.Open(text, FileMode.Open);
			value = ProtoBuf.AIDesign.Deserialize(stream);
			if (value == null)
			{
				return null;
			}
			designs.Add(designName, value);
			return value;
		}
		catch (Exception)
		{
			Debug.LogWarning("Error trying to find AI design by name: " + text);
			return null;
		}
	}
}
