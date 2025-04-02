using UnityEngine;

public class MetalDetectorFlag : BaseDiggableEntity
{
	public Collider Collision;

	public GameObject FlagModel;

	public float MoveUpBy = 0.2f;

	[ServerVar]
	public static float TimeoutDuration = 10800f;

	public override void ServerInit()
	{
		base.ServerInit();
		ResetTimeout();
	}

	private void ResetTimeout()
	{
		CancelInvoke(Timeout);
		Invoke(Timeout, TimeoutDuration * Random.Range(0.8f, 1.2f));
	}

	private void Timeout()
	{
		Kill();
	}

	public override void OnFullyDug(BasePlayer player)
	{
		if (Collision != null)
		{
			Collision.enabled = false;
		}
		player.ProcessMissionEvent(BaseMission.MissionEventType.METAL_DETECTOR_FIND, 0, 1f);
		base.OnFullyDug(player);
	}

	public override void OnSingleDig(BasePlayer player)
	{
		base.OnSingleDig(player);
	}

	public override void OnFirstDig(BasePlayer player)
	{
		base.OnFirstDig(player);
	}
}
