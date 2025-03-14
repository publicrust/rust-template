using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/NPC Vending Order")]
public class NPCVendingOrder : ScriptableObject
{
	[Serializable]
	public struct Entry
	{
		public ItemDefinition sellItem;

		public int sellItemAmount;

		public bool sellItemAsBP;

		public ItemDefinition currencyItem;

		public int currencyAmount;

		public bool currencyAsBP;

		[Tooltip("The higher this number, the more likely this will be chosen")]
		public int weight;
	}

	public Entry[] orders;
}
