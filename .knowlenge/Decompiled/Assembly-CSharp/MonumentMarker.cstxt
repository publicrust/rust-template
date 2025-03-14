using UnityEngine;
using UnityEngine.UI;

public class MonumentMarker : MonoBehaviour
{
	public Text text;

	public void Setup(MonumentInfo info)
	{
		string translated = info.displayPhrase.translated;
		text.text = (string.IsNullOrEmpty(translated) ? "Monument" : translated);
	}
}
