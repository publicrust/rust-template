using UnityEngine;

public class BasePrefab : BaseMonoBehaviour, IPrefabPreProcess
{
	[HideInInspector]
	public uint prefabID;

	[HideInInspector]
	public bool isClient;

	public bool isServer => !isClient;

	public virtual void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		prefabID = StringPool.Get(name);
		isClient = clientside;
	}
}
