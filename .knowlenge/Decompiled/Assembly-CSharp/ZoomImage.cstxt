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
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		ref RectTransform thisTransform = ref _thisTransform;
		Transform transform = ((Component)this).transform;
		thisTransform = (RectTransform)(object)((transform is RectTransform) ? transform : null);
		((Vector3)(ref _scale)).Set(_initialScale, _initialScale, 1f);
		((Transform)_thisTransform).localScale = _scale;
	}

	public void OnScroll(PointerEventData eventData)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = default(Vector2);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(_thisTransform, Vector2.op_Implicit(Input.mousePosition), (Camera)null, ref val);
		float y = eventData.scrollDelta.y;
		if (y > 0f && _scale.x < _maximumScale)
		{
			((Vector3)(ref _scale)).Set(_scale.x + _scaleIncrement, _scale.y + _scaleIncrement, 1f);
			((Transform)_thisTransform).localScale = _scale;
			RectTransform thisTransform = _thisTransform;
			thisTransform.anchoredPosition -= val * _scaleIncrement;
		}
		else if (y < 0f && _scale.x > _minimumScale)
		{
			((Vector3)(ref _scale)).Set(_scale.x - _scaleIncrement, _scale.y - _scaleIncrement, 1f);
			((Transform)_thisTransform).localScale = _scale;
			RectTransform thisTransform2 = _thisTransform;
			thisTransform2.anchoredPosition += val * _scaleIncrement;
		}
	}
}
