using UnityEngine;

public class AddToHeightMap : ProceduralObject
{
	public bool DestroyGameObject;

	public void Apply()
	{
		Collider component = GetComponent<Collider>();
		Bounds bounds = component.bounds;
		int num = TerrainMeta.HeightMap.Index(TerrainMeta.NormalizeX(bounds.min.x));
		int num2 = TerrainMeta.HeightMap.Index(TerrainMeta.NormalizeZ(bounds.max.x));
		int num3 = TerrainMeta.HeightMap.Index(TerrainMeta.NormalizeX(bounds.min.z));
		int num4 = TerrainMeta.HeightMap.Index(TerrainMeta.NormalizeZ(bounds.max.z));
		for (int i = num3; i <= num4; i++)
		{
			float normZ = TerrainMeta.HeightMap.Coordinate(i);
			for (int j = num; j <= num2; j++)
			{
				float normX = TerrainMeta.HeightMap.Coordinate(j);
				Vector3 origin = new Vector3(TerrainMeta.DenormalizeX(normX), bounds.max.y, TerrainMeta.DenormalizeZ(normZ));
				Ray ray = new Ray(origin, Vector3.down);
				if (component.Raycast(ray, out var hitInfo, bounds.size.y))
				{
					float num5 = TerrainMeta.NormalizeY(hitInfo.point.y);
					float height = TerrainMeta.HeightMap.GetHeight01(j, i);
					if (num5 > height)
					{
						TerrainMeta.HeightMap.SetHeight(j, i, num5);
					}
				}
			}
		}
	}

	public override void Process()
	{
		Apply();
		if (DestroyGameObject)
		{
			GameManager.Destroy(base.gameObject);
		}
		else
		{
			GameManager.Destroy(this);
		}
	}
}
