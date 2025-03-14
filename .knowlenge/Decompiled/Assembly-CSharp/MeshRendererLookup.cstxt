using System.Collections.Generic;
using UnityEngine;

public class MeshRendererLookup
{
	public class LookupGroup
	{
		public List<LookupEntry> data = new List<LookupEntry>();

		public void Clear()
		{
			data.Clear();
		}

		public void Add(MeshRendererInstance instance)
		{
			data.Add(new LookupEntry(instance));
		}

		public LookupEntry Get(int index)
		{
			return data[index];
		}
	}

	public struct LookupEntry
	{
		public Renderer renderer;

		public LookupEntry(MeshRendererInstance instance)
		{
			renderer = instance.renderer;
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

	public void Clear()
	{
		dst.Clear();
	}

	public void Add(MeshRendererInstance instance)
	{
		dst.Add(instance);
	}

	public LookupEntry Get(int index)
	{
		return src.Get(index);
	}
}
