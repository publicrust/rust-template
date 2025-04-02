using System;
using ProtoBuf;
using Rust;
using UnityEngine;
using UnityEngine.UI;

public class LifeInfographic : MonoBehaviour
{
	[Serializable]
	public struct DamageSetting
	{
		public DamageType ForType;

		public string Display;

		public Sprite DamageSprite;
	}

	[NonSerialized]
	public PlayerLifeStory life;

	public GameObject container;

	public RawImage AttackerAvatarImage;

	public Image DamageSourceImage;

	public LifeInfographicStat[] Stats;

	public Animator[] AllAnimators;

	public GameObject WeaponRoot;

	public GameObject DistanceRoot;

	public GameObject DistanceDivider;

	public Image WeaponImage;

	public DamageSetting[] DamageDisplays;

	public Texture2D defaultAvatarTexture;

	public bool ShowDebugData;
}
