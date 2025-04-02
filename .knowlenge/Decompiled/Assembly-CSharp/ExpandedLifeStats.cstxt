using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandedLifeStats : MonoBehaviour
{
	[Serializable]
	public struct GenericStatDisplay
	{
		public string statKey;

		public Sprite statSprite;

		public Translate.Phrase displayPhrase;
	}

	public GameObject DisplayRoot;

	public GameObjectRef GenericStatRow;

	[Header("Resources")]
	public Transform ResourcesStatRoot;

	public List<GenericStatDisplay> ResourceStats;

	[Header("Weapons")]
	public GameObjectRef WeaponStatRow;

	public Transform WeaponsRoot;

	[Header("Misc")]
	public Transform MiscRoot;

	public List<GenericStatDisplay> MiscStats;

	public LifeInfographic Infographic;

	public RectTransform MoveRoot;

	public Vector2 OpenPosition;

	public Vector2 ClosedPosition;

	public GameObject OpenButtonRoot;

	public GameObject CloseButtonRoot;

	public GameObject ScrollGradient;

	public ScrollRect Scroller;
}
