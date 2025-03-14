using System;
using System.Collections.Generic;
using System.Linq;
using ConVar;
using Facepunch;
using Oxide.Core;
using Rust;
using UnityEngine;

public class TriggerBase : BaseMonoBehaviour
{
	public LayerMask interestLayers;

	[NonSerialized]
	public HashSet<GameObject> contents;

	[NonSerialized]
	public HashSet<BaseEntity> entityContents;

	public bool HasAnyContents => !CollectionEx.IsNullOrEmpty(contents);

	public bool HasAnyEntityContents => !CollectionEx.IsNullOrEmpty(entityContents);

	public virtual GameObject InterestedInObject(GameObject obj)
	{
		int num = 1 << obj.layer;
		if ((interestLayers.value & num) != num)
		{
			return null;
		}
		return obj;
	}

	protected virtual void OnDisable()
	{
		if (!Rust.Application.isQuitting && contents != null)
		{
			GameObject[] array = contents.ToArray();
			foreach (GameObject targetObj in array)
			{
				OnTriggerExit(targetObj);
			}
			contents = null;
		}
	}

	public virtual void OnEntityEnter(BaseEntity ent)
	{
		if (!(ent == null))
		{
			if (entityContents == null)
			{
				entityContents = new HashSet<BaseEntity>();
			}
			if (Interface.CallHook("OnEntityEnter", this, ent) == null)
			{
				entityContents.Add(ent);
			}
		}
	}

	public virtual void OnEntityLeave(BaseEntity ent)
	{
		if (entityContents != null && Interface.CallHook("OnEntityLeave", this, ent) == null)
		{
			entityContents.Remove(ent);
		}
	}

	public virtual void OnObjectAdded(GameObject obj, Collider col)
	{
		if (!(obj == null))
		{
			BaseEntity baseEntity = GameObjectEx.ToBaseEntity(obj);
			if ((bool)baseEntity)
			{
				baseEntity.EnterTrigger(this);
				OnEntityEnter(baseEntity);
			}
		}
	}

	public virtual void OnObjectRemoved(GameObject obj)
	{
		if (obj == null)
		{
			return;
		}
		BaseEntity baseEntity = GameObjectEx.ToBaseEntity(obj);
		if (!baseEntity)
		{
			return;
		}
		bool flag = false;
		foreach (GameObject content in contents)
		{
			if (content == null)
			{
				Debug.LogWarning("Trigger " + ToString() + " contains null object.");
			}
			else if (GameObjectEx.ToBaseEntity(content) == baseEntity)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			baseEntity.LeaveTrigger(this);
			OnEntityLeave(baseEntity);
		}
	}

	public void RemoveInvalidEntities()
	{
		if (CollectionEx.IsNullOrEmpty(entityContents))
		{
			return;
		}
		Collider component = GetComponent<Collider>();
		if (component == null)
		{
			return;
		}
		Bounds bounds = component.bounds;
		bounds.Expand(1f);
		List<BaseEntity> obj = null;
		foreach (BaseEntity entityContent in entityContents)
		{
			if (entityContent == null)
			{
				if (Debugging.checktriggers)
				{
					Debug.LogWarning("Trigger " + ToString() + " contains destroyed entity.");
				}
				if (obj == null)
				{
					obj = Facepunch.Pool.GetList<BaseEntity>();
				}
				obj.Add(entityContent);
			}
			else if (!bounds.Contains(entityContent.ClosestPoint(base.transform.position)))
			{
				if (Debugging.checktriggers)
				{
					Debug.LogWarning("Trigger " + ToString() + " contains entity that is too far away: " + entityContent.ToString());
				}
				if (obj == null)
				{
					obj = Facepunch.Pool.GetList<BaseEntity>();
				}
				obj.Add(entityContent);
			}
		}
		if (obj == null)
		{
			return;
		}
		foreach (BaseEntity item in obj)
		{
			RemoveEntity(item);
		}
		Facepunch.Pool.FreeList(ref obj);
	}

	public bool CheckEntity(BaseEntity ent)
	{
		if (ent == null)
		{
			return true;
		}
		Collider component = GetComponent<Collider>();
		if (component == null)
		{
			return true;
		}
		Bounds bounds = component.bounds;
		bounds.Expand(1f);
		return bounds.Contains(ent.ClosestPoint(base.transform.position));
	}

	public virtual void OnObjects()
	{
	}

	public virtual void OnEmpty()
	{
		contents = null;
		entityContents = null;
	}

	public void RemoveObject(GameObject obj)
	{
		if (!(obj == null))
		{
			Collider component = obj.GetComponent<Collider>();
			if (!(component == null))
			{
				OnTriggerExit(component);
			}
		}
	}

	public void RemoveEntity(BaseEntity ent)
	{
		if (this == null || contents == null || ent == null)
		{
			return;
		}
		List<GameObject> obj = Facepunch.Pool.GetList<GameObject>();
		foreach (GameObject content in contents)
		{
			if (content != null && content.GetComponentInParent<BaseEntity>() == ent)
			{
				obj.Add(content);
			}
		}
		foreach (GameObject item in obj)
		{
			OnTriggerExit(item);
		}
		Facepunch.Pool.FreeList(ref obj);
	}

	public void OnTriggerEnter(Collider collider)
	{
		if (this == null || !base.enabled)
		{
			return;
		}
		using (TimeWarning.New("TriggerBase.OnTriggerEnter"))
		{
			GameObject gameObject = InterestedInObject(collider.gameObject);
			if (gameObject == null)
			{
				return;
			}
			if (contents == null)
			{
				contents = new HashSet<GameObject>();
			}
			if (contents.Contains(gameObject))
			{
				return;
			}
			int count = contents.Count;
			contents.Add(gameObject);
			OnObjectAdded(gameObject, collider);
			if (count == 0 && contents.Count == 1)
			{
				OnObjects();
			}
		}
		if (Debugging.checktriggers)
		{
			RemoveInvalidEntities();
		}
	}

	internal virtual bool SkipOnTriggerExit(Collider collider)
	{
		return false;
	}

	public void OnTriggerExit(Collider collider)
	{
		if (this == null || collider == null || SkipOnTriggerExit(collider))
		{
			return;
		}
		GameObject gameObject = InterestedInObject(collider.gameObject);
		if (!(gameObject == null))
		{
			OnTriggerExit(gameObject);
			if (Debugging.checktriggers)
			{
				RemoveInvalidEntities();
			}
		}
	}

	public void OnTriggerExit(GameObject targetObj)
	{
		if (contents != null && contents.Contains(targetObj))
		{
			contents.Remove(targetObj);
			OnObjectRemoved(targetObj);
			if (contents == null || contents.Count == 0)
			{
				OnEmpty();
			}
		}
	}
}
