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

	public static Phrase inStockPhrase = new Phrase("vendor_in_stock", "In Stock");

	public static Phrase outOfStockPhrase = new Phrase("vendor_out_stock", "Sold Out");

	public static Phrase attachmentsPhrase = new Phrase("vendor_attachments", "Attachments");

	public static Phrase ammoPhrase = new Phrase("vendor_ammo", "Ammo");
}
