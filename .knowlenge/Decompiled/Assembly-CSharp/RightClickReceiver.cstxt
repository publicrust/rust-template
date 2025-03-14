using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RightClickReceiver : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public UnityEvent ClickReceiver;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			ClickReceiver?.Invoke();
		}
	}
}
