using System;
using Epic.OnlineServices;
using Epic.OnlineServices.P2P;

public struct SendPacketOptions
{
	public ProductUserId LocalUserId { get; set; }

	public ProductUserId RemoteUserId { get; set; }

	public SocketId? SocketId { get; set; }

	public byte Channel { get; set; }

	public ArraySegment<byte> Data { get; set; }

	public bool AllowDelayedDelivery { get; set; }

	public PacketReliability Reliability { get; set; }

	public bool DisableAutoAcceptConnection { get; set; }
}
