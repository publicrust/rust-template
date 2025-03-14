public class GenerateClutterTopology : ProceduralComponent
{
	public override void Process(uint seed)
	{
		int[] map = TerrainMeta.TopologyMap.dst;
		int res = TerrainMeta.TopologyMap.res;
		ImageProcessing.Dilate2D(map, res, res, 16777728, 3, delegate(int x, int y)
		{
			if ((map[x * res + y] & 0x200) == 0)
			{
				map[x * res + y] |= 16777216;
			}
		});
	}
}
