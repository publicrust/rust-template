public class GenerateTerrainMesh : ProceduralComponent
{
	public override bool RunOnCache => true;

	public override void Process(uint seed)
	{
		if (!World.Cached)
		{
			World.AddMap("terrain", TerrainMeta.HeightMap.ToByteArray());
		}
		TerrainMeta.HeightMap.ApplyToTerrain();
	}
}
