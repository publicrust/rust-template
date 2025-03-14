using Network;
using TMPro;
using UnityEngine;

public class NetworkInfoGeneralText : MonoBehaviour
{
	public TextMeshProUGUI text;

	private void Update()
	{
		UpdateText();
	}

	private void UpdateText()
	{
		string text = "";
		if (Net.sv != null)
		{
			text += "Server\n";
			text += Net.sv.GetDebug(null);
			text += "\n";
		}
		this.text.text = text;
	}

	private static string ChannelStat(int window, int left)
	{
		return $"{left}/{window}";
	}
}
