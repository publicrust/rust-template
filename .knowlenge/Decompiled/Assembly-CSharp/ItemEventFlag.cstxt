using UnityEngine;
using UnityEngine.Events;

public class ItemEventFlag : MonoBehaviour, IItemUpdate
{
	public Item.Flag flag;

	public UnityEvent onEnabled = new UnityEvent();

	public UnityEvent onDisable = new UnityEvent();

	internal bool firstRun = true;

	internal bool lastState;

	public virtual void OnItemUpdate(Item item)
	{
		bool flag = item.HasFlag(this.flag);
		if (firstRun || flag != lastState)
		{
			if (flag)
			{
				onEnabled.Invoke();
			}
			else
			{
				onDisable.Invoke();
			}
			lastState = flag;
			firstRun = false;
		}
	}
}
