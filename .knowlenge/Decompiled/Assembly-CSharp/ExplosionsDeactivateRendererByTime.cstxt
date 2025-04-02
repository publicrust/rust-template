using UnityEngine;

public class ExplosionsDeactivateRendererByTime : MonoBehaviour
{
	public float TimeDelay = 1f;

	private Renderer rend;

	private void Awake()
	{
		rend = ((Component)this).GetComponent<Renderer>();
	}

	private void DeactivateRenderer()
	{
		rend.enabled = false;
	}

	private void OnEnable()
	{
		rend.enabled = true;
		((MonoBehaviour)this).Invoke("DeactivateRenderer", TimeDelay);
	}
}
