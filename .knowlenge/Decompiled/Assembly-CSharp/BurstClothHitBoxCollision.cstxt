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
		Vector3 vector = pointA - up * radius;
		Vector3 position = pointB + up * radius;
		sphereColliders.Add(new SphereParams
		{
			Transform = transform,
			Point = transform.InverseTransformPoint(vector),
			Radius = radius
		});
		sphereColliders.Add(new SphereParams
		{
			Transform = transform,
			Point = transform.InverseTransformPoint(position),
			Radius = radius
		});
		Vector3 vector2 = vector - up * radius;
		int num = Mathf.CeilToInt(math.max((2f * halfHeight - 4f * radius) / radius, 1f));
		for (int i = 0; i < num; i++)
		{
			sphereColliders.Add(new SphereParams
			{
				Transform = transform,
				Point = transform.InverseTransformPoint(vector2 - up * ((float)i * radius)),
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
