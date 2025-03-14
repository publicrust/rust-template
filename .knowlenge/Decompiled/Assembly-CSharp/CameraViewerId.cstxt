using System;

public struct CameraViewerId : IEquatable<CameraViewerId>
{
	public readonly ulong SteamId;

	public readonly long ConnectionId;

	public CameraViewerId(ulong steamId, long connectionId)
	{
		SteamId = steamId;
		ConnectionId = connectionId;
	}

	public bool Equals(CameraViewerId other)
	{
		if (SteamId == other.SteamId)
		{
			return ConnectionId == other.ConnectionId;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is CameraViewerId other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		ulong steamId = SteamId;
		int num = steamId.GetHashCode() * 397;
		long connectionId = ConnectionId;
		return num ^ connectionId.GetHashCode();
	}

	public static bool operator ==(CameraViewerId left, CameraViewerId right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(CameraViewerId left, CameraViewerId right)
	{
		return !left.Equals(right);
	}
}
