using System.Collections.Generic;
using Facepunch.BurstCloth;
using Unity.Mathematics;
using UnityEngine;

public class BurstClothHitBoxCollision : BurstCloth, IClientComponent, IPrefabPreProcess
{
	[Header("Rust Wearable BurstCloth")]
	public bool UseLocalGravity = true;

	public float GravityStrength = 0.8f;

	public float DefaultLength = 1f;

	public float MountedLengthMultiplier;

	public float DuckedLengthMultiplier = 0.5f;

	public float CorpseLengthMultiplier = 0.2f;

	public Transform UpAxis;

	[Header("Collision")]
	public Transform ColliderRoot;

	[Tooltip("Keywords in bone names which should be ignored for collision")]
	public string[] IgnoreKeywords;

	private static void BreakCapsuleIntoSpheres(Transform transform, Vector3 pointA, Vector3 pointB, Vector3 up, float halfHeight, float radius, List<SphereParams> sphereColliders)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = pointA - up * radius;
		Vector3 val2 = pointB + up * radius;
		sphereColliders.Add(new SphereParams
		{
			Transform = transform,
			Point = transform.InverseTransformPoint(val),
			Radius = radius
		});
		sphereColliders.Add(new SphereParams
		{
			Transform = transform,
			Point = transform.InverseTransformPoint(val2),
			Radius = radius
		});
		Vector3 val3 = val - up * radius;
		int num = Mathf.CeilToInt(math.max((2f * halfHeight - 4f * radius) / radius, 1f));
		for (int i = 0; i < num; i++)
		{
			sphereColliders.Add(new SphereParams
			{
				Transform = transform,
				Point = transform.InverseTransformPoint(val3 - up * ((float)i * radius)),
				Radius = radius
			});
		}
	}

	protected override void GatherColliders(List<SphereParams> sphereColliders)
	{
	}

	public void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
	}
}
