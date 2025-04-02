using Facepunch;
using Network;
using ProtoBuf;
using UnityEngine;

public class ConnectedSpeaker : IOEntity
{
	public AudioSource SoundSource;

	private EntityRef<IOEntity> connectedTo;

	public VoiceProcessor VoiceProcessor;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("ConnectedSpeaker.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void OnFlagsChanged(Flags old, Flags next)
	{
		base.OnFlagsChanged(old, next);
		if (!base.isServer || old.HasFlag(Flags.Reserved8) == next.HasFlag(Flags.Reserved8))
		{
			return;
		}
		if (next.HasFlag(Flags.Reserved8))
		{
			IAudioConnectionSource connectionSource = GetConnectionSource(this, BoomBox.BacktrackLength);
			if (connectionSource != null)
			{
				ClientRPC(RpcTarget.NetworkGroup("Client_PlayAudioFrom"), connectionSource.ToEntity().net.ID);
				connectedTo.Set(connectionSource.ToEntity());
			}
		}
		else if (connectedTo.IsSet)
		{
			ClientRPC(RpcTarget.NetworkGroup("Client_StopPlayingAudio"), connectedTo.uid);
			connectedTo.Set(null);
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.connectedSpeaker != null)
		{
			connectedTo.uid = info.msg.connectedSpeaker.connectedTo;
		}
	}

	private IAudioConnectionSource GetConnectionSource(IOEntity entity, int depth)
	{
		if (depth <= 0)
		{
			return null;
		}
		IOSlot[] array = entity.inputs;
		for (int i = 0; i < array.Length; i++)
		{
			IOEntity iOEntity = array[i].connectedTo.Get(base.isServer);
			if (iOEntity == this)
			{
				return null;
			}
			if (iOEntity != null && iOEntity is IAudioConnectionSource result)
			{
				return result;
			}
			if (iOEntity != null)
			{
				IAudioConnectionSource connectionSource = GetConnectionSource(iOEntity, depth - 1);
				if (connectionSource != null)
				{
					return connectionSource;
				}
			}
		}
		return null;
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.msg.connectedSpeaker == null)
		{
			info.msg.connectedSpeaker = Pool.Get<ProtoBuf.ConnectedSpeaker>();
		}
		info.msg.connectedSpeaker.connectedTo = connectedTo.uid;
	}
}
