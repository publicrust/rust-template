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
		if (!((Database)this).TableExists("seen"))
		{
			((Database)this).Execute("CREATE TABLE seen (id BLOB PRIMARY KEY)");
		}
		if (!((Database)this).TableExists("journal"))
		{
			((Database)this).Execute("CREATE TABLE journal (id BLOB PRIMARY KEY, time INTEGER, data BLOB)");
		}
		else
		{
			JournalCount = ((Database)this).Query<int>("SELECT COUNT(*) FROM journal");
			if (JournalCount > 0)
			{
				long seconds = ((Database)this).Query<long>("SELECT MIN(time) FROM journal");
				OldestJournal = DateTimeOffset.FromUnixTimeSeconds(seconds);
			}
			else
			{
				OldestJournal = null;
			}
		}
		if (!((Database)this).TableExists("transferred"))
		{
			((Database)this).Execute("CREATE TABLE transferred (id INTEGER PRIMARY KEY)");
		}
		else
		{
			TransferredCount = ((Database)this).Query<int>("SELECT COUNT(*) FROM transferred");
		}
	}

	public bool Seen(Guid id)
	{
		((Database)this).Execute<Guid>("INSERT INTO seen(id) VALUES(?) ON CONFLICT DO NOTHING", id);
		return ((Database)this).AffectedRows > 0;
	}

	public bool SeenJournaled(Guid id, byte[] data)
	{
		long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		((Database)this).BeginTransaction();
		try
		{
			((Database)this).Execute<Guid>("INSERT INTO seen(id) VALUES(?) ON CONFLICT DO NOTHING", id);
			if (((Database)this).AffectedRows <= 0)
			{
				((Database)this).Commit();
				return false;
			}
			((Database)this).Execute<Guid, long, byte[]>("INSERT INTO journal(id, time, data) VALUES(?, ?, ?)", id, num, data);
			JournalCount++;
			if (!OldestJournal.HasValue)
			{
				OldestJournal = DateTimeOffset.UtcNow;
			}
			((Database)this).Commit();
			return true;
		}
		catch
		{
			((Database)this).Rollback();
			throw;
		}
	}

	public List<(Guid Id, long Time, byte[] Data)> ReadJournal()
	{
		IntPtr intPtr = ((Database)this).Prepare("SELECT id, time, data FROM journal ORDER BY time ASC");
		return ((Database)this).ExecuteAndReadQueryResults<(Guid, long, byte[])>(intPtr, (Func<IntPtr, (Guid, long, byte[])>)ReadJournalRow).ToList();
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
		((Database)this).Execute("DELETE FROM journal");
		JournalCount = 0;
		OldestJournal = null;
	}

	public void MarkTransferred(HashSet<NetworkableId> entityIds)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		if (entityIds == null || entityIds.Count == 0)
		{
			return;
		}
		IntPtr intPtr = ((Database)this).Prepare("INSERT INTO transferred(id) VALUES(?) ON CONFLICT DO NOTHING");
		try
		{
			((Database)this).BeginTransaction();
			try
			{
				foreach (NetworkableId entityId in entityIds)
				{
					Database.Bind<ulong>(intPtr, 1, entityId.Value);
					((Database)this).ExecuteQuery(intPtr);
				}
				((Database)this).Commit();
				TransferredCount += entityIds.Count;
			}
			catch
			{
				((Database)this).Rollback();
				throw;
			}
		}
		finally
		{
			((Database)this).Complete(intPtr);
		}
	}

	public List<NetworkableId> ReadTransferred()
	{
		IntPtr intPtr = ((Database)this).Prepare("SELECT id FROM transferred");
		return ((Database)this).ExecuteAndReadQueryResults<NetworkableId>(intPtr, (Func<IntPtr, NetworkableId>)((IntPtr h) => new NetworkableId((ulong)Database.GetColumnValue<uint>(h, 0)))).ToList();
	}

	public void ClearTransferred()
	{
		((Database)this).Execute("DELETE FROM transferred");
		TransferredCount = 0;
	}
}
