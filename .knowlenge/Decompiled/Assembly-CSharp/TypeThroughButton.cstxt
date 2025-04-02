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
		if (typingTarget == null)
		{
			return;
		}
		while (Event.PopEvent(_processingEvent))
		{
			if (_processingEvent.rawType == EventType.KeyDown && _processingEvent.character != 0)
			{
				Event e = new Event(_processingEvent);
				Global.Runner.StartCoroutine(DelayedActivateTextField(e));
				break;
			}
		}
		eventData.Use();
	}

	private IEnumerator DelayedActivateTextField(Event e)
	{
		typingTarget.ActivateInputField();
		typingTarget.Select();
		if (e.character != ' ')
		{
			typingTarget.text += " ";
		}
		typingTarget.MoveTextEnd(shift: false);
		typingTarget.ProcessEvent(e);
		yield return null;
		typingTarget.caretPosition = typingTarget.text.Length;
		typingTarget.ForceLabelUpdate();
	}
}
