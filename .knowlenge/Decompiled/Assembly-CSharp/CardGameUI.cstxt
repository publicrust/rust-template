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
	private Translate.Phrase phraseLoading;

	[SerializeField]
	private Translate.Phrase phraseWaitingForNextRound;

	[SerializeField]
	private Translate.Phrase phraseNotEnoughPlayers;

	[SerializeField]
	private Translate.Phrase phrasePlayerLeftGame;

	[SerializeField]
	private Translate.Phrase phraseNotEnoughBuyIn;

	[SerializeField]
	private Translate.Phrase phraseTooMuchBuyIn;

	public Translate.Phrase phraseYourTurn;

	public Translate.Phrase phraseYouWinTheRound;

	public Translate.Phrase phraseRoundWinner;

	public Translate.Phrase phraseRoundWinners;

	public Translate.Phrase phraseScrapWon;

	public Translate.Phrase phraseScrapReturned;

	public Translate.Phrase phraseChangeBetAmount;

	public Translate.Phrase phraseBet;

	public Translate.Phrase phraseBetAdd;

	public Translate.Phrase phraseAllIn;

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
