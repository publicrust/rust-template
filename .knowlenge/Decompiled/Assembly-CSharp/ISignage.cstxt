using UnityEngine;

public interface ISignage
{
	Vector2i TextureSize { get; }

	int TextureCount { get; }

	NetworkableId NetworkID { get; }

	FileStorage.Type FileType { get; }

	bool CanUpdateSign(BasePlayer player);

	float Distance(Vector3 position);

	uint[] GetTextureCRCs();

	void SetTextureCRCs(uint[] crcs);
}
