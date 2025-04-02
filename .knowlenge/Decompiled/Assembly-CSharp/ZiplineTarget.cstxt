using UnityEngine;

public class ZiplineTarget : MonoBehaviour
{
	public Transform Target;

	public bool IsChainPoint;

	public float MonumentConnectionDotMin = 0.2f;

	public float MonumentConnectionDotMax = 1f;

	public bool IsValidPosition(Vector3 position)
	{
		float num = Vector3.Dot((position - Target.position.WithY(position.y)).normalized, Target.forward);
		if (num >= MonumentConnectionDotMin)
		{
			return num <= MonumentConnectionDotMax;
		}
		return false;
	}

	public bool IsValidChainPoint(Vector3 from, Vector3 to)
	{
		float num = Vector3.Dot((from - Target.position.WithY(from.y)).normalized, Target.forward);
		float num2 = Vector3.Dot((to - Target.position.WithY(from.y)).normalized, Target.forward);
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
