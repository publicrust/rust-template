using Network;
using UnityEngine;

public class SantaSleigh : BaseEntity
{
	public GameObjectRef prefabDrop;

	public SpawnFilter filter;

	public Transform dropOrigin;

	[ServerVar]
	public static float altitudeAboveTerrain = 50f;

	[ServerVar]
	public static float desiredAltitude = 60f;

	public Light bigLight;

	public SoundPlayer hohoho;

	public float hohohospacing = 4f;

	public float hohoho_additional_spacing = 2f;

	public Vector3 swimScale;

	public Vector3 swimSpeed;

	public float appliedSwimScale = 1f;

	public float appliedSwimRotation = 20f;

	private Vector3 startPos;

	private Vector3 endPos;

	private float secondsToTake;

	private float secondsTaken;

	private bool dropped;

	public Vector3 dropPosition = Vector3.zero;

	private float swimRandom;

	private const string path = "assets/prefabs/misc/xmas/sleigh/santasleigh.prefab";

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("SantaSleigh.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override float GetNetworkTime()
	{
		return Time.fixedTime;
	}

	public void InitDropPosition(Vector3 newDropPosition)
	{
		dropPosition = newDropPosition;
		dropPosition.y = 0f;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		if (dropPosition == Vector3.zero)
		{
			dropPosition = RandomDropPosition();
		}
		UpdateDropPosition(dropPosition);
		Invoke(SendHoHoHo, 0f);
	}

	public void SendHoHoHo()
	{
		Invoke(SendHoHoHo, hohohospacing + Random.Range(0f, hohoho_additional_spacing));
		ClientRPC(RpcTarget.NetworkGroup("ClientPlayHoHoHo"));
	}

	public Vector3 RandomDropPosition()
	{
		Vector3 zero = Vector3.zero;
		float num = 100f;
		float x = TerrainMeta.Size.x;
		do
		{
			zero = Vector3Ex.Range(0f - x / 3f, x / 3f);
		}
		while (filter.GetFactor(zero) == 0f && (num -= 1f) > 0f);
		zero.y = 0f;
		return zero;
	}

	public void UpdateDropPosition(Vector3 newDropPosition)
	{
		float x = TerrainMeta.Size.x;
		float y = altitudeAboveTerrain;
		startPos = Vector3Ex.Range(-1f, 1f);
		startPos.y = 0f;
		startPos.Normalize();
		startPos *= x * 1.25f;
		startPos.y = y;
		endPos = startPos * -1f;
		endPos.y = startPos.y;
		startPos += newDropPosition;
		endPos += newDropPosition;
		secondsToTake = Vector3.Distance(startPos, endPos) / 25f;
		secondsToTake *= Random.Range(0.95f, 1.05f);
		base.transform.SetPositionAndRotation(startPos, Quaternion.LookRotation(endPos - startPos));
		dropPosition = newDropPosition;
	}

	private void FixedUpdate()
	{
		if (!base.isServer)
		{
			return;
		}
		Vector3 position = base.transform.position;
		Quaternion rotation = base.transform.rotation;
		secondsTaken += Time.deltaTime;
		float num = Mathf.InverseLerp(0f, secondsToTake, secondsTaken);
		if (!dropped && num >= 0.5f)
		{
			dropped = true;
			BaseEntity baseEntity = GameManager.server.CreateEntity(prefabDrop.resourcePath, dropOrigin.transform.position);
			if ((bool)baseEntity)
			{
				baseEntity.globalBroadcast = true;
				baseEntity.Spawn();
			}
		}
		position = Vector3.Lerp(startPos, endPos, num);
		Vector3 normalized = (endPos - startPos).normalized;
		Vector3 zero = Vector3.zero;
		if (swimScale != Vector3.zero)
		{
			if (swimRandom == 0f)
			{
				swimRandom = Random.Range(0f, 20f);
			}
			float num2 = Time.time + swimRandom;
			zero = new Vector3(Mathf.Sin(num2 * swimSpeed.x) * swimScale.x, Mathf.Cos(num2 * swimSpeed.y) * swimScale.y, Mathf.Sin(num2 * swimSpeed.z) * swimScale.z);
			zero = base.transform.InverseTransformDirection(zero);
			position += zero * appliedSwimScale;
		}
		rotation = Quaternion.LookRotation(normalized) * Quaternion.Euler(Mathf.Cos(Time.time * swimSpeed.y) * appliedSwimRotation, 0f, Mathf.Sin(Time.time * swimSpeed.x) * appliedSwimRotation);
		Vector3 vector = position;
		float height = TerrainMeta.HeightMap.GetHeight(vector + base.transform.forward * 30f);
		float height2 = TerrainMeta.HeightMap.GetHeight(vector);
		float num3 = Mathf.Max(height, height2);
		float b = Mathf.Max(desiredAltitude, num3 + altitudeAboveTerrain);
		vector.y = Mathf.Lerp(base.transform.position.y, b, Time.fixedDeltaTime * 0.5f);
		position = vector;
		base.transform.hasChanged = true;
		if (num >= 1f)
		{
			Kill();
		}
		base.transform.SetPositionAndRotation(position, rotation);
	}

	[ServerVar]
	public static void drop(ConsoleSystem.Arg arg)
	{
		BasePlayer basePlayer = ArgEx.Player(arg);
		if ((bool)basePlayer)
		{
			Debug.Log("Santa Inbound");
			BaseEntity baseEntity = GameManager.server.CreateEntity("assets/prefabs/misc/xmas/sleigh/santasleigh.prefab");
			if ((bool)baseEntity)
			{
				baseEntity.GetComponent<SantaSleigh>().InitDropPosition(basePlayer.transform.position + new Vector3(0f, 10f, 0f));
				baseEntity.Spawn();
			}
		}
	}
}
