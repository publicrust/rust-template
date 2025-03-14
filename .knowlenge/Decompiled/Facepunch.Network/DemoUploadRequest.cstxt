using System.IO;
using Network;

public class DemoUploadRequest
{
	public DemoChunkHeader Header;

	public string DemoDiskPath;

	public string HeaderDiskPath;

	public string UploadEndpoint;

	public DemoUploadState State = new DemoUploadState();

	public long BytesToUpload { get; }

	public DemoUploadRequest(DemoChunkHeader header, string demoLocalPath, string headerDiskPath, string containerUrl)
	{
		Header = header;
		DemoDiskPath = demoLocalPath;
		HeaderDiskPath = headerDiskPath;
		UploadEndpoint = containerUrl;
		if (!File.Exists(DemoDiskPath))
		{
			throw new FileNotFoundException("Demo file not found", DemoDiskPath);
		}
		FileInfo fileInfo = new FileInfo(demoLocalPath);
		BytesToUpload = fileInfo.Length;
	}
}
