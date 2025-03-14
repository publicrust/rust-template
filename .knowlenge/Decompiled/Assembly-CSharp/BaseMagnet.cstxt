using UnityEngine;

public class BaseMagnet : MonoBehaviour
{
	public BaseEntity entityOwner;

	public BaseEntity.Flags magnetFlag = BaseEntity.Flags.Reserved6;

	public TriggerMagnet magnetTrigger;

	public FixedJoint fixedJoint;

	public Rigidbody kinematicAttachmentBody;

	public float magnetForce;

	public Transform attachDepthPoint;

	public GameObjectRef attachEffect;

	public bool isMagnetOn;

	public GameObject colliderSource;

	private BasePlayer associatedPlayer;

	public bool HasConnectedObject()
	{
		if (fixedJoint.connectedBody != null)
		{
			return isMagnetOn;
		}
		return false;
	}

	public OBB GetConnectedOBB(float scale = 1f)
	{
		if (fixedJoint.connectedBody == null)
		{
			Debug.LogError("BaseMagnet returning fake OBB because no connected body!");
			return new OBB(Vector3.zero, Vector3.one, Quaternion.identity);
		}
		BaseEntity component = fixedJoint.connectedBody.gameObject.GetComponent<BaseEntity>();
		Bounds bounds = component.bounds;
		bounds.extents *= scale;
		return new OBB(component.transform.position, component.transform.rotation, bounds);
	}

	public void SetCollisionsEnabled(GameObject other, bool wants)
	{
		Collider[] componentsInChildren = other.GetComponentsInChildren<Collider>();
		Collider[] componentsInChildren2 = colliderSource.GetComponentsInChildren<Collider>();
		Collider[] array = componentsInChildren;
		foreach (Collider collider in array)
		{
			Collider[] array2 = componentsInChildren2;
			foreach (Collider collider2 in array2)
			{
				Physics.IgnoreCollision(collider, collider2, !wants);
			}
		}
	}

	public virtual void SetMagnetEnabled(bool wantsOn, BasePlayer forPlayer)
	{
		if (isMagnetOn != wantsOn)
		{
			associatedPlayer = forPlayer;
			isMagnetOn = wantsOn;
			if (isMagnetOn)
			{
				OnMagnetEnabled();
			}
			else
			{
				OnMagnetDisabled();
			}
			if (entityOwner != null)
			{
				entityOwner.SetFlag(magnetFlag, isMagnetOn);
			}
		}
	}

	public virtual void OnMagnetEnabled()
	{
	}

	public virtual void OnMagnetDisabled()
	{
		if ((bool)fixedJoint.connectedBody)
		{
			SetCollisionsEnabled(fixedJoint.connectedBody.gameObject, wants: true);
			Rigidbody connectedBody = fixedJoint.connectedBody;
			fixedJoint.connectedBody = null;
			connectedBody.WakeUp();
		}
	}

	public bool IsMagnetOn()
	{
		return isMagnetOn;
	}

	public void MagnetThink(float delta)
	{
		if (!isMagnetOn)
		{
			return;
		}
		Vector3 position = magnetTrigger.transform.position;
		if (magnetTrigger.entityContents == null)
		{
			return;
		}
		foreach (BaseEntity entityContent in magnetTrigger.entityContents)
		{
			if (entityContent == null || !entityContent.syncPosition)
			{
				continue;
			}
			Rigidbody component = entityContent.GetComponent<Rigidbody>();
			if (component == null || component.isKinematic || entityContent.isClient)
			{
				continue;
			}
			if (new OBB(entityContent.transform.position, entityContent.transform.rotation, entityContent.bounds).Contains(attachDepthPoint.position))
			{
				MagnetLiftable component2 = entityContent.GetComponent<MagnetLiftable>();
				if (component2 != null)
				{
					if (component2.requireObjectOff && entityContent.IsOn())
					{
						continue;
					}
					component2.SetMagnetized(wantsOn: true, this, associatedPlayer);
					if (fixedJoint.connectedBody == null)
					{
						Effect.server.Run(attachEffect.resourcePath, attachDepthPoint.position, -attachDepthPoint.up);
						fixedJoint.connectedBody = component;
						SetCollisionsEnabled(component.gameObject, wants: false);
						continue;
					}
				}
			}
			if (fixedJoint.connectedBody == null)
			{
				Vector3 position2 = entityContent.transform.position;
				float b = Vector3.Distance(position2, position);
				Vector3 vector = Vector3Ex.Direction(position, position2);
				float num = 1f / Mathf.Max(1f, b);
				component.AddForce(vector * magnetForce * num, ForceMode.Acceleration);
			}
		}
	}
}
