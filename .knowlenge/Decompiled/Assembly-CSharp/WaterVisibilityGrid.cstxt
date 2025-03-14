#define UNITY_ASSERTIONS
using System;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class WaterVisibilityGrid
{
	private struct RefCountedSpatialArray
	{
		private byte[] _array;

		public int Length => _array.Length;

		public static RefCountedSpatialArray Init(int length)
		{
			RefCountedSpatialArray result = default(RefCountedSpatialArray);
			result._array = new byte[length];
			return result;
		}

		public void Add(int index)
		{
			Debug.Assert(_array[index] != byte.MaxValue);
			_array[index]++;
		}

		public void Remove(int index)
		{
			Debug.Assert(_array[index] != 0);
			_array[index]--;
		}

		public bool Get(int index)
		{
			return _array[index] > 0;
		}
	}

	private const int CellSize = 8;

	private const int MaxWorldSizeXZ = 8096;

	private const float StaticBoundsInflation = 0.1f;

	private static readonly ProfilerMarker p_QueryWorldPosition = new ProfilerMarker("WaterVisibilityGrid.QueryWorldPosition");

	private static readonly ProfilerMarker p_QueryBounds = new ProfilerMarker("WaterVisibilityGrid.QueryBounds");

	private RefCountedSpatialArray _staticTriggerGrid;

	private readonly int _cellXZDimensionCount;

	private readonly Vector2 _gridCentre;

	private readonly ListHashSet<WaterVisibilityTrigger> _dynamicListSet;

	internal WaterVisibilityGrid()
	{
		_cellXZDimensionCount = 1012;
		_gridCentre = new Vector2(4048f, 4048f);
		_staticTriggerGrid = RefCountedSpatialArray.Init(_cellXZDimensionCount * _cellXZDimensionCount);
		_dynamicListSet = new ListHashSet<WaterVisibilityTrigger>();
	}

	public void Add(WaterVisibilityTrigger trigger)
	{
		if (trigger.IsDynamic)
		{
			AddDynamic(trigger);
		}
		else
		{
			AddStatic(trigger);
		}
	}

	public void CheckIndices(Bounds bounds, List<int> toPopulate)
	{
		toPopulate.Clear();
		Vector2i vector2i = WorldPosToStaticGrid(bounds.min);
		Vector2i vector2i2 = WorldPosToStaticGrid(bounds.max);
		for (int i = vector2i.x; i <= vector2i2.x; i++)
		{
			for (int j = vector2i.y; j <= vector2i2.y; j++)
			{
				toPopulate.Add(GridToStaticIndex(new Vector2i(i, j)));
			}
		}
	}

	public void Remove(WaterVisibilityTrigger trigger)
	{
		if (trigger.IsDynamic)
		{
			RemoveDynamic(trigger);
		}
		else
		{
			RemoveStatic(trigger);
		}
	}

	private void AddStatic(WaterVisibilityTrigger trigger)
	{
		if (trigger.volume == null || trigger.volume.trigger == null)
		{
			return;
		}
		Bounds bounds = trigger.volume.trigger.bounds;
		bounds.Expand(0.1f);
		Vector2i vector2i = WorldPosToStaticGrid(bounds.min);
		Vector2i vector2i2 = WorldPosToStaticGrid(bounds.max);
		for (int i = vector2i.x; i <= vector2i2.x; i++)
		{
			for (int j = vector2i.y; j <= vector2i2.y; j++)
			{
				int index = GridToStaticIndex(new Vector2i(i, j));
				_staticTriggerGrid.Add(index);
			}
		}
	}

	private void RemoveStatic(WaterVisibilityTrigger trigger)
	{
		if (trigger.volume == null || trigger.volume.trigger == null)
		{
			return;
		}
		Bounds bounds = trigger.volume.trigger.bounds;
		bounds.Expand(0.1f);
		Vector2i vector2i = WorldPosToStaticGrid(bounds.min);
		Vector2i vector2i2 = WorldPosToStaticGrid(bounds.max);
		for (int i = vector2i.x; i <= vector2i2.x; i++)
		{
			for (int j = vector2i.y; j <= vector2i2.y; j++)
			{
				int index = GridToStaticIndex(new Vector2i(i, j));
				_staticTriggerGrid.Remove(index);
			}
		}
	}

	private void AddDynamic(WaterVisibilityTrigger trigger)
	{
		_dynamicListSet.TryAdd(trigger);
	}

	private void RemoveDynamic(WaterVisibilityTrigger trigger)
	{
		_dynamicListSet.Remove(trigger);
	}

	public bool Check(Bounds bounds)
	{
		using (p_QueryBounds.Auto())
		{
			Vector2i vector2i = WorldPosToStaticGrid(bounds.min);
			Vector2i vector2i2 = WorldPosToStaticGrid(bounds.max);
			for (int i = vector2i.x; i <= vector2i2.x; i++)
			{
				for (int j = vector2i.y; j <= vector2i2.y; j++)
				{
					int index = GridToStaticIndex(new Vector2i(i, j));
					if (_staticTriggerGrid.Get(index))
					{
						return true;
					}
				}
			}
			foreach (WaterVisibilityTrigger value in _dynamicListSet.Values)
			{
				if (value.volume.trigger.bounds.Intersects(bounds))
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool Check(Vector3 worldPosition, float radius)
	{
		using (p_QueryWorldPosition.Auto())
		{
			Vector2i vector2i = WorldPosToStaticGrid(worldPosition - Vector3.one * radius);
			Vector2i vector2i2 = WorldPosToStaticGrid(worldPosition + Vector3.one * radius);
			for (int i = vector2i.x; i <= vector2i2.x; i++)
			{
				for (int j = vector2i.y; j <= vector2i2.y; j++)
				{
					int index = GridToStaticIndex(new Vector2i(i, j));
					if (_staticTriggerGrid.Get(index))
					{
						return true;
					}
				}
			}
			float num = radius * radius;
			foreach (WaterVisibilityTrigger value in _dynamicListSet.Values)
			{
				if (Vector3.SqrMagnitude(value.volume.trigger.bounds.ClosestPoint(worldPosition) - worldPosition) <= num)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool Check(Vector3 start, Vector3 end, float radius)
	{
		Vector3 vector = Vector3.one * radius;
		Vector3 vector2 = Vector3.Min(start, end) - vector;
		Vector3 vector3 = Vector3.Max(start, end) + vector;
		Bounds bounds = new Bounds((vector3 + vector2) * 0.5f, vector3 - vector2);
		return Check(bounds);
	}

	private Vector2i WorldPosToStaticGrid(Vector3 worldPosition)
	{
		return new Vector2i((int)((worldPosition.x + _gridCentre.x) / 8f), (int)((worldPosition.z + _gridCentre.y) / 8f));
	}

	private int GridToStaticIndex(Vector2i gridPosition)
	{
		return Math.Clamp(gridPosition.x + gridPosition.y * _cellXZDimensionCount, 0, _staticTriggerGrid.Length - 1);
	}
}
