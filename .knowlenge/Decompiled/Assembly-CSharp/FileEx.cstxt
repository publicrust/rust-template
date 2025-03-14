using System;
using System.IO;
using System.Threading;

public static class FileEx
{
	public static void Backup(DirectoryInfo parent, params string[] names)
	{
		for (int i = 0; i < names.Length; i++)
		{
			names[i] = Path.Combine(parent.FullName, names[i]);
		}
		Backup(names);
	}

	public static bool MoveToSafe(this FileInfo parent, string target, int retries = 10)
	{
		for (int i = 0; i < retries; i++)
		{
			try
			{
				parent.MoveTo(target);
			}
			catch (Exception)
			{
				Thread.Sleep(5);
				continue;
			}
			return true;
		}
		return false;
	}

	public static void Backup(params string[] names)
	{
		for (int num = names.Length - 2; num >= 0; num--)
		{
			FileInfo fileInfo = new FileInfo(names[num]);
			FileInfo fileInfo2 = new FileInfo(names[num + 1]);
			if (fileInfo.Exists)
			{
				if (fileInfo2.Exists)
				{
					double totalHours = (DateTime.Now - fileInfo2.LastWriteTime).TotalHours;
					int num2 = ((num != 0) ? (1 << num - 1) : 0);
					if (totalHours >= (double)num2)
					{
						fileInfo2.Delete();
						MoveToSafe(fileInfo, fileInfo2.FullName);
					}
				}
				else
				{
					if (!fileInfo2.Directory.Exists)
					{
						fileInfo2.Directory.Create();
					}
					MoveToSafe(fileInfo, fileInfo2.FullName);
				}
			}
		}
	}
}
