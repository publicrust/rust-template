using ConVar;
using UnityEngine;

public class BushEntity : BaseEntity, IPrefabPreProcess
{
	public GameObjectRef prefab;

	public bool globalBillboard = true;

	public override void InitShared()
	{
		base.InitShared();
		if (base.isServer)
		{
			DecorComponent[] components = PrefabAttribute.server.FindAll<DecorComponent>(prefabID);
			base.transform.ApplyDecorComponentsScaleOnly(components);
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if (globalBillboard)
		{
			TreeManager.OnTreeSpawned(this);
		}
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		if (globalBillboard)
		{
			TreeManager.OnTreeDestroyed(this);
		}
	}

	public override void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		base.PreProcess(preProcess, rootObj, name, serverside, clientside, bundling);
		if (serverside)
		{
			globalBroadcast = ConVar.Tree.global_broadcast;
		}
	}
}
