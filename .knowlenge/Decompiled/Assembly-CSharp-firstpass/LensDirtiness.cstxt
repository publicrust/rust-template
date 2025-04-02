using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Lens Dirtiness")]
public class LensDirtiness : MonoBehaviour, IImageEffect
{
	private enum Pass
	{
		Threshold,
		Kawase,
		Compose
	}

	private Shader Shader_Dirtiness;

	private Material Material_Dirtiness;

	private RenderTexture RTT_BloomThreshold;

	private RenderTexture RTT_1;

	private RenderTexture RTT_2;

	private RenderTexture RTT_3;

	private RenderTexture RTT_4;

	private RenderTexture RTT_Bloom_1;

	private RenderTexture RTT_Bloom_2;

	private int ScreenX = 1280;

	private int ScreenY = 720;

	public bool ShowScreenControls;

	public bool SceneTintsBloom = true;

	public Texture2D DirtinessTexture;

	public float gain = 1f;

	public float threshold = 1f;

	public float BloomSize = 5f;

	public float Dirtiness = 1f;

	public Color BloomColor = Color.white;

	private void OnEnable()
	{
		Shader_Dirtiness = Shader.Find("Hidden/LensDirtiness");
		if (Shader_Dirtiness == null)
		{
			Debug.Log("#ERROR# Hidden/LensDirtiness Shader not found");
		}
		Material_Dirtiness = new Material(Shader_Dirtiness);
		Material_Dirtiness.hideFlags = HideFlags.HideAndDontSave;
		SetKeyword();
	}

	private void SetKeyword()
	{
		if ((bool)Material_Dirtiness)
		{
			KeywordUtil.EnsureKeywordState(Material_Dirtiness, "_SCENE_TINTS_BLOOM", SceneTintsBloom);
		}
	}

	public bool IsActive()
	{
		return base.enabled;
	}

	public void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		RenderTextureFormat format = source.format;
		ScreenX = source.width;
		ScreenY = source.height;
		Material_Dirtiness.SetFloat("_Gain", gain);
		Material_Dirtiness.SetFloat("_Threshold", threshold);
		RTT_BloomThreshold = RenderTexture.GetTemporary(ScreenX / 2, ScreenY / 2, 0, format);
		RTT_BloomThreshold.name = "RTT_BloomThreshold";
		Graphics.Blit(source, RTT_BloomThreshold, Material_Dirtiness, 0);
		Material_Dirtiness.SetVector("_Offset", new Vector4(1f / (float)ScreenX, 1f / (float)ScreenY, 0f, 0f) * 2f);
		RTT_1 = RenderTexture.GetTemporary(ScreenX / 2, ScreenY / 2, 0, format);
		Graphics.Blit(RTT_BloomThreshold, RTT_1, Material_Dirtiness, 1);
		RenderTexture.ReleaseTemporary(RTT_BloomThreshold);
		RTT_2 = RenderTexture.GetTemporary(ScreenX / 4, ScreenY / 4, 0, format);
		Graphics.Blit(RTT_1, RTT_2, Material_Dirtiness, 1);
		RenderTexture.ReleaseTemporary(RTT_1);
		RTT_3 = RenderTexture.GetTemporary(ScreenX / 8, ScreenY / 8, 0, format);
		Graphics.Blit(RTT_2, RTT_3, Material_Dirtiness, 1);
		RenderTexture.ReleaseTemporary(RTT_2);
		RTT_4 = RenderTexture.GetTemporary(ScreenX / 16, ScreenY / 16, 0, format);
		Graphics.Blit(RTT_3, RTT_4, Material_Dirtiness, 1);
		RenderTexture.ReleaseTemporary(RTT_3);
		RTT_1.name = "RTT_1";
		RTT_2.name = "RTT_2";
		RTT_3.name = "RTT_3";
		RTT_4.name = "RTT_4";
		RTT_Bloom_1 = RenderTexture.GetTemporary(ScreenX / 16, ScreenY / 16, 0, format);
		RTT_Bloom_1.name = "RTT_Bloom_1";
		RTT_Bloom_2 = RenderTexture.GetTemporary(ScreenX / 16, ScreenY / 16, 0, format);
		RTT_Bloom_2.name = "RTT_Bloom_2";
		Graphics.Blit(RTT_4, RTT_Bloom_1);
		RenderTexture.ReleaseTemporary(RTT_4);
		for (int i = 1; i <= 8; i++)
		{
			float x = BloomSize * (float)i / (float)ScreenX;
			float y = BloomSize * (float)i / (float)ScreenY;
			Material_Dirtiness.SetVector("_Offset", new Vector4(x, y, 0f, 0f));
			Graphics.Blit(RTT_Bloom_1, RTT_Bloom_2, Material_Dirtiness, 1);
			Graphics.Blit(RTT_Bloom_2, RTT_Bloom_1, Material_Dirtiness, 1);
		}
		RenderTexture.ReleaseTemporary(RTT_Bloom_1);
		RenderTexture.ReleaseTemporary(RTT_Bloom_2);
		Material_Dirtiness.SetTexture("_Bloom", RTT_Bloom_2);
		Material_Dirtiness.SetFloat("_Dirtiness", Dirtiness);
		Material_Dirtiness.SetColor("_BloomColor", BloomColor);
		Material_Dirtiness.SetTexture("_DirtinessTexture", DirtinessTexture);
		Graphics.Blit(source, destination, Material_Dirtiness, 2);
	}
}
