using Facepunch.CardGames;
using UnityEngine;

public class BlackjackMachine : BaseCardGameEntity
{
	[Header("Blackjack Machine")]
	[SerializeField]
	private GameObjectRef mainScreenPrefab;

	[SerializeField]
	private GameObjectRef smallScreenPrefab;

	[SerializeField]
	private Transform mainScreenParent;

	[SerializeField]
	private Transform[] smallScreenParents;

	private static int _maxbet = 500;

	private BlackjackController controller;

	private BlackjackMainScreenUI mainScreenUI;

	private BlackjackSmallScreenUI[] smallScreenUIs = new BlackjackSmallScreenUI[3];

	[ServerVar(Help = "Maximum initial bet per round")]
	public static int maxbet
	{
		get
		{
			return _maxbet;
		}
		set
		{
			_maxbet = Mathf.Clamp(value, 25, 1000000);
		}
	}

	protected override float MaxStorageInteractionDist => 1f;

	public override void InitShared()
	{
		base.InitShared();
		controller = (BlackjackController)base.GameController;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
	}

	public override void PlayerStorageChanged()
	{
		base.PlayerStorageChanged();
		SendNetworkUpdate();
	}
}
