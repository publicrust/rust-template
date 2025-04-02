using System.Collections.Generic;
using UnityEngine;

public class MetalDetectorSource : BaseEntity, IMetalDetectable
{
	[ServerVar(Help = "Population active on the server, per square km", ShowInAdminUI = true)]
	public static float Population = 1200f;

	[ServerVar]
	public static int AttemptsPerSubSourceSpawn = 5;

	[ServerVar]
	public static float MinDistanceBetweenSubSources = 1.5f;

	[ServerVar]
	public static float TimeoutDuration = 7200f;

	public static int ServerCount = 0;

	[ClientVar(Saved = true)]
	public static bool DrawEditorGizmos = false;

	public int MinSources = 2;

	public int MaxSources = 5;

	public float SpawnRadiusMin = 4f;

	public float SpawnRadiusMax = 6f;

	public float SpawnRadiusBuffer = 1f;

	public GameObjectRef FlagPrefab;

	public GameObjectRef EffectPrefab;

	public const int placementMask = 8388608;

	public const int blockMask = 1075904769;

	public float SpawnRadius { get; private set; }

	public List<Vector3> SpawnLocations { get; private set; } = new List<Vector3>();

	[ServerVar]
	public static void ServerCountSources()
	{
		Debug.Log("Server sources: " + ServerCount);
	}

	public override void ServerInit()
	{
		base.ServerInit();
		base.limitNetworking = true;
		ServerCount++;
		SpawnRadius = Random.Range(SpawnRadiusMin, SpawnRadiusMax);
		ResetTimeout();
		Invoke(SpawnSources, Random.Range(0.1f, 1.5f));
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		ServerCount--;
	}

	private void SpawnSources()
	{
		SpawnLocations.Clear();
		int num = Random.Range(MinSources, MaxSources);
		for (int i = 0; i < num; i++)
		{
			TrySpawnSource();
		}
		KillIfNoSources();
		SendNetworkUpdate();
	}

	private void TrySpawnSource()
	{
		bool flag = true;
		int num = 0;
		while (flag)
		{
			Vector3 vector = Random.insideUnitCircle;
			Vector3 pos = base.transform.position + new Vector3(vector.x, 0f, vector.y) * (SpawnRadius - SpawnRadiusBuffer);
			bool num2 = ValidateSourcePosition(ref pos);
			if (num2)
			{
				AddSource(pos);
			}
			flag = !num2 && ++num < AttemptsPerSubSourceSpawn;
		}
	}

	private bool ValidateSourcePosition(ref Vector3 pos)
	{
		if (Physics.Raycast(pos + Vector3.up, Vector3.down, out var hitInfo, 4f, 8388608))
		{
			foreach (Vector3 spawnLocation in SpawnLocations)
			{
				if (Vector3.SqrMagnitude(hitInfo.point - spawnLocation) < MinDistanceBetweenSubSources * MinDistanceBetweenSubSources)
				{
					return false;
				}
			}
			if (!GamePhysics.LineOfSight(hitInfo.point, hitInfo.point + Vector3.up * 4f, 1075904769))
			{
				return false;
			}
			if (!GamePhysics.LineOfSight(base.transform.position, hitInfo.point, 1075904769))
			{
				return false;
			}
			pos = hitInfo.point;
			return true;
		}
		return false;
	}

	private void ResetTimeout()
	{
		CancelInvoke(Timeout);
		Invoke(Timeout, TimeoutDuration * Random.Range(0.8f, 1.2f));
	}

	private void Timeout()
	{
		Kill();
	}

	private void KillIfNoSources()
	{
		if (SpawnLocations.Count == 0)
		{
			Kill();
		}
	}

	private void AddSource(Vector3 pos)
	{
		SpawnLocations.Add(pos);
	}

	private void RemoveSource(Vector3 pos)
	{
		SpawnLocations.Remove(pos);
		KillIfNoSources();
	}

	public Vector3 FindNearestSubSource(Vector3 scanPosition)
	{
		float num = float.PositiveInfinity;
		Vector3 result = scanPosition;
		foreach (Vector3 spawnLocation in SpawnLocations)
		{
			float num2 = Vector3.SqrMagnitude(scanPosition - spawnLocation);
			if (num2 < num)
			{
				num = num2;
				result = spawnLocation;
			}
		}
		return result;
	}

	public void RemoveSweetSpotAndCreateFlag(Vector3 position)
	{
		bool flag = false;
		for (int num = SpawnLocations.Count - 1; num >= 0; num--)
		{
			Vector3 vector = SpawnLocations[num];
			if (Vector3.SqrMagnitude(position - vector) <= 0.040000003f)
			{
				RemoveSource(vector);
				CreateFlag(vector);
				flag = true;
			}
		}
		if (flag)
		{
			SendNetworkUpdateImmediate();
		}
	}

	private void CreateFlag(Vector3 pos)
	{
		GameManager.server.CreateEntity(FlagPrefab.resourcePath, pos, Quaternion.Euler(0f, Random.Range(0, 360), 0f)).Spawn();
		Effect.server.Run(EffectPrefab.resourcePath, pos + Vector3.up * 0.1f, Vector3.up);
	}

	public bool VerifySweetSpotPosition(Vector3 playerPos, Vector3 pos, out Vector3 spotPos)
	{
		spotPos = playerPos;
		if (Vector3.SqrMagnitude(playerPos - pos) >= 4f)
		{
			return false;
		}
		foreach (Vector3 spawnLocation in SpawnLocations)
		{
			if (Vector3.SqrMagnitude(pos - spawnLocation) <= 0.25f)
			{
				spotPos = spawnLocation;
				return true;
			}
		}
		return false;
	}

	public List<Vector3> GetScanLocations()
	{
		return SpawnLocations;
	}

	public Vector3 GetNearestPosition(Vector3 pos)
	{
		return FindNearestSubSource(pos);
	}

	public bool VerifyScanPosition(Vector3 playerPos, Vector3 pos, out Vector3 spotPos)
	{
		return VerifySweetSpotPosition(playerPos, pos, out spotPos);
	}

	public void Detected(Vector3 pos)
	{
		RemoveSweetSpotAndCreateFlag(pos);
	}

	public float GetRadius()
	{
		return SpawnRadius;
	}
}
