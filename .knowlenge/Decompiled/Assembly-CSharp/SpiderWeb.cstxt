using UnityEngine;

public class SpiderWeb : BaseCombatEntity
{
	public bool Fresh()
	{
		if (!HasFlag(Flags.Reserved1) && !HasFlag(Flags.Reserved2) && !HasFlag(Flags.Reserved3))
		{
			return !HasFlag(Flags.Reserved4);
		}
		return false;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if (Fresh())
		{
			int num = Random.Range(0, 4);
			Flags f = Flags.Reserved1;
			switch (num)
			{
			case 0:
				f = Flags.Reserved1;
				break;
			case 1:
				f = Flags.Reserved2;
				break;
			case 2:
				f = Flags.Reserved3;
				break;
			case 3:
				f = Flags.Reserved4;
				break;
			}
			SetFlag(f, b: true);
		}
	}
}
