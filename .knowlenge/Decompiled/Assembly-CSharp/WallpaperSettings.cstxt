using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Wallpaper/Wallpaper Settings")]
public class WallpaperSettings : BaseScriptableObject
{
	public GameObjectRef[] WallpaperPrefabs;

	public BuildingBlock[] BuildingBlocks;

	public GameObjectRef GetWallpaperPrefab(BuildingBlock buildingBlock)
	{
		if (buildingBlock != null)
		{
			for (int i = 0; i < BuildingBlocks.Length; i++)
			{
				if (BuildingBlocks[i].prefabID == buildingBlock.prefabID)
				{
					return WallpaperPrefabs[i];
				}
			}
		}
		return null;
	}

	public Construction GetConstruction(BuildingBlock buildingBlock)
	{
		GameObjectRef wallpaperPrefab = GetWallpaperPrefab(buildingBlock);
		if (wallpaperPrefab == null)
		{
			return null;
		}
		if (buildingBlock.isServer)
		{
			return PrefabAttribute.server.Find<Construction>(wallpaperPrefab.resourceID);
		}
		return null;
	}

	public Deployable GetDeployable(BuildingBlock buildingBlock)
	{
		GameObjectRef wallpaperPrefab = GetWallpaperPrefab(buildingBlock);
		if (wallpaperPrefab == null)
		{
			return null;
		}
		if (buildingBlock.isServer)
		{
			return PrefabAttribute.server.Find<Deployable>(wallpaperPrefab.resourceID);
		}
		return null;
	}
}
