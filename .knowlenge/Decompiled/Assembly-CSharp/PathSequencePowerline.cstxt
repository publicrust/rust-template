using System.Collections.Generic;
using UnityEngine;

public class PathSequencePowerline : PathSequence
{
	public enum SequenceRule
	{
		PowerlinePlatform,
		Powerline
	}

	public SequenceRule Rule;

	private const int RegularPowerlineSpacing = 2;

	public override void ApplySequenceReplacement(List<Prefab> sequence, ref Prefab replacement, Prefab[] possibleReplacements, int pathLength, int pathIndex, Vector3 position)
	{
		bool flag = false;
		if (Rule == SequenceRule.Powerline)
		{
			if (pathLength >= 3)
			{
				flag = sequence.Count == 0 || pathIndex == pathLength - 1;
				if (!flag)
				{
					flag = GetIndexCountToRule(sequence, SequenceRule.PowerlinePlatform) >= 2;
				}
			}
		}
		else if (Rule == SequenceRule.PowerlinePlatform)
		{
			flag = pathLength < 3;
			if (!flag)
			{
				int indexCountToRule = GetIndexCountToRule(sequence, SequenceRule.PowerlinePlatform);
				flag = indexCountToRule < 2 && indexCountToRule != sequence.Count && pathIndex < pathLength - 1;
			}
		}
		if (flag)
		{
			Prefab prefabOfType = GetPrefabOfType(possibleReplacements, (Rule == SequenceRule.PowerlinePlatform) ? SequenceRule.Powerline : SequenceRule.PowerlinePlatform);
			if (prefabOfType != null)
			{
				replacement = prefabOfType;
			}
		}
	}

	private Prefab GetPrefabOfType(Prefab[] options, SequenceRule ruleToFind)
	{
		for (int i = 0; i < options.Length; i++)
		{
			PathSequencePowerline pathSequencePowerline = options[i].Attribute.Find<PathSequence>(options[i].ID) as PathSequencePowerline;
			if (pathSequencePowerline == null || pathSequencePowerline.Rule == ruleToFind)
			{
				return options[i];
			}
		}
		return null;
	}

	private int GetIndexCountToRule(List<Prefab> sequence, SequenceRule rule)
	{
		int num = 0;
		for (int num2 = sequence.Count - 1; num2 >= 0; num2--)
		{
			PathSequencePowerline pathSequencePowerline = sequence[num2].Attribute.Find<PathSequence>(sequence[num2].ID) as PathSequencePowerline;
			if (pathSequencePowerline != null)
			{
				if (pathSequencePowerline.Rule == rule)
				{
					break;
				}
				num++;
			}
		}
		return num;
	}
}
