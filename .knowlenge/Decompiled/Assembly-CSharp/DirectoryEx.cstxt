using System;
using System.IO;
using System.Threading;

public static class DirectoryEx
{
	public static void Backup(DirectoryInfo parent, params string[] names)
	{
		for (int i = 0; i < names.Length; i++)
		{
			names[i] = Path.Combine(parent.FullName, names[i]);
		}
		Backup(names);
	}

	public static bool MoveToSafe(this DirectoryInfo parent, string target, int retries = 10)
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
			DirectoryInfo directoryInfo = new DirectoryInfo(names[num]);
			DirectoryInfo directoryInfo2 = new DirectoryInfo(names[num + 1]);
			if (directoryInfo.Exists)
			{
				if (directoryInfo2.Exists)
				{
					double totalHours = (DateTime.Now - directoryInfo2.LastWriteTime).TotalHours;
					int num2 = ((num != 0) ? (1 << num - 1) : 0);
					if (totalHours >= (double)num2)
					{
						directoryInfo2.Delete(recursive: true);
						MoveToSafe(directoryInfo, directoryInfo2.FullName);
					}
				}
				else
				{
					if (!directoryInfo2.Parent.Exists)
					{
						directoryInfo2.Parent.Create();
					}
					MoveToSafe(directoryInfo, directoryInfo2.FullName);
				}
			}
		}
	}

	public static void CopyAll(string sourceDirectory, string targetDirectory)
	{
		DirectoryInfo source = new DirectoryInfo(sourceDirectory);
		DirectoryInfo target = new DirectoryInfo(targetDirectory);
		CopyAll(source, target);
	}

	public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
	{
		if (!(source.FullName.ToLower() == target.FullName.ToLower()) && source.Exists)
		{
			if (!target.Exists)
			{
				target.Create();
			}
			FileInfo[] files = source.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				FileInfo fileInfo2 = new FileInfo(Path.Combine(target.FullName, fileInfo.Name));
				fileInfo.CopyTo(fileInfo2.FullName, overwrite: true);
				fileInfo2.CreationTime = fileInfo.CreationTime;
				fileInfo2.LastAccessTime = fileInfo.LastAccessTime;
				fileInfo2.LastWriteTime = fileInfo.LastWriteTime;
			}
			DirectoryInfo[] directories = source.GetDirectories();
			foreach (DirectoryInfo directoryInfo in directories)
			{
				DirectoryInfo directoryInfo2 = target.CreateSubdirectory(directoryInfo.Name);
				CopyAll(directoryInfo, directoryInfo2);
				directoryInfo2.CreationTime = directoryInfo.CreationTime;
				directoryInfo2.LastAccessTime = directoryInfo.LastAccessTime;
				directoryInfo2.LastWriteTime = directoryInfo.LastWriteTime;
			}
		}
	}
}
