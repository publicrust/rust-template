using System;
using Facepunch;
using Network;
using ProtoBuf;
using UnityEngine;

public class PlayerStateManager
{
	private readonly MruDictionary<ulong, PlayerState> _cache;

	private readonly UserPersistance _persistence;

	public int CacheSize
	{
		get
		{
			return _cache.Capacity;
		}
		set
		{
			_cache.SetCapacity(value);
		}
	}

	public int CacheCount => _cache.Count;

	public long CacheEvictions => _cache.EvictionCount;

	public PlayerStateManager(UserPersistance persistence)
	{
		_cache = new MruDictionary<ulong, PlayerState>(10000, FreeOldState);
		_persistence = persistence;
	}

	public PlayerState Get(ulong playerId)
	{
		using (TimeWarning.New("PlayerStateManager.Get"))
		{
			if (_cache.TryGetValue(playerId, out var value))
			{
				return value;
			}
			byte[] playerState = _persistence.GetPlayerState(playerId);
			PlayerState playerState2;
			if (playerState != null && playerState.Length != 0)
			{
				try
				{
					playerState2 = PlayerState.Deserialize(playerState);
					OnPlayerStateLoaded(playerState2);
					_cache.Add(playerId, playerState2);
					return playerState2;
				}
				catch (Exception arg)
				{
					Debug.LogError($"Failed to load player state for {playerId}: {arg}");
				}
			}
			playerState2 = Pool.Get<PlayerState>();
			_cache.Add(playerId, playerState2);
			return playerState2;
		}
	}

	public void Save(ulong playerId)
	{
		if (_cache.TryGetValue(playerId, out var value))
		{
			SaveState(playerId, value);
		}
	}

	private void SaveState(ulong playerId, PlayerState state)
	{
		using (TimeWarning.New("PlayerStateManager.SaveState"))
		{
			try
			{
				byte[] state2 = PlayerState.SerializeToBytes(state);
				_persistence.SetPlayerState(playerId, state2);
			}
			catch (Exception arg)
			{
				Debug.LogError($"Failed to save player state for {playerId}: {arg}");
			}
		}
	}

	private void FreeOldState(ulong playerId, PlayerState state)
	{
		SaveState(playerId, state);
		state.Dispose();
	}

	public void Reset(ulong playerId)
	{
		_cache.Remove(playerId);
		_persistence.ResetPlayerState(playerId);
	}

	private void OnPlayerStateLoaded(PlayerState state)
	{
		state.unHostileTimestamp = Math.Min(state.unHostileTimestamp, TimeEx.currentTimestamp + 1800.0);
	}
}
