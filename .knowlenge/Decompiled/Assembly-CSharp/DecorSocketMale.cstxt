using System;
using UnityEngine;

public class DecorSocketMale : PrefabAttribute
{
	protected override Type GetIndexedType()
	{
		return typeof(DecorSocketMale);
	}

	protected void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0.5f, 0.5f, 1f, 1f);
		Gizmos.DrawSphere(base.transform.position, 1f);
	}
}
