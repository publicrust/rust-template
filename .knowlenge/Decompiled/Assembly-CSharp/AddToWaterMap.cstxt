using UnityEngine;

public class AddToWaterMap : ProceduralObject
{
	public bool automaticallyAddTerrainTopology;

	public override void Process()
	{
		WaterBody component = GetComponent<WaterBody>();
		Collider component2 = GetComponent<Collider>();
		Bounds bounds = component2.bounds;
		int mask = ((component != null) ? component.GetTopologyMask() : 0);
		float num = TerrainMeta.NormalizeY(bounds.max.y);
		int num2 = TerrainMeta.WaterMap.Index(TerrainMeta.NormalizeX(bounds.min.x));
		int num3 = TerrainMeta.WaterMap.Index(TerrainMeta.NormalizeZ(bounds.max.x));
		int num4 = TerrainMeta.WaterMap.Index(TerrainMeta.NormalizeX(bounds.min.z));
		int num5 = TerrainMeta.WaterMap.Index(TerrainMeta.NormalizeZ(bounds.max.z));
		bool flag = component2 is BoxCollider && base.transform.rotation == Quaternion.identity;
		for (int i = num4; i <= num5; i++)
		{
			float normZ = TerrainMeta.WaterMap.Coordinate(i);
			for (int j = num2; j <= num3; j++)
			{
				float normX = TerrainMeta.WaterMap.Coordinate(j);
				Vector3 origin = new Vector3(TerrainMeta.DenormalizeX(normX), bounds.max.y + 1f, TerrainMeta.DenormalizeZ(normZ));
				if (!flag)
				{
					Ray ray = new Ray(origin, Vector3.down);
					if (!component2.Raycast(ray, out var hitInfo, bounds.size.y + 1f + 1f))
					{
						continue;
					}
					num = TerrainMeta.NormalizeY(hitInfo.point.y);
				}
				float height = TerrainMeta.HeightMap.GetHeight01(normX, normZ);
				if (num < height - TerrainMeta.OneOverSize.z)
				{
					continue;
				}
				if (component != null)
				{
					if (automaticallyAddTerrainTopology)
					{
						TerrainMeta.TopologyMap.AddTopology(normX, normZ, mask);
					}
					if (component.Type == WaterBodyType.Lake && !TerrainMeta.TopologyMap.GetTopology(normX, normZ, 196608))
					{
						continue;
					}
				}
				if (!(TerrainMeta.WaterMap.GetHeight01(j, i) >= num))
				{
					TerrainMeta.WaterMap.SetHeight(j, i, num);
				}
			}
		}
		GameManager.Destroy(this);
	}
}
