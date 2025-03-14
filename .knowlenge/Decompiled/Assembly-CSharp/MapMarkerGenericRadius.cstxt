using Network;
using ProtoBuf;
using UnityEngine;

public class MapMarkerGenericRadius : MapMarker
{
	public float radius;

	public Color color1;

	public Color color2;

	public float alpha;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("MapMarkerGenericRadius.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public void SendUpdate(bool fullUpdate = true)
	{
		float a = color1.a;
		Vector3 arg = new Vector3(color1.r, color1.g, color1.b);
		Vector3 arg2 = new Vector3(color2.r, color2.g, color2.b);
		ClientRPC(null, "MarkerUpdate", arg, a, arg2, alpha, radius);
	}

	public override AppMarker GetAppMarkerData()
	{
		AppMarker appMarkerData = base.GetAppMarkerData();
		appMarkerData.radius = radius;
		appMarkerData.color1 = color1;
		appMarkerData.color2 = color2;
		appMarkerData.alpha = alpha;
		return appMarkerData;
	}
}
