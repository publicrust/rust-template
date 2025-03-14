using UnityEngine;

public static class GameObjectUtil
{
	public static void GlobalBroadcast(string messageName, object param = null)
	{
		Transform[] rootObjects = TransformUtil.GetRootObjects();
		for (int i = 0; i < rootObjects.Length; i++)
		{
			rootObjects[i].BroadcastMessage(messageName, param, SendMessageOptions.DontRequireReceiver);
		}
	}
}
