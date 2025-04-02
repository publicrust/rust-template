using UnityEngine;

public class UnityHookHandler : SingletonComponent<UnityHookHandler>
{
	public static void EnsureCreated()
	{
		if (SingletonComponent<UnityHookHandler>.Instance == null)
		{
			CreateInstance();
		}
	}

	private static void CreateInstance()
	{
		GameObject obj = new GameObject("UnityHookHandler");
		obj.AddComponent<UnityHookHandler>();
		obj.AddComponent<PreUpdateHook>();
		obj.AddComponent<PostUpdateHook>();
		Object.DontDestroyOnLoad(obj);
		PerformanceMetrics.Setup();
		Debug.Log("Setup unity update hooks");
	}
}
