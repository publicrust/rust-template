using System.Collections;
using Network;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
	public static string CurrentLevelName;

	public static bool isLoaded
	{
		get
		{
			if (CurrentLevelName == null)
			{
				return false;
			}
			if (CurrentLevelName == "")
			{
				return false;
			}
			if (CurrentLevelName == "Empty")
			{
				return false;
			}
			if (CurrentLevelName == "MenuBackground")
			{
				return false;
			}
			return true;
		}
	}

	public static bool IsValid(string strName)
	{
		return Application.CanStreamedLevelBeLoaded(strName);
	}

	public static void LoadLevel(string strName, bool keepLoadingScreenOpen = true)
	{
		if (strName == "proceduralmap")
		{
			strName = "Procedural Map";
		}
		CurrentLevelName = strName;
		Net.sv.Reset();
		SceneManager.LoadScene(strName, LoadSceneMode.Single);
	}

	public static IEnumerator LoadLevelAsync(string strName, bool keepLoadingScreenOpen = true)
	{
		if (strName == "proceduralmap")
		{
			strName = "Procedural Map";
		}
		CurrentLevelName = strName;
		Net.sv.Reset();
		yield return null;
		yield return SceneManager.LoadSceneAsync(strName, LoadSceneMode.Single);
		yield return null;
		yield return null;
	}

	public static void UnloadLevel(bool loadingScreen = true)
	{
		CurrentLevelName = null;
		SceneManager.LoadScene("Empty");
	}
}
