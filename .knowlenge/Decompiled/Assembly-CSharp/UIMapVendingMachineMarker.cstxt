using ProtoBuf;
using UnityEngine;
using UnityEngine.UI;

public class UIMapVendingMachineMarker : MonoBehaviour
{
	public Color inStock;

	public Color outOfStock;

	public Image colorBackground;

	public string displayName;

	public Tooltip toolTip;

	private bool isInStock;

	public void SetOutOfStock(bool stock)
	{
		colorBackground.color = (stock ? inStock : outOfStock);
		isInStock = stock;
	}

	public void UpdateDisplayName(string newName, ProtoBuf.VendingMachine.SellOrderContainer sellOrderContainer)
	{
		newName = newName.Replace('>', ' ');
		newName = newName.Replace('<', ' ');
		displayName = newName;
		toolTip.Text = displayName;
		if (isInStock && sellOrderContainer != null && sellOrderContainer.sellOrders != null && sellOrderContainer.sellOrders.Count > 0)
		{
			toolTip.Text += "\n";
			foreach (ProtoBuf.VendingMachine.SellOrder sellOrder in sellOrderContainer.sellOrders)
			{
				if (sellOrder.inStock > 0)
				{
					string text = ItemManager.FindItemDefinition(sellOrder.itemToSellID).displayName.translated + (sellOrder.itemToSellIsBP ? " (BP)" : "");
					string text2 = ItemManager.FindItemDefinition(sellOrder.currencyID).displayName.translated + (sellOrder.currencyIsBP ? " (BP)" : "");
					Tooltip tooltip = toolTip;
					tooltip.Text = tooltip.Text + "\n" + sellOrder.itemToSellAmount + " " + text + " | " + sellOrder.currencyAmountPerItem + " " + text2;
					tooltip = toolTip;
					tooltip.Text = tooltip.Text + " (" + sellOrder.inStock + " Left)";
				}
			}
		}
		toolTip.enabled = toolTip.Text != "";
	}
}
