using System.Collections.Generic;

public interface IUGCBrowserEntity
{
	uint[] GetContentCRCs { get; }

	UGCType ContentType { get; }

	List<ulong> EditingHistory { get; }

	BaseNetworkable UgcEntity { get; }

	void ClearContent();
}
