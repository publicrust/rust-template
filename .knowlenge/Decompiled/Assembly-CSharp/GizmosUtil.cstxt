using System;
using UnityEngine;

public static class GizmosUtil
{
	public static void DrawWireCircleX(Vector3 pos, float radius)
	{
		Matrix4x4 matrix = Gizmos.matrix;
		Gizmos.matrix *= Matrix4x4.TRS(pos, Quaternion.identity, new Vector3(0f, 1f, 1f));
		Gizmos.DrawWireSphere(Vector3.zero, radius);
		Gizmos.matrix = matrix;
	}

	public static void DrawWireCircleY(Vector3 pos, float radius)
	{
		Matrix4x4 matrix = Gizmos.matrix;
		Gizmos.matrix *= Matrix4x4.TRS(pos, Quaternion.identity, new Vector3(1f, 0f, 1f));
		Gizmos.DrawWireSphere(Vector3.zero, radius);
		Gizmos.matrix = matrix;
	}

	public static void DrawWireCircleZ(Vector3 pos, float radius)
	{
		Matrix4x4 matrix = Gizmos.matrix;
		Gizmos.matrix *= Matrix4x4.TRS(pos, Quaternion.identity, new Vector3(1f, 1f, 0f));
		Gizmos.DrawWireSphere(Vector3.zero, radius);
		Gizmos.matrix = matrix;
	}

	public static void DrawCircleX(Vector3 pos, float radius)
	{
		Matrix4x4 matrix = Gizmos.matrix;
		Gizmos.matrix *= Matrix4x4.TRS(pos, Quaternion.identity, new Vector3(0f, 1f, 1f));
		Gizmos.DrawSphere(Vector3.zero, radius);
		Gizmos.matrix = matrix;
	}

	public static void DrawCircleY(Vector3 pos, float radius)
	{
		Matrix4x4 matrix = Gizmos.matrix;
		Gizmos.matrix *= Matrix4x4.TRS(pos, Quaternion.identity, new Vector3(1f, 0f, 1f));
		Gizmos.DrawSphere(Vector3.zero, radius);
		Gizmos.matrix = matrix;
	}

	public static void DrawCircleZ(Vector3 pos, float radius)
	{
		Matrix4x4 matrix = Gizmos.matrix;
		Gizmos.matrix *= Matrix4x4.TRS(pos, Quaternion.identity, new Vector3(1f, 1f, 0f));
		Gizmos.DrawSphere(Vector3.zero, radius);
		Gizmos.matrix = matrix;
	}

	public static void DrawWireCylinderX(Vector3 pos, float radius, float height)
	{
		DrawWireCircleX(pos - new Vector3(0.5f * height, 0f, 0f), radius);
		DrawWireCircleX(pos + new Vector3(0.5f * height, 0f, 0f), radius);
	}

	public static void DrawWireCylinderY(Vector3 pos, float radius, float height)
	{
		DrawWireCircleY(pos - new Vector3(0f, 0.5f * height, 0f), radius);
		DrawWireCircleY(pos + new Vector3(0f, 0.5f * height, 0f), radius);
	}

	public static void DrawWireCylinderZ(Vector3 pos, float radius, float height)
	{
		DrawWireCircleZ(pos - new Vector3(0f, 0f, 0.5f * height), radius);
		DrawWireCircleZ(pos + new Vector3(0f, 0f, 0.5f * height), radius);
	}

	public static void DrawCylinderX(Vector3 pos, float radius, float height)
	{
		DrawCircleX(pos - new Vector3(0.5f * height, 0f, 0f), radius);
		DrawCircleX(pos + new Vector3(0.5f * height, 0f, 0f), radius);
	}

	public static void DrawCylinderY(Vector3 pos, float radius, float height)
	{
		DrawCircleY(pos - new Vector3(0f, 0.5f * height, 0f), radius);
		DrawCircleY(pos + new Vector3(0f, 0.5f * height, 0f), radius);
	}

	public static void DrawCylinderZ(Vector3 pos, float radius, float height)
	{
		DrawCircleZ(pos - new Vector3(0f, 0f, 0.5f * height), radius);
		DrawCircleZ(pos + new Vector3(0f, 0f, 0.5f * height), radius);
	}

	public static void DrawWireCapsuleX(Vector3 pos, float radius, float height)
	{
		Vector3 vector = pos - new Vector3(0.5f * height, 0f, 0f) + Vector3.right * radius;
		Vector3 vector2 = pos + new Vector3(0.5f * height, 0f, 0f) - Vector3.right * radius;
		Gizmos.DrawWireSphere(vector, radius);
		Gizmos.DrawWireSphere(vector2, radius);
		Gizmos.DrawLine(vector + Vector3.forward * radius, vector2 + Vector3.forward * radius);
		Gizmos.DrawLine(vector + Vector3.up * radius, vector2 + Vector3.up * radius);
		Gizmos.DrawLine(vector + Vector3.back * radius, vector2 + Vector3.back * radius);
		Gizmos.DrawLine(vector + Vector3.down * radius, vector2 + Vector3.down * radius);
	}

	public static void DrawWireCapsuleY(Vector3 pos, float radius, float height)
	{
		Vector3 vector = pos - new Vector3(0f, 0.5f * height, 0f) + Vector3.up * radius;
		Vector3 vector2 = pos + new Vector3(0f, 0.5f * height, 0f) - Vector3.up * radius;
		Gizmos.DrawWireSphere(vector, radius);
		Gizmos.DrawWireSphere(vector2, radius);
		Gizmos.DrawLine(vector + Vector3.forward * radius, vector2 + Vector3.forward * radius);
		Gizmos.DrawLine(vector + Vector3.right * radius, vector2 + Vector3.right * radius);
		Gizmos.DrawLine(vector + Vector3.back * radius, vector2 + Vector3.back * radius);
		Gizmos.DrawLine(vector + Vector3.left * radius, vector2 + Vector3.left * radius);
	}

	public static void DrawWireCapsuleZ(Vector3 pos, float radius, float height)
	{
		Vector3 vector = pos - new Vector3(0f, 0f, 0.5f * height) + Vector3.forward * radius;
		Vector3 vector2 = pos + new Vector3(0f, 0f, 0.5f * height) - Vector3.forward * radius;
		Gizmos.DrawWireSphere(vector, radius);
		Gizmos.DrawWireSphere(vector2, radius);
		Gizmos.DrawLine(vector + Vector3.up * radius, vector2 + Vector3.up * radius);
		Gizmos.DrawLine(vector + Vector3.right * radius, vector2 + Vector3.right * radius);
		Gizmos.DrawLine(vector + Vector3.down * radius, vector2 + Vector3.down * radius);
		Gizmos.DrawLine(vector + Vector3.left * radius, vector2 + Vector3.left * radius);
	}

	public static void DrawCapsuleX(Vector3 pos, float radius, float height)
	{
		Vector3 center = pos - new Vector3(0.5f * height, 0f, 0f);
		Vector3 center2 = pos + new Vector3(0.5f * height, 0f, 0f);
		Gizmos.DrawSphere(center, radius);
		Gizmos.DrawSphere(center2, radius);
	}

	public static void DrawCapsuleY(Vector3 pos, float radius, float height)
	{
		Vector3 center = pos - new Vector3(0f, 0.5f * height, 0f);
		Vector3 center2 = pos + new Vector3(0f, 0.5f * height, 0f);
		Gizmos.DrawSphere(center, radius);
		Gizmos.DrawSphere(center2, radius);
	}

	public static void DrawCapsuleZ(Vector3 pos, float radius, float height)
	{
		Vector3 center = pos - new Vector3(0f, 0f, 0.5f * height);
		Vector3 center2 = pos + new Vector3(0f, 0f, 0.5f * height);
		Gizmos.DrawSphere(center, radius);
		Gizmos.DrawSphere(center2, radius);
	}

	public static void DrawWireCube(Vector3 pos, Vector3 size, Quaternion rot)
	{
		Matrix4x4 matrix = Gizmos.matrix;
		Gizmos.matrix = Matrix4x4.TRS(pos, rot, size);
		Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
		Gizmos.matrix = matrix;
	}

	public static void DrawCube(Vector3 pos, Vector3 size, Quaternion rot)
	{
		Matrix4x4 matrix = Gizmos.matrix;
		Gizmos.matrix = Matrix4x4.TRS(pos, rot, size);
		Gizmos.DrawCube(Vector3.zero, Vector3.one);
		Gizmos.matrix = matrix;
	}

	public static void DrawWirePath(Vector3 a, Vector3 b, float thickness)
	{
		DrawWireCircleY(a, thickness);
		DrawWireCircleY(b, thickness);
		Vector3 normalized = (b - a).normalized;
		Vector3 vector = Quaternion.Euler(0f, 90f, 0f) * normalized;
		Gizmos.DrawLine(b + vector * thickness, a + vector * thickness);
		Gizmos.DrawLine(b - vector * thickness, a - vector * thickness);
	}

	public static void DrawSemiCircle(float radius)
	{
		float num = radius * (MathF.PI / 180f) * 0.5f;
		Vector3 vector = Mathf.Cos(num) * Vector3.forward + Mathf.Sin(num) * Vector3.right;
		Gizmos.DrawLine(Vector3.zero, vector);
		Vector3 vector2 = Mathf.Cos(0f - num) * Vector3.forward + Mathf.Sin(0f - num) * Vector3.right;
		Gizmos.DrawLine(Vector3.zero, vector2);
		float num2 = Mathf.Clamp(radius / 16f, 4f, 64f);
		float num3 = num / num2;
		for (float num4 = num; num4 > 0f; num4 -= num3)
		{
			Vector3 vector3 = Mathf.Cos(num4) * Vector3.forward + Mathf.Sin(num4) * Vector3.right;
			Gizmos.DrawLine(Vector3.zero, vector3);
			if (vector != Vector3.zero)
			{
				Gizmos.DrawLine(vector3, vector);
			}
			vector = vector3;
			Vector3 vector4 = Mathf.Cos(0f - num4) * Vector3.forward + Mathf.Sin(0f - num4) * Vector3.right;
			Gizmos.DrawLine(Vector3.zero, vector4);
			if (vector2 != Vector3.zero)
			{
				Gizmos.DrawLine(vector4, vector2);
			}
			vector2 = vector4;
		}
		Gizmos.DrawLine(vector, vector2);
	}

	public static void DrawArrowHead(Vector3 pos, Vector3 dir, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
	{
		Vector3 vector = Quaternion.LookRotation(dir) * Quaternion.Euler(arrowHeadAngle, 0f, 0f) * Vector3.back;
		Vector3 vector2 = Quaternion.LookRotation(dir) * Quaternion.Euler(0f - arrowHeadAngle, 0f, 0f) * Vector3.back;
		Vector3 vector3 = Quaternion.LookRotation(dir) * Quaternion.Euler(0f, arrowHeadAngle, 0f) * Vector3.back;
		Vector3 vector4 = Quaternion.LookRotation(dir) * Quaternion.Euler(0f, 0f - arrowHeadAngle, 0f) * Vector3.back;
		Gizmos.DrawRay(pos + dir, vector * arrowHeadLength);
		Gizmos.DrawRay(pos + dir, vector2 * arrowHeadLength);
		Gizmos.DrawRay(pos + dir, vector3 * arrowHeadLength);
		Gizmos.DrawRay(pos + dir, vector4 * arrowHeadLength);
	}

	public static void DrawMeshes(Transform transform)
	{
		MeshRenderer[] componentsInChildren = transform.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer meshRenderer in componentsInChildren)
		{
			if (!meshRenderer.enabled)
			{
				continue;
			}
			MeshFilter component = meshRenderer.GetComponent<MeshFilter>();
			if ((bool)component)
			{
				Transform transform2 = meshRenderer.transform;
				if (transform2 != null && component != null && component.sharedMesh != null && component.sharedMesh.normals != null && component.sharedMesh.normals.Length != 0)
				{
					Gizmos.DrawMesh(component.sharedMesh, transform2.position, transform2.rotation, transform2.lossyScale);
				}
			}
		}
	}

	public static void DrawBounds(Transform transform)
	{
		Bounds bounds = TransformEx.GetBounds(transform, includeRenderers: true, includeColliders: false);
		Vector3 lossyScale = transform.lossyScale;
		Quaternion rotation = transform.rotation;
		Vector3 pos = transform.position + rotation * Vector3.Scale(lossyScale, bounds.center);
		Vector3 size = Vector3.Scale(lossyScale, bounds.size);
		DrawCube(pos, size, rotation);
		DrawWireCube(pos, size, rotation);
	}
}
