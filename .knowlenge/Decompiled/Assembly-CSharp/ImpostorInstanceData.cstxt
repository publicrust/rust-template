using UnityEngine;

public class ImpostorInstanceData
{
	public ImpostorBatch Batch;

	public int BatchIndex;

	private int hash;

	private Vector4 positionAndScale = Vector4.zero;

	public Renderer Renderer { get; private set; }

	public Mesh Mesh { get; private set; }

	public Material Material { get; private set; }

	public ImpostorInstanceData(Renderer renderer, Mesh mesh, Material material)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		Renderer = renderer;
		Mesh = mesh;
		Material = material;
		hash = GenerateHashCode();
		Update();
	}

	public ImpostorInstanceData(Vector3 position, Vector3 scale, Mesh mesh, Material material)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		positionAndScale = new Vector4(position.x, position.y, position.z, scale.x);
		Mesh = mesh;
		Material = material;
		hash = GenerateHashCode();
		Update();
	}

	private int GenerateHashCode()
	{
		return (17 * 31 + ((object)Material).GetHashCode()) * 31 + ((object)Mesh).GetHashCode();
	}

	public override bool Equals(object obj)
	{
		ImpostorInstanceData impostorInstanceData = obj as ImpostorInstanceData;
		if ((Object)(object)impostorInstanceData.Material == (Object)(object)Material)
		{
			return (Object)(object)impostorInstanceData.Mesh == (Object)(object)Mesh;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return hash;
	}

	public Vector4 PositionAndScale()
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)Renderer != (Object)null)
		{
			Transform transform = ((Component)Renderer).transform;
			Vector3 position = transform.position;
			Vector3 lossyScale = transform.lossyScale;
			float num = (Renderer.enabled ? lossyScale.x : (0f - lossyScale.x));
			positionAndScale = new Vector4(position.x, position.y, position.z, num);
		}
		return positionAndScale;
	}

	public void Update()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (Batch != null)
		{
			Batch.Positions[BatchIndex] = PositionAndScale();
			Batch.IsDirty = true;
		}
	}
}
