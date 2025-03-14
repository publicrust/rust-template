using System;
using UnityEngine;

public class m2bradleyAnimator : MonoBehaviour
{
	public Animator m2Animator;

	public Material treadLeftMaterial;

	public Material treadRightMaterial;

	private Rigidbody mainRigidbody;

	[Header("GunBones")]
	public Transform turret;

	public Transform mainCannon;

	public Transform coaxGun;

	public Transform rocketsPitch;

	public Transform spotLightYaw;

	public Transform spotLightPitch;

	public Transform sideMG;

	public Transform[] sideguns;

	[Header("WheelBones")]
	public Transform[] ShocksBones;

	public Transform[] ShockTraceLineBegin;

	public Vector3[] vecShocksOffsetPosition;

	[Header("Targeting")]
	public Transform targetTurret;

	public Transform targetSpotLight;

	public Transform[] targetSideguns;

	private Vector3 vecTurret = new Vector3(0f, 0f, 0f);

	private Vector3 vecMainCannon = new Vector3(0f, 0f, 0f);

	private Vector3 vecCoaxGun = new Vector3(0f, 0f, 0f);

	private Vector3 vecRocketsPitch = new Vector3(0f, 0f, 0f);

	private Vector3 vecSpotLightBase = new Vector3(0f, 0f, 0f);

	private Vector3 vecSpotLight = new Vector3(0f, 0f, 0f);

	private float sideMGPitchValue;

	[Header("MuzzleFlash locations")]
	public GameObject muzzleflashCannon;

	public GameObject muzzleflashCoaxGun;

	public GameObject muzzleflashSideMG;

	public GameObject[] muzzleflashRockets;

	public GameObject spotLightHaloSawnpoint;

	public GameObject[] muzzleflashSideguns;

	[Header("MuzzleFlash Particle Systems")]
	public GameObjectRef machineGunMuzzleFlashFX;

	public GameObjectRef mainCannonFireFX;

	public GameObjectRef rocketLaunchFX;

	[Header("Misc")]
	public bool rocketsOpen;

	public Vector3[] vecSideGunRotation;

	public float treadConstant = 0.14f;

	public float wheelSpinConstant = 80f;

	[Header("Gun Movement speeds")]
	public float sidegunsTurnSpeed = 30f;

	public float turretTurnSpeed = 6f;

	public float cannonPitchSpeed = 10f;

	public float rocketPitchSpeed = 20f;

	public float spotLightTurnSpeed = 60f;

	public float machineGunSpeed = 20f;

	private float wheelAngle;

	private void Start()
	{
		mainRigidbody = GetComponent<Rigidbody>();
		for (int i = 0; i < ShocksBones.Length; i++)
		{
			vecShocksOffsetPosition[i] = ShocksBones[i].localPosition;
		}
	}

	private void Update()
	{
		TrackTurret();
		TrackSpotLight();
		TrackSideGuns();
		AnimateWheelsTreads();
		AdjustShocksHeight();
		m2Animator.SetBool("rocketpods", rocketsOpen);
	}

	private void AnimateWheelsTreads()
	{
		float num = 0f;
		if (mainRigidbody != null)
		{
			num = Vector3.Dot(mainRigidbody.velocity, base.transform.forward);
		}
		float x = Time.time * -1f * num * treadConstant % 1f;
		treadLeftMaterial.SetTextureOffset("_MainTex", new Vector2(x, 0f));
		treadLeftMaterial.SetTextureOffset("_BumpMap", new Vector2(x, 0f));
		treadLeftMaterial.SetTextureOffset("_SpecGlossMap", new Vector2(x, 0f));
		treadRightMaterial.SetTextureOffset("_MainTex", new Vector2(x, 0f));
		treadRightMaterial.SetTextureOffset("_BumpMap", new Vector2(x, 0f));
		treadRightMaterial.SetTextureOffset("_SpecGlossMap", new Vector2(x, 0f));
		if (num >= 0f)
		{
			wheelAngle = (wheelAngle + Time.deltaTime * num * wheelSpinConstant) % 360f;
		}
		else
		{
			wheelAngle += Time.deltaTime * num * wheelSpinConstant;
			if (wheelAngle <= 0f)
			{
				wheelAngle = 360f;
			}
		}
		m2Animator.SetFloat("wheel_spin", wheelAngle);
		m2Animator.SetFloat("speed", num);
	}

	private void AdjustShocksHeight()
	{
		Ray ray = default(Ray);
		int mask = LayerMask.GetMask("Terrain", "World", "Construction");
		int num = ShocksBones.Length;
		float num2 = 0.55f;
		float maxDistance = 0.79f;
		float num3 = 0.26f;
		for (int i = 0; i < num; i++)
		{
			ray.origin = ShockTraceLineBegin[i].position;
			ray.direction = base.transform.up * -1f;
			num3 = ((!Physics.SphereCast(ray, 0.15f, out var hitInfo, maxDistance, mask)) ? 0.26f : (hitInfo.distance - num2));
			vecShocksOffsetPosition[i].y = Mathf.Lerp(vecShocksOffsetPosition[i].y, Mathf.Clamp(num3 * -1f, -0.26f, 0f), Time.deltaTime * 5f);
			ShocksBones[i].localPosition = vecShocksOffsetPosition[i];
		}
	}

	private void TrackTurret()
	{
		if (!(targetTurret != null))
		{
			return;
		}
		_ = (targetTurret.position - turret.position).normalized;
		CalculateYawPitchOffset(turret, turret.position, targetTurret.position, out var yaw, out var pitch);
		yaw = NormalizeYaw(yaw);
		float num = Time.deltaTime * turretTurnSpeed;
		if (yaw < -0.5f)
		{
			vecTurret.y = (vecTurret.y - num) % 360f;
		}
		else if (yaw > 0.5f)
		{
			vecTurret.y = (vecTurret.y + num) % 360f;
		}
		turret.localEulerAngles = vecTurret;
		float num2 = Time.deltaTime * cannonPitchSpeed;
		CalculateYawPitchOffset(mainCannon, mainCannon.position, targetTurret.position, out yaw, out pitch);
		if (pitch < -0.5f)
		{
			vecMainCannon.x -= num2;
		}
		else if (pitch > 0.5f)
		{
			vecMainCannon.x += num2;
		}
		vecMainCannon.x = Mathf.Clamp(vecMainCannon.x, -55f, 5f);
		mainCannon.localEulerAngles = vecMainCannon;
		if (pitch < -0.5f)
		{
			vecCoaxGun.x -= num2;
		}
		else if (pitch > 0.5f)
		{
			vecCoaxGun.x += num2;
		}
		vecCoaxGun.x = Mathf.Clamp(vecCoaxGun.x, -65f, 15f);
		coaxGun.localEulerAngles = vecCoaxGun;
		if (rocketsOpen)
		{
			num2 = Time.deltaTime * rocketPitchSpeed;
			CalculateYawPitchOffset(rocketsPitch, rocketsPitch.position, targetTurret.position, out yaw, out pitch);
			if (pitch < -0.5f)
			{
				vecRocketsPitch.x -= num2;
			}
			else if (pitch > 0.5f)
			{
				vecRocketsPitch.x += num2;
			}
			vecRocketsPitch.x = Mathf.Clamp(vecRocketsPitch.x, -45f, 45f);
		}
		else
		{
			vecRocketsPitch.x = Mathf.Lerp(vecRocketsPitch.x, 0f, Time.deltaTime * 1.7f);
		}
		rocketsPitch.localEulerAngles = vecRocketsPitch;
	}

	private void TrackSpotLight()
	{
		if (targetSpotLight != null)
		{
			_ = (targetSpotLight.position - spotLightYaw.position).normalized;
			CalculateYawPitchOffset(spotLightYaw, spotLightYaw.position, targetSpotLight.position, out var yaw, out var pitch);
			yaw = NormalizeYaw(yaw);
			float num = Time.deltaTime * spotLightTurnSpeed;
			if (yaw < -0.5f)
			{
				vecSpotLightBase.y = (vecSpotLightBase.y - num) % 360f;
			}
			else if (yaw > 0.5f)
			{
				vecSpotLightBase.y = (vecSpotLightBase.y + num) % 360f;
			}
			spotLightYaw.localEulerAngles = vecSpotLightBase;
			CalculateYawPitchOffset(spotLightPitch, spotLightPitch.position, targetSpotLight.position, out yaw, out pitch);
			if (pitch < -0.5f)
			{
				vecSpotLight.x -= num;
			}
			else if (pitch > 0.5f)
			{
				vecSpotLight.x += num;
			}
			vecSpotLight.x = Mathf.Clamp(vecSpotLight.x, -50f, 50f);
			spotLightPitch.localEulerAngles = vecSpotLight;
			m2Animator.SetFloat("sideMG_pitch", vecSpotLight.x, 0.5f, Time.deltaTime);
		}
	}

	private void TrackSideGuns()
	{
		for (int i = 0; i < sideguns.Length; i++)
		{
			if (!(targetSideguns[i] == null))
			{
				_ = (targetSideguns[i].position - sideguns[i].position).normalized;
				CalculateYawPitchOffset(sideguns[i], sideguns[i].position, targetSideguns[i].position, out var yaw, out var pitch);
				yaw = NormalizeYaw(yaw);
				float num = Time.deltaTime * sidegunsTurnSpeed;
				if (yaw < -0.5f)
				{
					vecSideGunRotation[i].y -= num;
				}
				else if (yaw > 0.5f)
				{
					vecSideGunRotation[i].y += num;
				}
				if (pitch < -0.5f)
				{
					vecSideGunRotation[i].x -= num;
				}
				else if (pitch > 0.5f)
				{
					vecSideGunRotation[i].x += num;
				}
				vecSideGunRotation[i].x = Mathf.Clamp(vecSideGunRotation[i].x, -45f, 45f);
				vecSideGunRotation[i].y = Mathf.Clamp(vecSideGunRotation[i].y, -45f, 45f);
				sideguns[i].localEulerAngles = vecSideGunRotation[i];
			}
		}
	}

	public void CalculateYawPitchOffset(Transform objectTransform, Vector3 vecStart, Vector3 vecEnd, out float yaw, out float pitch)
	{
		Vector3 vector = objectTransform.InverseTransformDirection(vecEnd - vecStart);
		float x = Mathf.Sqrt(vector.x * vector.x + vector.z * vector.z);
		pitch = (0f - Mathf.Atan2(vector.y, x)) * (180f / MathF.PI);
		vector = (vecEnd - vecStart).normalized;
		Vector3 forward = objectTransform.forward;
		forward.y = 0f;
		forward.Normalize();
		float num = Vector3.Dot(vector, forward);
		float num2 = Vector3.Dot(vector, objectTransform.right);
		float y = 360f * num2;
		float x2 = 360f * (0f - num);
		yaw = (Mathf.Atan2(y, x2) + MathF.PI) * (180f / MathF.PI);
	}

	public float NormalizeYaw(float flYaw)
	{
		if (flYaw > 180f)
		{
			return 360f - flYaw;
		}
		return flYaw * -1f;
	}
}
