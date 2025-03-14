using System.Collections.Generic;
using UnityEngine;

public class BaseViewModel : FacepunchBehaviour, IPrefabPreProcess
{
	[Header("BaseViewModel")]
	public LazyAimProperties lazyaimRegular;

	public LazyAimProperties lazyaimIronsights;

	public Transform pivot;

	public bool useViewModelCamera = true;

	public bool wantsHeldItemFlags;

	public GameObject[] hideSightMeshes;

	public bool isGestureViewModel;

	public Transform MuzzlePoint;

	[Header("Skin")]
	public SubsurfaceProfile subsurfaceProfile;

	[HideInInspector]
	public List<SkinnedMeshRenderer> baseSkinPieces = new List<SkinnedMeshRenderer>();

	public void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
	}
}
