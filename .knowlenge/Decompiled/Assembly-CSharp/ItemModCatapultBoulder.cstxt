using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemModCatapultBoulder : MonoBehaviour
{
	[Serializable]
	public struct ProjectileSettings
	{
		public GameObjectRef prefab;

		public int count;

		public float gravityModifier;
	}

	[SerializeField]
	public List<ProjectileSettings> projectileSettings = new List<ProjectileSettings>();

	public float spreadAngle = 6f;
}
