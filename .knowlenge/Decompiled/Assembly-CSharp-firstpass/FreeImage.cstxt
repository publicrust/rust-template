using System;
using System.Runtime.InteropServices;

public static class FreeImage
{
	public enum Format
	{
		Unknown = -1,
		BMP = 0,
		JPEG = 2,
		PNG = 13,
		TARGA = 17,
		TIFF = 18,
		PSD = 20,
		DDS = 24,
		HDR = 26,
		EXR = 29,
		J2K = 30,
		JP2 = 31,
		WEBP = 35,
		JXR = 36
	}

	public enum SaveFlags
	{
		DEFAULT = 0,
		BMP_SAVE_RLE = 1,
		EXR_FLOAT = 1,
		EXR_NONE = 2,
		EXR_ZIP = 4,
		EXR_PIZ = 8,
		EXR_PXR24 = 16,
		EXR_B44 = 32,
		EXR_LC = 64,
		JPEG_QUALITYSUPERB = 128,
		JPEG_QUALITYGOOD = 256,
		JPEG_QUALITYNORMAL = 512,
		JPEG_QUALITYAVERAGE = 1024,
		JPEG_QUALITYBAD = 2048,
		JPEG_PROGRESSIVE = 8192,
		JPEG_SUBSAMPLING_411 = 4096,
		JPEG_SUBSAMPLING_420 = 16384,
		JPEG_SUBSAMPLING_422 = 32768,
		JPEG_SUBSAMPLING_444 = 65536,
		JPEG_OPTIMIZE = 131072,
		JPEG_BASELINE = 262144,
		PNG_Z_BEST_SPEED = 1,
		PNG_Z_DEFAULT_COMPRESSION = 6,
		PNG_Z_BEST_COMPRESSION = 9,
		PNG_Z_NO_COMPRESSION = 256,
		PNG_INTERLACED = 512,
		PNM_SAVE_ASCII = 1,
		TIFF_CMYK = 1,
		TIFF_PACKBITS = 256,
		TIFF_DEFLATE = 512,
		TIFF_ADOBE_DEFLATE = 1024,
		TIFF_NONE = 2048,
		TIFF_CCITTFAX3 = 4096,
		TIFF_CCITTFAX4 = 8192,
		TIFF_LZW = 16384,
		TIFF_JPEG = 32768
	}

	public enum LoadFlags
	{
		DEFAULT = 0,
		GIF_LOAD256 = 1,
		GIF_PLAYBACK = 2,
		ICO_MAKEALPHA = 1,
		JPEG_FAST = 1,
		JPEG_ACCURATE = 2,
		JPEG_CMYK = 4,
		JPEG_EXIFROTATE = 8,
		PCD_BASE = 1,
		PCD_BASEDIV4 = 2,
		PCD_BASEDIV16 = 3,
		PNG_IGNOREGAMMA = 1,
		TARGA_LOAD_RGB888 = 1,
		TIFF_CMYK = 1,
		RAW_PREVIEW = 1,
		RAW_DISPLAY = 2
	}

	[Serializable]
	public struct Header
	{
		public uint size;

		public int width;

		public int height;

		public ushort planes;

		public ushort bitCount;

		public uint compression;

		public uint sizeImage;

		public int xPelsPerMeter;

		public int yPelsPerMeter;

		public uint clrUsed;

		public uint clrImportant;
	}

	[Serializable]
	public struct Bitmap
	{
		public IntPtr data;

		public static Bitmap Null = new Bitmap
		{
			data = IntPtr.Zero
		};

		public bool IsNull => data == IntPtr.Zero;

		public void Unload()
		{
			FreeImage.Unload(this);
			data = IntPtr.Zero;
		}
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct RGBQuad
	{
		[FieldOffset(0)]
		public byte rgbBlue;

		[FieldOffset(1)]
		public byte rgbGreen;

		[FieldOffset(2)]
		public byte rgbRed;

		[FieldOffset(3)]
		public byte rgbReserved;

		[FieldOffset(0)]
		public uint uintValue;
	}

	public enum Filter
	{
		Box,
		Bicubic,
		Bilinear,
		Bspline,
		CatmullRom,
		Lanczos3
	}

	public const uint FI_RGBA_RED_MASK = 16711680u;

	public const uint FI_RGBA_GREEN_MASK = 65280u;

	public const uint FI_RGBA_BLUE_MASK = 255u;

	public const string FreeImageLibrary = "FreeImage";

	[DllImport("FreeImage", CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFIFFromFilename")]
	public static extern Format GetFIFFromFilename(string filename);

	[DllImport("FreeImage", CharSet = CharSet.Ansi, EntryPoint = "FreeImage_Load")]
	public static extern Bitmap Load(Format fif, string filename, LoadFlags flags = LoadFlags.DEFAULT);

	[DllImport("FreeImage", CharSet = CharSet.Ansi, EntryPoint = "FreeImage_Save")]
	public static extern bool Save(Format fif, Bitmap bitmap, string filename, SaveFlags flags = SaveFlags.DEFAULT);

	[DllImport("FreeImage", EntryPoint = "FreeImage_Allocate")]
	public static extern Bitmap Allocate(int width, int height, int bpp, uint red_mask = 16711680u, uint green_mask = 65280u, uint blue_mask = 255u);

	[DllImport("FreeImage", EntryPoint = "FreeImage_Unload")]
	public static extern void Unload(Bitmap bitmap);

	[DllImport("FreeImage", EntryPoint = "FreeImage_GetBits")]
	public static extern IntPtr GetBits(Bitmap bitmap);

	[DllImport("FreeImage", EntryPoint = "FreeImage_GetBPP")]
	public static extern uint GetBPP(Bitmap bitmap);

	[DllImport("FreeImage", EntryPoint = "FreeImage_GetWidth")]
	public static extern uint GetWidth(Bitmap bitmap);

	[DllImport("FreeImage", EntryPoint = "FreeImage_GetHeight")]
	public static extern uint GetHeight(Bitmap bitmap);

	[DllImport("FreeImage", EntryPoint = "FreeImage_GetLine")]
	public static extern uint GetLine(Bitmap bitmap);

	[DllImport("FreeImage", EntryPoint = "FreeImage_GetPitch")]
	public static extern uint GetPitch(Bitmap bitmap);

	[DllImport("FreeImage", EntryPoint = "FreeImage_GetPixelColor")]
	public static extern bool GetPixelColor(Bitmap bitmap, uint x, uint y, out RGBQuad value);

	[DllImport("FreeImage", EntryPoint = "FreeImage_Rescale")]
	public static extern Bitmap Rescale(Bitmap bitmap, int dst_width, int dst_height, Filter filter);

	[DllImport("FreeImage", EntryPoint = "FreeImage_ConvertTo24Bits")]
	public static extern Bitmap ConvertTo24Bits(Bitmap bitmap);

	[DllImport("FreeImage", EntryPoint = "FreeImage_ConvertTo32Bits")]
	public static extern Bitmap ConvertTo32Bits(Bitmap bitmap);
}
