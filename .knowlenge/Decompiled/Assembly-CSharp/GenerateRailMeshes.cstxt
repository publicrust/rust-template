using UnityEngine;

public class GenerateRailMeshes : ProceduralComponent
{
	public const float NormalSmoothing = 0f;

	public const bool SnapToTerrain = false;

	public Mesh RailMesh;

	public Mesh[] RailMeshes;

	public Material RailMaterial;

	public PhysicMaterial RailPhysicMaterial;

	public override bool RunOnCache => true;

	public override void Process(uint seed)
	{
		if (RailMeshes == null || RailMeshes.Length == 0)
		{
			RailMeshes = new Mesh[1] { RailMesh };
		}
		foreach (PathList rail in TerrainMeta.Path.Rails)
		{
			foreach (PathList.MeshObject item in rail.CreateMesh(RailMeshes, 0f, snapToTerrain: false, !rail.Path.Circular && !rail.Start, !rail.Path.Circular && !rail.End))
			{
				GameObject obj = new GameObject("Rail Mesh");
				obj.transform.position = item.Position;
				obj.tag = "Railway";
				obj.layer = 16;
				GameObjectEx.SetHierarchyGroup(obj, rail.Name);
				obj.SetActive(value: false);
				MeshCollider meshCollider = obj.AddComponent<MeshCollider>();
				meshCollider.sharedMaterial = RailPhysicMaterial;
				meshCollider.sharedMesh = item.Meshes[0];
				obj.AddComponent<AddToHeightMap>();
				obj.SetActive(value: true);
			}
			AddTrackSpline(rail);
		}
	}

	private void AddTrackSpline(PathList rail)
	{
		TrainTrackSpline trainTrackSpline = HierarchyUtil.GetRoot(rail.Name).AddComponent<TrainTrackSpline>();
		trainTrackSpline.aboveGroundSpawn = rail.Hierarchy == 2;
		trainTrackSpline.hierarchy = rail.Hierarchy;
		if (trainTrackSpline.aboveGroundSpawn)
		{
			TrainTrackSpline.SidingSplines.Add(trainTrackSpline);
		}
		Vector3[] array = new Vector3[rail.Path.Points.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = rail.Path.Points[i];
			array[i].y += 0.41f;
		}
		Vector3[] array2 = new Vector3[rail.Path.Tangents.Length];
		for (int j = 0; j < array.Length; j++)
		{
			array2[j] = rail.Path.Tangents[j];
		}
		trainTrackSpline.SetAll(array, array2, 0.25f);
	}
}
