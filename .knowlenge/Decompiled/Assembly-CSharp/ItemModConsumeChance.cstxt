using UnityEngine;

public class ItemModConsumeChance : ItemModConsume
{
	public float chanceForSecondaryConsume = 0.5f;

	public GameObjectRef secondaryConsumeEffect;

	public ItemModConsumable secondaryConsumable;

	private bool GetChance()
	{
		Random.State state = Random.state;
		Random.InitState(Time.frameCount);
		bool result = Random.Range(0f, 1f) <= chanceForSecondaryConsume;
		Random.state = state;
		return result;
	}

	public override ItemModConsumable GetConsumable()
	{
		if (GetChance())
		{
			return secondaryConsumable;
		}
		return base.GetConsumable();
	}

	public override GameObjectRef GetConsumeEffect()
	{
		if (GetChance())
		{
			return secondaryConsumeEffect;
		}
		return base.GetConsumeEffect();
	}
}
