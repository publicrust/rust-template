using System;

public class SocketMod : PrefabAttribute
{
	[NonSerialized]
	public Socket_Base baseSocket;

	public Translate.Phrase FailedPhrase;

	public virtual bool DoCheck(Construction.Placement place)
	{
		return false;
	}

	public virtual void ModifyPlacement(Construction.Placement place)
	{
	}

	protected override Type GetIndexedType()
	{
		return typeof(SocketMod);
	}
}
