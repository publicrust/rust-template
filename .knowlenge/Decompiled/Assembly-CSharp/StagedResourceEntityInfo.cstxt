using System;
using UnityEngine;

public class StagedResourceEntityInfo : PrefabAttribute
{
	[Serializable]
	public class ResourceStage
	{
		public float Health;

		public Mesh CollisionMesh;

		public Mesh[] VisualMeshLods;
	}

	public ResourceStage[] Stages;

	public Mesh GetCollisionMesh(int index)
	{
		index = Mathf.Clamp(index, 0, Stages.Length);
		return Stages[index].CollisionMesh;
	}

	public Mesh[] GetVisualMeshLods(int index)
	{
		index = Mathf.Clamp(index, 0, Stages.Length);
		return Stages[index].VisualMeshLods;
	}

	public float GetHealth(int index)
	{
		index = Mathf.Clamp(index, 0, Stages.Length);
		return Stages[index].Health;
	}

	protected override Type GetIndexedType()
	{
		return typeof(StagedResourceEntityInfo);
	}
}
