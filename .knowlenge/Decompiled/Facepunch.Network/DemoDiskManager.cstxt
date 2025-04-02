using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Network;

public class DemoDiskManager
{
	private DateTime nextDemoDiskQuotaEnforcement;

	internal void EnforceDemoDiskSpaceQuota()
	{
		if (nextDemoDiskQuotaEnforcement > DateTime.UtcNow)
		{
			return;
		}
		nextDemoDiskQuotaEnforcement = DateTime.UtcNow.AddMinutes(DemoConVars.DiskCleanupIntervalMinutes);
		if (!Directory.Exists(DemoConVars.ServerDemoDirectory))
		{
			return;
		}
		FileInfo[] files = new DirectoryInfo(DemoConVars.ServerDemoDirectory).GetFiles("*.sdem");
		List<FileInfo> list = files.OrderBy((FileInfo x) => x.CreationTimeUtc).ToList();
		long num = files.Sum((FileInfo x) => x.Length);
		long num2 = (long)DemoConVars.MaxDemoDiskSpaceGB * 1024L * 1024 * 1024;
		foreach (FileInfo item in list)
		{
			if (num < num2)
			{
				break;
			}
			num -= item.Length;
			item.Delete();
			File.Delete(DemoPaths.GetLocalHeaderPath(Path.GetFileNameWithoutExtension(item.Name)));
		}
	}
}
