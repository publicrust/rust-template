using UnityEngine;

public class DropBox : Mailbox
{
	public Transform EyePoint;

	public override bool PlayerIsOwner(BasePlayer player)
	{
		return PlayerBehind(player);
	}

	public bool PlayerBehind(BasePlayer player)
	{
		if (Vector3.Dot(base.transform.forward, (player.transform.position - base.transform.position).normalized) <= -0.3f)
		{
			return GamePhysics.LineOfSight(player.eyes.position, EyePoint.position, 2162688);
		}
		return false;
	}

	public bool PlayerInfront(BasePlayer player)
	{
		return Vector3.Dot(base.transform.forward, (player.transform.position - base.transform.position).normalized) >= 0.7f;
	}

	public override bool SupportsChildDeployables()
	{
		return true;
	}
}
