using System.Collections.Generic;
using UnityEngine.Events;

public class UIEscapeCapture : ListComponent<UIEscapeCapture>
{
	public UnityEvent onEscape = new UnityEvent();

	public static bool EscapePressed()
	{
		using (IEnumerator<UIEscapeCapture> enumerator = ListComponent<UIEscapeCapture>.InstanceList.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				enumerator.Current.onEscape.Invoke();
				return true;
			}
		}
		return false;
	}
}
