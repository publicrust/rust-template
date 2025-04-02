using UnityEngine;
using UnityEngine.UI;

public class BlueprintHeader : MonoBehaviour
{
	public Text categoryName;

	public Text unlockCount;

	public void Setup(ItemCategory name, int unlocked, int total)
	{
		categoryName.text = name.ToString().ToUpper();
		unlockCount.text = $"UNLOCKED {unlocked}/{total}";
	}
}
