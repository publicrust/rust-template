using ConVar;
using UnityEngine;

public class FPSGraph : Graph
{
	public void Refresh()
	{
		((Behaviour)this).enabled = FPS.graph > 0;
		((Rect)(ref Area)).width = (Resolution = Mathf.Clamp(FPS.graph, 0, Screen.width));
	}

	protected void OnEnable()
	{
		Refresh();
	}

	protected override float GetValue()
	{
		return 1f / Time.deltaTime;
	}

	protected override Color GetColor(float value)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
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
