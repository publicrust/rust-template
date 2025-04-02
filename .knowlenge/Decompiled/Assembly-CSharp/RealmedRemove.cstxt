using System.Linq;
using UnityEngine;

public class RealmedRemove : MonoBehaviour, IPrefabPreProcess
{
	public GameObject[] removedFromClient;

	public Component[] removedComponentFromClient;

	public GameObject[] removedFromServer;

	public Component[] removedComponentFromServer;

	public Component[] doNotRemoveFromServer;

	public Component[] doNotRemoveFromClient;

	public void PreProcess(IPrefabProcessor process, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		if (clientside)
		{
			GameObject[] array = removedFromClient;
			for (int i = 0; i < array.Length; i++)
			{
				Object.DestroyImmediate(array[i], allowDestroyingAssets: true);
			}
			Component[] array2 = removedComponentFromClient;
			for (int i = 0; i < array2.Length; i++)
			{
				Object.DestroyImmediate(array2[i], allowDestroyingAssets: true);
			}
		}
		if (serverside)
		{
			GameObject[] array = removedFromServer;
			for (int i = 0; i < array.Length; i++)
			{
				Object.DestroyImmediate(array[i], allowDestroyingAssets: true);
			}
			Component[] array2 = removedComponentFromServer;
			for (int i = 0; i < array2.Length; i++)
			{
				Object.DestroyImmediate(array2[i], allowDestroyingAssets: true);
			}
		}
		if (!bundling)
		{
			process.RemoveComponent(this);
		}
	}

	public bool ShouldDelete(Component comp, bool client, bool server)
	{
		if (client && doNotRemoveFromClient != null && doNotRemoveFromClient.Contains(comp))
		{
			return false;
		}
		if (server && doNotRemoveFromServer != null && doNotRemoveFromServer.Contains(comp))
		{
			return false;
		}
		return true;
	}
}
