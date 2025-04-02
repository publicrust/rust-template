using UnityEngine;

public class AICoverPointTool : MonoBehaviour
{
	private struct TestResult
	{
		public Vector3 Position;

		public bool Valid;

		public bool Forward;

		public bool Right;

		public bool Backward;

		public bool Left;
	}

	[ContextMenu("Place Cover Points")]
	public void PlaceCoverPoints()
	{
		foreach (Transform item in base.transform)
		{
			Object.DestroyImmediate(item.gameObject);
		}
		Vector3 pos = new Vector3(base.transform.position.x - 50f, base.transform.position.y, base.transform.position.z - 50f);
		for (int i = 0; i < 50; i++)
		{
			for (int j = 0; j < 50; j++)
			{
				TestResult result = TestPoint(pos);
				if (result.Valid)
				{
					PlacePoint(result);
				}
				pos.x += 2f;
			}
			pos.x -= 100f;
			pos.z += 2f;
		}
	}

	private TestResult TestPoint(Vector3 pos)
	{
		pos.y += 0.5f;
		TestResult result = default(TestResult);
		result.Position = pos;
		if (HitsCover(new Ray(pos, Vector3.forward), 1218519041, 1f))
		{
			result.Forward = true;
			result.Valid = true;
		}
		if (HitsCover(new Ray(pos, Vector3.right), 1218519041, 1f))
		{
			result.Right = true;
			result.Valid = true;
		}
		if (HitsCover(new Ray(pos, Vector3.back), 1218519041, 1f))
		{
			result.Backward = true;
			result.Valid = true;
		}
		if (HitsCover(new Ray(pos, Vector3.left), 1218519041, 1f))
		{
			result.Left = true;
			result.Valid = true;
		}
		return result;
	}

	private void PlacePoint(TestResult result)
	{
		if (result.Forward)
		{
			PlacePoint(result.Position, Vector3.forward);
		}
		if (result.Right)
		{
			PlacePoint(result.Position, Vector3.right);
		}
		if (result.Backward)
		{
			PlacePoint(result.Position, Vector3.back);
		}
		if (result.Left)
		{
			PlacePoint(result.Position, Vector3.left);
		}
	}

	private void PlacePoint(Vector3 pos, Vector3 dir)
	{
		AICoverPoint aICoverPoint = new GameObject("CP").AddComponent<AICoverPoint>();
		aICoverPoint.transform.position = pos;
		aICoverPoint.transform.forward = dir;
		aICoverPoint.transform.SetParent(base.transform);
	}

	public bool HitsCover(Ray ray, int layerMask, float maxDistance)
	{
		if (ray.origin.IsNaNOrInfinity())
		{
			return false;
		}
		if (ray.direction.IsNaNOrInfinity())
		{
			return false;
		}
		if (ray.direction == Vector3.zero)
		{
			return false;
		}
		if (GamePhysics.Trace(ray, 0f, out var _, maxDistance, layerMask))
		{
			return true;
		}
		return false;
	}
}
