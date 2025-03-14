using System.Runtime.InteropServices;
using System.Security;

[SuppressUnmanagedCodeSecurity]
public static class NativeNoise
{
	[DllImport("RustNative", EntryPoint = "snoise1_32")]
	public static extern float Simplex1D(float x);

	[DllImport("RustNative", EntryPoint = "sdnoise1_32")]
	public static extern float Simplex1D(float x, out float dx);

	[DllImport("RustNative", EntryPoint = "snoise2_32")]
	public static extern float Simplex2D(float x, float y);

	[DllImport("RustNative", EntryPoint = "sdnoise2_32")]
	public static extern float Simplex2D(float x, float y, out float dx, out float dy);

	[DllImport("RustNative", EntryPoint = "turbulence_32")]
	public static extern float Turbulence(float x, float y, int octaves, float frequency, float amplitude, float lacunarity, float gain);

	[DllImport("RustNative", EntryPoint = "billow_32")]
	public static extern float Billow(float x, float y, int octaves, float frequency, float amplitude, float lacunarity, float gain);

	[DllImport("RustNative", EntryPoint = "ridge_32")]
	public static extern float Ridge(float x, float y, int octaves, float frequency, float amplitude, float lacunarity, float gain);

	[DllImport("RustNative", EntryPoint = "sharp_32")]
	public static extern float Sharp(float x, float y, int octaves, float frequency, float amplitude, float lacunarity, float gain);

	[DllImport("RustNative", EntryPoint = "turbulence_iq_32")]
	public static extern float TurbulenceIQ(float x, float y, int octaves, float frequency, float amplitude, float lacunarity, float gain);

	[DllImport("RustNative", EntryPoint = "billow_iq_32")]
	public static extern float BillowIQ(float x, float y, int octaves, float frequency, float amplitude, float lacunarity, float gain);

	[DllImport("RustNative", EntryPoint = "ridge_iq_32")]
	public static extern float RidgeIQ(float x, float y, int octaves, float frequency, float amplitude, float lacunarity, float gain);

	[DllImport("RustNative", EntryPoint = "sharp_iq_32")]
	public static extern float SharpIQ(float x, float y, int octaves, float frequency, float amplitude, float lacunarity, float gain);

	[DllImport("RustNative", EntryPoint = "turbulence_warp_32")]
	public static extern float TurbulenceWarp(float x, float y, int octaves, float frequency, float amplitude, float lacunarity, float gain, float warp);

	[DllImport("RustNative", EntryPoint = "billow_warp_32")]
	public static extern float BillowWarp(float x, float y, int octaves, float frequency, float amplitude, float lacunarity, float gain, float warp);

	[DllImport("RustNative", EntryPoint = "ridge_warp_32")]
	public static extern float RidgeWarp(float x, float y, int octaves, float frequency, float amplitude, float lacunarity, float gain, float warp);

	[DllImport("RustNative", EntryPoint = "sharp_warp_32")]
	public static extern float SharpWarp(float x, float y, int octaves, float frequency, float amplitude, float lacunarity, float gain, float warp);

	[DllImport("RustNative", EntryPoint = "jordan_32")]
	public static extern float Jordan(float x, float y, int octaves, float frequency, float amplitude, float lacunarity, float gain, float warp, float damp, float damp_scale);
}
