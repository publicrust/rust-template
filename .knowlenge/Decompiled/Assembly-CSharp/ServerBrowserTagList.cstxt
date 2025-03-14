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

	public bool Refresh(in ServerInfo server)
	{
		Initialize();
		int tagsEnabled = 0;
		ServerBrowserTagGroup[] groups = _groups;
		for (int i = 0; i < groups.Length; i++)
		{
			groups[i].Refresh(in server, ref tagsEnabled, maxTagsToShow);
		}
		return tagsEnabled > 0;
	}
}
