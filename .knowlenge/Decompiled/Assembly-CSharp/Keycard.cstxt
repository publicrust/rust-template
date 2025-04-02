using UnityEngine;

public class Keycard : AttackEntity
{
	public int accessLevel
	{
		get
		{
			Item item = GetItem();
			if (item == null)
			{
				return 0;
			}
			ItemModKeycard component = ((Component)item.info).GetComponent<ItemModKeycard>();
			if ((Object)(object)component == (Object)null)
			{
				return 0;
			}
			return component.accessLevel;
		}
	}
}
