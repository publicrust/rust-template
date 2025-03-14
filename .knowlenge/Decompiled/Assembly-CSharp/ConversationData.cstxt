using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConversation", menuName = "Rust/ConversationData", order = 1)]
public class ConversationData : ScriptableObject
{
	[Serializable]
	public class ConversationCondition
	{
		public enum ConditionType
		{
			None,
			HasHealth,
			HasScrap,
			ProviderBusy,
			MissionComplete,
			MissionAttempted,
			CanAccept
		}

		public ConditionType conditionType;

		public uint conditionAmount;

		public BaseMission conditionMission;

		public bool inverse;

		public string failedSpeechNode;

		public bool Passes(BasePlayer player, IConversationProvider provider)
		{
			bool flag = false;
			if (conditionType == ConditionType.HasScrap)
			{
				flag = player.inventory.GetAmount(ItemManager.FindItemDefinition("scrap").itemid) >= conditionAmount;
			}
			else if (conditionType == ConditionType.HasHealth)
			{
				flag = player.health >= (float)conditionAmount;
			}
			else if (conditionType == ConditionType.ProviderBusy)
			{
				flag = provider.ProviderBusy();
			}
			else if (conditionType == ConditionType.MissionComplete)
			{
				flag = player.HasCompletedMission(MissionID());
			}
			else if (conditionType == ConditionType.MissionAttempted)
			{
				flag = player.HasAttemptedMission(MissionID());
			}
			else if (conditionType == ConditionType.CanAccept)
			{
				flag = player.CanAcceptMission(MissionID());
			}
			if (!inverse)
			{
				return flag;
			}
			return !flag;
		}

		private uint MissionID()
		{
			if (!(conditionMission != null))
			{
				return conditionAmount;
			}
			return conditionMission.id;
		}
	}

	[Serializable]
	public class ResponseNode
	{
		public enum ActionType
		{
			Custom,
			None,
			AssignMission
		}

		public Translate.Phrase responseTextLocalized;

		public ConversationCondition[] conditions;

		public ActionType actionType;

		public string actionString;

		public BaseMission actionMission;

		public string resultingSpeechNode;

		public string responseText => responseTextLocalized.translated;

		public bool PassesConditions(BasePlayer player, IConversationProvider provider)
		{
			ConversationCondition[] array = conditions;
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].Passes(player, provider))
				{
					return false;
				}
			}
			return true;
		}

		public string GetFailedSpeechNode(BasePlayer player, IConversationProvider provider)
		{
			ConversationCondition[] array = conditions;
			foreach (ConversationCondition conversationCondition in array)
			{
				if (!conversationCondition.Passes(player, provider))
				{
					return conversationCondition.failedSpeechNode;
				}
			}
			return "";
		}

		public string GetActionString()
		{
			switch (actionType)
			{
			case ActionType.None:
				return "";
			case ActionType.Custom:
				return actionString ?? "";
			case ActionType.AssignMission:
				if (!(actionMission != null) || string.IsNullOrWhiteSpace(actionMission.shortname))
				{
					return "";
				}
				return "assignmission " + actionMission.shortname;
			default:
				Debug.LogWarning($"Cannot get conversation action string! Unhandled action type: {actionType}");
				return "";
			}
		}
	}

	[Serializable]
	public class SpeechNode
	{
		public string shortname;

		public Translate.Phrase statementLocalized;

		public ResponseNode[] responses;

		public Vector2 nodePosition;

		public string statement => statementLocalized.translated;
	}

	public string shortname;

	public Translate.Phrase providerNameTranslated;

	public Sprite providerIcon;

	public bool canBeCancelled = true;

	public SpeechNode[] speeches;

	public string providerName => providerNameTranslated.translated;

	public int GetSpeechNodeIndex(string speechShortName)
	{
		for (int i = 0; i < speeches.Length; i++)
		{
			if (speeches[i].shortname == speechShortName)
			{
				return i;
			}
		}
		return -1;
	}

	public void FindAllMissionAssignments(List<BaseMission> results)
	{
		SpeechNode[] array = speeches;
		for (int i = 0; i < array.Length; i++)
		{
			ResponseNode[] responses = array[i].responses;
			foreach (ResponseNode responseNode in responses)
			{
				if (responseNode.actionType == ResponseNode.ActionType.AssignMission && responseNode.actionMission != null)
				{
					results.Add(responseNode.actionMission);
				}
			}
		}
	}
}
