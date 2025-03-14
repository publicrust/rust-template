public class EntityFlag_TOD : EntityComponent<BaseEntity>
{
	public BaseEntity.Flags desiredFlag;

	public bool onAtNight = true;

	public void Start()
	{
		Invoke(Initialize, 1f);
	}

	public void Initialize()
	{
		if (!(base.baseEntity == null) && !base.baseEntity.isClient)
		{
			InvokeRandomized(DoTimeCheck, 0f, 5f, 1f);
		}
	}

	public bool WantsOn()
	{
		if (TOD_Sky.Instance == null)
		{
			return false;
		}
		bool isNight = TOD_Sky.Instance.IsNight;
		if (onAtNight == isNight)
		{
			return true;
		}
		return false;
	}

	private void DoTimeCheck()
	{
		bool num = base.baseEntity.HasFlag(desiredFlag);
		bool flag = WantsOn();
		if (num != flag)
		{
			base.baseEntity.SetFlag(desiredFlag, flag);
		}
	}
}
