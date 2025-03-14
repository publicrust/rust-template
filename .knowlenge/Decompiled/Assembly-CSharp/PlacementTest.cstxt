using UnityEngine;

public class PlacementTest : MonoBehaviour
{
	public MeshCollider myMeshCollider;

	public Transform testTransform;

	public Transform visualTest;

	public float hemisphere = 45f;

	public float clampTest = 45f;

	public float testDist = 2f;

	private float nextTest;

	public Vector3 RandomHemisphereDirection(Vector3 input, float degreesOffset)
	{
		degreesOffset = Mathf.Clamp(degreesOffset / 180f, -180f, 180f);
		Vector2 insideUnitCircle = Random.insideUnitCircle;
		Vector3 vector = new Vector3(insideUnitCircle.x * degreesOffset, Random.Range(-1f, 1f) * degreesOffset, insideUnitCircle.y * degreesOffset);
		return (input + vector).normalized;
	}

	public Vector3 RandomCylinderPointAroundVector(Vector3 input, float distance, float minHeight = 0f, float maxHeight = 0f)
	{
		Vector2 insideUnitCircle = Random.insideUnitCircle;
		Vector3 normalized = new Vector3(insideUnitCircle.x, 0f, insideUnitCircle.y).normalized;
		return new Vector3(normalized.x * distance, Random.Range(minHeight, maxHeight), normalized.z * distance);
	}

	public Vector3 ClampToHemisphere(Vector3 hemiInput, float degreesOffset, Vector3 inputVec)
	{
		degreesOffset = Mathf.Clamp(degreesOffset / 180f, -180f, 180f);
		Vector3 normalized = (hemiInput + Vector3.one * degreesOffset).normalized;
		Vector3 normalized2 = (hemiInput + Vector3.one * (0f - degreesOffset)).normalized;
		for (int i = 0; i < 3; i++)
		{
			inputVec[i] = Mathf.Clamp(inputVec[i], normalized2[i], normalized[i]);
		}
		return inputVec.normalized;
	}

	private void Update()
	{
		if (Time.realtimeSinceStartup < nextTest)
		{
			return;
		}
		nextTest = Time.realtimeSinceStartup + 0f;
		Vector3 position = RandomCylinderPointAroundVector(Vector3.up, 0.5f, 0.25f, 0.5f);
		position = base.transform.TransformPoint(position);
		testTransform.transform.position = position;
		if (testTransform != null && visualTest != null)
		{
			Vector3 position2 = base.transform.position;
			if (myMeshCollider.Raycast(new Ray(testTransform.position, (base.transform.position - testTransform.position).normalized), out var hitInfo, 5f))
			{
				position2 = hitInfo.point;
			}
			else
			{
				Debug.LogError("Missed");
			}
			visualTest.transform.position = position2;
		}
	}

	public void OnDrawGizmos()
	{
	}
}
