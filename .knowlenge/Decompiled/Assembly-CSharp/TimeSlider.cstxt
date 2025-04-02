using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
	private Slider slider;

	private void Start()
	{
		slider = ((Component)this).GetComponent<Slider>();
	}

	private void Update()
	{
		if (!((Object)(object)TOD_Sky.Instance == (Object)null))
		{
			slider.value = TOD_Sky.Instance.Cycle.Hour;
		}
	}

	public void OnValue(float f)
	{
		if (!((Object)(object)TOD_Sky.Instance == (Object)null))
		{
			TOD_Sky.Instance.Cycle.Hour = f;
			TOD_Sky.Instance.UpdateAmbient();
			TOD_Sky.Instance.UpdateReflection();
			TOD_Sky.Instance.UpdateFog();
		}
	}
}
