using System.Collections.Generic;
using ConVar;
using Facepunch;
using UnityEngine;
using UnityEngine.Rendering;

public class MeshRendererBatch : MeshBatch
{
	private Vector3 position;

	private UnityEngine.Mesh meshBatch;

	private MeshFilter meshFilter;

	private MeshRenderer meshRenderer;

	private MeshRendererData meshData;

	private MeshRendererGroup meshGroup;

	private MeshRendererLookup meshLookup;

	private static MaterialPropertyBlock propertyBlock;

	public override int VertexCapacity => Batching.renderer_capacity;

	public override int VertexCutoff => Batching.renderer_vertices;

	protected void Awake()
	{
		meshFilter = GetComponent<MeshFilter>();
		meshRenderer = GetComponent<MeshRenderer>();
		meshData = new MeshRendererData();
		meshLookup = new MeshRendererLookup();
	}

	public void SetupColor(Color color)
	{
		if (propertyBlock == null)
		{
			propertyBlock = new MaterialPropertyBlock();
		}
		meshRenderer.GetPropertyBlock(propertyBlock);
		meshRenderer.SetPropertyBlock(propertyBlock);
	}

	public void Setup(Vector3 position, Material material, ShadowCastingMode shadows, int layer, Color color)
	{
		Vector3 vector2 = (base.transform.position = position);
		this.position = vector2;
		base.gameObject.layer = layer;
		meshRenderer.sharedMaterial = material;
		meshRenderer.shadowCastingMode = shadows;
		SetupColor(color);
		if (shadows == ShadowCastingMode.ShadowsOnly)
		{
			meshRenderer.receiveShadows = false;
			meshRenderer.motionVectors = false;
			meshRenderer.lightProbeUsage = LightProbeUsage.Off;
			meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
		}
		else
		{
			meshRenderer.receiveShadows = true;
			meshRenderer.motionVectors = true;
			meshRenderer.lightProbeUsage = LightProbeUsage.BlendProbes;
			meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.BlendProbes;
		}
	}

	public void Add(MeshRendererInstance instance)
	{
		instance.position -= position;
		meshGroup.Add(instance);
		AddVertices(instance.mesh.vertexCount);
	}

	protected override void AllocMemory()
	{
		meshGroup = Facepunch.Pool.Get<MeshRendererGroup>();
		meshData.Alloc();
	}

	protected override void FreeMemory()
	{
		Facepunch.Pool.Free(ref meshGroup);
		meshData.Free();
	}

	protected override void RefreshMesh()
	{
		meshLookup.dst.Clear();
		meshData.Clear();
		meshData.Combine(meshGroup, meshLookup);
	}

	protected override void ApplyMesh()
	{
		if (!meshBatch)
		{
			meshBatch = AssetPool.Get<UnityEngine.Mesh>();
		}
		meshLookup.Apply();
		meshData.Apply(meshBatch);
		meshBatch.UploadMeshData(markNoLongerReadable: false);
	}

	protected override void ToggleMesh(bool state)
	{
		List<MeshRendererLookup.LookupEntry> data = meshLookup.src.data;
		for (int i = 0; i < data.Count; i++)
		{
			Renderer renderer = data[i].renderer;
			if ((bool)renderer)
			{
				renderer.enabled = !state;
			}
		}
		if (state)
		{
			if ((bool)meshFilter)
			{
				meshFilter.sharedMesh = meshBatch;
			}
			if ((bool)meshRenderer)
			{
				meshRenderer.enabled = true;
			}
		}
		else
		{
			if ((bool)meshFilter)
			{
				meshFilter.sharedMesh = null;
			}
			if ((bool)meshRenderer)
			{
				meshRenderer.enabled = false;
			}
		}
	}

	protected override void OnPooled()
	{
		if ((bool)meshFilter)
		{
			meshFilter.sharedMesh = null;
		}
		if ((bool)meshBatch)
		{
			AssetPool.Free(ref meshBatch);
		}
		meshData.Free();
		if (meshGroup != null)
		{
			Facepunch.Pool.Free(ref meshGroup);
		}
		meshLookup.src.Clear();
		meshLookup.dst.Clear();
	}
}
