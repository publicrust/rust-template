using ConVar;
using UnityEngine;

public class FPSGraph : Graph
{
	public void Refresh()
	{
		base.enabled = FPS.graph > 0;
		Area.width = (Resolution = Mathf.Clamp(FPS.graph, 0, Screen.width));
	}

	protected void OnEnable()
	{
		Refresh();
	}

	protected override float GetValue()
	{
		return 1f / UnityEngine.Time.deltaTime;
	}

	protected override Color GetColor(float value)
	{
		if (!(value < 10f))
		{
			if (!(value < 30f))
			{
				return Color.green;
			}
			return Color.yellow;
		}
		return Color.red;
	}
}
