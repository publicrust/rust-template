public interface IFuelSystem
{
	bool HasValidInstance(bool isServer);

	NetworkableId GetInstanceID();

	void SetInstanceID(NetworkableId uid);

	bool CheckNewChild(BaseEntity child);

	int GetFuelAmount();

	float GetFuelFraction();

	bool HasFuel(bool forceCheck = false);

	int TryUseFuel(float seconds, float fuelUsedPerSecond);

	int GetFuelCapacity();

	void LootFuel(BasePlayer player);

	void AddFuel(int amount);

	void RemoveFuel(int amount);

	void FillFuel();
}
