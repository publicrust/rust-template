public class KeyBinding : ListComponent<KeyBinding>
{
	public static bool IsOpen
	{
		get
		{
			for (int i = 0; i < ListComponent<KeyBinding>.InstanceList.Count; i++)
			{
				if (ListComponent<KeyBinding>.InstanceList[i].isActiveAndEnabled)
				{
					return true;
				}
			}
			return false;
		}
	}
}
