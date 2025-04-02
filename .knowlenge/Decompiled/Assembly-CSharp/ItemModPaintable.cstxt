using UnityEngine;

[RequireComponent(typeof(ItemModWearable))]
public class ItemModPaintable : ItemModAssociatedEntity<PaintedItemStorageEntity>
{
	public static readonly Translate.Phrase ItemPaintTitle = new Translate.Phrase("item.paint", "Paint");

	public static readonly Translate.Phrase ItemPaintDesc = new Translate.Phrase("item.paint.desc", "Paint on this item.");

	public GameObjectRef ChangeSignTextDialog;

	public MeshPaintableSource[] PaintableSources;

	protected override bool AllowNullParenting => true;

	protected override bool OwnedByParentPlayer => true;
}
