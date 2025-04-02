using UnityEngine;
using UnityEngine.UI;

public class SetMemorySlider : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<Slider>().maxValue = Mathf.Min(4096, SystemInfo.systemMemorySize / 8);
	}
}
