using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Game Mode Manifest")]
public class GameModeManifest : ScriptableObject
{
	public static GameModeManifest instance;

	public List<GameObjectRef> gameModePrefabs;

	public static GameModeManifest Get()
	{
		if (instance == null)
		{
			instance = Resources.Load<GameModeManifest>("GameModeManifest");
		}
		return instance;
	}
}
