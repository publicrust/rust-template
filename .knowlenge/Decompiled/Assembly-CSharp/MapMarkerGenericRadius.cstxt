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
		ClientRPC<Vector3, float, Vector3, float, float>(arg1: new Vector3(color1.r, color1.g, color1.b), arg3: new Vector3(color2.r, color2.g, color2.b), target: RpcTarget.NetworkGroup("MarkerUpdate"), arg2: a, arg4: alpha, arg5: radius);
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
