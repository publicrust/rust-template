public static class Noise
{
	public const float MIN = -1000000f;

	public const float MAX = 1000000f;

	public static float SimplexSigned(float x)
	{
		return NativeNoise.Simplex1D(x);
	}

	public static float SimplexSigned(float x, float y)
	{
		return NativeNoise.Simplex2D(x, y);
	}

	public static float SimplexUnsigned(float x)
	{
		return NativeNoise.Simplex1D(x) * 0.5f + 1f;
	}

	public static float SimplexUnsigned(float x, float y)
	{
		return NativeNoise.Simplex2D(x, y) * 0.5f + 1f;
	}

	public static float Turbulence(float x, float y, int octaves = 1, float frequency = 1f, float amplitude = 1f, float lacunarity = 2f, float gain = 0.5f)
	{
		return NativeNoise.Turbulence(x, y, octaves, frequency, amplitude, lacunarity, gain);
	}

	public static float Billow(float x, float y, int octaves = 1, float frequency = 1f, float amplitude = 1f, float lacunarity = 2f, float gain = 0.5f)
	{
		return NativeNoise.Billow(x, y, octaves, frequency, amplitude, lacunarity, gain);
	}

	public static float Ridge(float x, float y, int octaves = 1, float frequency = 1f, float amplitude = 1f, float lacunarity = 2f, float gain = 0.5f)
	{
		return NativeNoise.Ridge(x, y, octaves, frequency, amplitude, lacunarity, gain);
	}

	public static float Sharp(float x, float y, int octaves = 1, float frequency = 1f, float amplitude = 1f, float lacunarity = 2f, float gain = 0.5f)
	{
		return NativeNoise.Sharp(x, y, octaves, frequency, amplitude, lacunarity, gain);
	}

	public static float TurbulenceIQ(float x, float y, int octaves = 1, float frequency = 1f, float amplitude = 1f, float lacunarity = 2f, float gain = 0.5f)
	{
		return NativeNoise.TurbulenceIQ(x, y, octaves, frequency, amplitude, lacunarity, gain);
	}

	public static float BillowIQ(float x, float y, int octaves = 1, float frequency = 1f, float amplitude = 1f, float lacunarity = 2f, float gain = 0.5f)
	{
		return NativeNoise.BillowIQ(x, y, octaves, frequency, amplitude, lacunarity, gain);
	}

	public static float RidgeIQ(float x, float y, int octaves = 1, float frequency = 1f, float amplitude = 1f, float lacunarity = 2f, float gain = 0.5f)
	{
		return NativeNoise.RidgeIQ(x, y, octaves, frequency, amplitude, lacunarity, gain);
	}

	public static float SharpIQ(float x, float y, int octaves = 1, float frequency = 1f, float amplitude = 1f, float lacunarity = 2f, float gain = 0.5f)
	{
		return NativeNoise.SharpIQ(x, y, octaves, frequency, amplitude, lacunarity, gain);
	}

	public static float TurbulenceWarp(float x, float y, int octaves = 1, float frequency = 1f, float amplitude = 1f, float lacunarity = 2f, float gain = 0.5f, float warp = 0.25f)
	{
		return NativeNoise.TurbulenceWarp(x, y, octaves, frequency, amplitude, lacunarity, gain, warp);
	}

	public static float BillowWarp(float x, float y, int octaves = 1, float frequency = 1f, float amplitude = 1f, float lacunarity = 2f, float gain = 0.5f, float warp = 0.25f)
	{
		return NativeNoise.BillowWarp(x, y, octaves, frequency, amplitude, lacunarity, gain, warp);
	}

	public static float RidgeWarp(float x, float y, int octaves = 1, float frequency = 1f, float amplitude = 1f, float lacunarity = 2f, float gain = 0.5f, float warp = 0.25f)
	{
		return NativeNoise.RidgeWarp(x, y, octaves, frequency, amplitude, lacunarity, gain, warp);
	}

	public static float SharpWarp(float x, float y, int octaves = 1, float frequency = 1f, float amplitude = 1f, float lacunarity = 2f, float gain = 0.5f, float warp = 0.25f)
	{
		return NativeNoise.SharpWarp(x, y, octaves, frequency, amplitude, lacunarity, gain, warp);
	}

	public static float Jordan(float x, float y, int octaves = 1, float frequency = 1f, float amplitude = 1f, float lacunarity = 2f, float gain = 0.5f, float warp = 1f, float damp = 1f, float damp_scale = 1f)
	{
		return NativeNoise.Jordan(x, y, octaves, frequency, amplitude, lacunarity, gain, warp, damp, damp_scale);
	}
}
