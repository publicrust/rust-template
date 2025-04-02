using System.Collections.Generic;
using Facepunch;
using Oxide.Core;
using UnityEngine;

public class SurveyCharge : TimedExplosive
{
	public GameObjectRef craterPrefab;

	public GameObjectRef craterPrefab_Oil;

	public override void Explode()
	{
		base.Explode();
		if (WaterLevel.Test(base.transform.position, waves: true, volumes: true, this))
		{
			return;
		}
		ResourceDepositManager.ResourceDeposit orCreate = ResourceDepositManager.GetOrCreate(base.transform.position);
		if (orCreate == null || Time.realtimeSinceStartup - orCreate.lastSurveyTime < 10f)
		{
			return;
		}
		orCreate.lastSurveyTime = Time.realtimeSinceStartup;
		if (!TransformUtil.GetGroundInfo(base.transform.position, out var hitOut, 0.3f, 8388608))
		{
			return;
		}
		Vector3 point = hitOut.point;
		_ = hitOut.normal;
		List<SurveyCrater> obj = Pool.Get<List<SurveyCrater>>();
		Vis.Entities(base.transform.position, 10f, obj, 1);
		bool num = obj.Count > 0;
		Pool.FreeUnmanaged(ref obj);
		if (num)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		foreach (ResourceDepositManager.ResourceDeposit.ResourceDepositEntry resource in orCreate._resources)
		{
			if (resource.spawnType == ResourceDepositManager.ResourceDeposit.surveySpawnType.ITEM && !resource.isLiquid && resource.amount >= 1000)
			{
				int num2 = Mathf.Clamp(Mathf.CeilToInt(2.5f / resource.workNeeded * 10f), 0, 5);
				int iAmount = 1;
				flag = true;
				if (resource.isLiquid)
				{
					flag2 = true;
				}
				for (int i = 0; i < num2; i++)
				{
					Item item = ItemManager.Create(resource.type, iAmount, 0uL);
					Interface.CallHook("OnSurveyGather", this, item);
					Vector3 modifiedAimConeDirection = AimConeUtil.GetModifiedAimConeDirection(20f, Vector3.up);
					item.Drop(base.transform.position + Vector3.up * 1f, GetInheritedDropVelocity() + modifiedAimConeDirection * UnityEngine.Random.Range(5f, 10f), UnityEngine.Random.rotation).SetAngularVelocity(UnityEngine.Random.rotation.eulerAngles * 5f);
				}
			}
		}
		if (flag)
		{
			string strPrefab = (flag2 ? craterPrefab_Oil.resourcePath : craterPrefab.resourcePath);
			BaseEntity baseEntity = GameManager.server.CreateEntity(strPrefab, point, Quaternion.identity);
			if ((bool)baseEntity)
			{
				baseEntity.Spawn();
			}
		}
	}
}
