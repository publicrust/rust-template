using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePrefab : MonoBehaviour
{
	private const string MarkerGameObjectName = "Linked_To_Prefab_Marker";

	public string ServerScene;

	public string ClientScene;

	public string GenericScene;

	public string PrefabPath;

	public bool NeedsPreProcess { get; private set; }

	public Scene Scene { get; private set; }

	private bool loadCanceled { get; set; }

	private string scenePath { get; set; }

	private string sceneName { get; set; }

	public bool IsServer => true;

	private void Start()
	{
		NeedsPreProcess = true;
		scenePath = GenericScene;
		if (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
		{
			scenePath = scenePath.Replace("\\", "/");
		}
		sceneName = Path.GetFileNameWithoutExtension(scenePath);
		SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).completed += OnSceneLoaded;
	}

	private void OnDestroy()
	{
		loadCanceled = true;
		UnloadScene();
	}

	private void OnSceneLoaded(AsyncOperation obj)
	{
		FindLoadedScene();
		if (loadCanceled)
		{
			UnloadScene();
			return;
		}
		RunPreProcess();
		RepositionScene();
		DeleteEntities();
		ActivateSceneRoots();
	}

	private void FindLoadedScene()
	{
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			Scene sceneAt = SceneManager.GetSceneAt(i);
			if (!(sceneAt.name != sceneName) && !(sceneAt.GetRootGameObjects().FirstOrDefault((GameObject x) => IsMarkerObject(x)) != null))
			{
				Scene = sceneAt;
				CreateMarkerObjectInScene(sceneAt);
				return;
			}
		}
		throw new Exception("Failed to find the scene '" + sceneName + "' after async load operation said it was done");
	}

	private string GetPrefabPath()
	{
		return PrefabPath;
	}

	private void RunPreProcess()
	{
		if (!NeedsPreProcess)
		{
			return;
		}
		GameObject[] rootGameObjects = Scene.GetRootGameObjects();
		foreach (GameObject go in rootGameObjects)
		{
			if (!IsMarkerObject(go))
			{
				Prefab.DefaultManager.preProcessed.ProcessObject(GetPrefabPath(), go, PreProcessPrefabOptions.Default);
			}
		}
	}

	private void CreateMarkerObjectInScene(Scene scene)
	{
		SceneManager.MoveGameObjectToScene(new GameObject("Linked_To_Prefab_Marker"), scene);
	}

	private bool IsMarkerObject(GameObject go)
	{
		return go.name == "Linked_To_Prefab_Marker";
	}

	private void RepositionScene()
	{
		GameObject[] rootGameObjects = Scene.GetRootGameObjects();
		foreach (GameObject gameObject in rootGameObjects)
		{
			if (!IsMarkerObject(gameObject))
			{
				gameObject.transform.position = base.transform.position;
				gameObject.transform.rotation = base.transform.rotation;
			}
		}
	}

	private void DeleteEntities()
	{
	}

	private void ActivateSceneRoots()
	{
		GameObject[] rootGameObjects = Scene.GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			rootGameObjects[i].SetActive(value: true);
		}
	}

	private void UnloadScene()
	{
		if (Scene.IsValid())
		{
			SceneManager.UnloadSceneAsync(Scene);
		}
	}
}
