using System;
using ConVar;
using Rust;

public class PrefabWeight : PrefabAttribute
{
	public float Scale = 1f;

	public Era Era;

	protected override Type GetIndexedType()
	{
		return typeof(PrefabWeight);
	}

	public bool IsActiveInEra()
	{
		if (Era != 0)
		{
			return Era == ConVar.Server.Era;
		}
		return true;
	}
}
