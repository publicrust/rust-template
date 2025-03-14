using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class UIMixingTableItem : MonoBehaviour
{
	public Image ItemIcon;

	public Tooltip ItemTooltip;

	public RustText TextItemNameAndQuantity;

	public UIMixingTableItemIngredient[] Ingredients;

	public void Init(Recipe recipe)
	{
		if (recipe == null)
		{
			return;
		}
		ItemIcon.sprite = recipe.ProducedItem.iconSprite;
		TextItemNameAndQuantity.text = recipe.ProducedItemCount + " x " + recipe.ProducedItem.displayName.translated;
		ItemTooltip.Text = recipe.ProducedItem.displayDescription.translated;
		for (int i = 0; i < Ingredients.Length; i++)
		{
			if (i >= recipe.Ingredients.Length)
			{
				Ingredients[i].InitBlank();
			}
			else
			{
				Ingredients[i].Init(recipe.Ingredients[i]);
			}
		}
	}
}
