using System.Collections.Generic;
using Facepunch;
using Rust.UI;
using UnityEngine;

public class ServerBrowserTag : MonoBehaviour
{
	public string serverTag;

	private string _tag;

	public RustButton button;

	public string CompactTag
	{
		get
		{
			if (_tag == null)
			{
				_tag = ServerTagCompressor.ShortenTag(serverTag);
			}
			return _tag;
		}
	}

	public bool IsActive
	{
		get
		{
			if (button != null)
			{
				return button.IsPressed;
			}
			return false;
		}
	}

	public bool ContainsTag(HashSet<StringView> tags)
	{
		if (tags.Contains(CompactTag) || tags.Contains(serverTag))
		{
			return true;
		}
		if (CompactTag != serverTag)
		{
			foreach (StringView tag in tags)
			{
				if (tag.Contains(CompactTag))
				{
					return true;
				}
			}
		}
		return false;
	}
}
