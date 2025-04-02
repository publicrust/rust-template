public class DummySwitch : IOEntity
{
	public string listenString = "";

	public string listenStringOff = "";

	public float duration = -1f;

	public override bool WantsPower(int inputIndex)
	{
		return IsOn();
	}

	public override void ResetIOState()
	{
		SetFlag(Flags.On, b: false);
	}

	public override int GetPassthroughAmount(int outputSlot = 0)
	{
		if (!IsOn())
		{
			return 0;
		}
		return GetCurrentEnergy();
	}

	public void SetOn(bool wantsOn)
	{
		SetFlag(Flags.On, wantsOn);
		MarkDirty();
		if (IsOn() && duration != -1f)
		{
			Invoke(SetOff, duration);
		}
	}

	public void SetOff()
	{
		SetOn(wantsOn: false);
	}

	public override void OnEntityMessage(BaseEntity from, string msg)
	{
		if (msg == listenString)
		{
			if (IsOn())
			{
				SetOn(wantsOn: false);
			}
			SetOn(wantsOn: true);
		}
		else if (msg == listenStringOff && listenStringOff != "" && IsOn())
		{
			SetOn(wantsOn: false);
		}
	}
}
