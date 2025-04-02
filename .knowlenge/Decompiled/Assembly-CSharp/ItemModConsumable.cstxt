using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemModConsumable : MonoBehaviour
{
	[Serializable]
	public class ConsumableEffect
	{
		public MetabolismAttribute.Type type;

		public float amount;

		public float time;

		public float onlyIfHealthLessThan = 1f;
	}

	public int amountToConsume = 1;

	public float conditionFractionToLose;

	public string achievementWhenEaten;

	public bool chickenCoopFood;

	public List<ConsumableEffect> effects = new List<ConsumableEffect>();

	public List<ModifierDefintion> modifiers = new List<ModifierDefintion>();

	public float GetIfType(MetabolismAttribute.Type typeToPick)
	{
		for (int i = 0; i < effects.Count; i++)
		{
			if (effects[i].type == typeToPick)
			{
				return effects[i].amount;
			}
		}
		return 0f;
	}
}
