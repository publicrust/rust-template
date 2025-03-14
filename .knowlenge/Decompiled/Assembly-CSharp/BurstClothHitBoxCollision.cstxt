using System.Collections.Generic;
using Facepunch.BurstCloth;
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

	protected override void GatherColliders(List<CapsuleParams> colliders)
	{
	}

	public void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
	}
}
