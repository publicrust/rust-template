using ConVar;
using UnityEngine;
using UnityEngine.UI;

public class UIScale : MonoBehaviour
{
	public CanvasScaler scaler;

	private void Update()
	{
		Vector2 vector = new Vector2(1280f / ConVar.Graphics.uiscale, 720f / ConVar.Graphics.uiscale);
		if (scaler.referenceResolution != vector)
		{
			scaler.referenceResolution = vector;
		}
	}
}
