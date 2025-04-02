using UnityEngine;

[CreateAssetMenu(fileName = "NewEntityList", menuName = "Rust/EntityList")]
public class EntityListScriptableObject : ScriptableObject
{
	[SerializeField]
	public BaseEntity[] entities;

	public bool blockIfAny;

	public bool IsInList(uint prefabId)
	{
		if (entities == null)
		{
			return false;
		}
		BaseEntity[] array = entities;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].prefabID == prefabId)
			{
				return true;
			}
		}
		return false;
	}
}
