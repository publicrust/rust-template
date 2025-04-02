using UnityEngine;

public class ZiplineTarget : MonoBehaviour
{
	public Transform Target;

	public bool IsChainPoint;

	public float MonumentConnectionDotMin = 0.2f;

	public float MonumentConnectionDotMax = 1f;

	public bool IsValidPosition(Vector3 position)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = position - Vector3Ex.WithY(Target.position, position.y);
		float num = Vector3.Dot(((Vector3)(ref val)).normalized, Target.forward);
		if (num >= MonumentConnectionDotMin)
		{
			return num <= MonumentConnectionDotMax;
		}
		return false;
	}

	public bool IsValidChainPoint(Vector3 from, Vector3 to)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = from - Vector3Ex.WithY(Target.position, from.y);
		float num = Vector3.Dot(((Vector3)(ref val)).normalized, Target.forward);
		val = to - Vector3Ex.WithY(Target.position, from.y);
		float num2 = Vector3.Dot(((Vector3)(ref val)).normalized, Target.forward);
		if ((num > 0f && num2 > 0f) || (num < 0f && num2 < 0f))
		{
			return false;
		}
		num2 = Mathf.Abs(num2);
		if (num2 >= MonumentConnectionDotMin)
		{
			return num2 <= MonumentConnectionDotMax;
		}
		return false;
	}
}
