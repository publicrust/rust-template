using System.Collections.Generic;
using UnityEngine;

public class SubsurfaceProfileTexture
{
	private struct SubsurfaceProfileEntry
	{
		public SubsurfaceProfileData data;

		public SubsurfaceProfile profile;

		public SubsurfaceProfileEntry(SubsurfaceProfileData data, SubsurfaceProfile profile)
		{
			this.data = data;
			this.profile = profile;
		}
	}

	public const int SUBSURFACE_PROFILE_COUNT = 16;

	public const int MAX_SUBSURFACE_PROFILES = 15;

	public const int SUBSURFACE_RADIUS_SCALE = 1024;

	public const int SUBSURFACE_KERNEL_SIZE = 3;

	private HashSet<SubsurfaceProfile> entries = new HashSet<SubsurfaceProfile>();

	private Texture2D texture;

	private Vector4[] transmissionTints = new Vector4[16];

	private const int KernelSize0 = 24;

	private const int KernelSize1 = 16;

	private const int KernelSize2 = 8;

	private const int KernelTotalSize = 49;

	private const int Width = 49;

	public Texture2D Texture
	{
		get
		{
			if (texture == null)
			{
				CreateResources();
			}
			return texture;
		}
	}

	public Vector4[] TransmissionTints
	{
		get
		{
			if (texture == null)
			{
				CreateResources();
			}
			return transmissionTints;
		}
	}

	public void AddProfile(SubsurfaceProfile profile)
	{
		entries.Add(profile);
		if (entries.Count > 15)
		{
			Debug.LogWarning($"[SubsurfaceScattering] Maximum number of supported Subsurface Profiles has been reached ({entries.Count}/{15}). Please remove some.");
		}
		ReleaseResources();
	}

	public static Color Clamp(Color color, float min = 0f, float max = 1f)
	{
		Color result = default(Color);
		result.r = Mathf.Clamp(color.r, min, max);
		result.g = Mathf.Clamp(color.g, min, max);
		result.b = Mathf.Clamp(color.b, min, max);
		result.a = Mathf.Clamp(color.a, min, max);
		return result;
	}

	private void WriteKernel(ref Color[] pixels, ref Color[] kernel, int id, int y, in SubsurfaceProfileData data)
	{
		Color color = Clamp(data.SubsurfaceColor);
		Color falloffColor = Clamp(data.FalloffColor, 0.009f);
		transmissionTints[id] = data.TransmissionTint;
		kernel[0] = color;
		kernel[0].a = data.ScatterRadius;
		SeparableSSS.CalculateKernel(kernel, 1, 24, color, falloffColor);
		SeparableSSS.CalculateKernel(kernel, 25, 16, color, falloffColor);
		SeparableSSS.CalculateKernel(kernel, 41, 8, color, falloffColor);
		int num = 49 * y;
		for (int i = 0; i < 49; i++)
		{
			Color color2 = kernel[i];
			color2.a *= ((i > 0) ? (data.ScatterRadius / 1024f) : 1f);
			pixels[num + i] = color2;
		}
	}

	private void CreateResources()
	{
		if (entries.Count <= 0)
		{
			return;
		}
		int num = Mathf.Min(entries.Count, 15) + 1;
		ReleaseResources();
		texture = new Texture2D(49, num, TextureFormat.RGBAHalf, mipChain: false, linear: true);
		texture.name = "SubsurfaceProfiles";
		texture.wrapMode = TextureWrapMode.Clamp;
		texture.filterMode = FilterMode.Bilinear;
		Color[] pixels = texture.GetPixels(0);
		Color[] kernel = new Color[49];
		int num2 = num - 1;
		int id = 0;
		WriteKernel(ref pixels, ref kernel, id++, num2--, SubsurfaceProfileData.Default);
		foreach (SubsurfaceProfile entry in entries)
		{
			entry.Id = id;
			WriteKernel(ref pixels, ref kernel, id++, num2--, in entry.Data);
			if (num2 < 0)
			{
				break;
			}
		}
		texture.SetPixels(pixels, 0);
		texture.Apply(updateMipmaps: false, makeNoLongerReadable: false);
	}

	public void ReleaseResources()
	{
		if (texture != null)
		{
			Object.DestroyImmediate(texture);
			texture = null;
		}
		if (transmissionTints != null)
		{
			for (int i = 0; i < transmissionTints.Length; i++)
			{
				transmissionTints[i] = SubsurfaceProfileData.Default.TransmissionTint.linear;
			}
		}
	}
}
