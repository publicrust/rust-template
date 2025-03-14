using System.Collections.Generic;
using Rust;
using UnityEngine;

public class EffectDictionary
{
	private static Dictionary<string, string[]> effectDictionary;

	public static string GetParticle(string impactType, string materialName)
	{
		return LookupEffect("impacts", impactType, materialName);
	}

	public static string GetParticle(DamageType damageType, string materialName)
	{
		return damageType switch
		{
			DamageType.Bullet => GetParticle("bullet", materialName), 
			DamageType.Arrow => GetParticle("bullet", materialName), 
			DamageType.Blunt => GetParticle("blunt", materialName), 
			DamageType.Slash => GetParticle("slash", materialName), 
			DamageType.Stab => GetParticle("stab", materialName), 
			_ => GetParticle("blunt", materialName), 
		};
	}

	public static string GetDecal(string impactType, string materialName)
	{
		return LookupEffect("decals", impactType, materialName);
	}

	public static string GetDecal(DamageType damageType, string materialName)
	{
		return damageType switch
		{
			DamageType.Bullet => GetDecal("bullet", materialName), 
			DamageType.Arrow => GetDecal("bullet", materialName), 
			DamageType.Blunt => GetDecal("blunt", materialName), 
			DamageType.Slash => GetDecal("slash", materialName), 
			DamageType.Stab => GetDecal("stab", materialName), 
			_ => GetDecal("blunt", materialName), 
		};
	}

	public static string GetDisplacement(string impactType, string materialName)
	{
		return LookupEffect("displacement", impactType, materialName);
	}

	private static string LookupEffect(string category, string effect, string material)
	{
		if (effectDictionary == null)
		{
			effectDictionary = GameManifest.LoadEffectDictionary();
		}
		string format = "assets/bundled/prefabs/fx/{0}/{1}/{2}";
		if (!effectDictionary.TryGetValue(StringFormatCache.Get(format, category, effect, material), out var value) && !effectDictionary.TryGetValue(StringFormatCache.Get(format, category, effect, "generic"), out value))
		{
			return string.Empty;
		}
		return value[Random.Range(0, value.Length)];
	}
}
