using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class EnvironmentManager : SingletonComponent<EnvironmentManager>
{
	public static EnvironmentType Get(OBB obb)
	{
		EnvironmentType environmentType = (EnvironmentType)0;
		List<EnvironmentVolume> obj = Pool.GetList<EnvironmentVolume>();
		GamePhysics.OverlapOBB(obb, obj, 262144, QueryTriggerInteraction.Collide);
		for (int i = 0; i < obj.Count; i++)
		{
			environmentType |= obj[i].Type;
		}
		Pool.FreeList(ref obj);
		return environmentType;
	}

	public static EnvironmentType Get(Vector3 pos, ref List<EnvironmentVolume> list)
	{
		EnvironmentType environmentType = (EnvironmentType)0;
		GamePhysics.OverlapSphere(pos, 0.01f, list, 262144, QueryTriggerInteraction.Collide);
		for (int i = 0; i < list.Count; i++)
		{
			environmentType |= list[i].Type;
		}
		return environmentType;
	}

	public static EnvironmentType Get(Vector3 pos)
	{
		List<EnvironmentVolume> list = Pool.GetList<EnvironmentVolume>();
		EnvironmentType result = Get(pos, ref list);
		Pool.FreeList(ref list);
		return result;
	}

	public static bool Check(OBB obb, EnvironmentType type)
	{
		return (Get(obb) & type) != 0;
	}

	public static bool Check(Vector3 pos, EnvironmentType type)
	{
		return (Get(pos) & type) != 0;
	}
}
