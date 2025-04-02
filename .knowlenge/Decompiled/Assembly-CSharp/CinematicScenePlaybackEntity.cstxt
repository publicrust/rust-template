using System;
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
		if ((Object)(object)basePlayer != (Object)null)
		{
			TutorialIsland currentTutorialIsland = basePlayer.GetCurrentTutorialIsland();
			if ((Object)(object)currentTutorialIsland != (Object)null)
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
		((FacepunchBehaviour)this).Invoke((Action)Timeout, Duration);
	}

	private void Timeout()
	{
		BasePlayer basePlayer = currentPlayer.Get(serverside: true);
		if ((Object)(object)basePlayer != (Object)null)
		{
			basePlayer.Respawn();
		}
		Kill();
	}

	public override void Save(SaveInfo info)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		base.Save(info);
		BasePlayer basePlayer = currentPlayer.Get(serverside: true);
		if ((Object)(object)basePlayer != (Object)null)
		{
			if (info.msg.cinematicEntity == null)
			{
				info.msg.cinematicEntity = Pool.Get<CinematicEntity>();
			}
			info.msg.cinematicEntity.targetPlayer = basePlayer.net.ID;
		}
	}

	public override void Load(LoadInfo info)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		base.Load(info);
		currentPlayer.Set(null);
		if (info.msg.cinematicEntity != null)
		{
			currentPlayer.uid = info.msg.cinematicEntity.targetPlayer;
		}
	}
}
