using System.Collections.Generic;
using UnityEngine;

public class MeshColliderLookup
{
	public class LookupGroup
	{
		public List<LookupEntry> data = new List<LookupEntry>();

		public List<int> indices = new List<int>();

		public void Clear()
		{
			data.Clear();
			indices.Clear();
		}

		public void Add(MeshColliderInstance instance)
		{
			data.Add(new LookupEntry(instance));
			int item = data.Count - 1;
			int num = instance.data.triangles.Length / 3;
			for (int i = 0; i < num; i++)
			{
				indices.Add(item);
			}
		}

		public LookupEntry Get(int index)
		{
			return data[indices[index]];
		}
	}

	public struct LookupEntry
	{
		public Transform transform;

		public Rigidbody rigidbody;

		public Collider collider;

		public OBB bounds;

		public LookupEntry(MeshColliderInstance instance)
		{
			transform = instance.transform;
			rigidbody = instance.rigidbody;
			collider = instance.collider;
			bounds = instance.bounds;
		}
	}

	public LookupGroup src = new LookupGroup();

	public LookupGroup dst = new LookupGroup();

	public void Apply()
	{
		LookupGroup lookupGroup = src;
		src = dst;
		dst = lookupGroup;
		dst.Clear();
	}

	public void Add(MeshColliderInstance instance)
	{
		dst.Add(instance);
	}

	public LookupEntry Get(int index)
	{
		return src.Get(index);
	}
}
