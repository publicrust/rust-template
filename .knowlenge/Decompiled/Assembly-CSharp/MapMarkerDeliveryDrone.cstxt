public class MapMarkerDeliveryDrone : MapMarker
{
	public override void ServerInit()
	{
		base.ServerInit();
		base.limitNetworking = true;
	}

	public override bool ShouldNetworkTo(BasePlayer player)
	{
		return player.userID == base.OwnerID;
	}
}
