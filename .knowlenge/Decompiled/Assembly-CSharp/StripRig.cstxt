using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class StripRig : MonoBehaviour, IPrefabPreProcess
{
	public Transform root;

	public bool fromClient;

	public bool fromServer;

	public void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		if ((bool)root && ((serverside && fromServer) || (clientside && fromClient)))
		{
			SkinnedMeshRenderer component = GetComponent<SkinnedMeshRenderer>();
			Strip(preProcess, component);
		}
		preProcess.RemoveComponent(this);
	}

	public void Strip(IPrefabProcessor preProcess, SkinnedMeshRenderer skinnedMeshRenderer)
	{
		List<Transform> obj = Pool.Get<List<Transform>>();
		root.GetComponentsInChildren(obj);
		for (int num = obj.Count - 1; num >= 0; num--)
		{
			if (preProcess != null)
			{
				preProcess.NominateForDeletion(obj[num].gameObject);
			}
			else
			{
				Object.DestroyImmediate(obj[num].gameObject);
			}
		}
		Pool.FreeUnmanaged(ref obj);
	}
}
