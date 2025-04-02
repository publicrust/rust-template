using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRectZoom : MonoBehaviour, IScrollHandler, IEventSystemHandler
{
	public ScrollRectEx scrollRect;

	public float zoom = 1f;

	public float max = 1.5f;

	public float min = 0.5f;

	public bool mouseWheelZoom = true;

	public float scrollAmount = 0.2f;

	public RectTransform rectTransform => scrollRect.transform as RectTransform;

	private void OnEnable()
	{
		SetZoom(zoom);
	}

	public void OnScroll(PointerEventData data)
	{
		if (mouseWheelZoom)
		{
			SetZoom(zoom + scrollAmount * data.scrollDelta.y);
		}
	}

	public void SetZoom(float z, bool expZoom = true)
	{
		z = Mathf.Clamp(z, min, max);
		zoom = z;
		Vector2 normalizedPosition = scrollRect.normalizedPosition;
		if (expZoom)
		{
			scrollRect.content.localScale = Vector3.one * Mathf.Exp(zoom);
		}
		else
		{
			scrollRect.content.localScale = Vector3.one * zoom;
		}
		scrollRect.normalizedPosition = normalizedPosition;
	}
}
