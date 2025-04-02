using UnityEngine;

public class Mountain : TerrainPlacement
{
	public float Fade = 10f;

	public bool AutoCliffSplat;

	public bool AutoCliffTopology = true;

	protected void OnDrawGizmosSelected()
	{
		Vector3 vector = Vector3.up * (0.5f * Fade);
		Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 1f);
		Gizmos.DrawCube(base.transform.position + vector, new Vector3(size.x, Fade, size.z));
		Gizmos.DrawWireCube(base.transform.position + vector, new Vector3(size.x, Fade, size.z));
	}

	protected override void ApplyHeight(Matrix4x4 localToWorld, Matrix4x4 worldToLocal)
	{
		Vector3 position = localToWorld.MultiplyPoint3x4(Vector3.zero);
		TextureData heightdata = new TextureData(heightmap.Get());
		Vector3 v = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - extents.x, 0f, 0f - extents.z));
		Vector3 v2 = localToWorld.MultiplyPoint3x4(offset + new Vector3(extents.x, 0f, 0f - extents.z));
		Vector3 v3 = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - extents.x, 0f, extents.z));
		Vector3 v4 = localToWorld.MultiplyPoint3x4(offset + new Vector3(extents.x, 0f, extents.z));
		TerrainMeta.HeightMap.ForEachParallel(v, v2, v3, v4, delegate(int x, int z)
		{
			float normZ = TerrainMeta.HeightMap.Coordinate(z);
			float normX = TerrainMeta.HeightMap.Coordinate(x);
			Vector3 point = new Vector3(TerrainMeta.DenormalizeX(normX), 0f, TerrainMeta.DenormalizeZ(normZ));
			Vector3 vector = worldToLocal.MultiplyPoint3x4(point) - offset;
			float num = position.y + offset.y + heightdata.GetInterpolatedHalf((vector.x + extents.x) / size.x, (vector.z + extents.z) / size.z) * size.y;
			float num2 = Mathf.InverseLerp(position.y, position.y + Fade, num);
			if (num2 != 0f)
			{
				float b = TerrainMeta.NormalizeY(num);
				b = Mathx.SmoothMax(TerrainMeta.HeightMap.GetHeight01(x, z), b);
				TerrainMeta.HeightMap.SetHeight(x, z, b, num2);
			}
		});
	}

	protected override void ApplySplat(Matrix4x4 localToWorld, Matrix4x4 worldToLocal)
	{
		bool should0 = ShouldSplat(1);
		bool should1 = ShouldSplat(2);
		bool should2 = ShouldSplat(4);
		bool should3 = ShouldSplat(8);
		bool should4 = ShouldSplat(16);
		bool should5 = ShouldSplat(32);
		bool should6 = ShouldSplat(64);
		bool should7 = ShouldSplat(128);
		if (!should0 && !should1 && !should2 && !should3 && !should4 && !should5 && !should6 && !should7)
		{
			return;
		}
		Vector3 position = localToWorld.MultiplyPoint3x4(Vector3.zero);
		TextureData heightdata = new TextureData(heightmap.Get());
		TextureData splat0data = new TextureData(splatmap0.Get());
		TextureData splat1data = new TextureData(splatmap1.Get());
		Vector3 v = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - extents.x, 0f, 0f - extents.z));
		Vector3 v2 = localToWorld.MultiplyPoint3x4(offset + new Vector3(extents.x, 0f, 0f - extents.z));
		Vector3 v3 = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - extents.x, 0f, extents.z));
		Vector3 v4 = localToWorld.MultiplyPoint3x4(offset + new Vector3(extents.x, 0f, extents.z));
		TerrainMeta.SplatMap.ForEachParallel(v, v2, v3, v4, delegate(int x, int z)
		{
			if (AutoCliffSplat)
			{
				GenerateCliffSplat.Process(x, z);
			}
			float normZ = TerrainMeta.SplatMap.Coordinate(z);
			float normX = TerrainMeta.SplatMap.Coordinate(x);
			Vector3 point = new Vector3(TerrainMeta.DenormalizeX(normX), 0f, TerrainMeta.DenormalizeZ(normZ));
			Vector3 vector = worldToLocal.MultiplyPoint3x4(point) - offset;
			float value = position.y + offset.y + heightdata.GetInterpolatedHalf((vector.x + extents.x) / size.x, (vector.z + extents.z) / size.z) * size.y;
			float num = Mathf.InverseLerp(position.y, position.y + Fade, value);
			if (num != 0f)
			{
				Vector4 interpolatedVector = splat0data.GetInterpolatedVector((vector.x + extents.x) / size.x, (vector.z + extents.z) / size.z);
				Vector4 interpolatedVector2 = splat1data.GetInterpolatedVector((vector.x + extents.x) / size.x, (vector.z + extents.z) / size.z);
				if (!should0)
				{
					interpolatedVector.x = 0f;
				}
				if (!should1)
				{
					interpolatedVector.y = 0f;
				}
				if (!should2)
				{
					interpolatedVector.z = 0f;
				}
				if (!should3)
				{
					interpolatedVector.w = 0f;
				}
				if (!should4)
				{
					interpolatedVector2.x = 0f;
				}
				if (!should5)
				{
					interpolatedVector2.y = 0f;
				}
				if (!should6)
				{
					interpolatedVector2.z = 0f;
				}
				if (!should7)
				{
					interpolatedVector2.w = 0f;
				}
				TerrainMeta.SplatMap.SetSplatRaw(x, z, interpolatedVector, interpolatedVector2, num);
			}
		});
	}

	protected override void ApplyAlpha(Matrix4x4 localToWorld, Matrix4x4 worldToLocal)
	{
	}

	protected override void ApplyBiome(Matrix4x4 localToWorld, Matrix4x4 worldToLocal)
	{
		bool should0 = ShouldBiome(1);
		bool should1 = ShouldBiome(2);
		bool should2 = ShouldBiome(4);
		bool should3 = ShouldBiome(8);
		if (!should0 && !should1 && !should2 && !should3)
		{
			return;
		}
		Vector3 position = localToWorld.MultiplyPoint3x4(Vector3.zero);
		TextureData heightdata = new TextureData(heightmap.Get());
		TextureData biomedata = new TextureData(biomemap.Get());
		Vector3 v = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - extents.x, 0f, 0f - extents.z));
		Vector3 v2 = localToWorld.MultiplyPoint3x4(offset + new Vector3(extents.x, 0f, 0f - extents.z));
		Vector3 v3 = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - extents.x, 0f, extents.z));
		Vector3 v4 = localToWorld.MultiplyPoint3x4(offset + new Vector3(extents.x, 0f, extents.z));
		TerrainMeta.BiomeMap.ForEachParallel(v, v2, v3, v4, delegate(int x, int z)
		{
			float normZ = TerrainMeta.BiomeMap.Coordinate(z);
			float normX = TerrainMeta.BiomeMap.Coordinate(x);
			Vector3 point = new Vector3(TerrainMeta.DenormalizeX(normX), 0f, TerrainMeta.DenormalizeZ(normZ));
			Vector3 vector = worldToLocal.MultiplyPoint3x4(point) - offset;
			float value = position.y + offset.y + heightdata.GetInterpolatedHalf((vector.x + extents.x) / size.x, (vector.z + extents.z) / size.z) * size.y;
			float num = Mathf.InverseLerp(position.y, position.y + Fade, value);
			if (num != 0f)
			{
				Vector4 interpolatedVector = biomedata.GetInterpolatedVector((vector.x + extents.x) / size.x, (vector.z + extents.z) / size.z);
				if (!should0)
				{
					interpolatedVector.x = 0f;
				}
				if (!should1)
				{
					interpolatedVector.y = 0f;
				}
				if (!should2)
				{
					interpolatedVector.z = 0f;
				}
				if (!should3)
				{
					interpolatedVector.w = 0f;
				}
				TerrainMeta.BiomeMap.SetBiomeRaw(x, z, interpolatedVector, num);
			}
		});
	}

	protected override void ApplyTopology(Matrix4x4 localToWorld, Matrix4x4 worldToLocal)
	{
		TextureData topologydata = new TextureData(topologymap.Get());
		Vector3 v = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - extents.x, 0f, 0f - extents.z));
		Vector3 v2 = localToWorld.MultiplyPoint3x4(offset + new Vector3(extents.x, 0f, 0f - extents.z));
		Vector3 v3 = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - extents.x, 0f, extents.z));
		Vector3 v4 = localToWorld.MultiplyPoint3x4(offset + new Vector3(extents.x, 0f, extents.z));
		TerrainMeta.TopologyMap.ForEachParallel(v, v2, v3, v4, delegate(int x, int z)
		{
			if (AutoCliffTopology)
			{
				GenerateCliffTopology.Process(x, z);
			}
			float normZ = TerrainMeta.TopologyMap.Coordinate(z);
			float normX = TerrainMeta.TopologyMap.Coordinate(x);
			Vector3 point = new Vector3(TerrainMeta.DenormalizeX(normX), 0f, TerrainMeta.DenormalizeZ(normZ));
			Vector3 vector = worldToLocal.MultiplyPoint3x4(point) - offset;
			int interpolatedInt = topologydata.GetInterpolatedInt((vector.x + extents.x) / size.x, (vector.z + extents.z) / size.z);
			if (ShouldTopology(interpolatedInt))
			{
				TerrainMeta.TopologyMap.AddTopology(x, z, interpolatedInt & (int)TopologyMask);
			}
		});
	}

	protected override void ApplyWater(Matrix4x4 localToWorld, Matrix4x4 worldToLocal)
	{
	}
}
