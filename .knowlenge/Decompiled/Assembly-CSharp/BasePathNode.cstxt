using System;
using System.Collections.Generic;
using UnityEngine;

public class BasePathNode : MonoBehaviour, IAIPathNode
{
	public BasePath Path;

	public List<BasePathNode> linked;

	public float maxVelocityOnApproach = -1f;

	public bool straightaway;

	public Vector3 Position => ((Component)this).transform.position;

	public bool Straightaway => straightaway;

	public IEnumerable<IAIPathNode> Linked => linked;

	public bool IsValid()
	{
		return (Object)(object)((Component)this).transform != (Object)null;
	}

	public void AddLink(IAIPathNode link)
	{
		throw new NotImplementedException();
	}

	public void OnDrawGizmosSelected()
	{
	}
}
