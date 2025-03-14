using System;
using UnityEngine;

[Serializable]
public class SceneField
{
	[SerializeField]
	private UnityEngine.Object sceneAsset;

	[SerializeField]
	private string sceneName = "";

	public string SceneName => sceneName;

	public static implicit operator string(SceneField sceneField)
	{
		return sceneField.SceneName;
	}
}
