using System;
using System.Collections.Generic;
using UnityEngine;
using VLB;

public static class TagComponentEx
{
	private static Dictionary<GameObjectTag, string> strings;

	static TagComponentEx()
	{
		strings = new Dictionary<GameObjectTag, string>();
		foreach (object value in Enum.GetValues(typeof(GameObjectTag)))
		{
			strings[(GameObjectTag)value] = value.ToString();
		}
	}

	public static bool HasCustomTag(this GameObject gameObject, GameObjectTag tag)
	{
		string text = strings[tag];
		if (gameObject.CompareTag(text))
		{
			return true;
		}
		TagComponent component = gameObject.GetComponent<TagComponent>();
		if ((Object)(object)component == (Object)null)
		{
			return false;
		}
		return component.HasTag(tag);
	}

	public static bool SetCustomTag(this GameObject gameObject, GameObjectTag tag, bool apply)
	{
		string text = strings[tag];
		if (apply)
		{
			if (gameObject.tag == text)
			{
				return false;
			}
			if (gameObject.CompareTag("Untagged"))
			{
				gameObject.tag = text;
				return true;
			}
			TagComponent orAddComponent = gameObject.GetOrAddComponent<TagComponent>();
			if (orAddComponent.HasTag(tag))
			{
				return false;
			}
			orAddComponent.AddTag(tag);
			return true;
		}
		if (gameObject.tag == text)
		{
			gameObject.CompareTag("Untagged");
			return true;
		}
		TagComponent component = gameObject.GetComponent<TagComponent>();
		if ((Object)(object)component == (Object)null)
		{
			return false;
		}
		if (!component.HasTag(tag))
		{
			return false;
		}
		component.RemoveTag(tag);
		return true;
	}
}
