using UnityEngine;

public class AIMemoryBank<T>
{
	private MemoryBankType type;

	private T[] slots;

	private float[] slotSetTimestamps;

	private int slotCount;

	public AIMemoryBank(MemoryBankType type, int slots)
	{
		Init(type, slots);
	}

	public void Init(MemoryBankType type, int slots)
	{
		this.type = type;
		slotCount = slots;
		this.slots = new T[slotCount];
		slotSetTimestamps = new float[slotCount];
	}

	public void Set(T item, int index)
	{
		if (index >= 0 && index < slotCount)
		{
			slots[index] = item;
			slotSetTimestamps[index] = Time.realtimeSinceStartup;
		}
	}

	public T Get(int index)
	{
		if (index < 0 || index >= slotCount)
		{
			return default(T);
		}
		return slots[index];
	}

	public float GetTimeSinceSet(int index)
	{
		if (index < 0 || index >= slotCount)
		{
			return 0f;
		}
		return Time.realtimeSinceStartup - slotSetTimestamps[index];
	}

	public void Remove(int index)
	{
		if (index >= 0 && index < slotCount)
		{
			slots[index] = default(T);
		}
	}

	public void Clear()
	{
		for (int i = 0; i < 4; i++)
		{
			Remove(i);
		}
	}
}
