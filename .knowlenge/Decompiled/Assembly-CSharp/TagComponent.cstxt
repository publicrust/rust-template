using UnityEngine;

public class TagComponent : MonoBehaviour
{
	public GameObjectTag Tag;

	public bool HasTag(GameObjectTag tag)
	{
		return (Tag & tag) == tag;
	}

	public void AddTag(GameObjectTag tag)
	{
		Tag |= tag;
	}

	public void RemoveTag(GameObjectTag tag)
	{
		Tag &= ~tag;
	}

	public void SetTag(GameObjectTag tag, bool state)
	{
		if (state)
		{
			AddTag(tag);
		}
		else
		{
			RemoveTag(tag);
		}
	}
}
