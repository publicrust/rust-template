using UnityEngine;

public class TriggeredEventPrefab : TriggeredEvent
{
	public GameObjectRef targetPrefab;

	private void RunEvent()
	{
		Debug.Log("[event] " + targetPrefab.resourcePath);
		BaseEntity baseEntity = GameManager.server.CreateEntity(targetPrefab.resourcePath);
		if ((bool)baseEntity)
		{
			baseEntity.SendMessage("TriggeredEventSpawn", SendMessageOptions.DontRequireReceiver);
			baseEntity.Spawn();
		}
	}
}
