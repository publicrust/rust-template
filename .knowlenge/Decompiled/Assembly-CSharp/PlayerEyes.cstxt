using UnityEngine;

public class PlayerEyes : EntityComponent<BasePlayer>
{
	public static readonly Vector3 EyeOffset = new Vector3(0f, 1.5f, 0f);

	public static readonly Vector3 DuckOffset = new Vector3(0f, -0.6f, 0f);

	public static readonly Vector3 CrawlOffset = new Vector3(0f, -1.15f, 0.175f);

	public static readonly Vector3 ParachuteOffset = new Vector3(0f, -1.45f, 0.3f);

	public Vector3 thirdPersonSleepingOffset = new Vector3(0.43f, 1.25f, 0.7f);

	public LazyAimProperties defaultLazyAim;

	private EncryptedValue<Vector3> viewOffset = Vector3.zero;

	public Vector3 worldMountedPosition
	{
		get
		{
			if ((bool)base.baseEntity && base.baseEntity.isMounted)
			{
				Vector3 vector = base.baseEntity.GetMounted().EyePositionForPlayer(base.baseEntity, GetLookRotation());
				if (vector != Vector3.zero)
				{
					return vector;
				}
			}
			return worldStandingPosition;
		}
	}

	public Vector3 worldStandingPosition => base.transform.position + EyeOffset;

	public Vector3 worldCrouchedPosition => worldStandingPosition + DuckOffset;

	public Vector3 worldCrawlingPosition => worldStandingPosition + CrawlOffset;

	public Vector3 position
	{
		get
		{
			if ((bool)base.baseEntity && base.baseEntity.isMounted)
			{
				Vector3 vector = base.baseEntity.GetMounted().EyePositionForPlayer(base.baseEntity, GetLookRotation());
				if (vector != Vector3.zero)
				{
					return vector;
				}
				return base.transform.position + base.transform.up * (EyeOffset.y + viewOffset.Get().y) + BodyLeanOffset;
			}
			return base.transform.position + base.transform.rotation * (EyeOffset + viewOffset) + BodyLeanOffset;
		}
	}

	private Vector3 BodyLeanOffset => Vector3.zero;

	public Vector3 center
	{
		get
		{
			if ((bool)base.baseEntity && base.baseEntity.isMounted)
			{
				Vector3 vector = base.baseEntity.GetMounted().EyeCenterForPlayer(base.baseEntity, GetLookRotation());
				if (vector != Vector3.zero)
				{
					return vector;
				}
			}
			return base.transform.position + base.transform.up * (EyeOffset.y + DuckOffset.y);
		}
	}

	public Vector3 offset => base.transform.up * (EyeOffset.y + viewOffset.Get().y);

	public Quaternion rotation
	{
		get
		{
			return parentRotation * bodyRotation;
		}
		set
		{
			bodyRotation = Quaternion.Inverse(parentRotation) * value;
		}
	}

	public Quaternion bodyRotation { get; set; }

	public Quaternion parentRotation
	{
		get
		{
			if (base.baseEntity.isMounted || !(base.transform.parent != null))
			{
				return Quaternion.identity;
			}
			return Quaternion.Euler(0f, base.transform.parent.rotation.eulerAngles.y, 0f);
		}
	}

	public void NetworkUpdate(Quaternion rot)
	{
		if (base.baseEntity.IsCrawling())
		{
			viewOffset = CrawlOffset;
		}
		else
		{
			viewOffset = Vector3.zero;
			viewOffset = Vector3.Lerp(viewOffset, DuckOffset, base.baseEntity.modelState.ducking);
		}
		bodyRotation = rot;
	}

	public Vector3 MovementForward()
	{
		return Quaternion.Euler(new Vector3(0f, rotation.eulerAngles.y, 0f)) * Vector3.forward;
	}

	public Vector3 MovementRight()
	{
		return Quaternion.Euler(new Vector3(0f, rotation.eulerAngles.y, 0f)) * Vector3.right;
	}

	public Ray BodyRay()
	{
		return new Ray(position, BodyForward());
	}

	public Vector3 BodyForward()
	{
		return rotation * Vector3.forward;
	}

	public Vector3 BodyRight()
	{
		return rotation * Vector3.right;
	}

	public Vector3 BodyUp()
	{
		return rotation * Vector3.up;
	}

	public Ray HeadRay()
	{
		return new Ray(position, HeadForward());
	}

	public Vector3 HeadForward()
	{
		return GetLookRotation() * Vector3.forward;
	}

	public Vector3 HeadRight()
	{
		return GetLookRotation() * Vector3.right;
	}

	public Vector3 HeadUp()
	{
		return GetLookRotation() * Vector3.up;
	}

	public Quaternion GetLookRotation()
	{
		return rotation;
	}

	public Quaternion GetAimRotation()
	{
		return rotation;
	}
}
