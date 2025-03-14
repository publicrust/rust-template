using System;
using System.Collections.Generic;
using UnityEngine;

public class CinematicEntity : BaseEntity
{
	[Serializable]
	public struct DisableGroup
	{
		public GameObject[] gameObjects;
	}

	private const Flags HideMesh = Flags.Reserved1;

	private const Flags HideMesh2 = Flags.Reserved2;

	private const Flags HideMesh3 = Flags.Reserved3;

	private const Flags HideMesh4 = Flags.Reserved4;

	public List<DisableGroup> DisableObjects;

	private static List<CinematicEntity> serverList = new List<CinematicEntity>();

	public override void ServerInit()
	{
		base.ServerInit();
		if (!serverList.Contains(this))
		{
			serverList.Add(this);
		}
	}

	[ServerVar(Help = "Hides cinematic entities by group (0= none, 1= lights, 2= BGs, 3= props, 4= misc)")]
	public static void HideObjects(ConsoleSystem.Arg args)
	{
		HideObjectShared(args, serverList);
	}

	public override void DestroyShared()
	{
		base.DestroyShared();
		if (base.isServer && serverList.Contains(this))
		{
			serverList.Remove(this);
		}
	}

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		bool state = !HasFlag(Flags.Reserved1) && !HasFlag(Flags.Reserved2) && !HasFlag(Flags.Reserved3) && !HasFlag(Flags.Reserved4);
		ToggleObjects(state);
	}

	private void ToggleObjects(bool state)
	{
		for (int i = 0; i < DisableObjects.Count; i++)
		{
			DisableGroup disableGroup = DisableObjects[i];
			bool active = state;
			if (!state)
			{
				int f = 1 << 7 + i;
				active = !HasFlag((Flags)f);
			}
			GameObject[] gameObjects = disableGroup.gameObjects;
			for (int j = 0; j < gameObjects.Length; j++)
			{
				gameObjects[j].SetActive(active);
			}
		}
	}

	public static void HideObjectShared(ConsoleSystem.Arg args, List<CinematicEntity> entList)
	{
		if (args.GetString(0) == "")
		{
			return;
		}
		List<int> list = new List<int>();
		if (args.GetInt(0) != 0)
		{
			for (int i = 0; i < 4 && !(args.GetString(i) == ""); i++)
			{
				int @int = args.GetInt(i);
				if (@int == 0)
				{
					break;
				}
				list.Add(@int - 1);
			}
		}
		foreach (CinematicEntity ent in entList)
		{
			for (int j = 0; j < 4; j++)
			{
				int f = 1 << 7 + j;
				ent.SetFlag((Flags)f, list.Contains(j));
			}
		}
	}
}
