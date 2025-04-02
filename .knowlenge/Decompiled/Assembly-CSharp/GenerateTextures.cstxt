public class GenerateTextures : ProceduralComponent
{
	public override bool RunOnCache => true;

	public override void Process(uint seed)
	{
		if (!World.Cached)
		{
			World.AddMap("height", TerrainMeta.HeightMap.ToByteArray());
			World.AddMap("splat", TerrainMeta.SplatMap.ToByteArray());
			World.AddMap("biome", TerrainMeta.BiomeMap.ToByteArray());
			World.AddMap("topology", TerrainMeta.TopologyMap.ToByteArray());
			World.AddMap("alpha", TerrainMeta.AlphaMap.ToByteArray());
			World.AddMap("water", TerrainMeta.WaterMap.ToByteArray());
		}
		else
		{
			TerrainMeta.HeightMap.FromByteArray(World.GetMap("height"));
		}
	}
}
