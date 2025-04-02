using System;
using System.Collections.Generic;
using Facepunch;
using ProtoBuf.Nexus;

public class NexusClanChatCollector
{
	private readonly IClanChangeSink _external;

	private readonly List<ClanChatBatchRequest.Message> _messagesBuffer;

	public NexusClanChatCollector(IClanChangeSink external)
	{
		_external = external ?? throw new ArgumentNullException("external");
		_messagesBuffer = new List<ClanChatBatchRequest.Message>();
	}

	public void TakeMessages(List<ClanChatBatchRequest.Message> messages)
	{
		foreach (ClanChatBatchRequest.Message item in _messagesBuffer)
		{
			messages.Add(item);
		}
		_messagesBuffer.Clear();
	}

	public void OnClanChatMessage(long clanId, ClanChatEntry entry)
	{
		ClanChatBatchRequest.Message message = Pool.Get<ClanChatBatchRequest.Message>();
		message.clanId = clanId;
		message.userId = entry.SteamId;
		message.name = entry.Name;
		message.text = entry.Message;
		message.timestamp = entry.Time;
		_messagesBuffer.Add(message);
		_external.ClanChatMessage(clanId, entry);
	}
}
