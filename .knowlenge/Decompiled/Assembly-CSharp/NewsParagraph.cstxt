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
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)Text == (Object)null || Links == null || (int)eventData.button != 0)
		{
			return;
		}
		int num = TMP_TextUtilities.FindIntersectingLink((TMP_Text)(object)Text, Vector2.op_Implicit(eventData.position), eventData.pressEventCamera);
		if (num < 0 || num >= ((TMP_Text)Text).textInfo.linkCount)
		{
			return;
		}
		TMP_LinkInfo val = ((TMP_Text)Text).textInfo.linkInfo[num];
		if (int.TryParse(((TMP_LinkInfo)(ref val)).GetLinkID(), out var result) && result >= 0 && result < Links.Count)
		{
			string text = Links[result];
			if (text.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
			{
				Application.OpenURL(text);
			}
		}
	}
}
