using System;
using UnityEngine;

public class ColliderInfo : MonoBehaviour
{
	[Flags]
	public enum Flags
	{
		Usable = 1,
		Shootable = 2,
		Melee = 4,
		Opaque = 8,
		Airflow = 0x10,
		OnlyBlockBuildingBlock = 0x20,
		Monument = 0x40,
		Tunnels = 0x80,
		AllowBuildInsideMesh = 0x100
	}

	public const Flags FlagsNone = (Flags)0;

	public const Flags FlagsEverything = (Flags)(-1);

	public const Flags FlagsDefault = Flags.Usable | Flags.Shootable | Flags.Melee | Flags.Opaque;

	[InspectorFlags]
	public Flags flags = Flags.Usable | Flags.Shootable | Flags.Melee | Flags.Opaque;

	public bool HasFlag(Flags f)
	{
		return (flags & f) == f;
	}

	public void SetFlag(Flags f, bool b)
	{
		if (b)
		{
			flags |= f;
		}
		else
		{
			flags &= ~f;
		}
	}

	public bool Filter(HitTest info)
	{
		switch (info.type)
		{
		case HitTest.Type.MeleeAttack:
			if ((flags & Flags.Melee) == 0)
			{
				return false;
			}
			break;
		case HitTest.Type.ProjectileEffect:
		case HitTest.Type.Projectile:
			if ((flags & Flags.Shootable) == 0)
			{
				return false;
			}
			break;
		case HitTest.Type.Use:
			if ((flags & Flags.Usable) == 0)
			{
				return false;
			}
			break;
		}
		return true;
	}
}
