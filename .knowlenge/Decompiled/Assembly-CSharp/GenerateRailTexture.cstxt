using System.Linq;

public class GenerateRailTexture : ProceduralComponent
{
	public override void Process(uint seed)
	{
		foreach (PathList item in TerrainMeta.Path.Rails.AsEnumerable().Reverse())
		{
			item.AdjustTerrainTexture();
		}
	}
}
