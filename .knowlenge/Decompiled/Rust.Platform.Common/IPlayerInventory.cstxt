using System;
using System.Collections.Generic;

public interface IPlayerInventory : IDisposable
{
	IReadOnlyList<IPlayerItem> Items { get; }

	bool BelongsTo(ulong userId);

	byte[] Serialize();
}
