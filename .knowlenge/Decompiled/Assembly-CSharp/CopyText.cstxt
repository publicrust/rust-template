using Rust.UI;
using TMPro;
using UnityEngine;

public class CopyText : MonoBehaviour
{
	public RustText TargetText;

	public void TriggerCopy()
	{
		if ((Object)(object)TargetText != (Object)null)
		{
			GUIUtility.systemCopyBuffer = ((TMP_Text)TargetText).text;
		}
	}
}
