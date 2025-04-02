using System.Collections.Generic;
using UnityEngine;

public class MusicClip : ScriptableObject
{
	public AudioClip audioClip;

	public int lengthInBars = 1;

	public int lengthInBarsWithTail;

	public List<float> fadeInPoints = new List<float>();

	public float GetNextFadeInPoint(float currentClipTimeBars)
	{
		if (fadeInPoints.Count == 0)
		{
			return currentClipTimeBars + 0.125f;
		}
		float result = -1f;
		float num = float.PositiveInfinity;
		for (int i = 0; i < fadeInPoints.Count; i++)
		{
			float num2 = fadeInPoints[i];
			float num3 = num2 - currentClipTimeBars;
			if (!(num2 <= 0.01f) && num3 > 0f && num3 < num)
			{
				num = num3;
				result = num2;
			}
		}
		return result;
	}
}
