using Facepunch;
using Rust.Platform.Steam;

public static class PlatformService
{
	public static readonly IPlatformService Instance = new SteamPlatform();

	public static bool Initialize(IPlatformHooks hooks)
	{
		if (CommandLine.HasSwitch("-nosteam"))
		{
			return true;
		}
		if (!Instance.Initialize(hooks))
		{
			return false;
		}
		return true;
	}
}
