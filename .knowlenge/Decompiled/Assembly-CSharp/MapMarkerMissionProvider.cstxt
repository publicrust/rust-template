using System.Collections.Generic;
using Facepunch;
using ProtoBuf;

public class MapMarkerMissionProvider : MapMarker
{
	private List<BaseMission> missionsProvided = new List<BaseMission>();

	private string providerToken = string.Empty;

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.missionMapMarker == null)
		{
			return;
		}
		if (info.msg.missionMapMarker.missionIds != null)
		{
			missionsProvided.Clear();
			foreach (uint missionId in info.msg.missionMapMarker.missionIds)
			{
				BaseMission fromID = MissionManifest.GetFromID(missionId);
				if (fromID != null)
				{
					missionsProvided.Add(fromID);
				}
			}
		}
		providerToken = info.msg.missionMapMarker.providerToken;
	}

	public void AssignMissions(List<BaseMission> missions, string token)
	{
		missionsProvided.Clear();
		foreach (BaseMission mission in missions)
		{
			missionsProvided.Add(mission);
		}
		providerToken = token;
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.missionMapMarker = Pool.Get<ProtoBuf.MissionMapMarker>();
		info.msg.missionMapMarker.missionIds = Pool.Get<List<uint>>();
		foreach (BaseMission item in missionsProvided)
		{
			info.msg.missionMapMarker.missionIds.Add(item.id);
		}
		info.msg.missionMapMarker.providerToken = providerToken;
	}
}
