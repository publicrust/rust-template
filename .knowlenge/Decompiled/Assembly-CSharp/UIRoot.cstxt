using UnityEngine;
using UnityEngine.UI;

public abstract class UIRoot : MonoBehaviour
{
	private GraphicRaycaster[] graphicRaycasters;

	public Canvas overlayCanvas;

	private void ToggleRaycasters(bool state)
	{
		for (int i = 0; i < graphicRaycasters.Length; i++)
		{
			GraphicRaycaster graphicRaycaster = graphicRaycasters[i];
			if (graphicRaycaster.enabled != state)
			{
				graphicRaycaster.enabled = state;
			}
		}
	}

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
		graphicRaycasters = GetComponentsInChildren<GraphicRaycaster>(includeInactive: true);
	}

	protected void Update()
	{
		Refresh();
	}

	protected abstract void Refresh();
}
