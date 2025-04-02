using System.Collections.Generic;

public interface IWorkshopContent
{
	ulong WorkshopId { get; }

	string Title { get; }

	string Description { get; }

	IEnumerable<string> Tags { get; }

	string Url { get; }

	string PreviewImageUrl { get; }

	ulong OwnerId { get; }

	IPlayerInfo Owner { get; }

	bool IsInstalled { get; }

	bool IsDownloadPending { get; }

	bool IsDownloading { get; }

	string Directory { get; }

	bool Download();
}
