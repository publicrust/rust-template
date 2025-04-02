using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class BaseResourceExtractor : BaseCombatEntity
{
	public bool canExtractLiquid;

	public bool canExtractSolid = true;

	public override void ServerInit()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		base.ServerInit();
		if (base.isClient)
		{
			return;
		}
		List<SurveyCrater> list = Pool.Get<List<SurveyCrater>>();
		Vis.Entities(((Component)this).transform.position, 3f, list, 1, (QueryTriggerInteraction)2);
		foreach (SurveyCrater item in list)
		{
			if (item.isServer)
			{
				item.Kill();
			}
		}
		Pool.FreeUnmanaged<SurveyCrater>(ref list);
	}
}
