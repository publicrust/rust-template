using System;
using UnityEngine;

public class DecorSocketFemale : PrefabAttribute
{
	protected override Type GetIndexedType()
	{
		return typeof(DecorSocketFemale);
	}

	protected void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(1f, 0.5f, 0.5f, 1f);
		Gizmos.DrawSphere(base.transform.position, 1f);
	}
}
