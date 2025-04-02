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
			GraphicRaycaster val = graphicRaycasters[i];
			if (((Behaviour)val).enabled != state)
			{
				((Behaviour)val).enabled = state;
			}
		}
	}

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
		graphicRaycasters = ((Component)this).GetComponentsInChildren<GraphicRaycaster>(true);
	}

	protected void Update()
	{
		Refresh();
	}

	protected abstract void Refresh();
}
