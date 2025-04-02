using UnityEngine;

public abstract class ProceduralObject : MonoBehaviour
{
	protected void Awake()
	{
		if (!((Object)(object)SingletonComponent<WorldSetup>.Instance == (Object)null))
		{
			if (SingletonComponent<WorldSetup>.Instance.ProceduralObjects == null)
			{
				Debug.LogError((object)"WorldSetup.Instance.ProceduralObjects is null.", (Object)(object)this);
			}
			else
			{
				SingletonComponent<WorldSetup>.Instance.ProceduralObjects.Add(this);
			}
		}
	}

	public abstract void Process();
}
