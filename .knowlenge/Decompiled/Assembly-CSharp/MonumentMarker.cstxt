using UnityEngine;
using UnityEngine.UI;

public class MonumentMarker : MonoBehaviour
{
	public Text text;

	public void Setup(MonumentInfo info)
	{
		text.text = (info.displayPhrase.IsValid() ? info.displayPhrase.translated : info.transform.root.name);
	}
}
