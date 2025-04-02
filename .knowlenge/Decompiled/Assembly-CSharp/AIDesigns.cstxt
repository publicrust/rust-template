using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;
using UnityEngine;

public static class AIDesigns
{
	public const string DesignFolderPath = "cfg/ai/";

	private static Dictionary<string, AIDesign> designs = new Dictionary<string, AIDesign>();

	public static AIDesign GetByNameOrInstance(string designName, AIDesign entityDesign)
	{
		if (entityDesign != null)
		{
			return entityDesign;
		}
		AIDesign byName = GetByName(designName + "_custom");
		if (byName != null)
		{
			return byName;
		}
		return GetByName(designName);
	}

	public static void RefreshCache(string designName, AIDesign design)
	{
		if (designs.ContainsKey(designName))
		{
			designs[designName] = design;
		}
	}

	private static AIDesign GetByName(string designName)
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
			using FileStream fileStream = File.Open(text, FileMode.Open);
			value = AIDesign.Deserialize((Stream)fileStream);
			if (value == null)
			{
				return null;
			}
			designs.Add(designName, value);
			return value;
		}
		catch (Exception)
		{
			Debug.LogWarning((object)("Error trying to find AI design by name: " + text));
			return null;
		}
	}
}
