using UnityEngine;

public class UIBuffs : SingletonComponent<UIBuffs>
{
	public bool Enabled = true;

	public Transform PrefabBuffIcon;

	public void Refresh(PlayerModifiers modifiers)
	{
		if (!Enabled)
		{
			return;
		}
		RemoveAll();
		if ((Object)(object)modifiers == (Object)null)
		{
			return;
		}
		foreach (Modifier item in modifiers.All)
		{
			if (item != null)
			{
				Object.Instantiate<Transform>(PrefabBuffIcon).SetParent(((Component)this).transform);
			}
		}
	}

	private void RemoveAll()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		foreach (Transform item in ((Component)this).transform)
		{
			Object.Destroy((Object)(object)((Component)item).gameObject);
		}
	}
}
