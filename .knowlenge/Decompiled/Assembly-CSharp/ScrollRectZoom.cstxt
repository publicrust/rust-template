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

	public RectTransform rectTransform
	{
		get
		{
			Transform transform = ((Component)scrollRect).transform;
			return (RectTransform)(object)((transform is RectTransform) ? transform : null);
		}
	}

	private void OnEnable()
	{
		SetZoom(zoom);
	}

	public void OnScroll(PointerEventData data)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if (mouseWheelZoom)
		{
			SetZoom(zoom + scrollAmount * data.scrollDelta.y);
		}
	}

	public void SetZoom(float z, bool expZoom = true)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		z = Mathf.Clamp(z, min, max);
		zoom = z;
		Vector2 normalizedPosition = scrollRect.normalizedPosition;
		if (expZoom)
		{
			((Transform)scrollRect.content).localScale = Vector3.one * Mathf.Exp(zoom);
		}
		else
		{
			((Transform)scrollRect.content).localScale = Vector3.one * zoom;
		}
		scrollRect.normalizedPosition = normalizedPosition;
	}
}
