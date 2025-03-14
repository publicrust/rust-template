using UnityEngine;

public class AddToWaterMap : ProceduralObject
{
	public override void Process()
	{
		Collider component = GetComponent<Collider>();
		Bounds bounds = component.bounds;
		int num = TerrainMeta.WaterMap.Index(TerrainMeta.NormalizeX(bounds.min.x));
		int num2 = TerrainMeta.WaterMap.Index(TerrainMeta.NormalizeZ(bounds.max.x));
		int num3 = TerrainMeta.WaterMap.Index(TerrainMeta.NormalizeX(bounds.min.z));
		int num4 = TerrainMeta.WaterMap.Index(TerrainMeta.NormalizeZ(bounds.max.z));
		if (component is BoxCollider && base.transform.rotation == Quaternion.identity)
		{
			float num5 = TerrainMeta.NormalizeY(bounds.max.y);
			for (int i = num3; i <= num4; i++)
			{
				for (int j = num; j <= num2; j++)
				{
					float height = TerrainMeta.WaterMap.GetHeight01(j, i);
					if (num5 > height)
					{
						TerrainMeta.WaterMap.SetHeight(j, i, num5);
					}
				}
			}
		}
		else
		{
			for (int k = num3; k <= num4; k++)
			{
				float normZ = TerrainMeta.WaterMap.Coordinate(k);
				for (int l = num; l <= num2; l++)
				{
					float normX = TerrainMeta.WaterMap.Coordinate(l);
					Vector3 origin = new Vector3(TerrainMeta.DenormalizeX(normX), bounds.max.y + 1f, TerrainMeta.DenormalizeZ(normZ));
					Ray ray = new Ray(origin, Vector3.down);
					if (component.Raycast(ray, out var hitInfo, bounds.size.y + 1f + 1f))
					{
						float num6 = TerrainMeta.NormalizeY(hitInfo.point.y);
						float height2 = TerrainMeta.WaterMap.GetHeight01(l, k);
						if (num6 > height2)
						{
							TerrainMeta.WaterMap.SetHeight(l, k, num6);
						}
					}
				}
			}
		}
		GameManager.Destroy(this);
	}
}
