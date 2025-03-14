using System.Collections.Generic;
using UnityEngine;

public class BaseHuntEvent : BaseEntity
{
	public GameObjectRef[] HuntablePrefab;

	protected List<string> HuntableResourcePathCached;

	public AudioSource huntStartSound;

	public override void ServerInit()
	{
		base.ServerInit();
		HuntableResourcePathCached = new List<string>();
		for (int i = 0; i < HuntablePrefab.Length; i++)
		{
			HuntableResourcePathCached.Add(HuntablePrefab[i].resourcePath);
		}
	}
}
