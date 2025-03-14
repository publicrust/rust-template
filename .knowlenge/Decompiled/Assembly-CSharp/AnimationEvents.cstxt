using UnityEngine;

public class AnimationEvents : BaseMonoBehaviour
{
	public Transform rootObject;

	public HeldEntity targetEntity;

	[Tooltip("Path to the effect folder for these animations. Relative to this object.")]
	public string effectFolder;

	public bool enforceClipWeights;

	public string localFolder;

	[Tooltip("If true the localFolder field won't update with manifest updates, use for custom paths")]
	public bool customLocalFolder;

	public bool IsBusy;

	protected void OnEnable()
	{
		if (rootObject == null)
		{
			rootObject = base.transform;
		}
	}
}
