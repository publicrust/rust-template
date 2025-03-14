using System;
using System.Collections.Generic;
using Facepunch.Flexbox;
using ProtoBuf;
using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class SingleVendor : FacepunchBehaviour, IComparable<SingleVendor>
{
	public RustText VendorName;

	public TmProEmojiRedirector emojiRedirector;

	public Transform ListingsParent;

	public Transform AccordionRow;

	public Transform AccordionChevron;

	public Image[] AccordionImages = new Image[3];

	public GameObjectRef VendorListingPrefab;

	[Header("References")]
	public GameObject NoListings;

	public FlexTransition VendorListingsTransition;

	public Image OwnerImage;

	public RustText OwnerName;

	public ProtoBuf.VendingMachine.SellOrderContainer SellOrdersContainer;

	private List<VendorListing> listings;

	public const int COUNT_FOR_ACCORDION = 5;

	public int CompareTo(SingleVendor other)
	{
		ProtoBuf.VendingMachine.SellOrderContainer sellOrdersContainer = SellOrdersContainer;
		bool flag = sellOrdersContainer != null && sellOrdersContainer.sellOrders.Count >= 5;
		ProtoBuf.VendingMachine.SellOrderContainer sellOrdersContainer2 = other.SellOrdersContainer;
		bool flag2 = sellOrdersContainer2 != null && sellOrdersContainer2.sellOrders.Count >= 5;
		if (flag && !flag2)
		{
			return 1;
		}
		if (!flag && flag2)
		{
			return -1;
		}
		ProtoBuf.VendingMachine.SellOrderContainer sellOrdersContainer3 = SellOrdersContainer;
		if (sellOrdersContainer3 != null && sellOrdersContainer3.sellOrders.Count == 0)
		{
			ProtoBuf.VendingMachine.SellOrderContainer sellOrdersContainer4 = other.SellOrdersContainer;
			if (sellOrdersContainer4 != null && sellOrdersContainer4.sellOrders.Count > 0)
			{
				return -1;
			}
		}
		ProtoBuf.VendingMachine.SellOrderContainer sellOrdersContainer5 = SellOrdersContainer;
		if (sellOrdersContainer5 != null && sellOrdersContainer5.sellOrders.Count > 0)
		{
			ProtoBuf.VendingMachine.SellOrderContainer sellOrdersContainer6 = other.SellOrdersContainer;
			if (sellOrdersContainer6 != null && sellOrdersContainer6.sellOrders.Count == 0)
			{
				return 1;
			}
		}
		return 0;
	}
}
