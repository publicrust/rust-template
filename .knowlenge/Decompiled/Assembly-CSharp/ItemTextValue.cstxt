using UnityEngine;
using UnityEngine.UI;

public class ItemTextValue : MonoBehaviour
{
	public Text text;

	public Color bad;

	public Color good;

	public bool negativestat;

	public bool asPercentage;

	public bool useColors = true;

	public bool signed = true;

	public string suffix;

	public float multiplier = 1f;

	public void SetValue(float val, int numDecimals = 0, string overrideText = "")
	{
		val *= multiplier;
		text.text = ((overrideText == "") ? string.Format("{0}{1:n" + numDecimals + "}", (val > 0f && signed) ? "+" : "", val) : overrideText);
		if (asPercentage)
		{
			text.text += " %";
		}
		if (suffix != "" && !float.IsPositiveInfinity(val))
		{
			text.text += suffix;
		}
		bool flag = val > 0f;
		if (negativestat)
		{
			flag = !flag;
		}
		if (useColors)
		{
			text.color = (flag ? good : bad);
		}
	}
}
