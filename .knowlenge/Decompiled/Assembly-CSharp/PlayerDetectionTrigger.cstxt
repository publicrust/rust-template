using UnityEngine;

public class PlayerDetectionTrigger : TriggerBase
{
	public GameObject detector;

	public IDetector _detector;

	private IDetector myDetector
	{
		get
		{
			if (_detector == null && detector != null)
			{
				_detector = detector.GetComponent<IDetector>();
			}
			return _detector;
		}
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

	public override void OnObjects()
	{
		base.OnObjects();
		if (myDetector != null)
		{
			myDetector.OnObjects();
		}
	}

	internal override void OnObjectAdded(GameObject obj, Collider col)
	{
		base.OnObjectAdded(obj, col);
		if (myDetector != null)
		{
			myDetector.OnObjectAdded(obj, col);
		}
	}

	public override void OnEmpty()
	{
		base.OnEmpty();
		if (myDetector != null)
		{
			myDetector.OnEmpty();
		}
	}
}
