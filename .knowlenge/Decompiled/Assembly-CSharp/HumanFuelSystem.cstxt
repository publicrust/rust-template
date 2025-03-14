using UnityEngine;

public class HumanFuelSystem : IFuelSystem
{
	private readonly bool isServer;

	private float percentFood;

	private EntityRef<BaseVehicle> vehilceRef;

	private float pendingFuel;

	public HumanFuelSystem(bool isServer, BaseVehicle owner, float percentFood)
	{
		this.isServer = isServer;
		this.percentFood = Mathf.Clamp01(percentFood);
		vehilceRef.Set(owner);
	}

	public bool HasValidInstance(bool isServer)
	{
		return vehilceRef.IsValid(isServer);
	}

	public NetworkableId GetInstanceID()
	{
		return vehilceRef.uid;
	}

	public void SetInstanceID(NetworkableId uid)
	{
		vehilceRef.uid = uid;
	}

	private BaseVehicle GetVehilce()
	{
		BaseVehicle baseVehicle = vehilceRef.Get(isServer);
		if (baseVehicle.IsValid())
		{
			return baseVehicle;
		}
		return null;
	}

	public int GetFuelCapacity()
	{
		return 0;
	}

	public bool CheckNewChild(BaseEntity child)
	{
		return false;
	}

	public int GetFuelAmount()
	{
		if (TryGetHuman(out var driver))
		{
			float value = driver.metabolism.calories.value;
			float value2 = driver.metabolism.hydration.value;
			return Mathf.FloorToInt(value + value2);
		}
		return 0;
	}

	public float GetFuelFraction()
	{
		if (TryGetHuman(out var driver))
		{
			float num = driver.metabolism.calories.Fraction() * percentFood;
			float num2 = driver.metabolism.hydration.Fraction() * (1f - percentFood);
			return num + num2;
		}
		return 0f;
	}

	public bool HasFuel(bool forceCheck = false)
	{
		if (!TryGetHuman(out var driver))
		{
			return false;
		}
		if (percentFood == 0f)
		{
			return driver.metabolism.hydration.Fraction() > 0f;
		}
		if (percentFood == 1f)
		{
			return driver.metabolism.calories.Fraction() > 0f;
		}
		if (!(driver.metabolism.hydration.Fraction() > 0f))
		{
			return driver.metabolism.calories.Fraction() > 0f;
		}
		return true;
	}

	public int TryUseFuel(float seconds, float fuelUsedPerSecond)
	{
		if (!TryGetHuman(out var driver))
		{
			return 0;
		}
		pendingFuel += seconds + fuelUsedPerSecond;
		if (pendingFuel >= 1f)
		{
			MetabolismAttribute calories = driver.metabolism.calories;
			MetabolismAttribute hydration = driver.metabolism.hydration;
			float val = fuelUsedPerSecond * percentFood;
			float val2 = fuelUsedPerSecond * (1f - percentFood);
			float value = calories.value;
			calories.Subtract(val);
			pendingFuel -= Mathf.RoundToInt(value - calories.value);
			float value2 = hydration.value;
			hydration.Subtract(val2);
			pendingFuel -= Mathf.RoundToInt(value2 - hydration.value);
		}
		return 0;
	}

	public void LootFuel(BasePlayer player)
	{
	}

	public void AddFuel(int amount)
	{
	}

	public void RemoveFuel(int amount)
	{
	}

	public void FillFuel()
	{
	}

	private bool TryGetHuman(out BasePlayer driver)
	{
		driver = null;
		BaseVehicle vehilce = GetVehilce();
		if (vehilce != null)
		{
			driver = vehilce.GetDriver();
		}
		return driver != null;
	}
}
