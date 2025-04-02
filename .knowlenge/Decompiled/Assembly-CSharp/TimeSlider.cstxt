using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
	private Slider slider;

	private void Start()
	{
		slider = GetComponent<Slider>();
	}

	private void Update()
	{
		if (!(TOD_Sky.Instance == null))
		{
			slider.value = TOD_Sky.Instance.Cycle.Hour;
		}
	}

	public void OnValue(float f)
	{
		if (!(TOD_Sky.Instance == null))
		{
			TOD_Sky.Instance.Cycle.Hour = f;
			TOD_Sky.Instance.UpdateAmbient();
			TOD_Sky.Instance.UpdateReflection();
			TOD_Sky.Instance.UpdateFog();
		}
	}
}
