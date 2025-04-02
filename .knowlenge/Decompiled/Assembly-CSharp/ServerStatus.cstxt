public struct ServerStatus
{
	public bool IsOnline;

	public RealTimeSince LastSeen;

	public int Players;

	public int MaxPlayers;

	public int QueuedPlayers;

	public bool IsFull => Players + QueuedPlayers >= MaxPlayers;
}
