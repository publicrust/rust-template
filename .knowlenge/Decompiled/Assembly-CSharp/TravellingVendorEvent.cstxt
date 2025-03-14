using UnityEngine;

public class TravellingVendorEvent : TriggeredEvent
{
	public Translate.Phrase spawnPhrase;

	public static TravellingVendor currentVendor = null;

	public static float dontSpawnHoursBeforeWipe = 24f;

	public override void RunEvent()
	{
		if (currentVendor != null || TerrainMeta.Path == null || TerrainMeta.Path.Roads.Count == 0 || !TravellingVendor.should_spawn || RoadBradleys.StaticBradleyCount > 0)
		{
			return;
		}
		TravellingVendor travellingVendor = TravellingVendor.SpawnTravellingVendorForEvent();
		if ((bool)travellingVendor)
		{
			Debug.Log("[event] assets/prefabs/npc/travelling vendor/travellingvendor.prefab");
			currentVendor = travellingVendor;
			{
				foreach (BasePlayer activePlayer in BasePlayer.activePlayerList)
				{
					if ((bool)activePlayer && activePlayer.IsConnected && !activePlayer.IsInTutorial)
					{
						activePlayer.ShowToast(GameTip.Styles.Server_Event, spawnPhrase, false);
					}
				}
				return;
			}
		}
		Debug.Log("Failed to spawn travelling vendor.");
	}

	private bool HoursCheck()
	{
		if (WipeTimer.serverinstance.GetTimeSpanUntilWipe().TotalHours > (double)dontSpawnHoursBeforeWipe)
		{
			return true;
		}
		return false;
	}
}
