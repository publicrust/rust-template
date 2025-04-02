using System.Collections.Generic;
using Facepunch;
using Rust.UI;
using UnityEngine;

public class ServerBrowserTag : MonoBehaviour
{
	public string serverTag;

	[Tooltip("Priority will choose what tag will show if multiple in group are defined. Seperate from display order")]
	public int priority;

	public bool excludeOnly;

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
			if ((Object)(object)button != (Object)null)
			{
				return ((RustControl)button).IsPressed;
			}
			return false;
		}
	}

	public bool ContainsTag(HashSet<StringView> tags)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		if (tags.Contains(StringView.op_Implicit(CompactTag)) || tags.Contains(StringView.op_Implicit(serverTag)))
		{
			return true;
		}
		if (CompactTag != serverTag)
		{
			foreach (StringView tag in tags)
			{
				StringView current = tag;
				if (((StringView)(ref current)).Contains(StringView.op_Implicit(CompactTag)))
				{
					return true;
				}
			}
		}
		return excludeOnly;
	}
}
