using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class ImpostorBatch : Pool.IPooled
{
	public FPNativeList<Vector4> Positions;

	private FPNativeList<uint> args;

	private Queue<int> recycle = new Queue<int>(32);

	public Mesh Mesh { get; private set; }

	public Material Material { get; private set; }

	public ComputeBuffer PositionBuffer { get; private set; }

	public ComputeBuffer ArgsBuffer { get; private set; }

	public bool IsDirty { get; set; }

	public int Count => Positions.Count;

	public bool Visible => Positions.Count - recycle.Count > 0;

	private ComputeBuffer SafeRelease(ComputeBuffer buffer)
	{
		buffer?.Release();
		return null;
	}

	public void Initialize(Mesh mesh, Material material)
	{
		Mesh = mesh;
		Material = material;
		args[0] = Mesh.GetIndexCount(0);
		args[2] = Mesh.GetIndexStart(0);
		args[3] = Mesh.GetBaseVertex(0);
	}

	void Pool.IPooled.LeavePool()
	{
		Positions = Pool.Get<FPNativeList<Vector4>>();
		args = Pool.Get<FPNativeList<uint>>();
		args.Resize(5);
		ArgsBuffer = new ComputeBuffer(1, args.Count * 4, ComputeBufferType.DrawIndirect);
	}

	void Pool.IPooled.EnterPool()
	{
		recycle.Clear();
		Pool.Free(ref Positions);
		Pool.Free(ref args);
		PositionBuffer = SafeRelease(PositionBuffer);
		ArgsBuffer.Release();
		ArgsBuffer = null;
	}

	public void AddInstance(ImpostorInstanceData data)
	{
		data.Batch = this;
		if (recycle.Count > 0)
		{
			data.BatchIndex = recycle.Dequeue();
			Positions[data.BatchIndex] = data.PositionAndScale();
		}
		else
		{
			data.BatchIndex = Positions.Count;
			Positions.Add(data.PositionAndScale());
		}
		IsDirty = true;
	}

	public void RemoveInstance(ImpostorInstanceData data)
	{
		Positions[data.BatchIndex] = new Vector4(0f, 0f, 0f, -1f);
		recycle.Enqueue(data.BatchIndex);
		data.BatchIndex = 0;
		data.Batch = null;
		IsDirty = true;
	}

	public void UpdateBuffers()
	{
		if (IsDirty)
		{
			bool flag = false;
			if (PositionBuffer == null || PositionBuffer.count != Positions.Count)
			{
				PositionBuffer = SafeRelease(PositionBuffer);
				PositionBuffer = new ComputeBuffer(Positions.Count, 16);
				flag = true;
			}
			PositionBuffer.SetData(Positions.Array, 0, 0, Positions.Count);
			if (flag)
			{
				args[1] = (uint)Positions.Count;
				ArgsBuffer.SetData(args.Array, 0, 0, args.Count);
			}
			IsDirty = false;
		}
	}
}
