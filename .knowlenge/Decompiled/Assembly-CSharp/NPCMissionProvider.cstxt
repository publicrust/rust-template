using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class NPCMissionProvider : NPCTalking, IMissionProvider
{
	public MissionManifest manifest;

	public GameObjectRef MarkerPrefab;

	public NetworkableId ProviderID()
	{
		return net.ID;
	}

	public Vector3 ProviderPosition()
	{
		return base.transform.position;
	}

	public BaseEntity Entity()
	{
		return this;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if (MarkerPrefab != null && MarkerPrefab.isValid)
		{
			List<BaseMission> obj = Pool.Get<List<BaseMission>>();
			ConversationData[] array = conversations;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].FindAllMissionAssignments(obj);
			}
			if (obj.Count > 0)
			{
				MapMarkerMissionProvider obj2 = GameManager.server.CreateEntity(MarkerPrefab.resourcePath, base.transform.position, base.transform.rotation) as MapMarkerMissionProvider;
				obj2.AssignMissions(obj, GetProviderToken());
				obj2.Spawn();
			}
			Pool.FreeUnmanaged(ref obj);
		}
	}

	private string GetProviderToken()
	{
		ConversationData[] array = conversations;
		int num = 0;
		if (num < array.Length)
		{
			return array[num].providerNameTranslated.token;
		}
		return string.Empty;
	}

	public override void OnConversationEnded(BasePlayer player)
	{
		player.ProcessMissionEvent(BaseMission.MissionEventType.CONVERSATION, ProviderID(), 0f);
		base.OnConversationEnded(player);
	}

	public override void OnConversationStarted(BasePlayer speakingTo)
	{
		speakingTo.ProcessMissionEvent(BaseMission.MissionEventType.CONVERSATION, ProviderID(), 1f);
		base.OnConversationStarted(speakingTo);
	}

	public bool ContainsSpeech(string speech)
	{
		ConversationData[] array = conversations;
		for (int i = 0; i < array.Length; i++)
		{
			ConversationData.SpeechNode[] speeches = array[i].speeches;
			for (int j = 0; j < speeches.Length; j++)
			{
				if (speeches[j].shortname == speech)
				{
					return true;
				}
			}
		}
		return false;
	}

	public string IntroOverride(string overrideSpeech)
	{
		if (!ContainsSpeech(overrideSpeech))
		{
			return "intro";
		}
		return overrideSpeech;
	}

	public override string GetConversationStartSpeech(BasePlayer player)
	{
		string text = "";
		foreach (BaseMission.MissionInstance mission in player.missions)
		{
			if (mission.status == BaseMission.MissionStatus.Active)
			{
				text = IntroOverride("missionactive");
			}
			if (mission.status == BaseMission.MissionStatus.Completed && mission.providerID == ProviderID() && Time.time - mission.endTime < 5f)
			{
				text = IntroOverride("missionreturn");
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			text = base.GetConversationStartSpeech(player);
		}
		return text;
	}

	public override void OnConversationAction(BasePlayer player, string action)
	{
		if (action.StartsWith("assignmission "))
		{
			int num = action.IndexOf(" ");
			BaseMission fromShortName = MissionManifest.GetFromShortName(action.Substring(num + 1));
			if ((bool)fromShortName)
			{
				BaseMission.AssignMission(player, this, fromShortName);
			}
		}
		base.OnConversationAction(player, action);
	}
}
