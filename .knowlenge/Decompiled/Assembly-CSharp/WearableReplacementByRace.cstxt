using UnityEngine;

public class WearableReplacementByRace : MonoBehaviour
{
	public GameObjectRef[] replacements;

	public GameObjectRef GetReplacement(int meshIndex)
	{
		int num = Mathf.Clamp(meshIndex, 0, replacements.Length - 1);
		return replacements[num];
	}
}
