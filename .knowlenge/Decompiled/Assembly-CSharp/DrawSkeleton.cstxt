using UnityEngine;

public class DrawSkeleton : MonoBehaviour
{
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		DrawTransform(base.transform);
	}

	private static void DrawTransform(Transform t)
	{
		for (int i = 0; i < t.childCount; i++)
		{
			Gizmos.DrawLine(t.position, t.GetChild(i).position);
			DrawTransform(t.GetChild(i));
		}
	}
}
