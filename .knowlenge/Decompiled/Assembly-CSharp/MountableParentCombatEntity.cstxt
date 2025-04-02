using UnityEngine;

public class MountableParentCombatEntity : BaseCombatEntity
{
	private BaseMountable mountable;

	private BaseMountable Mountable
	{
		get
		{
			if ((Object)(object)mountable == (Object)null)
			{
				mountable = ((Component)this).GetComponentInParent<BaseMountable>();
			}
			return mountable;
		}
	}
}
