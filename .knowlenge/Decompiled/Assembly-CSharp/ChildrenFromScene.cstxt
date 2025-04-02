using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChildrenFromScene : MonoBehaviour
{
	public string SceneName;

	public bool StartChildrenDisabled;

	private IEnumerator Start()
	{
		Debug.LogWarning((object)("WARNING: CHILDRENFROMSCENE(" + SceneName + ") - WE SHOULDN'T BE USING THIS SHITTY COMPONENT NOW WE HAVE AWESOME PREFABS"), (Object)(object)((Component)this).gameObject);
		Scene sceneByName = SceneManager.GetSceneByName(SceneName);
		if (!((Scene)(ref sceneByName)).isLoaded)
		{
			yield return SceneManager.LoadSceneAsync(SceneName, (LoadSceneMode)1);
		}
		sceneByName = SceneManager.GetSceneByName(SceneName);
		GameObject[] rootGameObjects = ((Scene)(ref sceneByName)).GetRootGameObjects();
		foreach (GameObject val in rootGameObjects)
		{
			val.transform.SetParent(((Component)this).transform, false);
			val.Identity();
			Transform transform = val.transform;
			RectTransform val2 = (RectTransform)(object)((transform is RectTransform) ? transform : null);
			if (Object.op_Implicit((Object)(object)val2))
			{
				val2.pivot = Vector2.zero;
				val2.anchoredPosition = Vector2.zero;
				val2.anchorMin = Vector2.zero;
				val2.anchorMax = Vector2.one;
				val2.sizeDelta = Vector2.one;
			}
			SingletonComponent[] componentsInChildren = val.GetComponentsInChildren<SingletonComponent>(true);
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				componentsInChildren[j].SingletonSetup();
			}
			if (StartChildrenDisabled)
			{
				val.SetActive(false);
			}
		}
		SceneManager.UnloadSceneAsync(sceneByName);
	}
}
