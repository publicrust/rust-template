using UnityEngine;

[CreateAssetMenu(menuName = "Rust/MissionManifest")]
public class MissionManifest : ScriptableObject
{
	public ScriptableObjectRef[] missionList;

	public WorldPositionGenerator[] positionGenerators;

	public static MissionManifest instance;

	public static MissionManifest Get()
	{
		if (instance == null)
		{
			instance = Resources.Load<MissionManifest>("MissionManifest");
			WorldPositionGenerator[] array = instance.positionGenerators;
			foreach (WorldPositionGenerator worldPositionGenerator in array)
			{
				if (worldPositionGenerator != null)
				{
					worldPositionGenerator.PrecalculatePositions();
				}
			}
		}
		return instance;
	}

	public static BaseMission GetFromShortName(string shortname)
	{
		ScriptableObjectRef[] array = Get().missionList;
		for (int i = 0; i < array.Length; i++)
		{
			BaseMission baseMission = array[i].Get() as BaseMission;
			if (baseMission.shortname == shortname)
			{
				return baseMission;
			}
		}
		return null;
	}

	public static BaseMission GetFromID(uint id)
	{
		MissionManifest missionManifest = Get();
		if (missionManifest.missionList == null)
		{
			return null;
		}
		ScriptableObjectRef[] array = missionManifest.missionList;
		for (int i = 0; i < array.Length; i++)
		{
			BaseMission baseMission = array[i].Get() as BaseMission;
			if (baseMission.id == id)
			{
				return baseMission;
			}
		}
		return null;
	}
}
