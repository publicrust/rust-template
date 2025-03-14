using ProtoBuf;

public class ItemModBeehiveNucleus : ItemMod
{
	public override void OnVirginItem(Item item, BasePlayer creatingPlayer)
	{
		base.OnVirginItem(item, creatingPlayer);
		item.instanceData = new ProtoBuf.Item.InstanceData
		{
			ShouldPool = false,
			dataInt = 0
		};
	}
}
