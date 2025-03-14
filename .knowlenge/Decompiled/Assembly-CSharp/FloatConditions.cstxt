using System;

[Serializable]
public class FloatConditions
{
	[Serializable]
	public struct Condition
	{
		public enum Types
		{
			Equal,
			NotEqual,
			Higher,
			Lower
		}

		public Types type;

		public float value;

		public bool Test(float val)
		{
			return type switch
			{
				Types.Equal => val == value, 
				Types.NotEqual => val != value, 
				Types.Higher => val > value, 
				Types.Lower => val < value, 
				_ => false, 
			};
		}
	}

	public Condition[] conditions;

	public bool AllTrue(float val)
	{
		Condition[] array = conditions;
		foreach (Condition condition in array)
		{
			if (!condition.Test(val))
			{
				return false;
			}
		}
		return true;
	}
}
