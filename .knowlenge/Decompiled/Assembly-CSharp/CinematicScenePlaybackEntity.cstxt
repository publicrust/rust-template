using Facepunch;
using ProtoBuf;
using UnityEngine;

public class CinematicScenePlaybackEntity : BaseEntity
{
	public Animator RootAnimator;

	public GameObjectRef CinematicUI;

	public float Duration = 10f;

	public GameObject DebugRoot;

	public bool ShowDebugRoot;

	public Transform LookPosition;

	public bool UseCinemachineBrain = true;

	public bool HidePlayerLegs = true;

	public float FadeToBlackTime = 0.5f;

	private EntityRef<BasePlayer> currentPlayer;

	public void SignalKillPlayer()
	{
		if (!base.isServer)
		{
			return;
		}
		BasePlayer basePlayer = currentPlayer.Get(serverside: true);
		if (basePlayer != null)
		{
			TutorialIsland currentTutorialIsland = basePlayer.GetCurrentTutorialIsland();
			if (currentTutorialIsland != null)
			{
				currentTutorialIsland.OnPlayerCompletedTutorial(basePlayer, isQuit: false, triggerAnalytics: true);
			}
		}
	}

	public void SignalFadeToBlack()
	{
	}

	public void AssignPlayer(BasePlayer bp)
	{
		currentPlayer.Set(bp);
		SendNetworkUpdate();
	}

	public override void ServerInit()
	{
		base.ServerInit();
		Invoke(Timeout, Duration);
	}

	private void Timeout()
	{
		BasePlayer basePlayer = currentPlayer.Get(serverside: true);
		if (basePlayer != null)
		{
			basePlayer.Respawn();
		}
		Kill();
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		BasePlayer basePlayer = currentPlayer.Get(serverside: true);
		if (basePlayer != null)
		{
			if (info.msg.cinematicEntity == null)
			{
				info.msg.cinematicEntity = Pool.Get<ProtoBuf.CinematicEntity>();
			}
			info.msg.cinematicEntity.targetPlayer = basePlayer.net.ID;
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		currentPlayer.Set(null);
		if (info.msg.cinematicEntity != null)
		{
			currentPlayer.uid = info.msg.cinematicEntity.targetPlayer;
		}
	}
}
