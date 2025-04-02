using System;
using UnityEngine;

public class EntityComponent<T> : EntityComponentBase where T : BaseEntity
{
	[NonSerialized]
	public T _baseEntity;

	public T baseEntity
	{
		get
		{
			if (_baseEntity == null)
			{
				UpdateBaseEntity();
			}
			return _baseEntity;
		}
	}

	protected void UpdateBaseEntity()
	{
		if ((bool)this && (bool)base.gameObject)
		{
			_baseEntity = GameObjectEx.ToBaseEntity(base.gameObject) as T;
		}
	}

	public override BaseEntity GetBaseEntity()
	{
		return baseEntity;
	}

	public T GetCastedEntity()
	{
		return baseEntity;
	}
}
