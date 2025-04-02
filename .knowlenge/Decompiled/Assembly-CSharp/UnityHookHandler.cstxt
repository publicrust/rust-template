using UnityEngine;

public class UnityHookHandler : SingletonComponent<UnityHookHandler>
{
	public static void EnsureCreated()
	{
		if ((Object)(object)SingletonComponent<UnityHookHandler>.Instance == (Object)null)
		{
			CreateInstance();
		}
	}

	private static void CreateInstance()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		GameObject val = new GameObject("UnityHookHandler");
		val.AddComponent<UnityHookHandler>();
		val.AddComponent<PreUpdateHook>();
		val.AddComponent<PostUpdateHook>();
		Object.DontDestroyOnLoad((Object)val);
		PerformanceMetrics.Setup();
		Debug.Log((object)"Setup unity update hooks");
	}
}
