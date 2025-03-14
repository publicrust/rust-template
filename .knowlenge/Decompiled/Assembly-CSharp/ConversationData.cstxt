using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConversation", menuName = "Rust/ConversationData", order = 1)]
public class ConversationData : ScriptableObject
{
	[Serializable]
	public class ConversationCondition
	{
		public enum ConditionType
		{
			NONE,
			HASHEALTH,
			HASSCRAP,
			PROVIDERBUSY,
			MISSIONCOMPLETE,
			MISSIONATTEMPTED,
			CANACCEPT
		}

		public ConditionType conditionType;

		public uint conditionAmount;

		public bool inverse;

		public string failedSpeechNode;

		public bool Passes(BasePlayer player, IConversationProvider provider)
		{
			bool flag = false;
			if (conditionType == ConditionType.HASSCRAP)
			{
				flag = player.inventory.GetAmount(ItemManager.FindItemDefinition("scrap").itemid) >= conditionAmount;
			}
			else if (conditionType == ConditionType.HASHEALTH)
			{
				flag = player.health >= (float)conditionAmount;
			}
			else if (conditionType == ConditionType.PROVIDERBUSY)
			{
				flag = provider.ProviderBusy();
			}
			else if (conditionType == ConditionType.MISSIONCOMPLETE)
			{
				flag = player.HasCompletedMission(conditionAmount);
			}
			else if (conditionType == ConditionType.MISSIONATTEMPTED)
			{
				flag = player.HasAttemptedMission(conditionAmount);
			}
			else if (conditionType == ConditionType.CANACCEPT)
			{
				flag = player.CanAcceptMission(conditionAmount);
			}
			if (!inverse)
			{
				return flag;
			}
			return !flag;
		}
	}

	[Serializable]
	public class ResponseNode
	{
		public Translate.Phrase responseTextLocalized;

		public ConversationCondition[] conditions;

		public string actionString;

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
}
