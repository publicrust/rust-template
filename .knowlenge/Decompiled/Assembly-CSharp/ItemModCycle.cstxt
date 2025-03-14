using UnityEngine;

public class ItemModCycle : ItemMod
{
	public ItemMod[] actions;

	public float timeBetweenCycles = 1f;

	public float timerStart;

	public bool onlyAdvanceTimerWhenPass;

	public override void OnItemCreated(Item itemcreated)
	{
		float timeTaken = timerStart;
		itemcreated.onCycle += delegate(Item item, float delta)
		{
			if (!onlyAdvanceTimerWhenPass || CanCycle(item))
			{
				timeTaken += delta;
				if (!(timeTaken < timeBetweenCycles))
				{
					timeTaken = 0f;
					if (onlyAdvanceTimerWhenPass || CanCycle(item))
					{
						CustomCycle(item, delta);
					}
				}
			}
		};
	}

	private bool CanCycle(Item item)
	{
		ItemMod[] array = actions;
		for (int i = 0; i < array.Length; i++)
		{
			if (!array[i].CanDoAction(item, item.GetOwnerPlayer()))
			{
				return false;
			}
		}
		return true;
	}

	public void CustomCycle(Item item, float delta)
	{
		BasePlayer ownerPlayer = item.GetOwnerPlayer();
		ItemMod[] array = actions;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].DoAction(item, ownerPlayer);
		}
	}

	private void OnValidate()
	{
		if (actions == null)
		{
			Debug.LogWarning("ItemModMenuOption: actions is null", base.gameObject);
		}
	}
}
