using Rust;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextEntryCookie : MonoBehaviour
{
	public InputField control => ((Component)this).GetComponent<InputField>();

	private void OnEnable()
	{
		string @string = PlayerPrefs.GetString("TextEntryCookie_" + ((Object)this).name);
		if (!string.IsNullOrEmpty(@string))
		{
			control.text = @string;
		}
		((UnityEvent<string>)(object)control.onValueChanged).Invoke(control.text);
	}

	private void OnDisable()
	{
		if (!Application.isQuitting)
		{
			PlayerPrefs.SetString("TextEntryCookie_" + ((Object)this).name, control.text);
		}
	}
}
