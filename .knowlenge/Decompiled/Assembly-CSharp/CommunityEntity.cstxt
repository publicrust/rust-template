using Network;
using UnityEngine;

public class CommunityEntity : PointEntity
{
	public static CommunityEntity ServerInstance;

	public static CommunityEntity ClientInstance;

	public GameObject[] OverallPanels;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("CommunityEntity.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void InitShared()
	{
		if (base.isServer)
		{
			ServerInstance = this;
		}
		else
		{
			ClientInstance = this;
		}
		base.InitShared();
	}

	public override void DestroyShared()
	{
		base.DestroyShared();
		if (base.isServer)
		{
			ServerInstance = null;
		}
		else
		{
			ClientInstance = null;
		}
	}
}
