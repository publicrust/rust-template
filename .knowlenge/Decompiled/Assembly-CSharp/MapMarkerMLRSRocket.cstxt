using UnityEngine;

public class MapMarkerMLRSRocket : MapMarker
{
	public RectTransform uiMarkerTransform;

	public override void ServerInit()
	{
		base.ServerInit();
		base.limitNetworking = true;
	}

	public override bool ShouldNetworkTo(BasePlayer player)
	{
		return (ulong)player.userID == base.OwnerID;
	}
}
