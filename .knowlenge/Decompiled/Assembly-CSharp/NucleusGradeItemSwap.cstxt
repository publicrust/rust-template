using ProtoBuf;
using UnityEngine;

public class NucleusGradeItemSwap : ItemModSwap
{
	public ItemDefinition NucleusItem;

	protected override void AugmentItem(Item item)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		if ((Object)(object)item.info == (Object)(object)NucleusItem)
		{
			item.instanceData = new InstanceData
			{
				ShouldPool = false,
				dataInt = 0
			};
		}
	}
}
