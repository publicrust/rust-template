using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeybindCategory : MonoBehaviour
{
	private List<KeyBindUI> keybinds = new List<KeyBindUI>();

	private void Awake()
	{
		for (int i = ((Component)this).transform.GetSiblingIndex() + 1; i < ((Component)this).transform.parent.childCount; i++)
		{
			Transform child = ((Component)this).transform.parent.GetChild(i);
			if (!((Object)(object)((Component)child).GetComponent<KeybindCategory>() != (Object)null))
			{
				KeyBindUI component = ((Component)child).GetComponent<KeyBindUI>();
				if (!((Object)(object)component == (Object)null))
				{
					keybinds.Add(component);
				}
				continue;
			}
			break;
		}
	}

	public void UpdateVisibility()
	{
		((Component)this).gameObject.SetActive(keybinds.Any((KeyBindUI x) => ((Behaviour)x).isActiveAndEnabled));
	}
}
