using System;
using UnityEngine;

[Serializable]
public class ResettableFloat : ISerializationCallbackReceiver
{
	[SerializeField]
	private float defaultValue;

	[NonSerialized]
	private float currentValue;

	public float Value
	{
		get
		{
			return currentValue;
		}
		set
		{
			currentValue = value;
		}
	}

	public ResettableFloat(float value)
	{
		defaultValue = value;
		currentValue = value;
	}

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
		currentValue = defaultValue;
	}

	public void Reset()
	{
		currentValue = defaultValue;
	}
}
