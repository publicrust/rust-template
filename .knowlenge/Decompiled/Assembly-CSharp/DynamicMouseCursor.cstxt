using System;
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
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		if (!Cursor.visible)
		{
			return;
		}
		GameObject val = CurrentlyHoveredItem();
		TimeWarning val2;
		if ((Object)(object)val != (Object)null)
		{
			val2 = TimeWarning.New("RustControl", 0);
			try
			{
				RustControl componentInParent = val.GetComponentInParent<RustControl>();
				if ((Object)(object)componentInParent != (Object)null && componentInParent.IsDisabled)
				{
					UpdateCursor(RegularCursor, RegularCursorPos);
					return;
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			val2 = TimeWarning.New("ISubmitHandler", 0);
			try
			{
				if (val.GetComponentInParent<ISubmitHandler>() != null)
				{
					UpdateCursor(HoverCursor, HoverCursorPos);
					return;
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			val2 = TimeWarning.New("IPointerDownHandler", 0);
			try
			{
				if (val.GetComponentInParent<IPointerDownHandler>() != null)
				{
					UpdateCursor(HoverCursor, HoverCursorPos);
					return;
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		val2 = TimeWarning.New("UpdateCursor", 0);
		try
		{
			UpdateCursor(RegularCursor, RegularCursorPos);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	private void UpdateCursor(Texture2D cursor, Vector2 offs)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)current == (Object)(object)cursor))
		{
			current = cursor;
			Cursor.SetCursor(cursor, offs, (CursorMode)0);
		}
	}

	private GameObject CurrentlyHoveredItem()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		FpStandaloneInputModule obj = EventSystem.current.currentInputModule as FpStandaloneInputModule;
		if (obj == null)
		{
			return null;
		}
		RaycastResult pointerCurrentRaycast = obj.CurrentData.pointerCurrentRaycast;
		return ((RaycastResult)(ref pointerCurrentRaycast)).gameObject;
	}
}
