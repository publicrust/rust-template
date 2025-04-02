using UnityEngine;
using UnityEngine.UI;

public class UIMixingTableItemIngredient : MonoBehaviour
{
	public Image ItemIcon;

	public Text ItemCount;

	public Tooltip ToolTip;

	public void Init(Recipe.RecipeIngredient ingredient)
	{
		ItemIcon.sprite = ingredient.Ingredient.iconSprite;
		ItemCount.text = ingredient.Count.ToString();
		ItemIcon.enabled = true;
		ItemCount.enabled = true;
		ToolTip.Text = ingredient.Count + " x " + ingredient.Ingredient.displayName.translated;
		ToolTip.enabled = true;
	}

	public void InitBlank()
	{
		ItemIcon.enabled = false;
		ItemCount.enabled = false;
		ToolTip.enabled = false;
	}
}
