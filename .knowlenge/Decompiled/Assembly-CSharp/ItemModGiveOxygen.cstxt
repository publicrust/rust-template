using UnityEngine;

public class ItemModGiveOxygen : ItemMod
{
	public int amountToConsume = 1;

	public GameObjectRef inhaleEffect;

	public GameObjectRef exhaleEffect;

	public GameObjectRef bubblesEffect;

	private bool inhaled;

	public override void DoAction(Item item, BasePlayer player)
	{
		if (item.hasCondition && item.conditionNormalized != 0f && !(player == null) && !(player.WaterFactor() < 1f) && item.parent != null && item.parent == player.inventory.containerWear)
		{
			Effect.server.Run((!inhaled) ? inhaleEffect.resourcePath : exhaleEffect.resourcePath, player, StringPool.Get("jaw"), Vector3.zero, Vector3.forward);
			inhaled = !inhaled;
			if (!inhaled && WaterLevel.GetWaterDepth(player.eyes.position, player) > 3f)
			{
				Effect.server.Run(bubblesEffect.resourcePath, player, StringPool.Get("jaw"), Vector3.zero, Vector3.forward);
			}
			item.LoseCondition(amountToConsume);
			player.metabolism.oxygen.Add(1f);
		}
	}
}
