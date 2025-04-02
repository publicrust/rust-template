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
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		Debug.Log((object)"Please read the comments at the top of the runtime script (/Assets/EasyRoads3D/Scripts/runtimeScript) before using the runtime API!");
		roadNetwork = new ERRoadNetwork();
		ERRoadType val = new ERRoadType();
		val.roadWidth = 6f;
		ref Material roadMaterial = ref val.roadMaterial;
		Object obj = Resources.Load("Materials/roads/road material");
		roadMaterial = (Material)(object)((obj is Material) ? obj : null);
		val.layer = 1;
		val.tag = "Untagged";
		Vector3[] array = (Vector3[])(object)new Vector3[4]
		{
			new Vector3(200f, 5f, 200f),
			new Vector3(250f, 5f, 200f),
			new Vector3(250f, 5f, 250f),
			new Vector3(300f, 5f, 250f)
		};
		road = roadNetwork.CreateRoad("road 1", val, array);
		road.AddMarker(new Vector3(300f, 5f, 300f));
		road.InsertMarker(new Vector3(275f, 5f, 235f));
		road.DeleteMarker(2);
		roadNetwork.BuildRoadNetwork();
		go = GameObject.CreatePrimitive((PrimitiveType)3);
	}

	private void Update()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
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
			Debug.Log((object)"Restore Road Network");
		}
	}
}
