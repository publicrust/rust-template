using UnityEngine;
using UnityEngine.UI;

public class ToggleTerrainRenderer : MonoBehaviour
{
	public Toggle toggleControl;

	public Text textControl;

	protected void OnEnable()
	{
		if (Object.op_Implicit((Object)(object)Terrain.activeTerrain))
		{
			toggleControl.isOn = Terrain.activeTerrain.drawHeightmap;
		}
	}

	public void OnToggleChanged()
	{
		if (Object.op_Implicit((Object)(object)Terrain.activeTerrain))
		{
			Terrain.activeTerrain.drawHeightmap = toggleControl.isOn;
		}
	}

	protected void OnValidate()
	{
		if (Object.op_Implicit((Object)(object)textControl))
		{
			textControl.text = "Terrain Renderer";
		}
	}
}
