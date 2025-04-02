using UnityEngine;

public class SwapKeycard : MonoBehaviour
{
	public GameObject[] accessLevels;

	public void UpdateAccessLevel(int level)
	{
		GameObject[] array = accessLevels;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
		}
		if (level > 0 && accessLevels.Length >= level)
		{
			accessLevels[level - 1].SetActive(true);
		}
	}

	public void SetRootActive(int index)
	{
		for (int i = 0; i < accessLevels.Length; i++)
		{
			accessLevels[i].SetActive(i == index);
		}
	}
}
