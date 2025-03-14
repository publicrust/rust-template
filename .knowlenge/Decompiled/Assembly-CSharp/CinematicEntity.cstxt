using System.Collections.Generic;
using UnityEngine;

public class CinematicEntity : BaseEntity
{
	private const Flags HideMesh = Flags.Reserved1;

	public GameObject[] DisableObjects;

	private static bool _hideObjects = false;

	private static List<CinematicEntity> serverList = new List<CinematicEntity>();

	[ServerVar(Help = "Hides cinematic light source meshes (keeps lights visible)")]
	public static bool HideObjects
	{
		get
		{
			return _hideObjects;
		}
		set
		{
			if (value == _hideObjects)
			{
				return;
			}
			_hideObjects = value;
			foreach (CinematicEntity server in serverList)
			{
				server.SetFlag(Flags.Reserved1, _hideObjects);
			}
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if (!serverList.Contains(this))
		{
			serverList.Add(this);
		}
		SetFlag(Flags.Reserved1, HideObjects);
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
		bool state = !HasFlag(Flags.Reserved1);
		ToggleObjects(state);
	}

	private void ToggleObjects(bool state)
	{
		GameObject[] disableObjects = DisableObjects;
		foreach (GameObject gameObject in disableObjects)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(state);
			}
		}
	}
}
