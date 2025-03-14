using UnityEngine;

public class ItemModConversation : ItemMod
{
	public static readonly Translate.Phrase SquakTitle = new Translate.Phrase("squak", "MISSING SQUAK PHRASE");

	public static readonly Translate.Phrase SquakDesc = new Translate.Phrase("squak_desc", "MISSING SQUAK DESC PHRASE");

	public ConversationData conversationData;

	public GameObjectRef conversationEntity;

	public GameObjectRef squakEffect;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		if (command == "squak")
		{
			if (squakEffect.isValid)
			{
				Effect.server.Run(squakEffect.resourcePath, player.eyes.position);
			}
			Debug.Log("Starting conversation");
			BaseEntity baseEntity = GameManager.server.CreateEntity(conversationEntity.resourcePath, player.transform.position + Vector3.up * -2f);
			baseEntity.GetComponent<NPCMissionProvider>().conversations[0] = conversationData;
			baseEntity.Spawn();
			baseEntity.Invoke("Kill", 600f);
		}
	}
}
