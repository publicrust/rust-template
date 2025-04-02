public class ModelConditionTest_Wallpaper : ModelConditionTest
{
	public bool softSide;

	public override bool DoTest(BaseEntity ent)
	{
		BuildingBlock buildingBlock = ent as BuildingBlock;
		if (buildingBlock == null)
		{
			return false;
		}
		return buildingBlock.HasWallpaper((!softSide) ? 1 : 0);
	}
}
