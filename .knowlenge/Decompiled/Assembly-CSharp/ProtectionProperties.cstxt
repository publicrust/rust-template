using System.Collections.Generic;
using Rust;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Protection Properties")]
public class ProtectionProperties : ScriptableObject
{
	[TextArea]
	public string comments;

	[Range(0f, 100f)]
	public float density = 1f;

	[ArrayIndexIsEnumRanged(enumType = typeof(DamageType), min = -4f, max = 3f)]
	public float[] amounts = new float[26];

	public void OnValidate()
	{
		if (amounts.Length >= 26)
		{
			return;
		}
		float[] array = new float[26];
		for (int i = 0; i < array.Length; i++)
		{
			if (i >= amounts.Length)
			{
				if (i == 21)
				{
					array[i] = amounts[9];
				}
			}
			else
			{
				array[i] = amounts[i];
			}
		}
		amounts = array;
	}

	public void Clear()
	{
		for (int i = 0; i < amounts.Length; i++)
		{
			amounts[i] = 0f;
		}
	}

	public void Add(float amount)
	{
		for (int i = 0; i < amounts.Length; i++)
		{
			amounts[i] += amount;
		}
	}

	public void Add(DamageType index, float amount)
	{
		amounts[(int)index] += amount;
	}

	public void Add(ProtectionProperties other, float scale)
	{
		for (int i = 0; i < Mathf.Min(other.amounts.Length, amounts.Length); i++)
		{
			amounts[i] += other.amounts[i] * scale;
		}
	}

	public void Add(List<Item> items, HitArea area = (HitArea)(-1))
	{
		for (int i = 0; i < items.Count; i++)
		{
			Item item = items[i];
			ItemModWearable component = item.info.GetComponent<ItemModWearable>();
			if (!(component == null) && component.ProtectsArea(area))
			{
				component.CollectProtection(item, this);
			}
		}
	}

	public void Multiply(float multiplier)
	{
		for (int i = 0; i < amounts.Length; i++)
		{
			amounts[i] *= multiplier;
		}
	}

	public void Multiply(DamageType index, float multiplier)
	{
		amounts[(int)index] *= multiplier;
	}

	public void Scale(DamageTypeList damageList, float ProtectionAmount = 1f)
	{
		for (int i = 0; i < amounts.Length; i++)
		{
			if (amounts[i] != 0f)
			{
				damageList.Scale((DamageType)i, 1f - Mathf.Clamp(amounts[i] * ProtectionAmount, -1f, 1f));
			}
		}
	}

	public float Get(DamageType damageType)
	{
		return amounts[(int)damageType];
	}
}
