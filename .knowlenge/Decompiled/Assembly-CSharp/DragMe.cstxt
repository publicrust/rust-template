using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragMe : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	public static DragMe dragging;

	public static GameObject dragIcon;

	public static object data;

	[NonSerialized]
	public string dragType = "generic";

	protected virtual Canvas TopCanvas => UIRootScaled.DragOverlayCanvas;

	public virtual void OnBeginDrag(PointerEventData eventData)
	{
	}

	public virtual void OnDrag(PointerEventData eventData)
	{
	}

	public virtual void OnEndDrag(PointerEventData eventData)
	{
	}

	public void CancelDrag()
	{
		OnEndDrag(new PointerEventData(EventSystem.current));
	}
}
