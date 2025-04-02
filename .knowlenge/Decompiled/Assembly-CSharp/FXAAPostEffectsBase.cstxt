using UnityEngine;

public class FXAAPostEffectsBase : MonoBehaviour
{
	protected bool supportHDRTextures = true;

	protected bool isSupported = true;

	public Material CheckShaderAndCreateMaterial(Shader s, Material m2Create)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		if (!Object.op_Implicit((Object)(object)s))
		{
			Debug.Log((object)("Missing shader in " + ((object)this).ToString()));
			((Behaviour)this).enabled = false;
			return null;
		}
		if (s.isSupported && Object.op_Implicit((Object)(object)m2Create) && (Object)(object)m2Create.shader == (Object)(object)s)
		{
			return m2Create;
		}
		if (!s.isSupported)
		{
			NotSupported();
			Debug.LogError((object)("The shader " + ((object)s).ToString() + " on effect " + ((object)this).ToString() + " is not supported on this platform!"));
			return null;
		}
		m2Create = new Material(s);
		((Object)m2Create).hideFlags = (HideFlags)52;
		if (Object.op_Implicit((Object)(object)m2Create))
		{
			return m2Create;
		}
		return null;
	}

	private Material CreateMaterial(Shader s, Material m2Create)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		if (!Object.op_Implicit((Object)(object)s))
		{
			Debug.Log((object)("Missing shader in " + ((object)this).ToString()));
			return null;
		}
		if (Object.op_Implicit((Object)(object)m2Create) && (Object)(object)m2Create.shader == (Object)(object)s && s.isSupported)
		{
			return m2Create;
		}
		if (!s.isSupported)
		{
			return null;
		}
		m2Create = new Material(s);
		((Object)m2Create).hideFlags = (HideFlags)52;
		if (Object.op_Implicit((Object)(object)m2Create))
		{
			return m2Create;
		}
		return null;
	}

	private void OnEnable()
	{
		isSupported = true;
	}

	private bool CheckSupport()
	{
		return CheckSupport(needDepth: false);
	}

	private bool CheckResources()
	{
		Debug.LogWarning((object)("CheckResources () for " + ((object)this).ToString() + " should be overwritten."));
		return isSupported;
	}

	private void Start()
	{
		CheckResources();
	}

	public bool CheckSupport(bool needDepth)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		isSupported = true;
		supportHDRTextures = SystemInfo.SupportsRenderTextureFormat((RenderTextureFormat)2);
		if (!SystemInfo.supportsImageEffects || !SystemInfo.supportsRenderTextures)
		{
			NotSupported();
			return false;
		}
		if (needDepth && !SystemInfo.SupportsRenderTextureFormat((RenderTextureFormat)1))
		{
			NotSupported();
			return false;
		}
		if (needDepth)
		{
			Camera component = ((Component)this).GetComponent<Camera>();
			component.depthTextureMode = (DepthTextureMode)(component.depthTextureMode | 1);
		}
		return true;
	}

	private bool CheckSupport(bool needDepth, bool needHdr)
	{
		if (!CheckSupport(needDepth))
		{
			return false;
		}
		if (needHdr && !supportHDRTextures)
		{
			NotSupported();
			return false;
		}
		return true;
	}

	private void ReportAutoDisable()
	{
		Debug.LogWarning((object)("The image effect " + ((object)this).ToString() + " has been disabled as it's not supported on the current platform."));
	}

	private bool CheckShader(Shader s)
	{
		Debug.Log((object)("The shader " + ((object)s).ToString() + " on effect " + ((object)this).ToString() + " is not part of the Unity 3.2+ effects suite anymore. For best performance and quality, please ensure you are using the latest Standard Assets Image Effects (Pro only) package."));
		if (!s.isSupported)
		{
			NotSupported();
			return false;
		}
		return false;
	}

	private void NotSupported()
	{
		((Behaviour)this).enabled = false;
		isSupported = false;
	}

	private void DrawBorder(RenderTexture dest, Material material)
	{
		RenderTexture.active = dest;
		bool flag = true;
		GL.PushMatrix();
		GL.LoadOrtho();
		for (int i = 0; i < material.passCount; i++)
		{
			material.SetPass(i);
			float num;
			float num2;
			if (flag)
			{
				num = 1f;
				num2 = 0f;
			}
			else
			{
				num = 0f;
				num2 = 1f;
			}
			float num3 = 0f + 1f / ((float)((Texture)dest).width * 1f);
			float num4 = 0f;
			float num5 = 1f;
			GL.Begin(7);
			GL.TexCoord2(0f, num);
			GL.Vertex3(0f, num4, 0.1f);
			GL.TexCoord2(1f, num);
			GL.Vertex3(num3, num4, 0.1f);
			GL.TexCoord2(1f, num2);
			GL.Vertex3(num3, num5, 0.1f);
			GL.TexCoord2(0f, num2);
			GL.Vertex3(0f, num5, 0.1f);
			float num6 = 1f - 1f / ((float)((Texture)dest).width * 1f);
			num3 = 1f;
			num4 = 0f;
			num5 = 1f;
			GL.TexCoord2(0f, num);
			GL.Vertex3(num6, num4, 0.1f);
			GL.TexCoord2(1f, num);
			GL.Vertex3(num3, num4, 0.1f);
			GL.TexCoord2(1f, num2);
			GL.Vertex3(num3, num5, 0.1f);
			GL.TexCoord2(0f, num2);
			GL.Vertex3(num6, num5, 0.1f);
			num3 = 1f;
			num4 = 0f;
			num5 = 0f + 1f / ((float)((Texture)dest).height * 1f);
			GL.TexCoord2(0f, num);
			GL.Vertex3(0f, num4, 0.1f);
			GL.TexCoord2(1f, num);
			GL.Vertex3(num3, num4, 0.1f);
			GL.TexCoord2(1f, num2);
			GL.Vertex3(num3, num5, 0.1f);
			GL.TexCoord2(0f, num2);
			GL.Vertex3(0f, num5, 0.1f);
			num3 = 1f;
			num4 = 1f - 1f / ((float)((Texture)dest).height * 1f);
			num5 = 1f;
			GL.TexCoord2(0f, num);
			GL.Vertex3(0f, num4, 0.1f);
			GL.TexCoord2(1f, num);
			GL.Vertex3(num3, num4, 0.1f);
			GL.TexCoord2(1f, num2);
			GL.Vertex3(num3, num5, 0.1f);
			GL.TexCoord2(0f, num2);
			GL.Vertex3(0f, num5, 0.1f);
			GL.End();
		}
		GL.PopMatrix();
	}
}
