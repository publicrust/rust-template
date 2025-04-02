using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class ImpostorBatch : IPooled
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
		if (buffer != null)
		{
			buffer.Release();
		}
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

	void IPooled.LeavePool()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		Positions = Pool.Get<FPNativeList<Vector4>>();
		args = Pool.Get<FPNativeList<uint>>();
		args.Resize(5);
		ArgsBuffer = new ComputeBuffer(1, args.Count * 4, (ComputeBufferType)256);
	}

	void IPooled.EnterPool()
	{
		recycle.Clear();
		Pool.Free<FPNativeList<Vector4>>(ref Positions);
		Pool.Free<FPNativeList<uint>>(ref args);
		PositionBuffer = SafeRelease(PositionBuffer);
		ArgsBuffer.Release();
		ArgsBuffer = null;
	}

	public void AddInstance(ImpostorInstanceData data)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		Positions[data.BatchIndex] = new Vector4(0f, 0f, 0f, -1f);
		recycle.Enqueue(data.BatchIndex);
		data.BatchIndex = 0;
		data.Batch = null;
		IsDirty = true;
	}

	public void UpdateBuffers()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		if (IsDirty)
		{
			bool flag = false;
			if (PositionBuffer == null || PositionBuffer.count != Positions.Count)
			{
				PositionBuffer = SafeRelease(PositionBuffer);
				PositionBuffer = new ComputeBuffer(Positions.Count, 16);
				flag = true;
			}
			PositionBuffer.SetData<Vector4>(Positions.Array, 0, 0, Positions.Count);
			if (flag)
			{
				args[1] = (uint)Positions.Count;
				ArgsBuffer.SetData<uint>(args.Array, 0, 0, args.Count);
			}
			IsDirty = false;
		}
	}
}
