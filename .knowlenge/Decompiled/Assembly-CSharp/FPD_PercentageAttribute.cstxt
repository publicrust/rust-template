using UnityEngine;

public class FPD_PercentageAttribute : PropertyAttribute
{
	public enum SuffixMode
	{
		From0to100,
		PercentageUnclamped,
		FromMinToMax,
		FromMinToMaxRounded
	}

	public readonly float Min;

	public readonly float Max;

	public readonly string Suffix;

	public readonly bool from0to100;

	public readonly bool editableValue;

	public readonly bool basic;

	public FPD_PercentageAttribute(float min, float max, bool goOver100Perc = false, bool editable = true, string suffix = "%", bool basicFromTo = false)
	{
		Min = min;
		Max = max;
		from0to100 = !goOver100Perc;
		editableValue = editable;
		Suffix = suffix;
		basic = basicFromTo;
	}
}
