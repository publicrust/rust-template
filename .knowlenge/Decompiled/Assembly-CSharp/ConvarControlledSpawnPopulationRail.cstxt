using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class ConvarControlledSpawnPopulationRail : ConvarControlledSpawnPopulation
{
	private const float MIN_MARGIN = 75f;

	public override bool GetSpawnPosOverride(Prefab<Spawnable> prefab, ref Vector3 newPos, ref Quaternion newRot)
	{
		if (TrainTrackSpline.SidingSplines.Count <= 0)
		{
			return false;
		}
		TrainCar component = prefab.Object.GetComponent<TrainCar>();
		if (component == null)
		{
			Debug.LogError(GetType().Name + ": Train prefab has no TrainCar component: " + prefab.Object.name);
			return false;
		}
		int num = 0;
		foreach (TrainTrackSpline sidingSpline in TrainTrackSpline.SidingSplines)
		{
			if (sidingSpline.HasAnyUsersOfType(TrainCar.TrainCarType.Engine))
			{
				num++;
			}
		}
		bool flag = component.CarType == TrainCar.TrainCarType.Engine;
		int num2 = 0;
		while (num2 < 20)
		{
			num2++;
			TrainTrackSpline trainTrackSpline = null;
			if (flag)
			{
				foreach (TrainTrackSpline sidingSpline2 in TrainTrackSpline.SidingSplines)
				{
					if (!sidingSpline2.HasAnyUsersOfType(TrainCar.TrainCarType.Engine))
					{
						trainTrackSpline = sidingSpline2;
						break;
					}
				}
			}
			if (trainTrackSpline == null)
			{
				int index = Random.Range(0, TrainTrackSpline.SidingSplines.Count);
				trainTrackSpline = TrainTrackSpline.SidingSplines[index];
			}
			if (trainTrackSpline != null && TryGetRandomPointOnSpline(trainTrackSpline, component, out newPos, out newRot))
			{
				return true;
			}
		}
		return false;
	}

	public override void SubFill(SpawnHandler spawnHandler, SpawnDistribution distribution, int numToFill, bool initialSpawn)
	{
		base.SubFill(spawnHandler, distribution, numToFill, initialSpawn);
		List<Prefab<Spawnable>> obj = Pool.Get<List<Prefab<Spawnable>>>();
		Prefab<Spawnable>[] prefabs = Prefabs;
		foreach (Prefab<Spawnable> prefab in prefabs)
		{
			TrainCar component = prefab.Object.GetComponent<TrainCar>();
			if (component != null && component.CarType == TrainCar.TrainCarType.Engine)
			{
				obj.Add(prefab);
			}
		}
		foreach (TrainTrackSpline sidingSpline in TrainTrackSpline.SidingSplines)
		{
			if (sidingSpline.HasAnyUsersOfType(TrainCar.TrainCarType.Engine))
			{
				continue;
			}
			int num = Random.Range(0, obj.Count);
			Prefab<Spawnable> prefab2 = Prefabs[num];
			TrainCar component2 = prefab2.Object.GetComponent<TrainCar>();
			if (component2 == null)
			{
				continue;
			}
			int num2 = 0;
			while (num2 < 20)
			{
				num2++;
				if (TryGetRandomPointOnSpline(sidingSpline, component2, out var pos, out var rot))
				{
					spawnHandler.Spawn(this, prefab2, pos, rot);
					break;
				}
			}
		}
		Pool.FreeUnmanaged(ref obj);
	}

	protected override float GetPrefabWeight(Prefab<Spawnable> prefab)
	{
		float num = (prefab.Parameters ? prefab.Parameters.Count : 1f);
		TrainCar component = prefab.Object.GetComponent<TrainCar>();
		if (component != null)
		{
			if (component.CarType == TrainCar.TrainCarType.Wagon)
			{
				num *= (float)TrainCar.wagons_per_engine;
			}
		}
		else
		{
			Debug.LogError(GetType().Name + ": No TrainCar script on train prefab " + prefab.Object.name);
		}
		return num;
	}

	private bool TryGetRandomPointOnSpline(TrainTrackSpline spline, TrainCar trainCar, out Vector3 pos, out Quaternion rot)
	{
		float length = spline.GetLength();
		if (length < 80f)
		{
			pos = Vector3.zero;
			rot = Quaternion.identity;
			return false;
		}
		float distance = Random.Range(75f, length - 75f);
		pos = spline.GetPointAndTangentCubicHermiteWorld(distance, out var tangent) + Vector3.up * 0.5f;
		rot = Quaternion.LookRotation(tangent);
		float radius = trainCar.bounds.extents.Max();
		List<Collider> obj = Pool.Get<List<Collider>>();
		GamePhysics.OverlapSphere(pos, radius, obj, 32768);
		bool result = true;
		foreach (Collider item in obj)
		{
			if (!trainCar.ColliderIsPartOfTrain(item))
			{
				result = false;
				break;
			}
		}
		Pool.FreeUnmanaged(ref obj);
		return result;
	}
}
