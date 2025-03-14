using System;
using UnityEngine;

public class BossFormController : ArcadeEntityController
{
	[Serializable]
	public class BossDamagePoint
	{
		public BoxCollider hitBox;

		public float health;

		public ArcadeEntityController damagePrefab;

		public ArcadeEntityController damageInstance;

		public bool destroyed;
	}

	public float animationSpeed = 0.5f;

	public Sprite[] animationFrames;

	public Vector2 roamDistance;

	public Transform colliderParent;

	public BossDamagePoint[] damagePoints;

	public ArcadeEntityController flashController;

	public float health = 50f;
}
