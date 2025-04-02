using Rust.UI;
using UnityEngine;

public class UIMarketTerminal : UIDialog, IVendingMachineInterface
{
	public static readonly Phrase PendingDeliveryPluralPhrase = new Phrase("market.pending_delivery.plural", "Waiting for {n} deliveries...");

	public static readonly Phrase PendingDeliverySingularPhrase = new Phrase("market.pending_delivery.singular", "Waiting for delivery...");

	public Canvas canvas;

	public MapView mapView;

	public RectTransform shopDetailsPanel;

	public float shopDetailsMargin = 16f;

	public float easeDuration = 0.2f;

	public LeanTweenType easeType = (LeanTweenType)1;

	public TmProEmojiRedirector shopName;

	public GameObject shopOrderingPanel;

	public RectTransform sellOrderContainer;

	public GameObjectRef sellOrderPrefab;

	public VirtualItemIcon deliveryFeeIcon;

	public GameObject deliveryFeeCantAffordIndicator;

	public GameObject inventoryFullIndicator;

	public GameObject notEligiblePanel;

	public GameObject pendingDeliveryPanel;

	public RustText pendingDeliveryLabel;

	public RectTransform itemNoticesContainer;

	public GameObjectRef itemRemovedPrefab;

	public GameObjectRef itemPendingPrefab;

	public GameObjectRef itemAddedPrefab;

	public CanvasGroup gettingStartedTip;

	public SoundDefinition buyItemSoundDef;

	public SoundDefinition buttonPressSoundDef;
}
