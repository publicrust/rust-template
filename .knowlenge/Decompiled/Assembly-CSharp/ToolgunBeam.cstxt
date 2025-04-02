using UnityEngine;

public class ToolgunBeam : MonoBehaviour
{
	public LineRenderer electricalBeam;

	public float scrollSpeed = -8f;

	private Color fadeColor = new Color(1f, 1f, 1f, 1f);

	public float fadeSpeed = 4f;

	public void Update()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		if (fadeColor.a <= 0f)
		{
			Object.Destroy((Object)(object)((Component)this).gameObject);
			return;
		}
		((Renderer)electricalBeam).sharedMaterial.SetTextureOffset("_MainTex", new Vector2(Time.time * scrollSpeed, 0f));
		fadeColor.a -= Time.deltaTime * fadeSpeed;
		electricalBeam.startColor = fadeColor;
		electricalBeam.endColor = fadeColor;
	}
}
