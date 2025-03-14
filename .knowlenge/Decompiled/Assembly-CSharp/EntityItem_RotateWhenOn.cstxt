using System;
using UnityEngine;

public class EntityItem_RotateWhenOn : EntityComponent<BaseEntity>
{
	[Serializable]
	public class State
	{
		public Vector3 rotation;

		public float initialDelay;

		public float timeToTake = 2f;

		public AnimationCurve animationCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public string effectOnStart = "";

		public string effectOnFinish = "";

		public SoundDefinition movementLoop;

		public float movementLoopFadeOutTime = 0.1f;

		public SoundDefinition startSound;

		public SoundDefinition stopSound;
	}

	public State on;

	public State off;

	internal bool currentlyOn;

	internal bool stateInitialized;

	public BaseEntity.Flags targetFlag = BaseEntity.Flags.On;
}
