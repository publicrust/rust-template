using System;
using UnityEngine;

public abstract class SocketMod : PrefabAttribute
{
	[NonSerialized]
	public Socket_Base baseSocket;

	public Translate.Phrase FailedPhrase;

	public SocketMod_Grouping SocketGrouping { get; private set; }

	protected virtual Translate.Phrase ErrorPhrase => string.Empty;

	protected override void AttributeSetup(GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		SocketGrouping = base.transform.parent?.GetComponent<SocketMod_Grouping>();
		base.AttributeSetup(rootObj, name, serverside, clientside, bundling);
	}

	public virtual Translate.Phrase GetTranslatedErrorMessage()
	{
		if (!string.IsNullOrEmpty(FailedPhrase.token))
		{
			return FailedPhrase;
		}
		return ErrorPhrase;
	}

	public virtual string GetDebugErrorMessage()
	{
		return hierachyName ?? "";
	}

	public virtual bool DoCheck(Construction.Placement place)
	{
		return false;
	}

	public virtual void ModifyPlacement(ref Construction.Placement place)
	{
	}

	protected override Type GetIndexedType()
	{
		return typeof(SocketMod);
	}
}
