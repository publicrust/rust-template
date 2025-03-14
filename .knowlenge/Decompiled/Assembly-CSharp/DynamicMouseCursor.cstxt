using System.Collections.Generic;
using Rust.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicMouseCursor : MonoBehaviour
{
	public Texture2D RegularCursor;

	public Vector2 RegularCursorPos;

	public Texture2D HoverCursor;

	public Vector2 HoverCursorPos;

	private Texture2D current;

	private PointerEventData pointer;

	private List<RaycastResult> results = new List<RaycastResult>();

	private void LateUpdate()
	{
		if (!Cursor.visible)
		{
			return;
		}
		GameObject gameObject = CurrentlyHoveredItem();
		if (gameObject != null)
		{
			RustControl componentInParent = gameObject.GetComponentInParent<RustControl>();
			if (componentInParent != null && componentInParent.IsDisabled)
			{
				UpdateCursor(RegularCursor, RegularCursorPos);
				return;
			}
			if (gameObject != null && gameObject.GetComponentInParent<ISubmitHandler>() != null)
			{
				UpdateCursor(HoverCursor, HoverCursorPos);
				return;
			}
			if (gameObject != null && gameObject.GetComponentInParent<IPointerDownHandler>() != null)
			{
				UpdateCursor(HoverCursor, HoverCursorPos);
				return;
			}
		}
		UpdateCursor(RegularCursor, RegularCursorPos);
	}

	private void UpdateCursor(Texture2D cursor, Vector2 offs)
	{
		if (!(current == cursor))
		{
			current = cursor;
			Cursor.SetCursor(cursor, offs, CursorMode.Auto);
		}
	}

	private GameObject CurrentlyHoveredItem()
	{
		if (pointer == null)
		{
			pointer = new PointerEventData(EventSystem.current);
		}
		pointer.position = Input.mousePosition;
		EventSystem.current.RaycastAll(pointer, results);
		using (List<RaycastResult>.Enumerator enumerator = results.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current.gameObject;
			}
		}
		return null;
	}
}
