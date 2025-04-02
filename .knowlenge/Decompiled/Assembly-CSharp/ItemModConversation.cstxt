using UnityEngine;

public class ItemModConversation : ItemMod
{
	public static readonly Phrase SquakTitle = new Phrase("squak", "MISSING SQUAK PHRASE");

	public static readonly Phrase SquakDesc = new Phrase("squak_desc", "MISSING SQUAK DESC PHRASE");

	public ConversationData conversationData;

	public GameObjectRef conversationEntity;

	public GameObjectRef squakEffect;

	public override void ServerCommand(Item item, string command, BasePlayer player)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		if (command == "squak")
		{
			if (squakEffect.isValid)
			{
				Effect.server.Run(squakEffect.resourcePath, player.eyes.position);
			}
			Debug.Log((object)"Starting conversation");
			BaseEntity baseEntity = GameManager.server.CreateEntity(conversationEntity.resourcePath, ((Component)player).transform.position + Vector3.up * -2f);
			((Component)baseEntity).GetComponent<NPCMissionProvider>().conversations[0] = conversationData;
			baseEntity.Spawn();
			((MonoBehaviour)baseEntity).Invoke("Kill", 600f);
		}
	}
}
