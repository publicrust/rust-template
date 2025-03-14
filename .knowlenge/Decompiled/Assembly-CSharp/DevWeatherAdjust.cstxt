using UnityEngine;

public class DevWeatherAdjust : MonoBehaviour
{
	protected void Awake()
	{
		SingletonComponent<Climate>.Instance.Overrides.Clouds = 0f;
		SingletonComponent<Climate>.Instance.Overrides.Fog = 0f;
		SingletonComponent<Climate>.Instance.Overrides.Wind = 0f;
		SingletonComponent<Climate>.Instance.Overrides.Rain = 0f;
	}

	protected void OnGUI()
	{
		float num = (float)Screen.width * 0.2f;
		GUILayout.BeginArea(new Rect((float)Screen.width - num - 20f, 20f, num, 400f), "", "box");
		GUILayout.Box("Weather");
		GUILayout.FlexibleSpace();
		GUILayout.Label("Clouds");
		SingletonComponent<Climate>.Instance.Overrides.Clouds = GUILayout.HorizontalSlider(SingletonComponent<Climate>.Instance.Overrides.Clouds, 0f, 1f);
		GUILayout.Label("Fog");
		SingletonComponent<Climate>.Instance.Overrides.Fog = GUILayout.HorizontalSlider(SingletonComponent<Climate>.Instance.Overrides.Fog, 0f, 1f);
		GUILayout.Label("Wind");
		SingletonComponent<Climate>.Instance.Overrides.Wind = GUILayout.HorizontalSlider(SingletonComponent<Climate>.Instance.Overrides.Wind, 0f, 1f);
		GUILayout.Label("Rain");
		SingletonComponent<Climate>.Instance.Overrides.Rain = GUILayout.HorizontalSlider(SingletonComponent<Climate>.Instance.Overrides.Rain, 0f, 1f);
		GUILayout.FlexibleSpace();
		GUILayout.EndArea();
	}
}
