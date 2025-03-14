using UnityEngine;

public class RealmedCollider : BasePrefab
{
	public Collider ServerCollider;

	public Collider ClientCollider;

	public override void PreProcess(IPrefabProcessor process, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		base.PreProcess(process, rootObj, name, serverside, clientside, bundling);
		if (ServerCollider != ClientCollider)
		{
			if (clientside)
			{
				if ((bool)ServerCollider)
				{
					process.RemoveComponent(ServerCollider);
					ServerCollider = null;
				}
			}
			else if ((bool)ClientCollider)
			{
				process.RemoveComponent(ClientCollider);
				ClientCollider = null;
			}
		}
		process.RemoveComponent(this);
	}
}
