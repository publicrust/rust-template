#define UNITY_ASSERTIONS
using System;
using System.Collections.Generic;
using ConVar;
using Facepunch;
using Network;
using ProtoBuf;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Audio;

public class MicrophoneStand : BaseMountable
{
	public enum SpeechMode
	{
		Normal,
		HighPitch,
		LowPitch
	}

	public VoiceProcessor VoiceProcessor;

	public AudioSource VoiceSource;

	private SpeechMode currentSpeechMode;

	public AudioMixerGroup NormalMix;

	public AudioMixerGroup HighPitchMix;

	public AudioMixerGroup LowPitchMix;

	public Translate.Phrase NormalPhrase = new Translate.Phrase("microphone_normal", "Normal");

	public Translate.Phrase NormalDescPhrase = new Translate.Phrase("microphone_normal_desc", "No voice effect");

	public Translate.Phrase HighPitchPhrase = new Translate.Phrase("microphone_high", "High Pitch");

	public Translate.Phrase HighPitchDescPhrase = new Translate.Phrase("microphone_high_desc", "High pitch voice");

	public Translate.Phrase LowPitchPhrase = new Translate.Phrase("microphone_low", "Low");

	public Translate.Phrase LowPitchDescPhrase = new Translate.Phrase("microphone_low_desc", "Low pitch voice");

	public GameObjectRef IOSubEntity;

	public Transform IOSubEntitySpawnPos;

	public bool IsStatic;

	public EntityRef<IOEntity> ioEntity;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("MicrophoneStand.OnRpcMessage"))
		{
			if (rpc == 1420522459 && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log("SV_RPCMessage: " + player?.ToString() + " - SetMode ");
				}
				using (TimeWarning.New("SetMode"))
				{
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage mode = rPCMessage;
							SetMode(mode);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in SetMode");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	[RPC_Server]
	public void SetMode(RPCMessage msg)
	{
		if (!(msg.player != GetMounted()))
		{
			SpeechMode speechMode = (SpeechMode)msg.read.Int32();
			if (speechMode != currentSpeechMode)
			{
				currentSpeechMode = speechMode;
				SendNetworkUpdate();
			}
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.msg.microphoneStand == null)
		{
			info.msg.microphoneStand = Facepunch.Pool.Get<ProtoBuf.MicrophoneStand>();
		}
		info.msg.microphoneStand.microphoneMode = (int)currentSpeechMode;
		info.msg.microphoneStand.IORef = ioEntity.uid;
	}

	public void SpawnChildEntity()
	{
		MicrophoneStandIOEntity microphoneStandIOEntity = GameManager.server.CreateEntity(IOSubEntity.resourcePath, IOSubEntitySpawnPos.localPosition, IOSubEntitySpawnPos.localRotation) as MicrophoneStandIOEntity;
		microphoneStandIOEntity.enableSaving = enableSaving;
		microphoneStandIOEntity.SetParent(this);
		microphoneStandIOEntity.Spawn();
		ioEntity.Set(microphoneStandIOEntity);
		SendNetworkUpdate();
	}

	public override void OnDeployed(BaseEntity parent, BasePlayer deployedBy, Item fromItem)
	{
		base.OnDeployed(parent, deployedBy, fromItem);
		SpawnChildEntity();
	}

	public override void PostMapEntitySpawn()
	{
		base.PostMapEntitySpawn();
		if (!IsStatic)
		{
			return;
		}
		SpawnChildEntity();
		int num = 128;
		List<ConnectedSpeaker> obj = Facepunch.Pool.Get<List<ConnectedSpeaker>>();
		GamePhysics.OverlapSphere(base.transform.position, num, obj, 256);
		IOEntity iOEntity = ioEntity.Get(serverside: true);
		List<MicrophoneStand> obj2 = Facepunch.Pool.Get<List<MicrophoneStand>>();
		int num2 = 0;
		foreach (ConnectedSpeaker item in obj)
		{
			bool flag = true;
			obj2.Clear();
			GamePhysics.OverlapSphere(item.transform.position, num, obj2, 256);
			if (obj2.Count > 1)
			{
				float num3 = Distance(item);
				foreach (MicrophoneStand item2 in obj2)
				{
					if (!item2.isClient && item2.Distance(item) < num3)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				iOEntity.outputs[0].connectedTo.Set(item);
				item.inputs[0].connectedTo.Set(iOEntity);
				iOEntity = item;
				num2++;
			}
		}
		Facepunch.Pool.FreeUnmanaged(ref obj);
		Facepunch.Pool.FreeUnmanaged(ref obj2);
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.microphoneStand != null)
		{
			currentSpeechMode = (SpeechMode)info.msg.microphoneStand.microphoneMode;
			ioEntity.uid = info.msg.microphoneStand.IORef;
		}
	}
}
