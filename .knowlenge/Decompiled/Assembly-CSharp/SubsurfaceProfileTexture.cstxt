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

	public const int SUBSURFACE_RADIUS_SCALE = 1024;

	public const int SUBSURFACE_KERNEL_SIZE = 3;

	private List<SubsurfaceProfileEntry> entries = new List<SubsurfaceProfileEntry>(16);

	private Texture2D texture;

	public Texture2D Texture
	{
		get
		{
			if (!(texture == null))
			{
				return texture;
			}
			return CreateTexture();
		}
	}

	public SubsurfaceProfileTexture()
	{
		AddProfile(SubsurfaceProfileData.Default, null);
	}

	public int FindEntryIndex(SubsurfaceProfile profile)
	{
		for (int i = 0; i < entries.Count; i++)
		{
			if (entries[i].profile == profile)
			{
				return i;
			}
		}
		return -1;
	}

	public int AddProfile(SubsurfaceProfileData data, SubsurfaceProfile profile)
	{
		int num = -1;
		for (int i = 0; i < entries.Count; i++)
		{
			if (entries[i].profile == profile)
			{
				num = i;
				entries[num] = new SubsurfaceProfileEntry(data, profile);
				break;
			}
		}
		if (num < 0)
		{
			num = entries.Count;
			entries.Add(new SubsurfaceProfileEntry(data, profile));
		}
		ReleaseTexture();
		return num;
	}

	public void UpdateProfile(int id, SubsurfaceProfileData data)
	{
		if (id >= 0)
		{
			entries[id] = new SubsurfaceProfileEntry(data, entries[id].profile);
			ReleaseTexture();
		}
	}

	public void RemoveProfile(int id)
	{
		if (id >= 0)
		{
			entries[id] = new SubsurfaceProfileEntry(SubsurfaceProfileData.Invalid, null);
			CheckReleaseTexture();
		}
	}

	public static Color ColorClamp(Color color, float min = 0f, float max = 1f)
	{
		Color result = default(Color);
		result.r = Mathf.Clamp(color.r, min, max);
		result.g = Mathf.Clamp(color.g, min, max);
		result.b = Mathf.Clamp(color.b, min, max);
		result.a = Mathf.Clamp(color.a, min, max);
		return result;
	}

	private Texture2D CreateTexture()
	{
		if (entries.Count > 0)
		{
			int num = 32;
			int num2 = Mathf.Max(entries.Count, 64);
			ReleaseTexture();
			texture = new Texture2D(num, num2, TextureFormat.RGBAHalf, mipChain: false, linear: true);
			texture.name = "SubsurfaceProfiles";
			texture.wrapMode = TextureWrapMode.Clamp;
			texture.filterMode = FilterMode.Bilinear;
			Color[] pixels = texture.GetPixels(0);
			for (int i = 0; i < pixels.Length; i++)
			{
				pixels[i] = Color.clear;
			}
			Color[] array = new Color[num];
			for (int j = 0; j < entries.Count; j++)
			{
				SubsurfaceProfileData data = entries[j].data;
				data.SubsurfaceColor = ColorClamp(data.SubsurfaceColor);
				data.FalloffColor = ColorClamp(data.FalloffColor, 0.009f);
				array[0] = data.SubsurfaceColor;
				array[0].a = 0f;
				SeparableSSS.CalculateKernel(array, 1, 13, data.SubsurfaceColor, data.FalloffColor);
				SeparableSSS.CalculateKernel(array, 14, 9, data.SubsurfaceColor, data.FalloffColor);
				SeparableSSS.CalculateKernel(array, 23, 6, data.SubsurfaceColor, data.FalloffColor);
				int num3 = num * (num2 - j - 1);
				for (int k = 0; k < 29; k++)
				{
					Color color = array[k] * new Color(1f, 1f, 1f, 1f / 3f);
					color.a *= data.ScatterRadius / 1024f;
					pixels[num3 + k] = color;
				}
			}
			texture.SetPixels(pixels, 0);
			texture.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			return texture;
		}
		return null;
	}

	private void CheckReleaseTexture()
	{
		int num = 0;
		for (int i = 0; i < entries.Count; i++)
		{
			num += ((entries[i].profile == null) ? 1 : 0);
		}
		if (entries.Count == num)
		{
			ReleaseTexture();
		}
	}

	private void ReleaseTexture()
	{
		if (texture != null)
		{
			Object.DestroyImmediate(texture);
			texture = null;
		}
	}
}
