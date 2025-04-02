using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using ConVar;
using UnityEngine;

public static class MapUploader
{
	private static readonly HttpClient Http = new HttpClient();

	public static bool IsUploaded { get; private set; }

	public static string OriginalName { get; private set; }

	public static string OriginalMapFileName { get; private set; }

	public static string OriginalSaveFileName { get; private set; }

	public static async void UploadMap()
	{
		if (IsUploaded)
		{
			Debug.Log("[Rust.MapCache] Map was already uploaded!");
			return;
		}
		if (!World.Procedural)
		{
			Debug.Log("[Rust.MapCache] Server is not using a procedural map, will not upload to backend");
			return;
		}
		if (World.CanLoadFromUrl())
		{
			Debug.Log("[Rust.MapCache] server.levelurl appears to have already been set, not uploading map to backend");
			return;
		}
		string mapFileName = World.MapFileName;
		string fullPath = Path.GetFullPath(Path.Join(World.MapFolderName, mapFileName));
		if (!File.Exists(fullPath))
		{
			Debug.LogWarning("[Rust.MapCache] Map file was not found: " + fullPath);
			return;
		}
		try
		{
			using FileStream fs = File.OpenRead(fullPath);
			string text = await UploadMapImpl(fs, mapFileName);
			if (text != null)
			{
				OriginalName = World.Name;
				OriginalMapFileName = World.MapFileName;
				OriginalSaveFileName = World.SaveFileName;
				Server.levelurl = text;
				World.Url = text;
				IsUploaded = true;
				Debug.Log("[Rust.MapCache] Map uploaded to backend: " + text);
			}
		}
		catch (Exception arg)
		{
			Debug.LogError($"[Rust.MapCache] Failed to upload map to backend: {arg}");
		}
	}

	private static async Task<string> UploadMapImpl(Stream stream, string mapFileName)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (string.IsNullOrWhiteSpace(mapFileName))
		{
			throw new ArgumentNullException("mapFileName");
		}
		if (!stream.CanRead || !stream.CanSeek)
		{
			throw new ArgumentException("Stream must be readable and seekable.", "stream");
		}
		string requestUri = "https://api.facepunch.com/api/public/rust-map-upload/" + mapFileName;
		for (int i = 0; i < 10; i++)
		{
			try
			{
				stream.Seek(0L, SeekOrigin.Begin);
				using MemoryStream streamCopy = new MemoryStream();
				await stream.CopyToAsync(streamCopy);
				streamCopy.Position = 0L;
				using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, requestUri);
				request.Content = new StreamContent(streamCopy);
				using HttpResponseMessage response = await Http.SendAsync(request);
				if (response.IsSuccessStatusCode)
				{
					string text = await response.Content.ReadAsStringAsync();
					if (string.IsNullOrWhiteSpace(text) || !text.StartsWith("http"))
					{
						throw new Exception("Backend sent an invalid success response when uploading the map.");
					}
					return text;
				}
				int statusCode = (int)response.StatusCode;
				if (statusCode >= 400 && statusCode <= 499)
				{
					Debug.LogError("[Rust.MapCache] Backend refused our map upload request: " + await response.Content.ReadAsStringAsync());
					return null;
				}
				response.EnsureSuccessStatusCode();
			}
			catch (Exception arg)
			{
				Debug.LogWarning($"[Rust.MapCache] Failed to upload map file: {arg}");
				await Task.Delay(1000 + i * 5000);
			}
		}
		Debug.LogError("[Rust.MapCache] Unable to upload map file!");
		return null;
	}
}
