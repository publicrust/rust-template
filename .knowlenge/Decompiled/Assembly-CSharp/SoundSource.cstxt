using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour, IClientComponentEx, ILOD
{
	[Serializable]
	public class OcclusionPoint
	{
		public Vector3 offset = Vector3.zero;

		public bool isOccluded;
	}

	[Header("Occlusion")]
	public bool handleOcclusionChecks;

	public LayerMask occlusionLayerMask;

	public List<OcclusionPoint> occlusionPoints = new List<OcclusionPoint>();

	public bool isOccluded;

	public float occlusionAmount;

	public float lodDistance = 100f;

	public bool inRange;

	public virtual void PreClientComponentCull(IPrefabProcessor p)
	{
		p.RemoveComponent(this);
	}

	public bool IsSyncedToParent()
	{
		return false;
	}
}
