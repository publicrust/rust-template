using UnityEngine;

public class Monument : TerrainPlacement
{
	public float Radius;

	public float Fade = 10f;

	public bool AutoCliffSplat = true;

	public bool AutoCliffTopology = true;

	public bool RemoveExistingTopology;

	protected void OnDrawGizmosSelected()
	{
		if (Radius == 0f)
		{
			Radius = extents.x;
		}
		Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 1f);
		GizmosUtil.DrawWireCircleY(base.transform.position, Radius);
		GizmosUtil.DrawWireCircleY(base.transform.position, Radius - Fade);
	}

	protected override void ApplyHeight(Matrix4x4 localToWorld, Matrix4x4 worldToLocal)
	{
		if (Radius == 0f)
		{
			Radius = extents.x;
		}
		bool useBlendMap = blendmap.isValid;
		Vector3 position = localToWorld.MultiplyPoint3x4(Vector3.zero);
		TextureData heightdata = new TextureData(heightmap.Get());
		TextureData blenddata = new TextureData(useBlendMap ? blendmap.Get() : null);
		float num = (useBlendMap ? extents.x : Radius);
		float num2 = (useBlendMap ? extents.z : Radius);
		Vector3 v = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - num, 0f, 0f - num2));
		Vector3 v2 = localToWorld.MultiplyPoint3x4(offset + new Vector3(num, 0f, 0f - num2));
		Vector3 v3 = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - num, 0f, num2));
		Vector3 v4 = localToWorld.MultiplyPoint3x4(offset + new Vector3(num, 0f, num2));
		TerrainMeta.HeightMap.ForEachParallel(v, v2, v3, v4, delegate(int x, int z)
		{
			float normZ = TerrainMeta.HeightMap.Coordinate(z);
			float normX = TerrainMeta.HeightMap.Coordinate(x);
			Vector3 point = new Vector3(TerrainMeta.DenormalizeX(normX), 0f, TerrainMeta.DenormalizeZ(normZ));
			Vector3 v5 = worldToLocal.MultiplyPoint3x4(point) - offset;
			float num3 = 1f;
			num3 = ((!useBlendMap) ? Mathf.InverseLerp(Radius, Radius - Fade, v5.Magnitude2D()) : blenddata.GetInterpolatedVector((v5.x + extents.x) / size.x, (v5.z + extents.z) / size.z).w);
			if (num3 != 0f)
			{
				int num4 = Mathx.Min(x, z, TerrainMeta.HeightMap.res - 1 - x, TerrainMeta.HeightMap.res - 1 - z);
				if (num4 < 10)
				{
					num3 *= Mathf.SmoothStep(0f, 1f, Mathf.InverseLerp(0f, 10f, num4));
				}
				if (num3 != 0f)
				{
					float to = TerrainMeta.NormalizeY(position.y + offset.y + heightdata.GetInterpolatedHalf((v5.x + extents.x) / size.x, (v5.z + extents.z) / size.z) * size.y);
					to = Mathf.SmoothStep(TerrainMeta.HeightMap.GetHeight01(x, z), to, num3);
					TerrainMeta.HeightMap.SetHeight(x, z, to);
				}
			}
		});
	}

	protected override void ApplySplat(Matrix4x4 localToWorld, Matrix4x4 worldToLocal)
	{
		if (Radius == 0f)
		{
			Radius = extents.x;
		}
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
		TextureData splat0data = new TextureData(splatmap0.Get());
		TextureData splat1data = new TextureData(splatmap1.Get());
		Vector3 v = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - Radius, 0f, 0f - Radius));
		Vector3 v2 = localToWorld.MultiplyPoint3x4(offset + new Vector3(Radius, 0f, 0f - Radius));
		Vector3 v3 = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - Radius, 0f, Radius));
		Vector3 v4 = localToWorld.MultiplyPoint3x4(offset + new Vector3(Radius, 0f, Radius));
		TerrainMeta.SplatMap.ForEachParallel(v, v2, v3, v4, delegate(int x, int z)
		{
			if (AutoCliffSplat)
			{
				GenerateCliffSplat.Process(x, z);
			}
			float normZ = TerrainMeta.SplatMap.Coordinate(z);
			float normX = TerrainMeta.SplatMap.Coordinate(x);
			Vector3 point = new Vector3(TerrainMeta.DenormalizeX(normX), 0f, TerrainMeta.DenormalizeZ(normZ));
			Vector3 v5 = worldToLocal.MultiplyPoint3x4(point) - offset;
			float num = Mathf.InverseLerp(Radius, Radius - Fade, v5.Magnitude2D());
			if (num != 0f)
			{
				Vector4 interpolatedVector = splat0data.GetInterpolatedVector((v5.x + extents.x) / size.x, (v5.z + extents.z) / size.z);
				Vector4 interpolatedVector2 = splat1data.GetInterpolatedVector((v5.x + extents.x) / size.x, (v5.z + extents.z) / size.z);
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
		if (Radius == 0f)
		{
			Radius = extents.x;
		}
		TextureData alphadata = new TextureData(alphamap.Get());
		Vector3 v = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - Radius, 0f, 0f - Radius));
		Vector3 v2 = localToWorld.MultiplyPoint3x4(offset + new Vector3(Radius, 0f, 0f - Radius));
		Vector3 v3 = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - Radius, 0f, Radius));
		Vector3 v4 = localToWorld.MultiplyPoint3x4(offset + new Vector3(Radius, 0f, Radius));
		TerrainMeta.AlphaMap.ForEachParallel(v, v2, v3, v4, delegate(int x, int z)
		{
			float normZ = TerrainMeta.AlphaMap.Coordinate(z);
			float normX = TerrainMeta.AlphaMap.Coordinate(x);
			Vector3 point = new Vector3(TerrainMeta.DenormalizeX(normX), 0f, TerrainMeta.DenormalizeZ(normZ));
			Vector3 v5 = worldToLocal.MultiplyPoint3x4(point) - offset;
			float num = Mathf.InverseLerp(Radius, Radius - Fade, v5.Magnitude2D());
			if (num != 0f)
			{
				float w = alphadata.GetInterpolatedVector((v5.x + extents.x) / size.x, (v5.z + extents.z) / size.z).w;
				TerrainMeta.AlphaMap.SetAlpha(x, z, w, num);
			}
		});
	}

	protected override void ApplyBiome(Matrix4x4 localToWorld, Matrix4x4 worldToLocal)
	{
		if (Radius == 0f)
		{
			Radius = extents.x;
		}
		bool should0 = ShouldBiome(1);
		bool should1 = ShouldBiome(2);
		bool should2 = ShouldBiome(4);
		bool should3 = ShouldBiome(8);
		if (!should0 && !should1 && !should2 && !should3)
		{
			return;
		}
		TextureData biomedata = new TextureData(biomemap.Get());
		Vector3 v = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - Radius, 0f, 0f - Radius));
		Vector3 v2 = localToWorld.MultiplyPoint3x4(offset + new Vector3(Radius, 0f, 0f - Radius));
		Vector3 v3 = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - Radius, 0f, Radius));
		Vector3 v4 = localToWorld.MultiplyPoint3x4(offset + new Vector3(Radius, 0f, Radius));
		TerrainMeta.BiomeMap.ForEachParallel(v, v2, v3, v4, delegate(int x, int z)
		{
			float normZ = TerrainMeta.BiomeMap.Coordinate(z);
			float normX = TerrainMeta.BiomeMap.Coordinate(x);
			Vector3 point = new Vector3(TerrainMeta.DenormalizeX(normX), 0f, TerrainMeta.DenormalizeZ(normZ));
			Vector3 v5 = worldToLocal.MultiplyPoint3x4(point) - offset;
			float num = Mathf.InverseLerp(Radius, Radius - Fade, v5.Magnitude2D());
			if (num != 0f)
			{
				Vector4 interpolatedVector = biomedata.GetInterpolatedVector((v5.x + extents.x) / size.x, (v5.z + extents.z) / size.z);
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
		if (Radius == 0f)
		{
			Radius = extents.x;
		}
		TextureData topologydata = new TextureData(topologymap.Get());
		Vector3 v = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - Radius, 0f, 0f - Radius));
		Vector3 v2 = localToWorld.MultiplyPoint3x4(offset + new Vector3(Radius, 0f, 0f - Radius));
		Vector3 v3 = localToWorld.MultiplyPoint3x4(offset + new Vector3(0f - Radius, 0f, Radius));
		Vector3 v4 = localToWorld.MultiplyPoint3x4(offset + new Vector3(Radius, 0f, Radius));
		TerrainMeta.TopologyMap.ForEachParallel(v, v2, v3, v4, delegate(int x, int z)
		{
			float normZ = TerrainMeta.TopologyMap.Coordinate(z);
			float normX = TerrainMeta.TopologyMap.Coordinate(x);
			Vector3 point = new Vector3(TerrainMeta.DenormalizeX(normX), 0f, TerrainMeta.DenormalizeZ(normZ));
			Vector3 vector = worldToLocal.MultiplyPoint3x4(point) - offset;
			int interpolatedInt = topologydata.GetInterpolatedInt((vector.x + extents.x) / size.x, (vector.z + extents.z) / size.z);
			bool num = ShouldTopology(interpolatedInt);
			if (num && RemoveExistingTopology)
			{
				TerrainMeta.TopologyMap.RemoveTopology(x, z, (int)TopologyMask);
			}
			if (AutoCliffTopology)
			{
				GenerateCliffTopology.Process(x, z);
			}
			if (num)
			{
				TerrainMeta.TopologyMap.AddTopology(x, z, interpolatedInt & (int)TopologyMask);
			}
		});
	}

	protected override void ApplyWater(Matrix4x4 localToWorld, Matrix4x4 worldToLocal)
	{
	}
}
