using UnityEngine;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("")]
public class ImageEffectBase : MonoBehaviour
{
	public Shader shader;

	private Material m_Material;

	protected Material material
	{
		get
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			if ((Object)(object)m_Material == (Object)null)
			{
				m_Material = new Material(shader);
				((Object)m_Material).hideFlags = (HideFlags)61;
			}
			return m_Material;
		}
	}

	protected virtual void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			((Behaviour)this).enabled = false;
		}
		else if (!Object.op_Implicit((Object)(object)shader) || !shader.isSupported)
		{
			((Behaviour)this).enabled = false;
		}
	}

	protected virtual void OnDisable()
	{
		if (Object.op_Implicit((Object)(object)m_Material))
		{
			Object.DestroyImmediate((Object)(object)m_Material);
		}
	}
}
