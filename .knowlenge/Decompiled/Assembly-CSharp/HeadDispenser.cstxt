public class HeadDispenser : EntityComponent<BaseEntity>
{
	public ItemDefinition HeadDef;

	public GameObjectRef SourceEntity;

	private bool hasDispensed;

	public BaseEntity overrideEntity { get; set; }

	public void DispenseHead(HitInfo info, BaseCorpse corpse)
	{
		if (hasDispensed || !(info.Weapon is BaseMelee baseMelee) || !baseMelee.gathering.ProduceHeadItem)
		{
			return;
		}
		if (info.InitiatorPlayer != null)
		{
			Item item = ItemManager.CreateByItemID(HeadDef.itemid, 1, 0uL);
			item.SetItemOwnership(info.InitiatorPlayer, ItemOwnershipPhrases.Beheaded);
			HeadEntity associatedEntity = ItemModAssociatedEntity<HeadEntity>.GetAssociatedEntity(item);
			BaseEntity baseEntity = ((overrideEntity != null) ? overrideEntity : SourceEntity.GetEntity());
			overrideEntity = null;
			if (associatedEntity != null && baseEntity != null)
			{
				associatedEntity.SetupSourceId(baseEntity.prefabID);
				if (corpse is PlayerCorpse playerCorpse)
				{
					associatedEntity.SetupPlayerId(playerCorpse.playerName, playerCorpse.playerSteamID);
					associatedEntity.AssignClothing(playerCorpse.containers[1]);
				}
				else if (corpse is HorseCorpse horseCorpse)
				{
					associatedEntity.AssignHorseBreed(horseCorpse.breedIndex);
				}
			}
			if (info.InitiatorPlayer.inventory.GiveItem(item))
			{
				info.InitiatorPlayer.Command("note.inv", HeadDef.itemid, 1);
			}
			else
			{
				item.DropAndTossUpwards(info.HitPositionWorld);
			}
		}
		hasDispensed = true;
	}
}
