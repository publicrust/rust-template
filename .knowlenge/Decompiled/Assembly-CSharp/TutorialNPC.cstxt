using Facepunch;
using ProtoBuf;
using UnityEngine;

public class TutorialNPC : NPCMissionProvider
{
	public ConversationData StartConversation;

	public ConversationData MissionInProgressConversation;

	public ConversationData ForageCompleteConversation;

	public ConversationData FirstBuildCompleteConversation;

	public ConversationData SecondBuildCompleteConversation;

	public ConversationData PrepareForCombatConversation;

	public ConversationData BuildKayakConversation;

	public ConversationData SetSailConversation;

	public ConversationData PostBearAttackConversation;

	public BaseMission PostBearAttackMission;

	public GameObjectRef BearRoarSfx;

	public Transform BearRoarSpawnPos;

	[Range(0f, 1f)]
	public float TalkingHeadIkWeight = 0.7f;

	public RuntimeAnimatorController CustomAnimator;

	private static readonly int IsTalking = Animator.StringToHash("IsTalking");

	private const uint FORAGE_MISSION = 2265941643u;

	private const uint BUILD1_MISSION = 1726435040u;

	private const uint BUILD2_MISSION = 1928576498u;

	private const uint COOK_MISSION = 3432877204u;

	private const uint KILL_BEAR_MISSION = 3396482113u;

	private const uint CRAFT_KAYAK_MISSION = 3197637569u;

	public const uint BEAR_ATTACK_RESPAWN_MISSION = 3156134108u;

	private BasePlayer playerToKill;

	protected override bool CanTalkTo(BasePlayer bp)
	{
		if (base.CanTalkTo(bp))
		{
			return !bp.HasPendingFollowupMission;
		}
		return false;
	}

	public override ConversationData GetConversationFor(BasePlayer player)
	{
		if (player.HasActiveMission())
		{
			return MissionInProgressConversation;
		}
		if (player.HasCompletedMission(3197637569u))
		{
			return SetSailConversation;
		}
		if (player.HasCompletedMission(3396482113u))
		{
			return BuildKayakConversation;
		}
		if (player.HasCompletedMission(3156134108u))
		{
			return PostBearAttackConversation;
		}
		if (player.HasCompletedMission(3432877204u))
		{
			return PrepareForCombatConversation;
		}
		if (player.HasCompletedMission(1928576498u))
		{
			return SecondBuildCompleteConversation;
		}
		if (player.HasCompletedMission(1726435040u))
		{
			return FirstBuildCompleteConversation;
		}
		if (player.HasCompletedMission(2265941643u))
		{
			return ForageCompleteConversation;
		}
		return StartConversation;
	}

	public override void OnConversationAction(BasePlayer player, string action)
	{
		base.OnConversationAction(player, action);
		if (action == "playbearsfx")
		{
			Effect.server.Run(BearRoarSfx.resourcePath, BearRoarSpawnPos.position);
			playerToKill = player;
			Invoke(WaitAndKill, 2f);
		}
		else if (action == "cleardeathmarker")
		{
			player.ClearDeathMarker(sendToClient: true);
		}
	}

	private void WaitAndKill()
	{
		if (playerToKill != null)
		{
			PlayerLifeStory.DeathInfo deathInfo = Pool.Get<PlayerLifeStory.DeathInfo>();
			deathInfo.attackerName = "bear";
			if (playerToKill.IsGod())
			{
				playerToKill.net.connection.info.Set("global.god", "0");
			}
			playerToKill.SetOverrideDeathBlow(deathInfo);
			playerToKill.Hurt(9999f);
			if (PostBearAttackMission != null)
			{
				BaseMission.AssignMission(playerToKill, this, PostBearAttackMission);
			}
		}
	}

	public override void PostServerLoad()
	{
		base.PostServerLoad();
		EndSleeping();
	}

	public override void GreetPlayer(BasePlayer player)
	{
	}

	public override void Greeting()
	{
	}

	public override void OnConversationStarted(BasePlayer speakingTo)
	{
		base.OnConversationStarted(speakingTo);
		SetFlag(Flags.Busy, b: true);
	}

	public override void OnConversationEnded(BasePlayer player)
	{
		base.OnConversationEnded(player);
		SetFlag(Flags.Busy, b: false);
	}
}
