using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(Camera))]
public class CoverageQueries : MonoBehaviour
{
	public class BufferSet
	{
		public int width;

		public int height;

		public Texture2D inputTexture;

		public RenderTexture resultTexture;

		public Color[] inputData = new Color[0];

		public Color32[] resultData = new Color32[0];

		private Material coverageMat;

		private const int MaxAsyncGPUReadbackRequests = 10;

		private Queue<AsyncGPUReadbackRequest> asyncRequests = new Queue<AsyncGPUReadbackRequest>();

		public void Attach(Material coverageMat)
		{
			this.coverageMat = coverageMat;
		}

		public void Dispose(bool data = true)
		{
			if (inputTexture != null)
			{
				UnityEngine.Object.DestroyImmediate(inputTexture);
				inputTexture = null;
			}
			if (resultTexture != null)
			{
				RenderTexture.active = null;
				resultTexture.Release();
				UnityEngine.Object.DestroyImmediate(resultTexture);
				resultTexture = null;
			}
			if (data)
			{
				inputData = new Color[0];
				resultData = new Color32[0];
			}
		}

		public bool CheckResize(int count)
		{
			if (count > inputData.Length || (resultTexture != null && !resultTexture.IsCreated()))
			{
				Dispose(data: false);
				width = Mathf.CeilToInt(Mathf.Sqrt(count));
				height = Mathf.CeilToInt((float)count / (float)width);
				inputTexture = new Texture2D(width, height, TextureFormat.RGBAFloat, mipChain: false, linear: true);
				inputTexture.name = "_Input";
				inputTexture.filterMode = FilterMode.Point;
				inputTexture.wrapMode = TextureWrapMode.Clamp;
				resultTexture = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
				resultTexture.name = "_Result";
				resultTexture.filterMode = FilterMode.Point;
				resultTexture.wrapMode = TextureWrapMode.Clamp;
				resultTexture.useMipMap = false;
				resultTexture.Create();
				int num = resultData.Length;
				int num2 = width * height;
				Array.Resize(ref inputData, num2);
				Array.Resize(ref resultData, num2);
				Color32 color = new Color32(byte.MaxValue, 0, 0, 0);
				for (int i = num; i < num2; i++)
				{
					resultData[i] = color;
				}
				return true;
			}
			return false;
		}

		public void UploadData()
		{
			if (inputData.Length != 0)
			{
				inputTexture.SetPixels(inputData);
				inputTexture.Apply();
			}
		}

		public void Dispatch(int count)
		{
			if (inputData.Length != 0)
			{
				RenderBuffer activeColorBuffer = Graphics.activeColorBuffer;
				RenderBuffer activeDepthBuffer = Graphics.activeDepthBuffer;
				coverageMat.SetTexture("_Input", inputTexture);
				Graphics.Blit(inputTexture, resultTexture, coverageMat, 0);
				Graphics.SetRenderTarget(activeColorBuffer, activeDepthBuffer);
			}
		}

		public void IssueRead()
		{
			if (asyncRequests.Count < 10)
			{
				asyncRequests.Enqueue(AsyncGPUReadback.Request(resultTexture));
			}
		}

		public void GetResults()
		{
			if (resultData.Length == 0)
			{
				return;
			}
			while (asyncRequests.Count > 0)
			{
				AsyncGPUReadbackRequest asyncGPUReadbackRequest = asyncRequests.Peek();
				if (asyncGPUReadbackRequest.hasError)
				{
					asyncRequests.Dequeue();
					continue;
				}
				if (asyncGPUReadbackRequest.done)
				{
					NativeArray<Color32> data = asyncGPUReadbackRequest.GetData<Color32>();
					for (int i = 0; i < data.Length; i++)
					{
						resultData[i] = data[i];
					}
					asyncRequests.Dequeue();
					continue;
				}
				break;
			}
		}
	}

	public enum RadiusSpace
	{
		ScreenNormalized,
		World
	}

	public class Query
	{
		public struct Input
		{
			public Vector3 position;

			public RadiusSpace radiusSpace;

			public float radius;

			public int sampleCount;

			public float smoothingSpeed;
		}

		public struct Internal
		{
			public int id;

			public void Reset()
			{
				id = -1;
			}
		}

		public struct Result
		{
			public int passed;

			public float coverage;

			public float smoothCoverage;

			public float weightedCoverage;

			public float weightedSmoothCoverage;

			public bool originOccluded;

			public int frame;

			public float originVisibility;

			public float originSmoothVisibility;

			public void Reset()
			{
				passed = 0;
				coverage = 0f;
				smoothCoverage = 0f;
				weightedCoverage = 0f;
				weightedSmoothCoverage = 0f;
				originOccluded = true;
				frame = -1;
				originVisibility = 0f;
				originSmoothVisibility = 0f;
			}
		}

		public Input input;

		public Internal intern;

		public Result result;

		public bool IsRegistered => intern.id >= 0;
	}

	public float depthBias = -0.1f;

	public bool debug;
}
