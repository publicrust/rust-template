using UnityEngine;
using UnityEngine.Serialization;

public class EffectRecycle : BaseMonoBehaviour, IClientComponent, global::IRagdollInhert, IEffectRecycle
{
	public enum PlayMode
	{
		Once,
		Looped
	}

	public enum ParentDestroyBehaviour
	{
		Detach,
		Destroy,
		DetachWaitDestroy
	}

	[FormerlySerializedAs("lifeTime")]
	[ReadOnly]
	public float detachTime;

	[FormerlySerializedAs("lifeTime")]
	[ReadOnly]
	public float recycleTime;

	public PlayMode playMode;

	public ParentDestroyBehaviour onParentDestroyed;

	[Range(1f, 50f)]
	public int WarmedUpAmount = 1;
}
