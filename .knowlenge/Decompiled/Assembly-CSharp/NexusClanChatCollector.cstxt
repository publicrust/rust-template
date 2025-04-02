using System;
using System.Collections.Generic;
using Facepunch;
using ProtoBuf.Nexus;

public class NexusClanChatCollector
{
	private readonly IClanChangeSink _external;

	private readonly List<Message> _messagesBuffer;

	public NexusClanChatCollector(IClanChangeSink external)
	{
		_external = external ?? throw new ArgumentNullException("external");
		_messagesBuffer = new List<Message>();
	}

	public void TakeMessages(List<Message> messages)
	{
		foreach (Message item in _messagesBuffer)
		{
			messages.Add(item);
		}
		_messagesBuffer.Clear();
	}

	public void OnClanChatMessage(long clanId, ClanChatEntry entry)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		Message val = Pool.Get<Message>();
		val.clanId = clanId;
		val.userId = entry.SteamId;
		val.name = entry.Name;
		val.text = entry.Message;
		val.timestamp = entry.Time;
		_messagesBuffer.Add(val);
		_external.ClanChatMessage(clanId, entry);
	}
}
