using Rust;
using UnityEngine;

public abstract class MeshBatch : MonoBehaviour
{
	public bool NeedsRefresh { get; private set; }

	public int Count { get; private set; }

	public int BatchedCount { get; private set; }

	public int VertexCount { get; private set; }

	public abstract int VertexCapacity { get; }

	public abstract int VertexCutoff { get; }

	public int AvailableVertices => Mathf.Clamp(VertexCapacity, VertexCutoff, 65534) - VertexCount;

	protected abstract void AllocMemory();

	protected abstract void FreeMemory();

	protected abstract void RefreshMesh();

	protected abstract void ApplyMesh();

	protected abstract void ToggleMesh(bool state);

	protected abstract void OnPooled();

	public void Alloc()
	{
		AllocMemory();
	}

	public void Free()
	{
		FreeMemory();
	}

	public void Refresh()
	{
		RefreshMesh();
	}

	public void Apply()
	{
		NeedsRefresh = false;
		ApplyMesh();
	}

	public void Display()
	{
		ToggleMesh(state: true);
		BatchedCount = Count;
	}

	public void Invalidate()
	{
		ToggleMesh(state: false);
		BatchedCount = 0;
	}

	protected void AddVertices(int vertices)
	{
		NeedsRefresh = true;
		Count++;
		VertexCount += vertices;
	}

	protected void OnEnable()
	{
		NeedsRefresh = false;
		Count = 0;
		BatchedCount = 0;
		VertexCount = 0;
	}

	protected void OnDisable()
	{
		if (!Rust.Application.isQuitting)
		{
			NeedsRefresh = false;
			Count = 0;
			BatchedCount = 0;
			VertexCount = 0;
			OnPooled();
		}
	}
}
