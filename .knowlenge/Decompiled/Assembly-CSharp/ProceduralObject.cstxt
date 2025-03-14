using UnityEngine;

public abstract class ProceduralObject : MonoBehaviour
{
	protected void Awake()
	{
		if (!(SingletonComponent<WorldSetup>.Instance == null))
		{
			if (SingletonComponent<WorldSetup>.Instance.ProceduralObjects == null)
			{
				Debug.LogError("WorldSetup.Instance.ProceduralObjects is null.", this);
			}
			else
			{
				SingletonComponent<WorldSetup>.Instance.ProceduralObjects.Add(this);
			}
		}
	}

	public abstract void Process();
}
