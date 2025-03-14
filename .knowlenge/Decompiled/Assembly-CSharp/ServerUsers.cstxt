using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ConVar;
using Facepunch.Math;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Oxide.Core;
using UnityEngine;

public static class ServerUsers
{
	public enum UserGroup
	{
		None,
		Owner,
		Moderator,
		Banned,
		SkipQueue
	}

	[JsonModel]
	public class User
	{
		public ulong steamid;

		[JsonConverter(typeof(StringEnumConverter))]
		public UserGroup group;

		public string username;

		public string notes;

		public long expiry;

		[JsonIgnore]
		public bool IsExpired
		{
			get
			{
				if (expiry > 0)
				{
					return Epoch.Current > expiry;
				}
				return false;
			}
		}
	}

	private static StringBuilder sb = new StringBuilder(65536);

	public static Dictionary<ulong, User> users = new Dictionary<ulong, User>();

	public static void Remove(ulong uid)
	{
		Interface.CallHook("OnServerUserRemove", uid);
		users.Remove(uid);
	}

	public static void Set(ulong uid, UserGroup group, string username, string notes, long expiry = -1L)
	{
		Remove(uid);
		User value = new User
		{
			steamid = uid,
			group = group,
			username = username,
			notes = notes,
			expiry = expiry
		};
		Interface.CallHook("OnServerUserSet", uid, group, username, notes, expiry);
		users.Add(uid, value);
	}

	public static User Get(ulong uid)
	{
		if (!users.TryGetValue(uid, out var value))
		{
			return null;
		}
		if (!value.IsExpired)
		{
			return value;
		}
		Remove(uid);
		return null;
	}

	public static bool Is(ulong uid, UserGroup group)
	{
		User user = Get(uid);
		if (user == null)
		{
			return false;
		}
		return user.group == group;
	}

	public static IEnumerable<User> GetAll(UserGroup group)
	{
		return from x in users.Values
			where x.@group == @group
			where !x.IsExpired
			select x;
	}

	public static void Clear()
	{
		users.Clear();
	}

	public static void Load()
	{
		Clear();
		string serverFolder = Server.GetServerFolder("cfg");
		if (File.Exists(serverFolder + "/bans.cfg"))
		{
			string text = File.ReadAllText(serverFolder + "/bans.cfg");
			if (!string.IsNullOrEmpty(text))
			{
				Debug.Log("Running " + serverFolder + "/bans.cfg");
				ConsoleSystem.RunFile(ConsoleSystem.Option.Server.Quiet(), text);
			}
		}
		if (File.Exists(serverFolder + "/users.cfg"))
		{
			string text2 = File.ReadAllText(serverFolder + "/users.cfg");
			if (!string.IsNullOrEmpty(text2))
			{
				Debug.Log("Running " + serverFolder + "/users.cfg");
				ConsoleSystem.RunFile(ConsoleSystem.Option.Server.Quiet(), text2);
			}
		}
	}

	public static void Save()
	{
		foreach (ulong item in (from kv in users
			where kv.Value.IsExpired
			select kv.Key).ToList())
		{
			Remove(item);
		}
		string serverFolder = Server.GetServerFolder("cfg");
		sb.Clear();
		foreach (User item2 in GetAll(UserGroup.Banned))
		{
			if (!(item2.notes == "EAC"))
			{
				sb.Append("banid ");
				sb.Append(item2.steamid);
				sb.Append(' ');
				sb.QuoteSafe(item2.username);
				sb.Append(' ');
				sb.QuoteSafe(item2.notes);
				sb.Append(' ');
				sb.Append(item2.expiry);
				sb.Append("\r\n");
			}
		}
		File.WriteAllText(serverFolder + "/bans.cfg", sb.ToString());
		sb.Clear();
		foreach (User item3 in GetAll(UserGroup.Owner))
		{
			sb.Append("ownerid ");
			sb.Append(item3.steamid);
			sb.Append(' ');
			sb.QuoteSafe(item3.username);
			sb.Append(' ');
			sb.QuoteSafe(item3.notes);
			sb.Append("\r\n");
		}
		foreach (User item4 in GetAll(UserGroup.Moderator))
		{
			sb.Append("moderatorid ");
			sb.Append(item4.steamid);
			sb.Append(' ');
			sb.QuoteSafe(item4.username);
			sb.Append(' ');
			sb.QuoteSafe(item4.notes);
			sb.Append("\r\n");
		}
		foreach (User item5 in GetAll(UserGroup.SkipQueue))
		{
			sb.Append("skipqueueid ");
			sb.Append(item5.steamid);
			sb.Append(' ');
			sb.QuoteSafe(item5.username);
			sb.Append(' ');
			sb.QuoteSafe(item5.notes);
			sb.Append("\r\n");
		}
		File.WriteAllText(serverFolder + "/users.cfg", sb.ToString());
	}

	public static string BanListString(bool bHeader = false)
	{
		List<User> list = GetAll(UserGroup.Banned).ToList();
		sb.Clear();
		if (bHeader)
		{
			if (list.Count == 0)
			{
				return "ID filter list: empty\n";
			}
			if (list.Count == 1)
			{
				sb.Append("ID filter list: 1 entry\n");
			}
			else
			{
				sb.Append($"ID filter list: {list.Count} entries\n");
			}
		}
		int num = 1;
		foreach (User item in list)
		{
			sb.Append(num);
			sb.Append(' ');
			sb.Append(item.steamid);
			sb.Append(" : ");
			if (item.expiry > 0)
			{
				double num2 = (double)(item.expiry - Epoch.Current) / 60.0;
				sb.Append(num2.ToString("F3"));
				sb.Append(" min");
			}
			else
			{
				sb.Append("permanent");
			}
			sb.Append('\n');
			num++;
		}
		return sb.ToString();
	}

	public static string BanListStringEx()
	{
		IEnumerable<User> all = GetAll(UserGroup.Banned);
		sb.Clear();
		int num = 1;
		foreach (User item in all)
		{
			sb.Append(num);
			sb.Append(' ');
			sb.Append(item.steamid);
			sb.Append(' ');
			sb.QuoteSafe(item.username);
			sb.Append(' ');
			sb.QuoteSafe(item.notes);
			sb.Append(' ');
			sb.Append(item.expiry);
			sb.Append('\n');
			num++;
		}
		return sb.ToString();
	}
}
