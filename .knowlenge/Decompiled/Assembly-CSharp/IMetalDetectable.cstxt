using System.Collections.Generic;
using UnityEngine;

public interface IMetalDetectable
{
	List<Vector3> GetScanLocations();

	Vector3 GetNearestPosition(Vector3 pos);

	bool VerifyScanPosition(Vector3 playerPos, Vector3 pos, out Vector3 spotPos);

	void Detected(Vector3 pos);

	float GetRadius();
}
