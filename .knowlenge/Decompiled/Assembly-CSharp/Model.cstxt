using Facepunch;
using UnityEngine;

public class Model : MonoBehaviour, IPrefabPreProcess
{
	public SphereCollider collision;

	public Transform rootBone;

	public Transform headBone;

	public Transform eyeBone;

	public Animator animator;

	public Skeleton skeleton;

	[HideInInspector]
	public Transform[] boneTransforms;

	[HideInInspector]
	public string[] boneNames;

	internal BoneDictionary boneDict;

	internal int skin;

	protected void OnEnable()
	{
		skin = -1;
	}

	public void BuildBoneDictionary()
	{
		if (boneDict == null)
		{
			boneDict = new BoneDictionary(((Component)this).transform, boneTransforms, boneNames);
		}
	}

	public int GetSkin()
	{
		return skin;
	}

	private Transform FindBoneInternal(string name)
	{
		BuildBoneDictionary();
		return boneDict.FindBone(name, defaultToRoot: false);
	}

	public Transform FindBone(string name)
	{
		BuildBoneDictionary();
		Transform result = rootBone;
		if (string.IsNullOrEmpty(name))
		{
			return result;
		}
		return boneDict.FindBone(name);
	}

	public Transform FindBone(uint hash)
	{
		BuildBoneDictionary();
		Transform result = rootBone;
		if (hash == 0)
		{
			return result;
		}
		return boneDict.FindBone(hash);
	}

	public uint FindBoneID(Transform transform)
	{
		BuildBoneDictionary();
		return boneDict.FindBoneID(transform);
	}

	public Transform[] GetBones()
	{
		BuildBoneDictionary();
		return boneDict.transforms;
	}

	public Transform FindClosestBone(Vector3 worldPos)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		Transform result = rootBone;
		float num = float.MaxValue;
		for (int i = 0; i < boneTransforms.Length; i++)
		{
			Transform val = boneTransforms[i];
			if (!((Object)(object)val == (Object)null))
			{
				float num2 = Vector3.Distance(val.position, worldPos);
				if (!(num2 >= num))
				{
					result = val;
					num = num2;
				}
			}
		}
		return result;
	}

	public void PreProcess(IPrefabProcessor process, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		if (!((Object)(object)this == (Object)null))
		{
			if ((Object)(object)animator == (Object)null)
			{
				animator = ((Component)this).GetComponent<Animator>();
			}
			if ((Object)(object)rootBone == (Object)null)
			{
				rootBone = ((Component)this).transform;
			}
			boneTransforms = ((Component)rootBone).GetComponentsInChildren<Transform>(true);
			boneNames = new string[boneTransforms.Length];
			for (int i = 0; i < boneTransforms.Length; i++)
			{
				boneNames[i] = ((Object)boneTransforms[i]).name;
			}
		}
	}
}
