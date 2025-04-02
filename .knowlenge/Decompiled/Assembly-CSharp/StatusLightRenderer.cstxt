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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		propertyBlock = new MaterialPropertyBlock();
		targetRenderer = ((Component)this).GetComponent<Renderer>();
		targetLight = ((Component)this).GetComponent<Light>();
		colorID = Shader.PropertyToID("_Color");
		emissionID = Shader.PropertyToID("_EmissionColor");
	}

	public void SetOff()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)targetRenderer))
		{
			targetRenderer.sharedMaterial = offMaterial;
			targetRenderer.SetPropertyBlock((MaterialPropertyBlock)null);
		}
		if (Object.op_Implicit((Object)(object)targetLight))
		{
			targetLight.color = Color.clear;
		}
	}

	public void SetOn()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)targetRenderer))
		{
			targetRenderer.sharedMaterial = onMaterial;
			targetRenderer.SetPropertyBlock(propertyBlock);
		}
		if (Object.op_Implicit((Object)(object)targetLight))
		{
			targetLight.color = lightColor;
		}
	}

	public void SetRed()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		propertyBlock.Clear();
		propertyBlock.SetColor(colorID, GetColor(197, 46, 0, byte.MaxValue));
		propertyBlock.SetColor(emissionID, GetColor(191, 0, 2, byte.MaxValue, 2.916925f));
		lightColor = GetColor(byte.MaxValue, 111, 102, byte.MaxValue);
		SetOn();
	}

	public void SetGreen()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		propertyBlock.Clear();
		propertyBlock.SetColor(colorID, GetColor(19, 191, 13, byte.MaxValue));
		propertyBlock.SetColor(emissionID, GetColor(19, 191, 13, byte.MaxValue, 2.5f));
		lightColor = GetColor(156, byte.MaxValue, 102, byte.MaxValue);
		SetOn();
	}

	private Color GetColor(byte r, byte g, byte b, byte a)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		return Color32.op_Implicit(new Color32(r, g, b, a));
	}

	private Color GetColor(byte r, byte g, byte b, byte a, float intensity)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		return Color32.op_Implicit(new Color32(r, g, b, a)) * intensity;
	}
}
