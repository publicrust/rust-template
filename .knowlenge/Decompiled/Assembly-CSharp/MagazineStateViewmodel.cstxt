using UnityEngine;

public class MagazineStateViewmodel : MonoBehaviour, IClientComponent, IViewmodelComponent, IAnimationEventReceiver
{
	public Animator TargetAnimator;

	[Tooltip("This gameobject will be toggled active if the gun has > 1 bullet")]
	public GameObject ShellRoot;

	[Tooltip("Will set layer 1 to full weight if the gun has no ammo")]
	public bool EmptyAmmoLayer;

	[Tooltip("Will update a parameter called 'hasAmmo' on the vm animator")]
	public bool SetHasAmmoParam;
}
