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
			boneDict = new BoneDictionary(base.transform, boneTransforms, boneNames);
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
		Transform result = rootBone;
		float num = float.MaxValue;
		for (int i = 0; i < boneTransforms.Length; i++)
		{
			Transform transform = boneTransforms[i];
			if (!(transform == null))
			{
				float num2 = Vector3.Distance(transform.position, worldPos);
				if (!(num2 >= num))
				{
					result = transform;
					num = num2;
				}
			}
		}
		return result;
	}

	public void PreProcess(IPrefabProcessor process, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		if (!(this == null))
		{
			if (animator == null)
			{
				animator = GetComponent<Animator>();
			}
			if (rootBone == null)
			{
				rootBone = base.transform;
			}
			boneTransforms = rootBone.GetComponentsInChildren<Transform>(includeInactive: true);
			boneNames = new string[boneTransforms.Length];
			for (int i = 0; i < boneTransforms.Length; i++)
			{
				boneNames[i] = boneTransforms[i].name;
			}
		}
	}
}
