using System;
using System.Collections.Generic;
using UnityEngine;

public class Gibbable : PrefabAttribute, IClientComponent
{
	[Serializable]
	public struct OverrideMesh
	{
		public bool enabled;

		public ColliderType ColliderType;

		public Vector3 BoxSize;

		public Vector3 ColliderCentre;

		public float ColliderRadius;

		public float CapsuleHeight;

		public int CapsuleDirection;
	}

	public enum ColliderType
	{
		Box,
		Sphere,
		Capsule
	}

	public enum ParentingType
	{
		None,
		GibsOnly,
		FXOnly,
		All
	}

	public GameObject gibSource;

	public Material[] customMaterials;

	public GameObject materialSource;

	public bool copyMaterialBlock = true;

	public PhysicMaterial physicsMaterial;

	public GameObjectRef fxPrefab;

	public bool spawnFxPrefab = true;

	[Tooltip("If enabled, gibs will spawn even though we've hit a gib limit")]
	public bool important;

	public float explodeScale;

	public float scaleOverride = 1f;

	public int uniqueId;

	public List<OverrideMesh> MeshOverrides = new List<OverrideMesh>();

	protected override Type GetIndexedType()
	{
		return typeof(Gibbable);
	}
}
