using UnityEngine;

public abstract class ProceduralComponent : MonoBehaviour
{
	public enum Realm
	{
		Client = 1,
		Server
	}

	[InspectorFlags]
	public Realm Mode = (Realm)(-1);

	public string Description = "Procedural Component";

	public virtual bool RunOnCache => false;

	public bool ShouldRun()
	{
		if (World.Cached && !RunOnCache)
		{
			return false;
		}
		if ((Mode & Realm.Server) != 0)
		{
			return true;
		}
		return false;
	}

	public abstract void Process(uint seed);
}
