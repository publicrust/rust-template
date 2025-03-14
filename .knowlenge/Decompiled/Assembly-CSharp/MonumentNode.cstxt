using UnityEngine;

public class MonumentNode : MonoBehaviour
{
	public string ResourceFolder = string.Empty;

	protected void Awake()
	{
		if (!(SingletonComponent<WorldSetup>.Instance == null))
		{
			if (SingletonComponent<WorldSetup>.Instance.MonumentNodes == null)
			{
				Debug.LogError("WorldSetup.Instance.MonumentNodes is null.", this);
			}
			else
			{
				SingletonComponent<WorldSetup>.Instance.MonumentNodes.Add(this);
			}
		}
	}

	public void Process(ref uint seed)
	{
		if (World.Networked)
		{
			World.Spawn("Monument", "assets/bundled/prefabs/autospawn/" + ResourceFolder + "/");
			return;
		}
		Prefab<MonumentInfo>[] array = Prefab.Load<MonumentInfo>("assets/bundled/prefabs/autospawn/" + ResourceFolder);
		if (array != null && array.Length != 0)
		{
			Prefab<MonumentInfo> random = ArrayEx.GetRandom(array, ref seed);
			float height = TerrainMeta.HeightMap.GetHeight(base.transform.position);
			Vector3 pos = new Vector3(base.transform.position.x, height, base.transform.position.z);
			Quaternion rot = random.Object.transform.localRotation;
			Vector3 scale = random.Object.transform.localScale;
			random.ApplyDecorComponents(ref pos, ref rot, ref scale);
			World.AddPrefab("Monument", random, pos, rot, scale);
		}
	}
}
