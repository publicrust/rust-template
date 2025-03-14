using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Recipe")]
public class Recipe : ScriptableObject
{
	[Serializable]
	public struct RecipeIngredient
	{
		public ItemDefinition Ingredient;

		public int Count;
	}

	public ItemDefinition ProducedItem;

	public int ProducedItemCount = 1;

	public bool RequiresBlueprint;

	public RecipeIngredient[] Ingredients;

	public float MixingDuration;

	public bool ContainsItem(Item item)
	{
		if (item == null)
		{
			return false;
		}
		if (Ingredients == null)
		{
			return false;
		}
		RecipeIngredient[] ingredients = Ingredients;
		for (int i = 0; i < ingredients.Length; i++)
		{
			RecipeIngredient recipeIngredient = ingredients[i];
			if (item.info == recipeIngredient.Ingredient)
			{
				return true;
			}
		}
		return false;
	}
}
