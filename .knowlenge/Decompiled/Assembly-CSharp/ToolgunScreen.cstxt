using UnityEngine;
using UnityEngine.UI;

public class ToolgunScreen : MonoBehaviour
{
	public Text blockInfoText;

	public Text noBlockText;

	public void SetScreenText(string newText)
	{
		bool flag = string.IsNullOrEmpty(newText);
		blockInfoText.gameObject.SetActive(!flag);
		noBlockText.gameObject.SetActive(flag);
		blockInfoText.text = newText;
	}
}
