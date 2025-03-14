using UnityEngine;
using UnityEngine.UI;

public class ToggleTerrainTrees : MonoBehaviour
{
	public Toggle toggleControl;

	public Text textControl;

	protected void OnEnable()
	{
		if ((bool)Terrain.activeTerrain)
		{
			toggleControl.isOn = Terrain.activeTerrain.drawTreesAndFoliage;
		}
	}

	public void OnToggleChanged()
	{
		if ((bool)Terrain.activeTerrain)
		{
			Terrain.activeTerrain.drawTreesAndFoliage = toggleControl.isOn;
		}
	}

	protected void OnValidate()
	{
		if ((bool)textControl)
		{
			textControl.text = "Terrain Trees";
		}
	}
}
