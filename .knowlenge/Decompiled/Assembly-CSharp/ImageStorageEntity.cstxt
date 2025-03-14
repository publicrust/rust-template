#define UNITY_ASSERTIONS
using System;
using System.Collections.Generic;
using ConVar;
using Network;
using UnityEngine;
using UnityEngine.Assertions;

public class ImageStorageEntity : BaseEntity
{
	private struct ImageRequest
	{
		public IImageReceiver Receiver;

		public float Time;
	}

	private List<ImageRequest> _requests;

	protected virtual FileStorage.Type StorageType => FileStorage.Type.jpg;

	protected virtual uint CrcToLoad => 0u;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("ImageStorageEntity.OnRpcMessage"))
		{
			if (rpc == 652912521 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - ImageRequested ");
				}
				using (TimeWarning.New("ImageRequested"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.CallsPerSecond.Test(652912521u, "ImageRequested", this, player, 3uL))
						{
							return true;
						}
					}
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg2 = rPCMessage;
							ImageRequested(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in ImageRequested");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	[RPC_Server]
	[RPC_Server.CallsPerSecond(3uL)]
	private void ImageRequested(RPCMessage msg)
	{
		if (!(msg.player == null))
		{
			byte[] array = FileStorage.server.Get(CrcToLoad, StorageType, net.ID);
			if (array == null)
			{
				Debug.LogWarning("Image entity has no image!");
				return;
			}
			SendInfo sendInfo = new SendInfo(msg.connection);
			sendInfo.method = SendMethod.Reliable;
			sendInfo.channel = 2;
			SendInfo sendInfo2 = sendInfo;
			ClientRPC(RpcTarget.SendInfo("ReceiveImage", sendInfo2), (uint)array.Length, array);
		}
	}
}
