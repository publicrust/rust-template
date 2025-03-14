using System.Collections.Generic;
using UnityEngine;

public class SocketMod_Grouping : SocketMod
{
	private List<SocketMod> SocketMods;

	protected override void AttributeSetup(GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		SocketMods = new List<SocketMod>();
		foreach (Transform child in TransformEx.GetChildren(base.transform))
		{
			SocketMods.AddRange(child.GetComponents<SocketMod>());
		}
		base.AttributeSetup(rootObj, name, serverside, clientside, bundling);
	}

	public override bool DoCheck(Construction.Placement place)
	{
		if (SocketMods == null || SocketMods.Count == 0)
		{
			return true;
		}
		foreach (SocketMod socketMod in SocketMods)
		{
			if (socketMod.DoCheck(place))
			{
				return true;
			}
		}
		return false;
	}
}
