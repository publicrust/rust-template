using System.Linq;

public class GenerateRoadTexture : ProceduralComponent
{
	public override void Process(uint seed)
	{
		foreach (PathList item in TerrainMeta.Path.Roads.AsEnumerable().Reverse())
		{
			item.AdjustTerrainTexture();
		}
	}
}
