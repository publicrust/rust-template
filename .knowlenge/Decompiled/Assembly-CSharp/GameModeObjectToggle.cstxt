using System.Linq;
using UnityEngine;

public class GameModeObjectToggle : BaseMonoBehaviour
{
	public string[] gameModeTags;

	public string[] tagsToDisable;

	public GameObject[] toToggle;

	public bool defaultState;

	public void Awake()
	{
		SetToggle(defaultState);
		BaseGameMode.GameModeChanged += OnGameModeChanged;
	}

	public void OnDestroy()
	{
		BaseGameMode.GameModeChanged -= OnGameModeChanged;
	}

	public void OnGameModeChanged(BaseGameMode newGameMode)
	{
		bool toggle = ShouldBeVisible(newGameMode);
		SetToggle(toggle);
	}

	public void SetToggle(bool wantsOn)
	{
		GameObject[] array = toToggle;
		foreach (GameObject gameObject in array)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(wantsOn);
			}
		}
	}

	public bool ShouldBeVisible(BaseGameMode newGameMode)
	{
		if (newGameMode == null)
		{
			return defaultState;
		}
		if (tagsToDisable.Length != 0 && (newGameMode.HasAnyGameModeTag(tagsToDisable) || tagsToDisable.Contains("*")))
		{
			return false;
		}
		if (gameModeTags.Length != 0 && (newGameMode.HasAnyGameModeTag(gameModeTags) || gameModeTags.Contains("*")))
		{
			return true;
		}
		return defaultState;
	}
}
