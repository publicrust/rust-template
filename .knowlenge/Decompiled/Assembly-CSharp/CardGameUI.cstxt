using System;
using Facepunch.CardGames;
using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class CardGameUI : UIDialog
{
	[Serializable]
	public class PlayingCardImage
	{
		public Rank rank;

		public Suit suit;

		public Sprite image;

		public Sprite imageSmall;

		public Sprite imageTransparent;
	}

	[Serializable]
	public class InfoTextUI
	{
		public enum Attitude
		{
			Neutral,
			Good,
			Bad
		}

		public GameObject gameObj;

		public RustText rustText;

		public Image background;
	}

	public interface ICardGameSubUI
	{
		int DynamicBetAmount { get; }

		void UpdateInGameUI(CardGameUI ui, CardGameController game);

		string GetSecondaryInfo(CardGameUI ui, CardGameController game, out InfoTextUI.Attitude attitude);

		void UpdateInGameUI_NoPlayer(CardGameUI ui);
	}

	[Header("Card Game")]
	[SerializeField]
	private InfoTextUI primaryInfo;

	[SerializeField]
	private InfoTextUI secondaryInfo;

	[SerializeField]
	private InfoTextUI playerLeaveInfo;

	[SerializeField]
	private GameObject playingUI;

	[SerializeField]
	private PlayingCardImage[] cardImages;

	[SerializeField]
	private CardInputWidget[] inputWidgets;

	[SerializeField]
	private RustSlider dismountProgressSlider;

	[SerializeField]
	private Phrase phraseLoading;

	[SerializeField]
	private Phrase phraseWaitingForNextRound;

	[SerializeField]
	private Phrase phraseNotEnoughPlayers;

	[SerializeField]
	private Phrase phrasePlayerLeftGame;

	[SerializeField]
	private Phrase phraseNotEnoughBuyIn;

	[SerializeField]
	private Phrase phraseTooMuchBuyIn;

	public Phrase phraseYourTurn;

	public Phrase phraseYouWinTheRound;

	public Phrase phraseRoundWinner;

	public Phrase phraseRoundWinners;

	public Phrase phraseScrapWon;

	public Phrase phraseScrapReturned;

	public Phrase phraseChangeBetAmount;

	public Phrase phraseBet;

	public Phrase phraseBetAdd;

	public Phrase phraseAllIn;

	public GameObject amountChangeRoot;

	public RustText amountChangeText;

	public Color colourNeutralUI;

	public Color colourGoodUI;

	public Color colourBadUI;

	[SerializeField]
	private CanvasGroup timerCanvas;

	[SerializeField]
	private RustSlider timerSlider;

	[SerializeField]
	private UIChat chat;

	[SerializeField]
	private HudElement Hunger;

	[SerializeField]
	private HudElement Thirst;

	[SerializeField]
	private HudElement Health;

	[SerializeField]
	private HudElement PendingHealth;

	public Sprite cardNone;

	public Sprite cardBackLarge;

	public Sprite cardBackSmall;

	private static Sprite cardBackLargeStatic;

	private static Sprite cardBackSmallStatic;

	[SerializeField]
	private TexasHoldEmUI texasHoldEmUI;

	[SerializeField]
	private BlackjackUI blackjackUI;
}
