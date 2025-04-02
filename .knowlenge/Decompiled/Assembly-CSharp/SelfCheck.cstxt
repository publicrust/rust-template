using System;
using System.Runtime.InteropServices;
using Facepunch;
using UnityEngine;

public static class SelfCheck
{
	public static bool Run()
	{
		if (FileSystem.Backend.isError)
		{
			return Failed("Asset Bundle Error: " + FileSystem.Backend.loadingError);
		}
		if (FileSystem.Load<GameManifest>("Assets/manifest.asset") == null)
		{
			return Failed("Couldn't load game manifest - verify your game content!");
		}
		if (!TestRustNative())
		{
			return false;
		}
		if (CommandLine.HasSwitch("-force-feature-level-9-3"))
		{
			return Failed("Invalid command line argument: -force-feature-level-9-3");
		}
		if (CommandLine.HasSwitch("-force-feature-level-10-0"))
		{
			return Failed("Invalid command line argument: -force-feature-level-10-0");
		}
		if (CommandLine.HasSwitch("-force-feature-level-10-1"))
		{
			return Failed("Invalid command line argument: -force-feature-level-10-1");
		}
		return true;
	}

	private static bool Failed(string Message)
	{
		if ((bool)SingletonComponent<Bootstrap>.Instance)
		{
			SingletonComponent<Bootstrap>.Instance.messageString = "";
			SingletonComponent<Bootstrap>.Instance.ThrowError(Message);
		}
		Debug.LogError("SelfCheck Failed: " + Message);
		return false;
	}

	private static bool TestRustNative()
	{
		try
		{
			if (!RustNative_VersionCheck(5))
			{
				return Failed("RustNative is wrong version!");
			}
		}
		catch (DllNotFoundException ex)
		{
			return Failed("RustNative library couldn't load! " + ex.Message);
		}
		return true;
	}

	[DllImport("RustNative")]
	private static extern bool RustNative_VersionCheck(int version);
}
