using System;
using System.Collections.Generic;
using System.Linq;
using Facepunch.Sqlite;

public class NexusDB : Database
{
	public int JournalCount { get; private set; }

	public DateTimeOffset? OldestJournal { get; private set; }

	public int TransferredCount { get; private set; }

	public void Initialize()
	{
		if (!TableExists("seen"))
		{
			Execute("CREATE TABLE seen (id BLOB PRIMARY KEY)");
		}
		if (!TableExists("journal"))
		{
			Execute("CREATE TABLE journal (id BLOB PRIMARY KEY, time INTEGER, data BLOB)");
		}
		else
		{
			JournalCount = Query<int>("SELECT COUNT(*) FROM journal");
			if (JournalCount > 0)
			{
				long seconds = Query<long>("SELECT MIN(time) FROM journal");
				OldestJournal = DateTimeOffset.FromUnixTimeSeconds(seconds);
			}
			else
			{
				OldestJournal = null;
			}
		}
		if (!TableExists("transferred"))
		{
			Execute("CREATE TABLE transferred (id INTEGER PRIMARY KEY)");
		}
		else
		{
			TransferredCount = Query<int>("SELECT COUNT(*) FROM transferred");
		}
	}

	public bool Seen(Guid id)
	{
		Execute("INSERT INTO seen(id) VALUES(?) ON CONFLICT DO NOTHING", id);
		return base.AffectedRows > 0;
	}

	public bool SeenJournaled(Guid id, byte[] data)
	{
		long arg = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		BeginTransaction();
		try
		{
			Execute("INSERT INTO seen(id) VALUES(?) ON CONFLICT DO NOTHING", id);
			if (base.AffectedRows <= 0)
			{
				Commit();
				return false;
			}
			Execute("INSERT INTO journal(id, time, data) VALUES(?, ?, ?)", id, arg, data);
			JournalCount++;
			if (!OldestJournal.HasValue)
			{
				OldestJournal = DateTimeOffset.UtcNow;
			}
			Commit();
			return true;
		}
		catch
		{
			Rollback();
			throw;
		}
	}

	public List<(Guid Id, long Time, byte[] Data)> ReadJournal()
	{
		IntPtr stmHandle = Prepare("SELECT id, time, data FROM journal ORDER BY time ASC");
		return ExecuteAndReadQueryResults(stmHandle, ReadJournalRow).ToList();
	}

	private static (Guid, long, byte[]) ReadJournalRow(IntPtr stmHandle)
	{
		Guid columnValue = Database.GetColumnValue<Guid>(stmHandle, 0);
		long columnValue2 = Database.GetColumnValue<long>(stmHandle, 1);
		byte[] columnValue3 = Database.GetColumnValue<byte[]>(stmHandle, 2);
		return (columnValue, columnValue2, columnValue3);
	}

	public void ClearJournal()
	{
		Execute("DELETE FROM journal");
		JournalCount = 0;
		OldestJournal = null;
	}

	public void MarkTransferred(HashSet<NetworkableId> entityIds)
	{
		if (entityIds == null || entityIds.Count == 0)
		{
			return;
		}
		IntPtr stmHandle = Prepare("INSERT INTO transferred(id) VALUES(?) ON CONFLICT DO NOTHING");
		try
		{
			BeginTransaction();
			try
			{
				foreach (NetworkableId entityId in entityIds)
				{
					Database.Bind(stmHandle, 1, entityId.Value);
					ExecuteQuery(stmHandle);
				}
				Commit();
				TransferredCount += entityIds.Count;
			}
			catch
			{
				Rollback();
				throw;
			}
		}
		finally
		{
			Complete(stmHandle);
		}
	}

	public List<NetworkableId> ReadTransferred()
	{
		IntPtr stmHandle = Prepare("SELECT id FROM transferred");
		return ExecuteAndReadQueryResults(stmHandle, (IntPtr h) => new NetworkableId(Database.GetColumnValue<uint>(h, 0))).ToList();
	}

	public void ClearTransferred()
	{
		Execute("DELETE FROM transferred");
		TransferredCount = 0;
	}
}
