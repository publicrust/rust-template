using ConVar;
using UnityEngine;

public class RealmedCollider : BasePrefab
{
	public Collider ServerCollider;

	public Collider ClientCollider;

	public override void PreProcess(IPrefabProcessor process, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		base.PreProcess(process, rootObj, name, serverside, clientside, bundling);
		if (serverside && (Object)(object)ServerCollider != (Object)(object)ClientCollider)
		{
			if (Tree.simplified_collider)
			{
				if (Object.op_Implicit((Object)(object)ClientCollider))
				{
					process.RemoveComponent((Component)(object)ClientCollider);
					ClientCollider = ServerCollider;
				}
			}
			else if (Object.op_Implicit((Object)(object)ServerCollider))
			{
				process.RemoveComponent((Component)(object)ServerCollider);
				ServerCollider = ClientCollider;
			}
		}
		process.RemoveComponent((Component)(object)this);
	}
}
