using System;
using UnityEngine;

public class SocketHandle : PrefabAttribute
{
	protected override Type GetIndexedType()
	{
		return typeof(SocketHandle);
	}

	internal void AdjustTarget(ref Construction.Target target, float maxplaceDistance)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = worldPosition;
		Vector3 val2 = ((Ray)(ref target.ray)).origin + ((Ray)(ref target.ray)).direction * maxplaceDistance - val;
		ref Ray ray = ref target.ray;
		Vector3 val3 = val2 - ((Ray)(ref target.ray)).origin;
		((Ray)(ref ray)).direction = ((Vector3)(ref val3)).normalized;
	}
}
