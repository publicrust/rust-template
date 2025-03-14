using UnityEngine;

public class ConstructionSkin_CustomDetail : ConstructionSkin
{
	public ConstructionSkin_ColourLookup ColourLookup;

	public override uint GetStartingDetailColour(uint playerColourIndex)
	{
		if (playerColourIndex != 0)
		{
			return (uint)Mathf.Clamp(playerColourIndex, 1f, ColourLookup.AllColours.Length + 1);
		}
		return (uint)Random.Range(1, ColourLookup.AllColours.Length + 1);
	}
}
