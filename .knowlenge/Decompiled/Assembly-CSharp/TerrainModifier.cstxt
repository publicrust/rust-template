using System;
using UnityEngine;

public abstract class TerrainModifier : PrefabAttribute
{
	public float Opacity = 1f;

	public float Radius;

	public float Fade;

	public void Apply(Vector3 pos, float scale)
	{
		float opacity = Opacity;
		float radius = scale * Radius;
		float fade = scale * Fade;
		Apply(pos, opacity, radius, fade);
	}

	protected abstract void Apply(Vector3 position, float opacity, float radius, float fade);

	protected override Type GetIndexedType()
	{
		return typeof(TerrainModifier);
	}
}
