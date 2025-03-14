using System;
using Painting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ImagePainter : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IInitializePotentialDragHandler
{
	[Serializable]
	public class OnDrawingEvent : UnityEvent<Vector2, Brush>
	{
	}

	internal class PointerState
	{
		public Vector2 lastPos;

		public bool isDown;
	}

	public OnDrawingEvent onDrawing = new OnDrawingEvent();

	public MonoBehaviour redirectRightClick;

	[Tooltip("Spacing scale will depend on your texel size, tweak to what's right.")]
	public float spacingScale = 1f;

	internal Brush brush;

	internal PointerState[] pointerState = new PointerState[3]
	{
		new PointerState(),
		new PointerState(),
		new PointerState()
	};

	public RectTransform rectTransform => base.transform as RectTransform;

	public virtual void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out var localPoint);
			DrawAt(localPoint, eventData.button);
			pointerState[(int)eventData.button].isDown = true;
		}
	}

	public virtual void OnPointerUp(PointerEventData eventData)
	{
		pointerState[(int)eventData.button].isDown = false;
	}

	public virtual void OnDrag(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			if ((bool)redirectRightClick)
			{
				redirectRightClick.SendMessage("OnDrag", eventData);
			}
		}
		else
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out var localPoint);
			DrawAt(localPoint, eventData.button);
		}
	}

	public virtual void OnBeginDrag(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right && (bool)redirectRightClick)
		{
			redirectRightClick.SendMessage("OnBeginDrag", eventData);
		}
	}

	public virtual void OnEndDrag(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right && (bool)redirectRightClick)
		{
			redirectRightClick.SendMessage("OnEndDrag", eventData);
		}
	}

	public virtual void OnInitializePotentialDrag(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right && (bool)redirectRightClick)
		{
			redirectRightClick.SendMessage("OnInitializePotentialDrag", eventData);
		}
	}

	private void DrawAt(Vector2 position, PointerEventData.InputButton button)
	{
		if (brush == null)
		{
			return;
		}
		PointerState pointerState = this.pointerState[(int)button];
		Vector2 vector = UIEx.Unpivot(rectTransform, position);
		if (pointerState.isDown)
		{
			Vector2 vector2 = pointerState.lastPos - vector;
			Vector2 normalized = vector2.normalized;
			for (float num = 0f; num < vector2.magnitude; num += Mathf.Max(brush.spacing, 1f) * Mathf.Max(spacingScale, 0.1f))
			{
				onDrawing.Invoke(vector + num * normalized, brush);
			}
			pointerState.lastPos = vector;
		}
		else
		{
			onDrawing.Invoke(vector, brush);
			pointerState.lastPos = vector;
		}
	}

	private void Start()
	{
	}

	public void UpdateBrush(Brush brush)
	{
		this.brush = brush;
	}
}
