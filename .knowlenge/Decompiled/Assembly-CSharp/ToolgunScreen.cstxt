using UnityEngine;
using UnityEngine.UI;

public class ToolgunScreen : MonoBehaviour
{
	public Text blockInfoText;

	public Text noBlockText;

	public void SetScreenText(string newText)
	{
		bool flag = string.IsNullOrEmpty(newText);
		((Component)blockInfoText).gameObject.SetActive(!flag);
		((Component)noBlockText).gameObject.SetActive(flag);
		blockInfoText.text = newText;
	}
}
