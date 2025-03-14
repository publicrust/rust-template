using ConVar;
using UnityEngine;

public class RealmedCollider : BasePrefab
{
	public Collider ServerCollider;

	public Collider ClientCollider;

	public override void PreProcess(IPrefabProcessor process, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		base.PreProcess(process, rootObj, name, serverside, clientside, bundling);
		if (serverside && ServerCollider != ClientCollider)
		{
			if (ConVar.Tree.simplified_collider)
			{
				if ((bool)ClientCollider)
				{
					process.RemoveComponent(ClientCollider);
					ClientCollider = ServerCollider;
				}
			}
			else if ((bool)ServerCollider)
			{
				process.RemoveComponent(ServerCollider);
				ServerCollider = ClientCollider;
			}
		}
		process.RemoveComponent(this);
	}
}
