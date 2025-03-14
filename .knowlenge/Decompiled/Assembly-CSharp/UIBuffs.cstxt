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
		if (modifiers == null)
		{
			return;
		}
		foreach (Modifier item in modifiers.All)
		{
			if (item != null)
			{
				Object.Instantiate(PrefabBuffIcon).SetParent(base.transform);
			}
		}
	}

	private void RemoveAll()
	{
		foreach (Transform item in base.transform)
		{
			Object.Destroy(item.gameObject);
		}
	}
}
