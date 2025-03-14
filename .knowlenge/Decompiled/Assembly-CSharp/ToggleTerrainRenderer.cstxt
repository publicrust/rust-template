using UnityEngine;
using UnityEngine.UI;

public class ToggleTerrainRenderer : MonoBehaviour
{
	public Toggle toggleControl;

	public Text textControl;

	protected void OnEnable()
	{
		if ((bool)Terrain.activeTerrain)
		{
			toggleControl.isOn = Terrain.activeTerrain.drawHeightmap;
		}
	}

	public void OnToggleChanged()
	{
		if ((bool)Terrain.activeTerrain)
		{
			Terrain.activeTerrain.drawHeightmap = toggleControl.isOn;
		}
	}

	protected void OnValidate()
	{
		if ((bool)textControl)
		{
			textControl.text = "Terrain Renderer";
		}
	}
}
