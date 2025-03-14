using System;
using UnityEngine;

public abstract class TerrainPlacement : PrefabAttribute
{
	[ReadOnly]
	public Vector3 size = Vector3.zero;

	[ReadOnly]
	public Vector3 extents = Vector3.zero;

	[ReadOnly]
	public Vector3 offset = Vector3.zero;

	public bool HeightMap = true;

	public bool AlphaMap = true;

	public bool WaterMap;

	[InspectorFlags]
	public TerrainSplat.Enum SplatMask;

	[InspectorFlags]
	public TerrainBiome.Enum BiomeMask;

	[InspectorFlags]
	public TerrainTopology.Enum TopologyMask;

	[HideInInspector]
	public Texture2DRef heightmap;

	[HideInInspector]
	public Texture2DRef splatmap0;

	[HideInInspector]
	public Texture2DRef splatmap1;

	[HideInInspector]
	public Texture2DRef alphamap;

	[HideInInspector]
	public Texture2DRef biomemap;

	[HideInInspector]
	public Texture2DRef topologymap;

	[HideInInspector]
	public Texture2DRef watermap;

	[HideInInspector]
	public Texture2DRef blendmap;

	public void Apply(Matrix4x4 localToWorld, Matrix4x4 worldToLocal)
	{
		if (ShouldHeight())
		{
			ApplyHeight(localToWorld, worldToLocal);
		}
		if (ShouldSplat())
		{
			ApplySplat(localToWorld, worldToLocal);
		}
		if (ShouldAlpha())
		{
			ApplyAlpha(localToWorld, worldToLocal);
		}
		if (ShouldBiome())
		{
			ApplyBiome(localToWorld, worldToLocal);
		}
		if (ShouldTopology())
		{
			ApplyTopology(localToWorld, worldToLocal);
		}
		if (ShouldWater())
		{
			ApplyWater(localToWorld, worldToLocal);
		}
	}

	protected bool ShouldHeight()
	{
		if (heightmap.isValid)
		{
			return HeightMap;
		}
		return false;
	}

	protected bool ShouldSplat(int id = -1)
	{
		if (splatmap0.isValid && splatmap1.isValid)
		{
			return ((uint)SplatMask & (uint)id) != 0;
		}
		return false;
	}

	protected bool ShouldAlpha()
	{
		if (alphamap.isValid)
		{
			return AlphaMap;
		}
		return false;
	}

	protected bool ShouldBiome(int id = -1)
	{
		if (biomemap.isValid)
		{
			return ((uint)BiomeMask & (uint)id) != 0;
		}
		return false;
	}

	protected bool ShouldTopology(int id = -1)
	{
		if (topologymap.isValid)
		{
			return ((uint)TopologyMask & (uint)id) != 0;
		}
		return false;
	}

	protected bool ShouldWater()
	{
		if (watermap.isValid)
		{
			return WaterMap;
		}
		return false;
	}

	protected abstract void ApplyHeight(Matrix4x4 localToWorld, Matrix4x4 worldToLocal);

	protected abstract void ApplySplat(Matrix4x4 localToWorld, Matrix4x4 worldToLocal);

	protected abstract void ApplyAlpha(Matrix4x4 localToWorld, Matrix4x4 worldToLocal);

	protected abstract void ApplyBiome(Matrix4x4 localToWorld, Matrix4x4 worldToLocal);

	protected abstract void ApplyTopology(Matrix4x4 localToWorld, Matrix4x4 worldToLocal);

	protected abstract void ApplyWater(Matrix4x4 localToWorld, Matrix4x4 worldToLocal);

	protected override Type GetIndexedType()
	{
		return typeof(TerrainPlacement);
	}
}
