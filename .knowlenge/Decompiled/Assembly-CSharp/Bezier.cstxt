using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public static class Bezier
{
	public static void ApplyLineSlack(ref Vector3[] positions, float[] slackLevels, int tesselationLevel, Transform referenceTransform = null)
	{
		ApplyLineSlack(positions, slackLevels, ref positions, tesselationLevel, referenceTransform);
	}

	public static void ApplyLineSlack(Vector3[] positions, float[] slackLevels, ref Vector3[] result, int tesselationLevel, Transform referenceTransform = null)
	{
		List<Vector3> result2 = Pool.Get<List<Vector3>>();
		ApplyLineSlack(positions, slackLevels, ref result2, tesselationLevel, referenceTransform);
		if (result.Length >= 2 && result.Length != result2.Count)
		{
			result = new Vector3[result2.Count];
		}
		result2.CopyTo(result);
		Pool.FreeUnmanaged(ref result2);
	}

	public static void ApplyLineSlack(Vector3[] positions, float[] slackLevels, ref List<Vector3> result, int tesselationLevel, Transform referenceTransform = null)
	{
		if (positions.Length < 2 || slackLevels.Length == 0)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < slackLevels.Length; i++)
		{
			if (slackLevels[i] > 0f)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			result.AddRange(positions);
			return;
		}
		bool flag2 = referenceTransform != null;
		float num = 1f / (float)tesselationLevel;
		for (int j = 0; j < positions.Length - 1; j++)
		{
			Vector3 vector = positions[j];
			Vector3 vector2 = positions[j + 1];
			if (referenceTransform != null)
			{
				vector = referenceTransform.TransformPoint(vector);
				vector2 = referenceTransform.TransformPoint(vector2);
			}
			Vector3 vector3 = Vector3.Lerp(vector, vector2, 0.5f);
			if (j < slackLevels.Length)
			{
				vector3 += Vector3.down * slackLevels[j];
			}
			if (flag2)
			{
				result.Add(referenceTransform.InverseTransformPoint(vector));
			}
			else
			{
				result.Add(vector);
			}
			for (int k = 0; k < tesselationLevel; k++)
			{
				float num2 = (float)k * num;
				num2 = num2 * 0.8f + 0.1f;
				Vector3 a = Vector3.Lerp(vector, vector3, num2);
				Vector3 b = Vector3.Lerp(vector3, vector2, num2);
				Vector3 vector4 = Vector3.Lerp(a, b, num2);
				if (flag2)
				{
					result.Add(referenceTransform.InverseTransformPoint(vector4));
				}
				else
				{
					result.Add(vector4);
				}
			}
		}
		Vector3 item = positions[^1];
		result.Add(item);
	}
}
