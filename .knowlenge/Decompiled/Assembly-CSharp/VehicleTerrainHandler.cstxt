using UnityEngine;

public class VehicleTerrainHandler
{
	public enum Surface
	{
		Default,
		Road,
		Snow,
		Ice,
		Sand,
		Frictionless
	}

	public string CurGroundPhysicsMatName;

	public Surface OnSurface;

	public bool IsGrounded;

	public float RayLength = 1.5f;

	private readonly string[] TerrainRoad = new string[5] { "rock", "concrete", "gravel", "metal", "path" };

	private const float SECONDS_BETWEEN_TERRAIN_SAMPLE = 0.25f;

	private TimeSince timeSinceTerrainCheck;

	private readonly BaseVehicle vehicle;

	public bool IsOnSnowOrIce
	{
		get
		{
			if (OnSurface != Surface.Snow)
			{
				return OnSurface == Surface.Ice;
			}
			return true;
		}
	}

	public VehicleTerrainHandler(BaseVehicle vehicle)
	{
		this.vehicle = vehicle;
	}

	public void FixedUpdate()
	{
		if (!vehicle.IsStationary() && (float)timeSinceTerrainCheck > 0.25f)
		{
			DoTerrainCheck();
		}
	}

	private void DoTerrainCheck()
	{
		timeSinceTerrainCheck = Random.Range(-0.025f, 0.025f);
		Transform transform = vehicle.transform;
		if (Physics.Raycast(transform.position + transform.up * 0.5f, -transform.up, out var hitInfo, RayLength, 161546241, QueryTriggerInteraction.Ignore))
		{
			CurGroundPhysicsMatName = AssetNameCache.GetNameLower(ColliderEx.GetMaterialAt(hitInfo.collider, hitInfo.point));
			if (GetOnRoad(CurGroundPhysicsMatName))
			{
				OnSurface = Surface.Road;
			}
			else if (CurGroundPhysicsMatName == "snow")
			{
				if (hitInfo.collider.CompareTag("TreatSnowAsIce"))
				{
					OnSurface = Surface.Ice;
				}
				else
				{
					OnSurface = Surface.Snow;
				}
			}
			else if (CurGroundPhysicsMatName == "sand")
			{
				OnSurface = Surface.Sand;
			}
			else if (CurGroundPhysicsMatName.Contains("zero friction"))
			{
				OnSurface = Surface.Frictionless;
			}
			else
			{
				OnSurface = Surface.Default;
			}
			IsGrounded = true;
		}
		else
		{
			CurGroundPhysicsMatName = "concrete";
			OnSurface = Surface.Default;
			IsGrounded = false;
		}
	}

	private bool GetOnRoad(string physicMat)
	{
		for (int i = 0; i < TerrainRoad.Length; i++)
		{
			if (TerrainRoad[i] == physicMat)
			{
				return true;
			}
		}
		return false;
	}
}
