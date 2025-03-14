using Rust.Platform.Common;

public interface IPlatformHooks
{
	uint SteamAppId { get; }

	ServerParameters? ServerParameters { get; }

	void Abort();

	void OnItemDefinitionsChanged();

	void AuthSessionValidated(ulong userId, ulong ownerUserId, AuthResponse response, string rawResponse);
}
