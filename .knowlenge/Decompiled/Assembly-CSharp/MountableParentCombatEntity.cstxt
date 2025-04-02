public class MountableParentCombatEntity : BaseCombatEntity
{
	private BaseMountable mountable;

	private BaseMountable Mountable
	{
		get
		{
			if (mountable == null)
			{
				mountable = GetComponentInParent<BaseMountable>();
			}
			return mountable;
		}
	}
}
