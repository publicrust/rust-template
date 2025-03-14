using System.Collections.Generic;
using Spatial;
using UnityEngine;

public class NpcFoodManager : SingletonComponent<NpcFoodManager>, IServerComponent
{
	private const float worldSize = 8096f;

	private const int cellSize = 32;

	private Grid<BaseEntity> foodGrid = new Grid<BaseEntity>(32, 8096f);

	public void Add(BaseEntity food)
	{
		if (IsFood(food))
		{
			foodGrid.Add(food, food.transform.position.x, food.transform.position.z);
		}
	}

	public void Move(BaseEntity food)
	{
		using (TimeWarning.New("NpcFoodManager.Move"))
		{
			if (IsFood(food))
			{
				Vector3 position = food.transform.position;
				foodGrid.Move(food, position.x, position.z);
			}
		}
	}

	public void Remove(BaseEntity food)
	{
		if (IsFood(food))
		{
			foodGrid.Remove(food);
		}
	}

	public void GetFoodAround(Vector3 position, float range, List<BaseEntity> results)
	{
		using (TimeWarning.New("NpcFoodManager.GetFoodAround"))
		{
			if (foodGrid != null)
			{
				foodGrid.Query(position.x, position.z, range, results);
			}
		}
	}

	public static bool IsFood(BaseEntity entity)
	{
		if (entity is DroppedItem droppedItem)
		{
			if (droppedItem.item == null)
			{
				return false;
			}
			return droppedItem.item.info.Traits.HasFlag(BaseEntity.TraitFlag.Meat);
		}
		return entity is BaseCorpse;
	}

	public static bool IsFoodImmobile(BaseEntity entity)
	{
		if (entity is DroppedItem { IsSleeping: not false })
		{
			return true;
		}
		if (entity is BaseCorpse { IsSleeping: not false })
		{
			return true;
		}
		return false;
	}
}
