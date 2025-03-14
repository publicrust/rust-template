using UnityEngine;

public class ClimateBlendTexture : ProcessedTexture
{
	public ClimateBlendTexture(int width, int height, bool linear = true)
	{
		material = CreateMaterial("Hidden/ClimateBlendLUTs");
		result = CreateRenderTexture("Climate Blend Texture", width, height, linear);
		result.wrapMode = TextureWrapMode.Clamp;
	}

	public bool CheckLostData()
	{
		if (!result.IsCreated())
		{
			result.Create();
			return true;
		}
		return false;
	}

	public void Blend(Texture srcLut1, Texture dstLut1, float lerpLut1, Texture srcLut2, Texture dstLut2, float lerpLut2, float lerp, ClimateBlendTexture prevLut, float time)
	{
		material.SetTexture("_srcLut1", srcLut1);
		material.SetTexture("_dstLut1", dstLut1);
		material.SetTexture("_srcLut2", srcLut2);
		material.SetTexture("_dstLut2", dstLut2);
		material.SetTexture("_prevLut", prevLut);
		material.SetFloat("_lerpLut1", lerpLut1);
		material.SetFloat("_lerpLut2", lerpLut2);
		material.SetFloat("_lerp", lerp);
		material.SetFloat("_time", time);
		Graphics.Blit(null, result, material);
	}

	public static void Swap(ref ClimateBlendTexture a, ref ClimateBlendTexture b)
	{
		ClimateBlendTexture climateBlendTexture = a;
		a = b;
		b = climateBlendTexture;
	}
}
