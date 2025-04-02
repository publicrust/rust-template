using UnityEngine;
using UnityEngine.UI;

public class SetMemorySlider : MonoBehaviour
{
	private void Awake()
	{
		((Component)this).GetComponent<Slider>().maxValue = Mathf.Min(4096, SystemInfo.systemMemorySize / 8);
	}
}
