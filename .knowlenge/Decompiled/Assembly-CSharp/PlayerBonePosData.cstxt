using System;
using Facepunch;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Player/Player Bone Pos Data", fileName = "Player Bone Pos Data")]
public class PlayerBonePosData : ScriptableObject
{
	[Serializable]
	public class BonePosData
	{
		public AnimationClip sourceAnim;

		public float animStartTime;

		public Vector3 rootRotationOffset;

		[ReadOnly]
		public Vector3[] bonePositions;

		[ReadOnly]
		public Quaternion[] boneRotations;
	}

	public SkeletonDefinition skeletonDef;

	public GameObjectRef playerModel;

	[ReadOnly]
	public string[] boneNames;

	public BonePosData crawling;

	public BonePosData ducking;

	public BonePosData incapacitated;

	public BonePosData onladder;

	public BonePosData sleeping;

	public BonePosData standing;

	public BonePosData swimming;

	public BonePosData[] mountedPoses;
}
