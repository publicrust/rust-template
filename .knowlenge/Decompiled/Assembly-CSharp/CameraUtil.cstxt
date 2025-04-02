using UnityEngine;

public static class CameraUtil
{
	public static void NormalizePlane(ref Plane plane)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		Vector3 normal = ((Plane)(ref plane)).normal;
		float num = 1f / ((Vector3)(ref normal)).magnitude;
		((Plane)(ref plane)).normal = ((Plane)(ref plane)).normal * num;
		((Plane)(ref plane)).distance = ((Plane)(ref plane)).distance * num;
	}

	public static void ExtractPlanes(Camera camera, ref Plane[] planes)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		Matrix4x4 worldToCameraMatrix = camera.worldToCameraMatrix;
		ExtractPlanes(GL.GetGPUProjectionMatrix(camera.projectionMatrix, false) * worldToCameraMatrix, ref planes);
	}

	public static void ExtractPlanes(Matrix4x4 viewProjMatrix, ref Plane[] planes)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		((Plane)(ref planes[0])).normal = new Vector3(viewProjMatrix.m30 + viewProjMatrix.m00, viewProjMatrix.m31 + viewProjMatrix.m01, viewProjMatrix.m32 + viewProjMatrix.m02);
		((Plane)(ref planes[0])).distance = viewProjMatrix.m33 + viewProjMatrix.m03;
		NormalizePlane(ref planes[0]);
		((Plane)(ref planes[1])).normal = new Vector3(viewProjMatrix.m30 - viewProjMatrix.m00, viewProjMatrix.m31 - viewProjMatrix.m01, viewProjMatrix.m32 - viewProjMatrix.m02);
		((Plane)(ref planes[1])).distance = viewProjMatrix.m33 - viewProjMatrix.m03;
		NormalizePlane(ref planes[1]);
		((Plane)(ref planes[2])).normal = new Vector3(viewProjMatrix.m30 - viewProjMatrix.m10, viewProjMatrix.m31 - viewProjMatrix.m11, viewProjMatrix.m32 - viewProjMatrix.m12);
		((Plane)(ref planes[2])).distance = viewProjMatrix.m33 - viewProjMatrix.m13;
		NormalizePlane(ref planes[2]);
		((Plane)(ref planes[3])).normal = new Vector3(viewProjMatrix.m30 + viewProjMatrix.m10, viewProjMatrix.m31 + viewProjMatrix.m11, viewProjMatrix.m32 + viewProjMatrix.m12);
		((Plane)(ref planes[3])).distance = viewProjMatrix.m33 + viewProjMatrix.m13;
		NormalizePlane(ref planes[3]);
		((Plane)(ref planes[4])).normal = new Vector3(viewProjMatrix.m20, viewProjMatrix.m21, viewProjMatrix.m22);
		((Plane)(ref planes[4])).distance = viewProjMatrix.m23;
		NormalizePlane(ref planes[4]);
		((Plane)(ref planes[5])).normal = new Vector3(viewProjMatrix.m30 - viewProjMatrix.m20, viewProjMatrix.m31 - viewProjMatrix.m21, viewProjMatrix.m32 - viewProjMatrix.m22);
		((Plane)(ref planes[5])).distance = viewProjMatrix.m33 - viewProjMatrix.m23;
		NormalizePlane(ref planes[5]);
	}
}
