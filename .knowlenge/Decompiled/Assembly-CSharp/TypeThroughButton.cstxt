using System.Collections;
using Rust;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TypeThroughButton : Button, IUpdateSelectedHandler, IEventSystemHandler
{
	public InputField typingTarget;

	private Event _processingEvent = new Event();

	public void OnUpdateSelected(BaseEventData eventData)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		if ((Object)(object)typingTarget == (Object)null)
		{
			return;
		}
		while (Event.PopEvent(_processingEvent))
		{
			if ((int)_processingEvent.rawType == 4 && _processingEvent.character != 0)
			{
				Event e = new Event(_processingEvent);
				((MonoBehaviour)Global.Runner).StartCoroutine(DelayedActivateTextField(e));
				break;
			}
		}
		((AbstractEventData)eventData).Use();
	}

	private IEnumerator DelayedActivateTextField(Event e)
	{
		typingTarget.ActivateInputField();
		((Selectable)typingTarget).Select();
		if (e.character != ' ')
		{
			InputField obj = typingTarget;
			obj.text += " ";
		}
		typingTarget.MoveTextEnd(false);
		typingTarget.ProcessEvent(e);
		yield return null;
		typingTarget.caretPosition = typingTarget.text.Length;
		typingTarget.ForceLabelUpdate();
	}
}
