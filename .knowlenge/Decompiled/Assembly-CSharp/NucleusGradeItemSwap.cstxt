using ProtoBuf;

public class NucleusGradeItemSwap : ItemModSwap
{
	public ItemDefinition NucleusItem;

	protected override void AugmentItem(Item item)
	{
		if (item.info == NucleusItem)
		{
			item.instanceData = new ProtoBuf.Item.InstanceData
			{
				ShouldPool = false,
				dataInt = 0
			};
		}
	}
}
