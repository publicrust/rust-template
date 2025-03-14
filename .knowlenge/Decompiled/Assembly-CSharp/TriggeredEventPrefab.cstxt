using Oxide.Core;
using UnityEngine;

public class TriggeredEventPrefab : TriggeredEvent
{
	public GameObjectRef targetPrefab;

	public bool shouldBroadcastSpawn;

	public Translate.Phrase spawnPhrase;

	private void RunEvent()
	{
		if (Interface.CallHook("OnEventTrigger", this) != null)
		{
			return;
		}
		Debug.Log("[event] " + targetPrefab.resourcePath);
		BaseEntity baseEntity = GameManager.server.CreateEntity(targetPrefab.resourcePath);
		if (!baseEntity)
		{
			return;
		}
		baseEntity.SendMessage("TriggeredEventSpawn", SendMessageOptions.DontRequireReceiver);
		baseEntity.Spawn();
		if (!shouldBroadcastSpawn)
		{
			return;
		}
		foreach (BasePlayer activePlayer in BasePlayer.activePlayerList)
		{
			if ((bool)activePlayer && activePlayer.IsConnected)
			{
				activePlayer.ShowToast(GameTip.Styles.Server_Event, spawnPhrase);
			}
		}
	}
}
