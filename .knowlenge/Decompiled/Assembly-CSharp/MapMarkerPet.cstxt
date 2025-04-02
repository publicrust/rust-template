public class MapMarkerPet : MapMarker
{
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
