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
		ItemIcon.sprite = recipe.DisplayIcon;
		TextItemNameAndQuantity.text = recipe.ProducedItemCount + " x " + recipe.DisplayName;
		ItemTooltip.Text = recipe.DisplayDescription;
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
