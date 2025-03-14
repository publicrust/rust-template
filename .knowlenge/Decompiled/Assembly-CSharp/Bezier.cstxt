using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public static class Bezier
{
	public static void ApplyLineSlack(ref Vector3[] positions, float[] slackLevels, int tesselationLevel)
	{
		ApplyLineSlack(positions, slackLevels, ref positions, tesselationLevel);
	}

	public static void ApplyLineSlack(Vector3[] positions, float[] slackLevels, ref Vector3[] result, int tesselationLevel)
	{
		List<Vector3> result2 = Pool.GetList<Vector3>();
		ApplyLineSlack(positions, slackLevels, ref result2, tesselationLevel);
		if (result.Length != result2.Count)
		{
			result = new Vector3[result2.Count];
		}
		result2.CopyTo(result);
		Pool.FreeList(ref result2);
	}

	public static void ApplyLineSlack(Vector3[] positions, float[] slackLevels, ref List<Vector3> result, int tesselationLevel)
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
		for (int j = 0; j < positions.Length; j++)
		{
			if (j < positions.Length - 1)
			{
				Vector3 vector = positions[j];
				Vector3 b = positions[j + 1];
				Vector3 vector2 = Vector3.Lerp(vector, b, 0.5f);
				if (j < slackLevels.Length)
				{
					vector2.y -= slackLevels[j];
				}
				result.Add(vector);
				for (int k = 0; k < tesselationLevel; k++)
				{
					float val = (float)k / (float)tesselationLevel;
					val = Mathx.RemapValClamped(val, 0f, 1f, 0.1f, 0.9f);
					Vector3 item = Vector3.Lerp(Vector3.Lerp(vector, vector2, val), Vector3.Lerp(vector2, b, val), val);
					result.Add(item);
				}
			}
			else
			{
				result.Add(positions[j]);
			}
		}
	}
}
