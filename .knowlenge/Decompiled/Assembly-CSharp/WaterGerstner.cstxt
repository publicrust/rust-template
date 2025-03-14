#define UNITY_ASSERTIONS
using System;
using UnityEngine;

public class WaterGerstner
{
	[Serializable]
	public class WaveParams
	{
		[Range(0f, 360f)]
		public float Angle;

		[Range(0f, 0.99f)]
		public float Steepness = 0.4f;

		[Range(0.01f, 1000f)]
		public float Length = 15f;

		[Range(-10f, 10f)]
		public float Speed = 0.4f;
	}

	[Serializable]
	public class ShoreWaveParams
	{
		[Range(0f, 2f)]
		public float Steepness = 0.99f;

		[Range(0f, 1f)]
		public float Amplitude = 0.2f;

		[Range(0.01f, 1000f)]
		public float Length = 20f;

		[Range(-10f, 10f)]
		public float Speed = 0.6f;

		public float[] DirectionAngles = new float[6] { 0f, 57.3f, 114.5f, 171.9f, 229.2f, 286.5f };

		public float DirectionVarFreq = 0.1f;

		public float DirectionVarAmp = 2.5f;
	}

	public struct PrecomputedWave
	{
		public float Angle;

		public Vector2 Direction;

		public float Steepness;

		public float K;

		public float C;

		public float A;

		public static PrecomputedWave Default = new PrecomputedWave
		{
			Angle = 0f,
			Direction = Vector2.right,
			Steepness = 0.4f,
			K = 1f,
			C = 1f,
			A = 1f
		};
	}

	public struct PrecomputedShoreWaves
	{
		public Vector2[] Directions;

		public float Steepness;

		public float Amplitude;

		public float K;

		public float C;

		public float A;

		public float DirectionVarFreq;

		public float DirectionVarAmp;

		public static PrecomputedShoreWaves Default = new PrecomputedShoreWaves
		{
			Directions = new Vector2[6]
			{
				Vector2.right,
				Vector2.right,
				Vector2.right,
				Vector2.right,
				Vector2.right,
				Vector2.right
			},
			Steepness = 0.75f,
			Amplitude = 0.2f,
			K = 1f,
			C = 1f,
			A = 1f,
			DirectionVarFreq = 0.1f,
			DirectionVarAmp = 3f
		};
	}

	public const int WaveCount = 6;

	public static void UpdatePrecomputedWaves(WaveParams[] waves, ref PrecomputedWave[] precomputed)
	{
		if (precomputed == null || precomputed.Length != 6)
		{
			precomputed = new PrecomputedWave[6];
		}
		Debug.Assert(precomputed.Length == waves.Length);
		for (int i = 0; i < 6; i++)
		{
			float num = waves[i].Angle * ((float)Math.PI / 180f);
			precomputed[i].Angle = num;
			precomputed[i].Direction = new Vector2(Mathf.Cos(num), Mathf.Sin(num));
			precomputed[i].Steepness = waves[i].Steepness;
			precomputed[i].K = (float)Math.PI * 2f / waves[i].Length;
			precomputed[i].C = Mathf.Sqrt(9.8f / precomputed[i].K) * waves[i].Speed * WaterSystem.WaveTime;
			precomputed[i].A = waves[i].Steepness / precomputed[i].K;
		}
	}

	public static void UpdatePrecomputedShoreWaves(ShoreWaveParams shoreWaves, ref PrecomputedShoreWaves precomputed)
	{
		if (precomputed.Directions == null || precomputed.Directions.Length != 6)
		{
			precomputed.Directions = new Vector2[6];
		}
		Debug.Assert(precomputed.Directions.Length == shoreWaves.DirectionAngles.Length);
		for (int i = 0; i < 6; i++)
		{
			float f = shoreWaves.DirectionAngles[i] * ((float)Math.PI / 180f);
			precomputed.Directions[i] = new Vector2(Mathf.Cos(f), Mathf.Sin(f));
		}
		precomputed.Steepness = shoreWaves.Steepness;
		precomputed.Amplitude = shoreWaves.Amplitude;
		precomputed.K = (float)Math.PI * 2f / shoreWaves.Length;
		precomputed.C = Mathf.Sqrt(9.8f / precomputed.K) * shoreWaves.Speed * WaterSystem.WaveTime;
		precomputed.A = shoreWaves.Steepness / precomputed.K;
		precomputed.DirectionVarFreq = shoreWaves.DirectionVarFreq;
		precomputed.DirectionVarAmp = shoreWaves.DirectionVarAmp;
	}

	public static void UpdateWaveArray(PrecomputedWave[] precomputed, ref Vector4[] array)
	{
		if (array == null || array.Length != 6)
		{
			array = new Vector4[6];
		}
		Debug.Assert(array.Length == precomputed.Length);
		for (int i = 0; i < 6; i++)
		{
			array[i] = new Vector4(precomputed[i].Angle, precomputed[i].Steepness, precomputed[i].K, precomputed[i].C);
		}
	}

	public static void UpdateShoreWaveArray(PrecomputedShoreWaves precomputed, ref Vector4[] array)
	{
		Debug.Assert(precomputed.Directions.Length == 6);
		if (array == null || array.Length != 3)
		{
			array = new Vector4[3];
		}
		Debug.Assert(array.Length == 3);
		Vector2[] directions = precomputed.Directions;
		array[0] = new Vector4(directions[0].x, directions[0].y, directions[1].x, directions[1].y);
		array[1] = new Vector4(directions[2].x, directions[2].y, directions[3].x, directions[3].y);
		array[2] = new Vector4(directions[4].x, directions[4].y, directions[5].x, directions[5].y);
	}

	private static void GerstnerWave(PrecomputedWave wave, Vector2 pos, Vector2 shoreVec, ref float outH)
	{
		Vector2 direction = wave.Direction;
		float num = Mathf.Sin(wave.K * (direction.x * pos.x + direction.y * pos.y - wave.C));
		outH += wave.A * num;
	}

	private static void GerstnerWave(PrecomputedWave wave, Vector2 pos, Vector2 shoreVec, ref Vector3 outP)
	{
		Vector2 direction = wave.Direction;
		float f = wave.K * (direction.x * pos.x + direction.y * pos.y - wave.C);
		float num = Mathf.Cos(f);
		float num2 = Mathf.Sin(f);
		outP.x += direction.x * wave.A * num;
		outP.y += wave.A * num2;
		outP.z += direction.y * wave.A * num;
	}

	private static void GerstnerShoreWave(PrecomputedShoreWaves wave, Vector2 waveDir, Vector2 pos, Vector2 shoreVec, float variation_t, ref float outH)
	{
		float num = Mathf.Clamp01(waveDir.x * shoreVec.x + waveDir.y * shoreVec.y);
		num *= num;
		float f = wave.K * (waveDir.x * pos.x + waveDir.y * pos.y - wave.C + variation_t);
		Mathf.Cos(f);
		float num2 = Mathf.Sin(f);
		outH += wave.A * wave.Amplitude * num2 * num;
	}

	private static void GerstnerShoreWave(PrecomputedShoreWaves wave, Vector2 waveDir, Vector2 pos, Vector2 shoreVec, float variation_t, ref Vector3 outP)
	{
		float num = Mathf.Clamp01(waveDir.x * shoreVec.x + waveDir.y * shoreVec.y);
		num *= num;
		float f = wave.K * (waveDir.x * pos.x + waveDir.y * pos.y - wave.C + variation_t);
		float num2 = Mathf.Cos(f);
		float num3 = Mathf.Sin(f);
		outP.x += waveDir.x * wave.A * num2 * num;
		outP.y += wave.A * wave.Amplitude * num3 * num;
		outP.z += waveDir.y * wave.A * num2 * num;
	}

	public static Vector3 SampleDisplacement(WaterSystem instance, Vector3 location, Vector3 shore)
	{
		PrecomputedWave[] precomputedWaves = instance.PrecomputedWaves;
		PrecomputedShoreWaves precomputedShoreWaves = instance.PrecomputedShoreWaves;
		Vector2 pos = new Vector2(location.x, location.z);
		Vector2 shoreVec = new Vector2(shore.x, shore.y);
		float t = 1f - Mathf.Clamp01(shore.z * instance.ShoreWavesRcpFadeDistance);
		float num = Mathf.Clamp01(shore.z * instance.TerrainRcpFadeDistance);
		float num2 = Mathf.Cos(pos.x * precomputedShoreWaves.DirectionVarFreq) * precomputedShoreWaves.DirectionVarAmp;
		float num3 = Mathf.Cos(pos.y * precomputedShoreWaves.DirectionVarFreq) * precomputedShoreWaves.DirectionVarAmp;
		float variation_t = num2 + num3;
		Vector3 outP = Vector3.zero;
		Vector3 outP2 = Vector3.zero;
		for (int i = 0; i < 6; i++)
		{
			GerstnerWave(precomputedWaves[i], pos, shoreVec, ref outP);
			GerstnerShoreWave(precomputedShoreWaves, precomputedShoreWaves.Directions[i], pos, shoreVec, variation_t, ref outP2);
		}
		return Vector3.Lerp(outP, outP2, t) * num;
	}

	private static float SampleHeightREF(WaterSystem instance, Vector3 location, Vector3 shore)
	{
		PrecomputedWave[] precomputedWaves = instance.PrecomputedWaves;
		PrecomputedShoreWaves precomputedShoreWaves = instance.PrecomputedShoreWaves;
		Vector2 pos = new Vector2(location.x, location.z);
		Vector2 shoreVec = new Vector2(shore.x, shore.y);
		float t = 1f - Mathf.Clamp01(shore.z * instance.ShoreWavesRcpFadeDistance);
		float num = Mathf.Clamp01(shore.z * instance.TerrainRcpFadeDistance);
		float num2 = Mathf.Cos(pos.x * precomputedShoreWaves.DirectionVarFreq) * precomputedShoreWaves.DirectionVarAmp;
		float num3 = Mathf.Cos(pos.y * precomputedShoreWaves.DirectionVarFreq) * precomputedShoreWaves.DirectionVarAmp;
		float variation_t = num2 + num3;
		float outH = 0f;
		float outH2 = 0f;
		for (int i = 0; i < 6; i++)
		{
			GerstnerWave(precomputedWaves[i], pos, shoreVec, ref outH);
			GerstnerShoreWave(precomputedShoreWaves, precomputedShoreWaves.Directions[i], pos, shoreVec, variation_t, ref outH2);
		}
		return Mathf.Lerp(outH, outH2, t) * num;
	}

	private static void SampleHeightArrayREF(WaterSystem instance, Vector2[] location, Vector3[] shore, float[] height)
	{
		Debug.Assert(location.Length == height.Length);
		for (int i = 0; i < location.Length; i++)
		{
			Vector3 location2 = new Vector3(location[i].x, 0f, location[i].y);
			height[i] = SampleHeight(instance, location2, shore[i]);
		}
	}

	public static float SampleHeight(WaterSystem instance, Vector3 location, Vector3 shore)
	{
		PrecomputedWave[] precomputedWaves = instance.PrecomputedWaves;
		Vector2[] directions = instance.PrecomputedShoreWaves.Directions;
		Vector4 global = instance.Global0;
		Vector4 global2 = instance.Global1;
		float x = global2.x;
		float y = global2.y;
		float z = global2.z;
		float w = global2.w;
		float num = x / z;
		Vector2 vector = new Vector2(location.x, location.z);
		Vector2 vector2 = new Vector2(shore.x, shore.y);
		float t = 1f - Mathf.Clamp01(shore.z * global.x);
		float num2 = Mathf.Clamp01(shore.z * global.y);
		float num3 = Mathf.Cos(vector.x * global.z) * global.w;
		float num4 = Mathf.Cos(vector.y * global.z) * global.w;
		float num5 = num3 + num4;
		float num6 = 0f;
		float num7 = 0f;
		for (int i = 0; i < 6; i++)
		{
			Vector2 direction = precomputedWaves[i].Direction;
			float c = precomputedWaves[i].C;
			float k = precomputedWaves[i].K;
			float a = precomputedWaves[i].A;
			float num8 = Mathf.Sin(k * (direction.x * vector.x + direction.y * vector.y - c));
			num6 += a * num8;
			Vector2 vector3 = directions[i];
			float num9 = Mathf.Clamp01(vector3.x * vector2.x + vector3.y * vector2.y);
			num9 *= num9;
			float num10 = Mathf.Sin(z * (vector3.x * vector.x + vector3.y * vector.y - w + num5));
			num7 += num * y * num10 * num9;
		}
		return Mathf.Lerp(num6, num7, t) * num2;
	}

	public static void SampleHeightArray(WaterSystem instance, Vector2[] location, Vector3[] shore, float[] height)
	{
		Debug.Assert(location.Length == height.Length);
		PrecomputedWave[] precomputedWaves = instance.PrecomputedWaves;
		Vector2[] directions = instance.PrecomputedShoreWaves.Directions;
		Vector4 global = instance.Global0;
		Vector4 global2 = instance.Global1;
		float x = global2.x;
		float y = global2.y;
		float z = global2.z;
		float w = global2.w;
		float num = x / z;
		for (int i = 0; i < location.Length; i++)
		{
			Vector2 vector = new Vector2(location[i].x, location[i].y);
			Vector2 vector2 = new Vector2(shore[i].x, shore[i].y);
			float t = 1f - Mathf.Clamp01(shore[i].z * global.x);
			float num2 = Mathf.Clamp01(shore[i].z * global.y);
			float num3 = Mathf.Cos(vector.x * global.z) * global.w;
			float num4 = Mathf.Cos(vector.y * global.z) * global.w;
			float num5 = num3 + num4;
			float num6 = 0f;
			float num7 = 0f;
			for (int j = 0; j < 6; j++)
			{
				Vector2 direction = precomputedWaves[j].Direction;
				float c = precomputedWaves[j].C;
				float k = precomputedWaves[j].K;
				float a = precomputedWaves[j].A;
				float num8 = Mathf.Sin(k * (direction.x * vector.x + direction.y * vector.y - c));
				num6 += a * num8;
				Vector2 vector3 = directions[j];
				float num9 = Mathf.Clamp01(vector3.x * vector2.x + vector3.y * vector2.y);
				num9 *= num9;
				float num10 = Mathf.Sin(z * (vector3.x * vector.x + vector3.y * vector.y - w + num5));
				num7 += num * y * num10 * num9;
			}
			height[i] = Mathf.Lerp(num6, num7, t) * num2;
		}
	}
}
