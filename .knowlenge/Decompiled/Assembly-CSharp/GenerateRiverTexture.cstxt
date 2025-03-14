using System.Linq;

public class GenerateRiverTexture : ProceduralComponent
{
	public override void Process(uint seed)
	{
		foreach (PathList item in TerrainMeta.Path.Rivers.AsEnumerable().Reverse())
		{
			item.AdjustTerrainTexture(scaleWidthWithLength: true);
		}
	}
}
