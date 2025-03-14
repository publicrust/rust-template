using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Underwear Manifest")]
public class UnderwearManifest : ScriptableObject
{
	public static UnderwearManifest instance;

	public List<Underwear> underwears;

	public static UnderwearManifest Get()
	{
		if (instance == null)
		{
			instance = Resources.Load<UnderwearManifest>("UnderwearManifest");
		}
		return instance;
	}

	public void PrintManifest()
	{
		Debug.Log("MANIFEST CONTENTS");
		foreach (Underwear underwear in underwears)
		{
			Debug.Log("Underwear name : " + underwear.shortname + " underwear ID : " + underwear.GetID());
		}
	}

	public Underwear GetUnderwear(uint id)
	{
		foreach (Underwear underwear in underwears)
		{
			if (underwear.GetID() == id)
			{
				return underwear;
			}
		}
		return null;
	}

	public Underwear GetUnderwearWithSkinId(int skinId)
	{
		foreach (Underwear underwear in underwears)
		{
			if (underwear.steamItem != null && underwear.steamItem.id == skinId)
			{
				return underwear;
			}
		}
		return null;
	}
}
