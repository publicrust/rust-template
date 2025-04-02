using UnityEngine;

public class DevMovePlayer : BaseMonoBehaviour
{
	public BasePlayer player;

	public Transform[] Waypoints;

	public bool moveRandomly;

	public Vector3 destination = Vector3.zero;

	public Vector3 lookPoint = Vector3.zero;

	private int waypointIndex;

	private float randRun;

	public void Awake()
	{
		randRun = Random.Range(5f, 10f);
		player = GetComponent<BasePlayer>();
		if (Waypoints.Length != 0)
		{
			destination = Waypoints[0].position;
		}
		else
		{
			destination = base.transform.position;
		}
		if (!player.isClient)
		{
			if (player.eyes == null)
			{
				player.eyes = player.GetComponent<PlayerEyes>();
			}
			Invoke(LateSpawn, 1f);
		}
	}

	public void LateSpawn()
	{
		Item item = ItemManager.CreateByName("rifle.semiauto", 1, 0uL);
		player.inventory.GiveItem(item, player.inventory.containerBelt);
		player.UpdateActiveItem(item.uid);
		player.health = 100f;
	}

	public void SetWaypoints(Transform[] wps)
	{
		Waypoints = wps;
		destination = wps[0].position;
	}

	public void Update()
	{
		if (player.isClient || !player.IsAlive() || player.IsWounded())
		{
			return;
		}
		if (Vector3.Distance(destination, base.transform.position) < 0.25f)
		{
			if (moveRandomly)
			{
				waypointIndex = Random.Range(0, Waypoints.Length);
			}
			else
			{
				waypointIndex++;
			}
			if (waypointIndex >= Waypoints.Length)
			{
				waypointIndex = 0;
			}
		}
		if (Waypoints.Length > waypointIndex)
		{
			destination = Waypoints[waypointIndex].position;
			Vector3 normalized = (destination - base.transform.position).normalized;
			float running = Mathf.Sin(Time.time + randRun);
			float speed = player.GetSpeed(running, 0f, 0f);
			Vector3 position = base.transform.position;
			float range = 1f;
			LayerMask mask = 1537286401;
			if (TransformUtil.GetGroundInfo(base.transform.position + normalized * speed * Time.deltaTime, out var hitOut, range, mask, player.transform))
			{
				position = hitOut.point;
			}
			base.transform.position = position;
			_ = (new Vector3(destination.x, 0f, destination.z) - new Vector3(player.transform.position.x, 0f, player.transform.position.z)).normalized;
			player.SendNetworkUpdate();
		}
	}
}
