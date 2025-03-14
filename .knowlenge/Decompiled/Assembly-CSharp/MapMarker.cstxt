using System.Collections.Generic;
using CompanionServer;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class MapMarker : BaseEntity
{
	public enum ClusterType
	{
		None,
		Vending
	}

	public AppMarkerType appType;

	public GameObjectRef markerObj;

	public static readonly List<MapMarker> serverMapMarkers = new List<MapMarker>();

	public override void InitShared()
	{
		if (base.isServer && !serverMapMarkers.Contains(this))
		{
			serverMapMarkers.Add(this);
		}
		base.InitShared();
	}

	public override void DestroyShared()
	{
		if (base.isServer)
		{
			serverMapMarkers.Remove(this);
		}
		base.DestroyShared();
	}

	public virtual AppMarker GetAppMarkerData()
	{
		AppMarker appMarker = Pool.Get<AppMarker>();
		Vector2 vector = CompanionServer.Util.WorldToMap(base.transform.position);
		appMarker.id = net.ID;
		appMarker.type = appType;
		appMarker.x = vector.x;
		appMarker.y = vector.y;
		return appMarker;
	}
}
