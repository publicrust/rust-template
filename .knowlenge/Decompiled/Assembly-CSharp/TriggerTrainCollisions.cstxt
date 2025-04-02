using System;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrainCollisions : TriggerBase
{
	public enum Location
	{
		Front,
		Rear
	}

	public Collider triggerCollider;

	public Location location;

	public TrainCar owner;

	[NonSerialized]
	public HashSet<GameObject> staticContents = new HashSet<GameObject>();

	[NonSerialized]
	public HashSet<TrainCar> trainContents = new HashSet<TrainCar>();

	[NonSerialized]
	public HashSet<Rigidbody> otherRigidbodyContents = new HashSet<Rigidbody>();

	[NonSerialized]
	public HashSet<Collider> colliderContents = new HashSet<Collider>();

	private const float TICK_RATE = 0.2f;

	public bool HasAnyStaticContents => staticContents.Count > 0;

	public bool HasAnyTrainContents => trainContents.Count > 0;

	public bool HasAnyOtherRigidbodyContents => otherRigidbodyContents.Count > 0;

	public bool HasAnyNonStaticContents
	{
		get
		{
			if (!HasAnyTrainContents)
			{
				return HasAnyOtherRigidbodyContents;
			}
			return true;
		}
	}

	internal override void OnObjectAdded(GameObject obj, Collider col)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		if (!owner.isServer)
		{
			return;
		}
		base.OnObjectAdded(obj, col);
		if ((Object)(object)obj != (Object)null)
		{
			BaseEntity baseEntity = obj.ToBaseEntity();
			if ((Object)(object)baseEntity != (Object)null)
			{
				Vector3 val = ((Component)baseEntity).transform.position + ((Component)baseEntity).transform.rotation * Vector3.Scale(obj.transform.lossyScale, ((Bounds)(ref baseEntity.bounds)).center);
				Bounds bounds = triggerCollider.bounds;
				Vector3 center = ((Bounds)(ref bounds)).center;
				Vector3 val2 = val - center;
				bool flag = Vector3.Dot(((Component)owner).transform.forward, val2) > 0f;
				if ((location == Location.Front && !flag) || (location == Location.Rear && flag))
				{
					return;
				}
			}
		}
		if ((Object)(object)obj != (Object)null)
		{
			Rigidbody componentInParent = obj.GetComponentInParent<Rigidbody>();
			if ((Object)(object)componentInParent != (Object)null)
			{
				TrainCar componentInParent2 = obj.GetComponentInParent<TrainCar>();
				if ((Object)(object)componentInParent2 != (Object)null)
				{
					trainContents.Add(componentInParent2);
					if (owner.coupling != null)
					{
						owner.coupling.TryCouple(componentInParent2, location);
					}
					((FacepunchBehaviour)this).InvokeRepeating((Action)TrainContentsTick, 0.2f, 0.2f);
				}
				else
				{
					otherRigidbodyContents.Add(componentInParent);
				}
			}
			else
			{
				ITrainCollidable componentInParent3 = obj.GetComponentInParent<ITrainCollidable>();
				if (componentInParent3 == null)
				{
					if (!obj.CompareTag("Railway"))
					{
						staticContents.Add(obj);
					}
				}
				else if (!componentInParent3.EqualNetID(owner) && !componentInParent3.CustomCollision(owner, this))
				{
					staticContents.Add(obj);
				}
			}
		}
		if ((Object)(object)col != (Object)null)
		{
			colliderContents.Add(col);
		}
	}

	internal override void OnObjectRemoved(GameObject obj)
	{
		if (!owner.isServer || (Object)(object)obj == (Object)null)
		{
			return;
		}
		Collider[] components = obj.GetComponents<Collider>();
		foreach (Collider item in components)
		{
			colliderContents.Remove(item);
		}
		if (!staticContents.Remove(obj))
		{
			TrainCar componentInParent = obj.GetComponentInParent<TrainCar>();
			if ((Object)(object)componentInParent != (Object)null)
			{
				if (!HasAnotherColliderFor<TrainCar>(componentInParent))
				{
					trainContents.Remove(componentInParent);
					if (trainContents == null || trainContents.Count == 0)
					{
						((FacepunchBehaviour)this).CancelInvoke((Action)TrainContentsTick);
					}
				}
			}
			else
			{
				Rigidbody componentInParent2 = obj.GetComponentInParent<Rigidbody>();
				if (!HasAnotherColliderFor<Rigidbody>(componentInParent2))
				{
					otherRigidbodyContents.Remove(componentInParent2);
				}
			}
		}
		base.OnObjectRemoved(obj);
		bool HasAnotherColliderFor<T>(T component) where T : Component
		{
			foreach (Collider colliderContent in colliderContents)
			{
				if ((Object)(object)colliderContent != (Object)null && (Object)(object)((Component)colliderContent).GetComponentInParent<T>() == (Object)(object)component)
				{
					return true;
				}
			}
			return false;
		}
	}

	private void TrainContentsTick()
	{
		if (trainContents == null)
		{
			return;
		}
		foreach (TrainCar trainContent in trainContents)
		{
			if (trainContent.IsValid() && !trainContent.IsDestroyed && owner.coupling != null)
			{
				owner.coupling.TryCouple(trainContent, location);
			}
		}
	}
}
