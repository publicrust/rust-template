using System;
using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class ServerBrowserTagGroup : MonoBehaviour
{
	[Tooltip("If set then queries will filter out servers matching unselected tags in the group")]
	public bool isExclusive;

	[NonSerialized]
	public ServerBrowserTag[] tags;

	private void Initialize()
	{
		if (tags == null)
		{
			tags = GetComponentsInChildren<ServerBrowserTag>(includeInactive: true);
		}
	}

	public void Awake()
	{
		Initialize();
	}

	public bool AnyActive()
	{
		ServerBrowserTag[] array = tags;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].IsActive)
			{
				return true;
			}
		}
		return false;
	}

	public void Refresh(HashSet<StringView> serverTags, ref int tagsEnabled, int maxTags)
	{
		Initialize();
		bool flag = false;
		ServerBrowserTag[] array = tags;
		foreach (ServerBrowserTag serverBrowserTag in array)
		{
			if ((!isExclusive || !flag) && tagsEnabled <= maxTags && serverBrowserTag.ContainsTag(serverTags))
			{
				serverBrowserTag.SetActive(active: true);
				tagsEnabled++;
				flag = true;
			}
			else
			{
				serverBrowserTag.SetActive(active: false);
			}
		}
		base.gameObject.SetActive(flag);
	}
}
