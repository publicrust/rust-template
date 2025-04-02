using System;
using UnityEngine;
using UnityEngine.UI;

public class CardTable : BaseCardGameEntity
{
	[Serializable]
	public class ChipStack : IComparable<ChipStack>
	{
		public int chipValue;

		public GameObject[] chips;

		public int CompareTo(ChipStack other)
		{
			if (other == null)
			{
				return 1;
			}
			return chipValue.CompareTo(other.chipValue);
		}
	}

	[Header("Card Table")]
	[SerializeField]
	private ViewModel viewModel;

	[SerializeField]
	private CardGameUI.PlayingCardImage[] tableCards;

	[SerializeField]
	private Renderer[] tableCardBackings;

	[SerializeField]
	private Canvas cardUICanvas;

	[SerializeField]
	private Image[] tableCardImages;

	[SerializeField]
	private Sprite blankCard;

	[SerializeField]
	private ChipStack[] chipStacks;

	[SerializeField]
	private ChipStack[] fillerStacks;

	protected override float MaxStorageInteractionDist => 1f;

	public override void Load(LoadInfo info)
	{
		base.Load(info);
	}
}
