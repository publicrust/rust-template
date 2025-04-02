using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChildrenFromScene : MonoBehaviour
{
	public string SceneName;

	public bool StartChildrenDisabled;

	private IEnumerator Start()
	{
		Debug.LogWarning("WARNING: CHILDRENFROMSCENE(" + SceneName + ") - WE SHOULDN'T BE USING THIS SHITTY COMPONENT NOW WE HAVE AWESOME PREFABS", base.gameObject);
		if (!SceneManager.GetSceneByName(SceneName).isLoaded)
		{
			yield return SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
		}
		Scene sceneByName = SceneManager.GetSceneByName(SceneName);
		GameObject[] rootGameObjects = sceneByName.GetRootGameObjects();
		foreach (GameObject gameObject in rootGameObjects)
		{
			gameObject.transform.SetParent(base.transform, worldPositionStays: false);
			TransformEx.Identity(gameObject);
			RectTransform rectTransform = gameObject.transform as RectTransform;
			if ((bool)rectTransform)
			{
				rectTransform.pivot = Vector2.zero;
				rectTransform.anchoredPosition = Vector2.zero;
				rectTransform.anchorMin = Vector2.zero;
				rectTransform.anchorMax = Vector2.one;
				rectTransform.sizeDelta = Vector2.one;
			}
			SingletonComponent[] componentsInChildren = gameObject.GetComponentsInChildren<SingletonComponent>(includeInactive: true);
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				componentsInChildren[j].SingletonSetup();
			}
			if (StartChildrenDisabled)
			{
				gameObject.SetActive(value: false);
			}
		}
		SceneManager.UnloadSceneAsync(sceneByName);
	}
}
