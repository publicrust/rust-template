using Facepunch.Flexbox;
using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class VendorListing : FacepunchBehaviour
{
	public Image panelBacking;

	[Header("Text")]
	public RustText AvailableText;

	public RustText CostText;

	public RustText AvailableAmount;

	public RustText CostAmount;

	public RustText InStockAmount;

	public RustText InStockText;

	public VendingPriceMultiplierWidget PriceMultiplier;

	public VendingPriceMultiplierWidget RecievedCurrencyMultiplier;

	[Header("Icons")]
	public VirtualItemIcon AvaliableIcon;

	public VirtualItemIcon CostIcon;

	[Header("Tooltips")]
	public Tooltip avaliableIconTooltip;

	public Tooltip costIconTooltip;

	[SerializeField]
	private FlexTransition transition;

	public static Translate.Phrase inStockPhrase = new Translate.Phrase("vendor_in_stock", "In Stock");

	public static Translate.Phrase outOfStockPhrase = new Translate.Phrase("vendor_out_stock", "Sold Out");

	public static Translate.Phrase attachmentsPhrase = new Translate.Phrase("vendor_attachments", "Attachments");

	public static Translate.Phrase ammoPhrase = new Translate.Phrase("vendor_ammo", "Ammo");
}
