using UnityEngine;

public class SeekerTest : BaseEntity, SeekerTarget.ISeekerTargetOwner
{
	public GameObjectRef roadFlare;

	public bool useRoadFlares;

	public int numFlares = 3;

	public int maxFlares = 3;

	public float flareRegenTime = 10f;

	public float timeBetweenFlares = 10f;

	public Transform flareSpawnPoint;

	public float flareDuration = 5f;

	private float nextFlareRegenTime;

	public override void ServerInit()
	{
		SeekerTarget.SetSeekerTarget(this, SeekerTarget.SeekerStrength.MEDIUM);
		base.ServerInit();
	}

	public void Update()
	{
		if (Time.time > nextFlareRegenTime)
		{
			numFlares = Mathf.Clamp(numFlares + 1, 0, maxFlares);
			nextFlareRegenTime = Time.time + timeBetweenFlares;
		}
	}

	public void DoFlare()
	{
		if (numFlares != 0)
		{
			numFlares--;
			if (useRoadFlares)
			{
				GameManager.server.CreateEntity(roadFlare.resourcePath, flareSpawnPoint.position).Spawn();
				return;
			}
			SetFlag(Flags.OnFire, b: true);
			SeekerTarget.SetSeekerTarget(this, SeekerTarget.SeekerStrength.OFF);
			Invoke(ClearFlares, flareDuration);
		}
	}

	public void ClearFlares()
	{
		SetFlag(Flags.OnFire, b: false);
		SeekerTarget.SetSeekerTarget(this, SeekerTarget.SeekerStrength.MEDIUM);
	}

	public override void OnEntityMessage(BaseEntity from, string msg)
	{
		if (msg == "RadarLock")
		{
			if (!IsInvoking(DoFlare))
			{
				Invoke(DoFlare, Random.Range(0.5f, 1f));
			}
		}
		else if (msg == "RadarWarning")
		{
			SetFlag(Flags.Reserved1, b: true);
			Invoke(ClearWarning, 1f);
		}
		else
		{
			base.OnEntityMessage(from, msg);
		}
	}

	public void ClearWarning()
	{
		SetFlag(Flags.Reserved1, b: false);
	}

	public override void DestroyShared()
	{
		if (base.isServer)
		{
			SeekerTarget.SetSeekerTarget(this, SeekerTarget.SeekerStrength.OFF);
		}
		base.DestroyShared();
	}

	public bool IsValidHomingTarget()
	{
		return true;
	}
}
