using UnityEngine;

public class StatusLightRenderer : MonoBehaviour, IClientComponent
{
	public Material offMaterial;

	public Material onMaterial;

	private MaterialPropertyBlock propertyBlock;

	private Renderer targetRenderer;

	private Color lightColor;

	private Light targetLight;

	private int colorID;

	private int emissionID;

	protected void Awake()
	{
		propertyBlock = new MaterialPropertyBlock();
		targetRenderer = GetComponent<Renderer>();
		targetLight = GetComponent<Light>();
		colorID = Shader.PropertyToID("_Color");
		emissionID = Shader.PropertyToID("_EmissionColor");
	}

	public void SetOff()
	{
		if ((bool)targetRenderer)
		{
			targetRenderer.sharedMaterial = offMaterial;
			targetRenderer.SetPropertyBlock(null);
		}
		if ((bool)targetLight)
		{
			targetLight.color = Color.clear;
		}
	}

	public void SetOn()
	{
		if ((bool)targetRenderer)
		{
			targetRenderer.sharedMaterial = onMaterial;
			targetRenderer.SetPropertyBlock(propertyBlock);
		}
		if ((bool)targetLight)
		{
			targetLight.color = lightColor;
		}
	}

	public void SetRed()
	{
		propertyBlock.Clear();
		propertyBlock.SetColor(colorID, GetColor(197, 46, 0, byte.MaxValue));
		propertyBlock.SetColor(emissionID, GetColor(191, 0, 2, byte.MaxValue, 2.916925f));
		lightColor = GetColor(byte.MaxValue, 111, 102, byte.MaxValue);
		SetOn();
	}

	public void SetGreen()
	{
		propertyBlock.Clear();
		propertyBlock.SetColor(colorID, GetColor(19, 191, 13, byte.MaxValue));
		propertyBlock.SetColor(emissionID, GetColor(19, 191, 13, byte.MaxValue, 2.5f));
		lightColor = GetColor(156, byte.MaxValue, 102, byte.MaxValue);
		SetOn();
	}

	private Color GetColor(byte r, byte g, byte b, byte a)
	{
		return new Color32(r, g, b, a);
	}

	private Color GetColor(byte r, byte g, byte b, byte a, float intensity)
	{
		return (Color)new Color32(r, g, b, a) * intensity;
	}
}
