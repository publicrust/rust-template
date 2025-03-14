public class SocketMod_EnvironmentVolume : SocketMod
{
	[InspectorFlags]
	public EnvironmentType environmentNone;

	public override bool DoCheck(Construction.Placement place)
	{
		EnvironmentType environmentType = EnvironmentManager.Get(place.position + place.rotation * worldPosition);
		if (environmentNone != 0 && (environmentType & environmentNone) != 0)
		{
			EnvironmentType blockedTypes = environmentType & environmentNone;
			Construction.lastPlacementError = GetErrorMessage(blockedTypes);
			return false;
		}
		return true;
	}

	private string GetErrorMessage(EnvironmentType blockedTypes)
	{
		string text = "Can't be placed ";
		if (blockedTypes.HasFlag(EnvironmentType.TrainTunnels))
		{
			return text + "In Train Tunnels";
		}
		if (blockedTypes.HasFlag(EnvironmentType.Underground))
		{
			return text + "Underground";
		}
		if (blockedTypes.HasFlag(EnvironmentType.NoSunlight))
		{
			return text + "In The Dark";
		}
		if (blockedTypes.HasFlag(EnvironmentType.Submarine))
		{
			return text + "In A Submarine";
		}
		if (blockedTypes.HasFlag(EnvironmentType.Outdoor))
		{
			return text + "Outdoors";
		}
		if (blockedTypes.HasFlag(EnvironmentType.PlayerConstruction))
		{
			return text + "Near Player Construction";
		}
		if (blockedTypes.HasFlag(EnvironmentType.UnderwaterLab))
		{
			return text + "In Underwater Labs";
		}
		if (blockedTypes.HasFlag(EnvironmentType.Elevator))
		{
			return text + "Near Elevators";
		}
		if (blockedTypes.HasFlag(EnvironmentType.Building) || blockedTypes.HasFlag(EnvironmentType.BuildingDark) || blockedTypes.HasFlag(EnvironmentType.BuildingVeryDark))
		{
			return text + "In A Building";
		}
		return text + "(Unknown Environment)";
	}
}
