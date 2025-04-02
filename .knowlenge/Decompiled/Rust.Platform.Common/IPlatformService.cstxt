using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPlatformService
{
	bool IsValid { get; }

	IReadOnlyList<IPlayerItemDefinition> ItemDefinitions { get; }

	bool Initialize(IPlatformHooks hooks);

	void Shutdown();

	void Update();

	void RefreshItemDefinitions();

	IPlayerItemDefinition GetItemDefinition(int definitionId);

	Task<IPlayerInventory> DeserializeInventory(byte[] data);

	bool PlayerOwnsDownloadableContent(ulong userId, int appId);

	Task<bool> LoadPlayerStats(ulong userId);

	Task<bool> SavePlayerStats(ulong userId);

	long GetPlayerStatInt(ulong userId, string key, long defaultValue = 0L);

	bool SetPlayerStatInt(ulong userId, string key, long value);

	bool BeginPlayerSession(ulong userId, byte[] authToken);

	void UpdatePlayerSession(ulong userId, string userName);

	void EndPlayerSession(ulong userId);
}
