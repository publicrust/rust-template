using EasyRoads3Dv3;
using UnityEngine;

public class runtimeScript : MonoBehaviour
{
	public ERRoadNetwork roadNetwork;

	public ERRoad road;

	public GameObject go;

	public int currentElement;

	public float distance;

	public float speed = 5f;

	private void Start()
	{
		Debug.Log("Please read the comments at the top of the runtime script (/Assets/EasyRoads3D/Scripts/runtimeScript) before using the runtime API!");
		roadNetwork = new ERRoadNetwork();
		ERRoadType eRRoadType = new ERRoadType();
		eRRoadType.roadWidth = 6f;
		eRRoadType.roadMaterial = Resources.Load("Materials/roads/road material") as Material;
		eRRoadType.layer = 1;
		eRRoadType.tag = "Untagged";
		Vector3[] markers = new Vector3[4]
		{
			new Vector3(200f, 5f, 200f),
			new Vector3(250f, 5f, 200f),
			new Vector3(250f, 5f, 250f),
			new Vector3(300f, 5f, 250f)
		};
		road = roadNetwork.CreateRoad("road 1", eRRoadType, markers);
		road.AddMarker(new Vector3(300f, 5f, 300f));
		road.InsertMarker(new Vector3(275f, 5f, 235f));
		road.DeleteMarker(2);
		roadNetwork.BuildRoadNetwork();
		go = GameObject.CreatePrimitive(PrimitiveType.Cube);
	}

	private void Update()
	{
		if (roadNetwork != null)
		{
			float num = Time.deltaTime * speed;
			distance += num;
			Vector3 position = road.GetPosition(distance, ref currentElement);
			position.y += 1f;
			go.transform.position = position;
			go.transform.forward = road.GetLookatSmooth(distance, currentElement);
		}
	}

	private void OnDestroy()
	{
		if (roadNetwork != null && roadNetwork.isInBuildMode)
		{
			roadNetwork.RestoreRoadNetwork();
			Debug.Log("Restore Road Network");
		}
	}
}
