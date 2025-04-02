using System.Collections.Generic;
using Spatial;
using UnityEngine;

public class SmokeGrenadeManager : SingletonComponent<SmokeGrenadeManager>
{
	private const float worldSize = 8096f;

	private const int cellSize = 32;

	private Grid<BaseEntity> smokeGrid = new Grid<BaseEntity>(32, 8096f);

	public void Add(BaseEntity smoke)
	{
		if (IsSmokeGrenade(smoke))
		{
			smokeGrid.Add(smoke, smoke.transform.position.x, smoke.transform.position.z);
		}
	}

	public void Move(BaseEntity smoke)
	{
		using (TimeWarning.New("SmokeGrenadeManager.Move"))
		{
			if (IsSmokeGrenade(smoke))
			{
				Vector3 position = smoke.transform.position;
				smokeGrid.Move(smoke, position.x, position.z);
			}
		}
	}

	public void Remove(BaseEntity smoke)
	{
		if (IsSmokeGrenade(smoke))
		{
			smokeGrid.Remove(smoke);
		}
	}

	public void GetSmokeAround(Vector3 position, float range, List<BaseEntity> results)
	{
		using (TimeWarning.New("SmokeGrenadeManager.GetSmokeAround"))
		{
			if (smokeGrid != null)
			{
				smokeGrid.Query(position.x, position.z, range, results);
			}
		}
	}

	public static bool IsSmokeGrenade(BaseEntity entity)
	{
		if (entity is SmokeGrenade)
		{
			return true;
		}
		return false;
	}
}
