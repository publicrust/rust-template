using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Network;
using UnityEngine;

public class DemoUploadManager
{
	private class UploadResult
	{
		public long Bytes;

		public TimeSpan TimeTaken;

		public int Concurrency;

		public long BandwidthPerSecondPerThread;

		public UploadResult(long bytes, TimeSpan time, int concurrency)
		{
			Bytes = bytes;
			TimeTaken = time;
			Concurrency = concurrency;
		}
	}

	private const string UploadUrl = "https://rustserverdemos.blob.core.windows.net/";

	private List<UploadResult> history = new List<UploadResult>();

	private ConcurrentQueue<DemoUploadRequest> queue = new ConcurrentQueue<DemoUploadRequest>();

	private long bytesInQueue;

	private Func<bool> IsConnected;

	internal DemoUploadManager(Func<bool> isConnected)
	{
		IsConnected = isConnected;
	}

	public void EnqueueUpload(DemoUploadRequest request)
	{
		ServicePointManager.FindServicePoint(new Uri("https://rustserverdemos.blob.core.windows.net/")).ConnectionLimit = DemoConVars.MaxUploadConcurrency;
		bytesInQueue += request.BytesToUpload;
		queue.Enqueue(request);
	}

	private int CalculateConcurrency(long requestBytes)
	{
		long bytesPerSecond = 0L;
		lock (history)
		{
			if (history.Count == 0)
			{
				return DemoConVars.MinimumConcurrency;
			}
			bytesPerSecond = (long)history.Average((UploadResult x) => x.BandwidthPerSecondPerThread);
		}
		int a = ConcurrencyForBytes(requestBytes, bytesPerSecond, TimeSpan.FromSeconds((float)DemoConVars.ServerDemoFlushIntervalSeconds / DemoConVars.BandwidthLimitRatio));
		int b = ConcurrencyForBytes(bytesInQueue, bytesPerSecond, TimeSpan.FromSeconds(DemoConVars.ServerDemoFlushIntervalSeconds * 3));
		return Mathf.Max(a, b);
	}

	private int ConcurrencyForBytes(long bytes, long bytesPerSecond, TimeSpan interval)
	{
		int num = (int)(bytes / bytesPerSecond);
		int num2 = (int)interval.TotalSeconds;
		return Mathf.Max(1, Mathf.CeilToInt((float)num / (float)num2));
	}

	internal async Task UploadThread()
	{
		while (IsConnected())
		{
			await Task.Delay(TimeSpan.FromSeconds(1.0));
			if (queue.TryDequeue(out var result))
			{
				int concurrency = CalculateConcurrency(result.BytesToUpload);
				bytesInQueue -= result.BytesToUpload;
				await UploadDemoToAzure(result, concurrency);
			}
		}
	}

	private async Task UploadDemoToAzure(DemoUploadRequest request, int concurrency)
	{
		_ = 1;
		try
		{
			ServicePointManager.FindServicePoint(new Uri(request.UploadEndpoint)).ConnectionLimit = DemoConVars.MaxUploadConcurrency;
			concurrency = Mathf.Clamp(concurrency, DemoConVars.MinimumConcurrency, DemoConVars.MaxUploadConcurrency);
			BlobContainerClient blobContainer = new BlobContainerClient(new Uri(request.UploadEndpoint));
			if (!request.State.DemoUploaded)
			{
				BlobClient blobClient = blobContainer.GetBlobClient(DemoPaths.GetBlobDemoPath(request.Header));
				BlobUploadOptions options = new BlobUploadOptions
				{
					HttpHeaders = new BlobHttpHeaders
					{
						ContentEncoding = (request.Header.IsZipped ? "gzip" : null)
					},
					TransferOptions = new StorageTransferOptions
					{
						MaximumConcurrency = concurrency
					}
				};
				DateTime timeStart = DateTime.UtcNow;
				await blobClient.UploadAsync(request.DemoDiskPath, options);
				request.State.DemoUploaded = true;
				request.State.DemoUploadDuration = DateTime.UtcNow - timeStart;
			}
			await blobContainer.GetBlobClient(DemoPaths.GetBlobHeaderPath(request.Header)).UploadAsync(options: new BlobUploadOptions
			{
				HttpHeaders = new BlobHttpHeaders
				{
					ContentType = "application/json"
				}
			}, path: request.HeaderDiskPath);
			DeleteLocalDemo(request);
			lock (history)
			{
				history.Add(new UploadResult(request.BytesToUpload, request.State.DemoUploadDuration, concurrency));
				if (history.Count > 20)
				{
					history.RemoveAt(0);
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			request.State.Failures++;
			if (request.State.Failures >= DemoConVars.MaxUploadAttempts)
			{
				DeleteLocalDemo(request);
			}
			else
			{
				queue.Enqueue(request);
			}
		}
	}

	private void DeleteLocalDemo(DemoUploadRequest request)
	{
		if (File.Exists(request.DemoDiskPath))
		{
			File.Delete(request.DemoDiskPath);
		}
		if (File.Exists(request.HeaderDiskPath))
		{
			File.Delete(request.HeaderDiskPath);
		}
	}
}
