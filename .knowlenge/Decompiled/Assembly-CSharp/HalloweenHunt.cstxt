using System.Collections.Generic;
using ConVar;
using UnityEngine;

public class HalloweenHunt : EggHuntEvent
{
	public override void PrintWinnersAndAward()
	{
		List<EggHunter> topHunters = GetTopHunters();
		if (topHunters.Count > 0)
		{
			EggHunter eggHunter = topHunters[0];
			Chat.Broadcast(eggHunter.displayName + " is the top creep with " + eggHunter.numEggs + " candies collected.", "", "#eee", 0uL);
			for (int i = 0; i < topHunters.Count; i++)
			{
				EggHunter eggHunter2 = topHunters[i];
				BasePlayer basePlayer = BasePlayer.FindByID(eggHunter2.userid);
				if ((bool)basePlayer)
				{
					basePlayer.ChatMessage("You placed " + (i + 1) + " of " + topHunters.Count + " with " + topHunters[i].numEggs + " candies collected.");
				}
				else
				{
					Debug.LogWarning("EggHuntEvent Printwinners could not find player with id :" + eggHunter2.userid);
				}
			}
			for (int j = 0; j < placementAwards.Length && j < topHunters.Count; j++)
			{
				BasePlayer basePlayer2 = BasePlayer.FindByID(topHunters[j].userid);
				if ((bool)basePlayer2)
				{
					basePlayer2.inventory.GiveItem(ItemManager.Create(placementAwards[j].itemDef, (int)placementAwards[j].amount, 0uL), basePlayer2.inventory.containerMain);
					basePlayer2.ChatMessage("You received " + (int)placementAwards[j].amount + "x " + placementAwards[j].itemDef.displayName.english + " as an award!");
				}
			}
		}
		else
		{
			Chat.Broadcast("Wow, no one played so no one won.", "", "#eee", 0uL);
		}
	}
}
