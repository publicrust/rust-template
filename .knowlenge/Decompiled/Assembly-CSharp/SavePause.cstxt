using Rust;
using UnityEngine;

public class SavePause : MonoBehaviour, IServerComponent
{
	private bool tracked;

	protected void OnEnable()
	{
		if ((bool)SingletonComponent<SaveRestore>.Instance && !tracked)
		{
			tracked = true;
			SingletonComponent<SaveRestore>.Instance.timedSavePause++;
		}
	}

	protected void OnDisable()
	{
		if (!Rust.Application.isQuitting && (bool)SingletonComponent<SaveRestore>.Instance && tracked)
		{
			tracked = false;
			SingletonComponent<SaveRestore>.Instance.timedSavePause--;
		}
	}
}
