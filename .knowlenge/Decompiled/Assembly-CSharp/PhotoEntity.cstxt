#define UNITY_ASSERTIONS
using System;
using ConVar;
using Facepunch;
using Network;
using ProtoBuf;
using Rust;
using UnityEngine;
using UnityEngine.Assertions;

public class PhotoEntity : BaseEntity
{
	private byte[] _imageData;

	public ulong PhotographerSteamId { get; private set; }

	public uint ImageCrc { get; private set; }

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("PhotoEntity.OnRpcMessage"))
		{
			if (rpc == 652912521 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (ConVar.Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - ImageRequested "));
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

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.photo != null)
		{
			PhotographerSteamId = info.msg.photo.photographerSteamId;
			ImageCrc = info.msg.photo.imageCrc;
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.photo = Facepunch.Pool.Get<Photo>();
		info.msg.photo.photographerSteamId = PhotographerSteamId;
		info.msg.photo.imageCrc = ImageCrc;
	}

	public void SetImageData(ulong steamId, byte[] data)
	{
		_imageData = data;
		ImageCrc = FileStorage.server.Store(_imageData, FileStorage.Type.jpg, net.ID);
		PhotographerSteamId = steamId;
	}

	[RPC_Server]
	[RPC_Server.CallsPerSecond(3uL)]
	private void ImageRequested(RPCMessage msg)
	{
		if (msg.player == null)
		{
			return;
		}
		if (_imageData == null)
		{
			_imageData = FileStorage.server.Get(ImageCrc, FileStorage.Type.jpg, net.ID);
			if (_imageData == null)
			{
				Debug.LogWarning("Photo has no image!");
				return;
			}
		}
		SendInfo sendInfo = new SendInfo(msg.connection);
		sendInfo.method = SendMethod.Reliable;
		sendInfo.channel = 2;
		SendInfo sendInfo2 = sendInfo;
		ClientRPCEx(sendInfo2, null, "ReceiveImage", (uint)_imageData.Length, _imageData);
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		if (!Rust.Application.isQuitting && net != null)
		{
			FileStorage.server.RemoveAllByEntity(net.ID);
		}
	}
}
