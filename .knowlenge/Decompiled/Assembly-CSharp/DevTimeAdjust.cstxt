using UnityEngine;

public class DevTimeAdjust : MonoBehaviour
{
	private void Start()
	{
		if ((bool)TOD_Sky.Instance)
		{
			TOD_Sky.Instance.Cycle.Hour = PlayerPrefs.GetFloat("DevTime");
		}
	}

	private void OnGUI()
	{
		if ((bool)TOD_Sky.Instance)
		{
			float num = (float)Screen.width * 0.2f;
			Rect position = new Rect((float)Screen.width - (num + 20f), (float)Screen.height - 30f, num, 20f);
			float hour = TOD_Sky.Instance.Cycle.Hour;
			hour = GUI.HorizontalSlider(position, hour, 0f, 24f);
			position.y -= 20f;
			GUI.Label(position, "Time Of Day");
			if (hour != TOD_Sky.Instance.Cycle.Hour)
			{
				TOD_Sky.Instance.Cycle.Hour = hour;
				PlayerPrefs.SetFloat("DevTime", hour);
			}
		}
	}
}
