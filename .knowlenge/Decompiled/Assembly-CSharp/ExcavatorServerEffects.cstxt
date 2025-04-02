using UnityEngine;

public class ExcavatorServerEffects : MonoBehaviour
{
	public static ExcavatorServerEffects instance;

	public TriggerBase[] miningTriggers;

	public void Awake()
	{
		instance = this;
		SetMining(isMining: false, force: true);
	}

	public void OnDestroy()
	{
		instance = null;
	}

	public static void SetMining(bool isMining, bool force = false)
	{
		if ((Object)(object)instance == (Object)null)
		{
			return;
		}
		TriggerBase[] array = instance.miningTriggers;
		foreach (TriggerBase triggerBase in array)
		{
			if (!((Object)(object)triggerBase == (Object)null))
			{
				((Component)triggerBase).gameObject.SetActive(isMining);
			}
		}
	}
}
