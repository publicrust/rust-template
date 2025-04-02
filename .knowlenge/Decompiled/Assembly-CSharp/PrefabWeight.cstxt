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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Era != 0)
		{
			return Era == ConVar.Server.Era;
		}
		return true;
	}
}
