using Rust.UI;
using UnityEngine.EventSystems;

public class DemoShotButton : RustButton, IPointerClickHandler, IEventSystemHandler
{
	public bool FireEventOnClicked;

	public override void OnPointerDown(PointerEventData eventData)
	{
		if (!FireEventOnClicked)
		{
			base.OnPointerDown(eventData);
		}
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		if (!FireEventOnClicked)
		{
			base.OnPointerUp(eventData);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (FireEventOnClicked)
		{
			Press();
		}
	}
}
