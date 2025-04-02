using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeybindCategory : MonoBehaviour
{
	private List<KeyBindUI> keybinds = new List<KeyBindUI>();

	private void Awake()
	{
		for (int i = base.transform.GetSiblingIndex() + 1; i < base.transform.parent.childCount; i++)
		{
			Transform child = base.transform.parent.GetChild(i);
			if (!(child.GetComponent<KeybindCategory>() != null))
			{
				KeyBindUI component = child.GetComponent<KeyBindUI>();
				if (!(component == null))
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
		base.gameObject.SetActive(keybinds.Any((KeyBindUI x) => x.isActiveAndEnabled));
	}
}
