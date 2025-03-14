using UnityEngine;

public class HideIfScoped : MonoBehaviour
{
	public Renderer[] renderers;

	public void SetVisible(bool vis)
	{
		Renderer[] array = renderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = vis;
		}
	}
}
