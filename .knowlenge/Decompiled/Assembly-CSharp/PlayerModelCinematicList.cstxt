using System;
using UnityEngine;

public class PlayerModelCinematicList : PrefabAttribute, IClientComponent
{
	[Serializable]
	public struct PlayerModelCinematicAnimation
	{
		public string StateName;

		public string ClipName;

		public float Length;
	}

	public PlayerModelCinematicAnimation[] Animations;

	protected override Type GetIndexedType()
	{
		return typeof(PlayerModelCinematicList);
	}

	public override void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		base.PreProcess(preProcess, rootObj, name, serverside, clientside, bundling);
	}
}
