using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class ServerBrowserTagList : MonoBehaviour
{
	public int maxTagsToShow = 3;

	private ServerBrowserTagGroup[] _groups;

	private void Initialize()
	{
		if (_groups == null)
		{
			_groups = GetComponentsInChildren<ServerBrowserTagGroup>(includeInactive: true);
		}
	}

	public void Awake()
	{
		Initialize();
	}

	public bool Refresh(HashSet<StringView> serverTags)
	{
		Initialize();
		int tagsEnabled = 0;
		ServerBrowserTagGroup[] groups = _groups;
		for (int i = 0; i < groups.Length; i++)
		{
			groups[i].Refresh(serverTags, ref tagsEnabled, maxTagsToShow);
		}
		return tagsEnabled > 0;
	}

	public void PremiumButtonClicked()
	{
		SingletonComponent<PremiumModal>.Instance.Open();
	}
}
