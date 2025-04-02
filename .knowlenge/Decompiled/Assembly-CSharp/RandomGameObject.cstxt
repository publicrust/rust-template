using UnityEngine;

public class RandomGameObject : MonoBehaviour
{
	public GameObject[] gameObjects;

	private void Awake()
	{
		EnableRandomObject();
	}

	private void EnableRandomObject()
	{
		if (gameObjects.Length != 0)
		{
			GameObject[] array = gameObjects;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: false);
			}
			ArrayEx.GetRandom(gameObjects).SetActive(value: true);
		}
	}
}
