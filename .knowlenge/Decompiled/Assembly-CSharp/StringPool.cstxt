using System;
using System.Collections.Generic;
using UnityEngine;

public class StringPool
{
	public static Dictionary<uint, string> toString;

	public static Dictionary<string, uint> toNumber;

	private static bool initialized;

	public static uint closest;

	private static void Init()
	{
		if (initialized)
		{
			return;
		}
		toString = new Dictionary<uint, string>();
		toNumber = new Dictionary<string, uint>(StringComparer.OrdinalIgnoreCase);
		GameManifest gameManifest = FileSystem.Load<GameManifest>("Assets/manifest.asset");
		for (uint num = 0u; num < gameManifest.pooledStrings.Length; num++)
		{
			string str = gameManifest.pooledStrings[num].str;
			uint hash = gameManifest.pooledStrings[num].hash;
			if (toString.TryGetValue(hash, out var value))
			{
				if (str != value)
				{
					Debug.LogWarning($"Hash collision: {hash} already exists in string pool. `{str}` and `{value}` have the same hash.");
				}
			}
			else
			{
				toString.Add(hash, str);
				toNumber.Add(str, hash);
			}
		}
		initialized = true;
		closest = Get("closest");
	}

	public static string Get(uint i)
	{
		if (i == 0)
		{
			return string.Empty;
		}
		Init();
		if (toString.TryGetValue(i, out var value))
		{
			return value;
		}
		Debug.LogWarning("StringPool.GetString - no string for ID" + i);
		return "";
	}

	public static uint Get(string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return 0u;
		}
		Init();
		if (toNumber.TryGetValue(str, out var value))
		{
			return value;
		}
		Debug.LogWarning("StringPool.GetNumber - no number for string " + str);
		return 0u;
	}

	public static uint Add(string str)
	{
		uint value = 0u;
		if (!toNumber.TryGetValue(str, out value))
		{
			value = str.ManifestHash();
			toString.Add(value, str);
			toNumber.Add(str, value);
		}
		return value;
	}
}
