using System;
using UnityEngine;

public class CargoMoveTest : FacepunchBehaviour
{
	public int targetNodeIndex = -1;

	private float currentThrottle;

	private float turnScale;

	private void Awake()
	{
		((FacepunchBehaviour)this).Invoke((Action)FindInitialNode, 2f);
	}

	public void FindInitialNode()
	{
		targetNodeIndex = GetClosestNodeToUs();
	}

	private void Update()
	{
		UpdateMovement();
	}

	public void UpdateMovement()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		if (TerrainMeta.Path.OceanPatrolFar == null || TerrainMeta.Path.OceanPatrolFar.Count == 0 || targetNodeIndex == -1)
		{
			return;
		}
		Vector3 val = TerrainMeta.Path.OceanPatrolFar[targetNodeIndex];
		float num = 0f;
		Vector3 val2 = val - ((Component)this).transform.position;
		Vector3 normalized = ((Vector3)(ref val2)).normalized;
		float num2 = Vector3.Dot(((Component)this).transform.forward, normalized);
		num = Mathf.InverseLerp(0.5f, 1f, num2);
		float num3 = Vector3.Dot(((Component)this).transform.right, normalized);
		float num4 = 5f;
		float num5 = Mathf.InverseLerp(0.05f, 0.5f, Mathf.Abs(num3));
		turnScale = Mathf.Lerp(turnScale, num5, Time.deltaTime * 0.2f);
		float num6 = ((!(num3 < 0f)) ? 1 : (-1));
		((Component)this).transform.Rotate(Vector3.up, num4 * Time.deltaTime * turnScale * num6, (Space)0);
		currentThrottle = Mathf.Lerp(currentThrottle, num, Time.deltaTime * 0.2f);
		Transform transform = ((Component)this).transform;
		transform.position += ((Component)this).transform.forward * 5f * Time.deltaTime * currentThrottle;
		if (Vector3.Distance(((Component)this).transform.position, val) < 60f)
		{
			targetNodeIndex++;
			if (targetNodeIndex >= TerrainMeta.Path.OceanPatrolFar.Count)
			{
				targetNodeIndex = 0;
			}
		}
	}

	public int GetClosestNodeToUs()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		int result = 0;
		float num = float.PositiveInfinity;
		for (int i = 0; i < TerrainMeta.Path.OceanPatrolFar.Count; i++)
		{
			Vector3 val = TerrainMeta.Path.OceanPatrolFar[i];
			float num2 = Vector3.Distance(((Component)this).transform.position, val);
			if (num2 < num)
			{
				result = i;
				num = num2;
			}
		}
		return result;
	}

	public void OnDrawGizmosSelected()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		if (TerrainMeta.Path.OceanPatrolFar != null)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(TerrainMeta.Path.OceanPatrolFar[targetNodeIndex], 10f);
			for (int i = 0; i < TerrainMeta.Path.OceanPatrolFar.Count; i++)
			{
				Vector3 val = TerrainMeta.Path.OceanPatrolFar[i];
				Gizmos.color = Color.green;
				Gizmos.DrawSphere(val, 3f);
				Vector3 val2 = ((i + 1 == TerrainMeta.Path.OceanPatrolFar.Count) ? TerrainMeta.Path.OceanPatrolFar[0] : TerrainMeta.Path.OceanPatrolFar[i + 1]);
				Gizmos.DrawLine(val, val2);
			}
		}
	}
}
