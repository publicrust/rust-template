using System.Collections.Generic;
using UnityEngine;

public static class ServerPlayers
{
	private static readonly HashSet<ulong> OnlineUserIdSet = new HashSet<ulong>();

	private static int _currentFrame;

	public static bool IsOnline(ulong userId)
	{
		RebuildIfNecessary();
		return OnlineUserIdSet.Contains(userId);
	}

	public static void GetAll(List<ulong> userIds)
	{
		RebuildIfNecessary();
		foreach (ulong item in OnlineUserIdSet)
		{
			userIds.Add(item);
		}
	}

	private static void RebuildIfNecessary()
	{
		int frameCount = Time.frameCount;
		if (frameCount == _currentFrame)
		{
			return;
		}
		_currentFrame = frameCount;
		OnlineUserIdSet.Clear();
		foreach (BasePlayer activePlayer in BasePlayer.activePlayerList)
		{
			OnlineUserIdSet.Add(activePlayer.userID);
		}
	}
}
