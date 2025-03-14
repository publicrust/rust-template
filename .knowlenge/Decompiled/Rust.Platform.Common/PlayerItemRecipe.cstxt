using System;
using System.Collections.Generic;
using System.Linq;

public readonly struct PlayerItemRecipe : IEquatable<PlayerItemRecipe>
{
	public readonly struct Ingredient : IEquatable<Ingredient>
	{
		public int DefinitionId { get; }

		public int Amount { get; }

		public Ingredient(int definitionId, int amount)
		{
			DefinitionId = definitionId;
			Amount = amount;
		}

		public bool Equals(Ingredient other)
		{
			if (DefinitionId == other.DefinitionId)
			{
				return Amount == other.Amount;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Ingredient other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (DefinitionId * 397) ^ Amount;
		}

		public static bool operator ==(Ingredient left, Ingredient right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Ingredient left, Ingredient right)
		{
			return !left.Equals(right);
		}
	}

	public IReadOnlyList<Ingredient> Ingredients { get; }

	public IPlayerItemDefinition Result { get; }

	public PlayerItemRecipe(IReadOnlyList<Ingredient> ingredients, IPlayerItemDefinition result)
	{
		Ingredients = ingredients ?? throw new ArgumentNullException("ingredients");
		Result = result ?? throw new ArgumentNullException("result");
		if (Ingredients.Count == 0)
		{
			throw new ArgumentException("Recipes must have at least one ingredient.", "ingredients");
		}
	}

	public bool Equals(PlayerItemRecipe other)
	{
		if (Result.Equals(other.Result))
		{
			if (!Ingredients.Equals(other.Ingredients))
			{
				return Ingredients.SequenceEqual(other.Ingredients);
			}
			return true;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is PlayerItemRecipe other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (Ingredients.Sum((Ingredient i) => i.GetHashCode()) * 397) ^ Result.GetHashCode();
	}

	public static bool operator ==(PlayerItemRecipe left, PlayerItemRecipe right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(PlayerItemRecipe left, PlayerItemRecipe right)
	{
		return !left.Equals(right);
	}
}
