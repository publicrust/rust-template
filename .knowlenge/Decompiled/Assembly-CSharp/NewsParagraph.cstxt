using System;
using System.Collections.Generic;
using Rust.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewsParagraph : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public RustText Text;

	public List<string> Links;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (Text == null || Links == null || eventData.button != 0)
		{
			return;
		}
		int num = TMP_TextUtilities.FindIntersectingLink(Text, eventData.position, eventData.pressEventCamera);
		if (num < 0 || num >= Text.textInfo.linkCount)
		{
			return;
		}
		TMP_LinkInfo tMP_LinkInfo = Text.textInfo.linkInfo[num];
		if (int.TryParse(tMP_LinkInfo.GetLinkID(), out var result) && result >= 0 && result < Links.Count)
		{
			string text = Links[result];
			if (text.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
			{
				Application.OpenURL(text);
			}
		}
	}
}
