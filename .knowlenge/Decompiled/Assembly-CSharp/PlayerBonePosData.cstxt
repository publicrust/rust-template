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

	public BonePosData GetBonePositionData(BasePlayer.PlayerFlags flagsOnDeath, ModelState modelState)
	{
		if (flagsOnDeath.HasFlag(BasePlayer.PlayerFlags.Sleeping))
		{
			return sleeping;
		}
		if (flagsOnDeath.HasFlag(BasePlayer.PlayerFlags.Incapacitated))
		{
			return incapacitated;
		}
		if (flagsOnDeath.HasFlag(BasePlayer.PlayerFlags.Wounded))
		{
			return crawling;
		}
		if (modelState.onLadder)
		{
			return onladder;
		}
		if (modelState.ducked)
		{
			return ducking;
		}
		if (modelState.waterLevel >= 0.75f)
		{
			return swimming;
		}
		if (modelState.mounted)
		{
			if (modelState.poseType < mountedPoses.Length)
			{
				return mountedPoses[modelState.poseType];
			}
			if (modelState.poseType == 128)
			{
				return standing;
			}
			Debug.LogWarning($"PlayerCorpse GetBonePositionData: No saved bone position data for mount pose {modelState.poseType}. Falling back to SitGeneric. Please update the 'Server Side Ragdoll Bone Pos Data' file with the new mount pose.");
			return mountedPoses[7];
		}
		return standing;
	}
}
