using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomImage : MonoBehaviour, IScrollHandler, IEventSystemHandler
{
	[SerializeField]
	private float _minimumScale = 0.5f;

	[SerializeField]
	private float _initialScale = 1f;

	[SerializeField]
	private float _maximumScale = 3f;

	[SerializeField]
	private float _scaleIncrement = 0.5f;

	[HideInInspector]
	private Vector3 _scale;

	private RectTransform _thisTransform;

	private void Awake()
	{
		_thisTransform = base.transform as RectTransform;
		_scale.Set(_initialScale, _initialScale, 1f);
		_thisTransform.localScale = _scale;
	}

	public void OnScroll(PointerEventData eventData)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(_thisTransform, Input.mousePosition, null, out var localPoint);
		float y = eventData.scrollDelta.y;
		if (y > 0f && _scale.x < _maximumScale)
		{
			_scale.Set(_scale.x + _scaleIncrement, _scale.y + _scaleIncrement, 1f);
			_thisTransform.localScale = _scale;
			_thisTransform.anchoredPosition -= localPoint * _scaleIncrement;
		}
		else if (y < 0f && _scale.x > _minimumScale)
		{
			_scale.Set(_scale.x - _scaleIncrement, _scale.y - _scaleIncrement, 1f);
			_thisTransform.localScale = _scale;
			_thisTransform.anchoredPosition += localPoint * _scaleIncrement;
		}
	}
}
