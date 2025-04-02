using Facepunch.Rust;

public class WallpaperPlanner : Planner
{
	private static ItemDefinition _wallpaperItem;

	private static WallpaperSettings _settings;

	public static ItemDefinition WallpaperItemDef
	{
		get
		{
			if (_wallpaperItem == null)
			{
				_wallpaperItem = ItemManager.FindItemDefinition("wallpaper");
			}
			return _wallpaperItem;
		}
	}

	public static WallpaperSettings Settings
	{
		get
		{
			if (_settings == null)
			{
				_settings = FileSystem.Load<WallpaperSettings>("Assets/Prefabs/Wallpaper/Wallpaper Settings.asset");
			}
			return _settings;
		}
	}

	public override bool isTypeDeployable => true;

	public override Deployable GetDeployable(NetworkableId entityId)
	{
		if (entityId.IsValid)
		{
			BaseEntity baseEntity = BaseNetworkable.serverEntities.Find(entityId) as BaseEntity;
			return Settings.GetDeployable(baseEntity as BuildingBlock);
		}
		return null;
	}

	public override BaseEntity DoBuild(Construction.Target target, Construction component)
	{
		BasePlayer ownerPlayer = GetOwnerPlayer();
		if (ownerPlayer == null)
		{
			return null;
		}
		if (target.entity is BuildingBlock buildingBlock)
		{
			int side = ((!target.socket.socketName.EndsWith("1")) ? 1 : 0);
			if (buildingBlock.HasWallpaper(side))
			{
				return null;
			}
			if (!buildingBlock.CanSeeWallpaperSocket(ownerPlayer, side))
			{
				ownerPlayer.ShowToast(GameTip.Styles.Error, ConstructionErrors.LineOfSightBlocked, false);
				return null;
			}
			buildingBlock.SetWallpaper(skinID, side);
			PayForPlacement(ownerPlayer, component);
			Analytics.Azure.OnWallpaperPlaced(ownerPlayer, buildingBlock, skinID, side, reskin: false);
			if (component.deployable.placeEffect.isValid)
			{
				Effect.server.Run(component.deployable.placeEffect.resourcePath, buildingBlock.transform.TransformPoint(target.socket.worldPosition), buildingBlock.transform.up);
			}
		}
		return null;
	}
}
