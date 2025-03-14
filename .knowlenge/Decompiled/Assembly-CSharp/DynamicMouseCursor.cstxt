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

	private void LateUpdate()
	{
		if (!Cursor.visible)
		{
			return;
		}
		GameObject gameObject = CurrentlyHoveredItem();
		if (gameObject != null)
		{
			using (TimeWarning.New("RustControl"))
			{
				RustControl componentInParent = gameObject.GetComponentInParent<RustControl>();
				if (componentInParent != null && componentInParent.IsDisabled)
				{
					UpdateCursor(RegularCursor, RegularCursorPos);
					return;
				}
			}
			using (TimeWarning.New("ISubmitHandler"))
			{
				if (gameObject.GetComponentInParent<ISubmitHandler>() != null)
				{
					UpdateCursor(HoverCursor, HoverCursorPos);
					return;
				}
			}
			using (TimeWarning.New("IPointerDownHandler"))
			{
				if (gameObject.GetComponentInParent<IPointerDownHandler>() != null)
				{
					UpdateCursor(HoverCursor, HoverCursorPos);
					return;
				}
			}
		}
		using (TimeWarning.New("UpdateCursor"))
		{
			UpdateCursor(RegularCursor, RegularCursorPos);
		}
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
		return (EventSystem.current.currentInputModule as FpStandaloneInputModule)?.CurrentData.pointerCurrentRaycast.gameObject;
	}
}
