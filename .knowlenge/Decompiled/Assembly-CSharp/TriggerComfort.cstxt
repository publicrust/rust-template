using System.Collections.Generic;
using Oxide.Core;
using UnityEngine;

public class TriggerComfort : TriggerBase
{
	public float triggerSize;

	public float baseComfort = 0.5f;

	public float minComfortRange = 2.5f;

	private const float perPlayerComfortBonus = 0.25f;

	private const float bonusComfort = 0f;

	private List<BasePlayer> _players = new List<BasePlayer>();

	private void OnValidate()
	{
		triggerSize = GetComponent<SphereCollider>().radius * base.transform.localScale.y;
	}

	public override GameObject InterestedInObject(GameObject obj)
	{
		obj = base.InterestedInObject(obj);
		if (obj == null)
		{
			return null;
		}
		BaseEntity baseEntity = GameObjectEx.ToBaseEntity(obj);
		if (baseEntity == null)
		{
			return null;
		}
		if (baseEntity.isClient)
		{
			return null;
		}
		return baseEntity.gameObject;
	}

	public float CalculateComfort(Vector3 position, BasePlayer forPlayer = null)
	{
		float num = Vector3.Distance(base.gameObject.transform.position, position);
		float num2 = 1f - Mathf.Clamp(num - minComfortRange, 0f, num / (triggerSize - minComfortRange));
		float num3 = 0f;
		foreach (BasePlayer player in _players)
		{
			if (!(player == forPlayer))
			{
				num3 += 0.25f * (player.IsSleeping() ? 0.5f : 1f) * (player.IsAlive() ? 1f : 0f);
			}
		}
		float num4 = 0f + num3;
		return (baseComfort + num4) * num2;
	}

	public override void OnEntityEnter(BaseEntity ent)
	{
		BasePlayer basePlayer = ent as BasePlayer;
		if ((bool)basePlayer && Interface.CallHook("OnEntityEnter", this, ent) == null)
		{
			_players.Add(basePlayer);
		}
	}

	public override void OnEntityLeave(BaseEntity ent)
	{
		BasePlayer basePlayer = ent as BasePlayer;
		if ((bool)basePlayer && Interface.CallHook("OnEntityLeave", this, ent) == null)
		{
			_players.Remove(basePlayer);
		}
	}
}
