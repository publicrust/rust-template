using UnityEngine;

public class ToolgunBeam : MonoBehaviour
{
	public LineRenderer electricalBeam;

	public float scrollSpeed = -8f;

	private Color fadeColor = new Color(1f, 1f, 1f, 1f);

	public float fadeSpeed = 4f;

	public void Update()
	{
		if (fadeColor.a <= 0f)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		electricalBeam.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(Time.time * scrollSpeed, 0f));
		fadeColor.a -= Time.deltaTime * fadeSpeed;
		electricalBeam.startColor = fadeColor;
		electricalBeam.endColor = fadeColor;
	}
}
