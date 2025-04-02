using UnityEngine;

public class HexagonTile : BaseCombatEntity, IDetector
{
	public GameObject[] variants;

	public AnimationCurve tweenCurve;

	private MeshRenderer mesh;

	public bool ShouldTrigger()
	{
		return true;
	}

	public void OnObjects()
	{
		SetFlag(Flags.Busy, b: true);
	}

	public void OnObjectAdded(GameObject obj, Collider col)
	{
	}

	public void OnEmpty()
	{
	}

	public override void OnDied(HitInfo info)
	{
		base.OnDied(info);
		SetFlag(Flags.Busy, b: true);
	}

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		if (old.HasFlag(Flags.Busy) != next.HasFlag(Flags.Busy) && base.isServer)
		{
			Invoke(delegate
			{
				Kill();
			}, 1.2f);
		}
	}
}
