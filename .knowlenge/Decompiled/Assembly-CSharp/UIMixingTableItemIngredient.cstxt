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
		((Behaviour)ItemIcon).enabled = true;
		((Behaviour)ItemCount).enabled = true;
		ToolTip.Text = ingredient.Count + " x " + ingredient.Ingredient.displayName.translated;
		((Behaviour)ToolTip).enabled = true;
	}

	public void InitBlank()
	{
		((Behaviour)ItemIcon).enabled = false;
		((Behaviour)ItemCount).enabled = false;
		((Behaviour)ToolTip).enabled = false;
	}
}
