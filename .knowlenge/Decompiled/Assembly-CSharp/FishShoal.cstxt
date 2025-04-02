using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public class FishShoal : IDisposable
{
	[Serializable]
	public struct FishType
	{
		public Mesh mesh;

		public Material material;

		public int castsPerFrame;

		public int maxCount;

		public float minSpeed;

		public float maxSpeed;

		public float idealDepth;

		public float minTurnSpeed;

		public float maxTurnSpeed;

		public float minScale;

		public float maxScale;
	}

	public struct FishData
	{
		public bool isAlive;

		public float updateTime;

		public float startleTime;

		public float spawnX;

		public float spawnZ;

		public float destinationX;

		public float destinationZ;

		public float directionX;

		public float directionZ;

		public float speed;

		public float scale;
	}

	public struct FishRenderData
	{
		public float3 position;

		public float rotation;

		public float scale;

		public float distance;

		public float seed;
	}

	public struct FishCollisionGatherJob : IJob
	{
		public int layerMask;

		public uint seed;

		public int castCount;

		public int fishCount;

		public NativeArray<RaycastCommand> castCommands;

		public NativeArray<FishData> fishDataArray;

		public NativeArray<FishRenderData> fishRenderDataArray;

		public NativeArray<int> fishCastIndices;

		public void Execute()
		{
			Unity.Mathematics.Random random = new Unity.Mathematics.Random(seed);
			int length = castCommands.Length;
			for (int i = 0; i < length; i++)
			{
				if (i >= castCount)
				{
					castCommands[i] = default(RaycastCommand);
					continue;
				}
				int num = random.NextInt(0, fishCount);
				FishData fishData = fishDataArray[num];
				FishRenderData fishRenderData = fishRenderDataArray[num];
				castCommands[i] = new RaycastCommand
				{
					from = fishRenderData.position,
					direction = new float3(fishData.directionX, 0f, fishData.directionZ),
					distance = 4f,
					layerMask = layerMask,
					maxHits = 1
				};
				fishCastIndices[i] = num;
			}
		}
	}

	public struct FishCollisionProcessJob : IJob
	{
		public int castCount;

		public NativeArray<FishData> fishDataArray;

		[ReadOnly]
		public NativeArray<RaycastHit> castResults;

		[ReadOnly]
		public NativeArray<int> fishCastIndices;

		[ReadOnly]
		public NativeArray<FishRenderData> fishRenderDataArray;

		public void Execute()
		{
			for (int i = 0; i < castCount; i++)
			{
				if (castResults[i].normal != default(Vector3))
				{
					int index = fishCastIndices[i];
					FishData value = fishDataArray[index];
					if (value.startleTime <= 0f)
					{
						float2 xz = fishRenderDataArray[index].position.xz;
						float2 @float = math.normalize(new float2(castResults[i].point.x, castResults[i].point.z) - xz);
						float2 float2 = xz - @float * 8f;
						value.destinationX = float2.x;
						value.destinationZ = float2.y;
						value.startleTime = 2f;
						value.updateTime = 6f;
						fishDataArray[index] = value;
					}
				}
			}
		}
	}

	public struct FishUpdateJob : IJobParallelFor
	{
		[ReadOnly]
		public float3 cameraPosition;

		[ReadOnly]
		public uint seed;

		[ReadOnly]
		public float dt;

		[ReadOnly]
		public float minSpeed;

		[ReadOnly]
		public float maxSpeed;

		[ReadOnly]
		public float minTurnSpeed;

		[ReadOnly]
		public float maxTurnSpeed;

		[ReadOnly]
		public float minDepth;

		[NativeDisableUnsafePtrRestriction]
		public unsafe FishData* fishDataArray;

		[NativeDisableUnsafePtrRestriction]
		public unsafe FishRenderData* fishRenderDataArray;

		public unsafe void Execute(int i)
		{
			FishData* ptr = fishDataArray + i;
			FishRenderData* ptr2 = fishRenderDataArray + i;
			Unity.Mathematics.Random random = new Unity.Mathematics.Random((uint)(i * 3245 + seed));
			float num = math.distancesq(cameraPosition, ptr2->position);
			bool flag = ptr->startleTime > 0f;
			if (num > math.pow(40f, 2f) || ptr2->position.y > minDepth)
			{
				ptr->isAlive = false;
				return;
			}
			if (!flag && num < 100f)
			{
				ptr->startleTime = 2f;
				flag = true;
			}
			float3 @float = new float3(ptr->destinationX, ptr2->position.y, ptr->destinationZ);
			if (ptr->updateTime >= 8f || math.distancesq(@float, ptr2->position) < 1f)
			{
				float3 target = GetTarget(new float3(ptr->spawnX, 0f, ptr->spawnZ), ref random);
				ptr->updateTime = 0f;
				ptr->destinationX = target.x;
				ptr->destinationZ = target.z;
			}
			ptr2->scale = math.lerp(ptr2->scale, ptr->scale, dt * 5f);
			ptr->speed = math.lerp(ptr->speed, flag ? maxSpeed : minSpeed, dt * 4f);
			float3 float2 = math.normalize(@float - ptr2->position);
			float a = math.atan2(float2.z, float2.x);
			ptr2->rotation = 0f - ptr2->rotation + MathF.PI / 2f;
			float num2 = (flag ? maxTurnSpeed : minTurnSpeed);
			ptr2->rotation = LerpAngle(ptr2->rotation, a, dt * num2);
			float3 zero = float3.zero;
			math.sincos(ptr2->rotation, out zero.z, out zero.x);
			ptr->directionX = zero.x;
			ptr->directionZ = zero.z;
			ptr2->position += zero * ptr->speed * dt;
			ptr2->rotation = 0f - ptr2->rotation + MathF.PI / 2f;
			ptr2->distance += ptr->speed * dt;
			ptr->updateTime += dt;
			ptr->startleTime -= dt;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static float LerpAngle(float a0, float a1, float t)
		{
			float num = a1 - a0;
			num = math.clamp(num - math.floor(num / (MathF.PI * 2f)) * (MathF.PI * 2f), 0f, MathF.PI * 2f);
			return math.lerp(a0, a0 + ((num > MathF.PI) ? (num - MathF.PI * 2f) : num), t);
		}
	}

	public struct KillFish : IJob
	{
		public NativeArray<FishData> fishDataArray;

		public NativeArray<FishRenderData> fishRenderDataArray;

		public NativeArray<int> fishCount;

		public void Execute()
		{
			int num = fishCount[0];
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (!fishDataArray[num2].isAlive)
				{
					if (num2 < num - 1)
					{
						fishDataArray[num2] = fishDataArray[num - 1];
						fishRenderDataArray[num2] = fishRenderDataArray[num - 1];
					}
					num--;
				}
			}
			fishCount[0] = num;
		}
	}

	private const float maxFishDistance = 40f;

	private FishType fishType;

	private JobHandle jobHandle;

	private NativeArray<RaycastCommand> castCommands;

	private NativeArray<RaycastHit> castResults;

	private NativeArray<int> fishCastIndices;

	private NativeArray<FishData> fishData;

	private NativeArray<FishRenderData> fishRenderData;

	private NativeArray<int> fishCount;

	private MaterialPropertyBlock materialPropertyBlock;

	private ComputeBuffer fishBuffer;

	public FishShoal(FishType fishType)
	{
		this.fishType = fishType;
		castCommands = new NativeArray<RaycastCommand>(fishType.castsPerFrame, Allocator.Persistent);
		castResults = new NativeArray<RaycastHit>(fishType.castsPerFrame, Allocator.Persistent);
		fishCastIndices = new NativeArray<int>(fishType.castsPerFrame, Allocator.Persistent);
		fishData = new NativeArray<FishData>(fishType.maxCount, Allocator.Persistent);
		fishRenderData = new NativeArray<FishRenderData>(fishType.maxCount, Allocator.Persistent);
		fishCount = new NativeArray<int>(1, Allocator.Persistent);
		fishBuffer = new ComputeBuffer(fishType.maxCount, UnsafeUtility.SizeOf<FishRenderData>());
		materialPropertyBlock = new MaterialPropertyBlock();
		materialPropertyBlock.SetBuffer("_FishData", fishBuffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static float3 GetTarget(float3 spawnPos, ref Unity.Mathematics.Random random)
	{
		float2 @float = random.NextFloat2Direction();
		return spawnPos + new float3(@float.x, 0f, @float.y) * random.NextFloat(10f, 15f);
	}

	private int GetPopulationScaleForPoint(float3 cameraPosition)
	{
		return 1;
	}

	public void TrySpawn(float3 cameraPosition)
	{
		(float, float) waterAndTerrainSurface = WaterLevel.GetWaterAndTerrainSurface(cameraPosition, waves: false, volumes: false);
		float item = waterAndTerrainSurface.Item1;
		float item2 = waterAndTerrainSurface.Item2;
		item -= 3f;
		if (math.abs(item - item2) < 4f || item < item2)
		{
			return;
		}
		int num = fishCount[0];
		int num2 = Mathf.Min(Mathf.CeilToInt(fishType.maxCount * GetPopulationScaleForPoint(cameraPosition)) - num, 5);
		if (num2 <= 0)
		{
			return;
		}
		uint num3 = (uint)(Time.frameCount + fishType.mesh.vertexCount);
		int num4 = fishCount[0];
		int num5 = math.min(num4 + num2, fishType.maxCount);
		for (int i = num4; i < num5; i++)
		{
			Unity.Mathematics.Random random = new Unity.Mathematics.Random((uint)(i * 3245 + num3));
			float3 @float = cameraPosition + random.NextFloat3Direction() * random.NextFloat(40f);
			@float.y = random.NextFloat(math.max(item2 + 1f, cameraPosition.y - 30f), math.min(item, cameraPosition.y + 30f));
			if (!(WaterSystem.Instance == null) && WaterLevel.Test(@float, waves: false, volumes: false) && !(TerrainMeta.HeightMap.GetHeight(@float) > @float.y) && !EnvironmentManager.Check(@float, EnvironmentType.UnderwaterLab, 30f))
			{
				float3 target = GetTarget(@float, ref random);
				float3 float2 = math.normalize(target - @float);
				fishData[num] = new FishData
				{
					isAlive = true,
					spawnX = @float.x,
					spawnZ = @float.z,
					destinationX = target.x,
					destinationZ = target.z,
					scale = random.NextFloat(fishType.minScale, fishType.maxScale)
				};
				fishRenderData[num] = new FishRenderData
				{
					position = @float,
					rotation = math.atan2(float2.z, float2.x),
					scale = 0f,
					seed = random.NextFloat(0f, 2f)
				};
				num++;
			}
		}
		fishCount[0] = num;
	}

	public void OnUpdate(float3 cameraPosition)
	{
		UpdateJobs(cameraPosition);
	}

	private unsafe void UpdateJobs(float3 cameraPosition)
	{
		jobHandle.Complete();
		int num = fishCount[0];
		if (num != 0)
		{
			float item = WaterLevel.GetWaterAndTerrainSurface(cameraPosition, waves: false, volumes: false).Item1;
			item -= 3f;
			int castCount = math.min(fishType.castsPerFrame, num);
			uint seed = (uint)(Time.frameCount + fishType.mesh.vertexCount);
			FishCollisionGatherJob fishCollisionGatherJob = default(FishCollisionGatherJob);
			fishCollisionGatherJob.layerMask = -1;
			fishCollisionGatherJob.seed = seed;
			fishCollisionGatherJob.castCount = castCount;
			fishCollisionGatherJob.fishCount = num;
			fishCollisionGatherJob.castCommands = castCommands;
			fishCollisionGatherJob.fishCastIndices = fishCastIndices;
			fishCollisionGatherJob.fishDataArray = fishData;
			fishCollisionGatherJob.fishRenderDataArray = fishRenderData;
			FishCollisionGatherJob jobData = fishCollisionGatherJob;
			FishCollisionProcessJob fishCollisionProcessJob = default(FishCollisionProcessJob);
			fishCollisionProcessJob.castCount = castCount;
			fishCollisionProcessJob.castResults = castResults;
			fishCollisionProcessJob.fishCastIndices = fishCastIndices;
			fishCollisionProcessJob.fishDataArray = fishData;
			fishCollisionProcessJob.fishRenderDataArray = fishRenderData;
			FishCollisionProcessJob jobData2 = fishCollisionProcessJob;
			FishUpdateJob fishUpdateJob = default(FishUpdateJob);
			fishUpdateJob.cameraPosition = cameraPosition;
			fishUpdateJob.seed = seed;
			fishUpdateJob.dt = Time.deltaTime;
			fishUpdateJob.minSpeed = fishType.minSpeed;
			fishUpdateJob.maxSpeed = fishType.maxSpeed;
			fishUpdateJob.minTurnSpeed = fishType.minTurnSpeed;
			fishUpdateJob.maxTurnSpeed = fishType.maxTurnSpeed;
			fishUpdateJob.fishDataArray = (FishData*)fishData.GetUnsafePtr();
			fishUpdateJob.fishRenderDataArray = (FishRenderData*)fishRenderData.GetUnsafePtr();
			fishUpdateJob.minDepth = item - 3f;
			FishUpdateJob jobData3 = fishUpdateJob;
			KillFish killFish = default(KillFish);
			killFish.fishCount = fishCount;
			killFish.fishDataArray = fishData;
			killFish.fishRenderDataArray = fishRenderData;
			KillFish jobData4 = killFish;
			jobHandle = jobData.Schedule();
			jobHandle = RaycastCommand.ScheduleBatch(castCommands, castResults, 5, jobHandle);
			jobHandle = jobData2.Schedule(jobHandle);
			jobHandle = IJobParallelForExtensions.Schedule(jobData3, num, 10, jobHandle);
			jobHandle = jobData4.Schedule(jobHandle);
		}
	}

	public void OnLateUpdate(float3 cameraPosition)
	{
		jobHandle.Complete();
		if (fishCount[0] != 0)
		{
			Bounds bounds = new Bounds(cameraPosition, Vector3.one * 40f);
			fishBuffer.SetData(fishRenderData);
			Graphics.DrawMeshInstancedProcedural(fishType.mesh, 0, fishType.material, bounds, fishCount[0], materialPropertyBlock);
		}
	}

	public void Dispose()
	{
		jobHandle.Complete();
		castCommands.Dispose();
		castResults.Dispose();
		fishCastIndices.Dispose();
		fishData.Dispose();
		fishRenderData.Dispose();
		fishCount.Dispose();
		fishBuffer.Dispose();
	}

	public void OnDrawGizmosSelected()
	{
		jobHandle.Complete();
		_ = fishCount[0];
	}
}
