public class ItemModCassette : ItemModAssociatedEntity<Cassette>
{
	public int noteSpriteIndex;

	public PreloadedCassetteContent PreloadedContent;

	protected override bool AllowNullParenting => true;

	protected override bool AllowHeldEntityParenting => true;

	protected override void OnAssociatedItemCreated(Cassette ent)
	{
		base.OnAssociatedItemCreated(ent);
		ent.AssignPreloadContent();
	}
}
