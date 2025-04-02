using UnityEngine;

public class F15 : BaseCombatEntity
{
	public float speed = 150f;

	public float defaultAltitude = 150f;

	public float altitude = 250f;

	public float altitudeLerpSpeed = 30f;

	public float turnRate = 1f;

	public float flybySoundLengthUntilMax = 4.5f;

	public SoundPlayer flybySound;

	public GameObject body;

	public float rollSpeed = 1f;

	public Vector3 movePosition;

	public GameObjectRef missilePrefab;

	private float nextMissileTime;

	private float blockTurningFor;

	private bool isRetiring;

	private CH47PathFinder pathFinder = new CH47PathFinder();

	private float turnSeconds;

	public override float PositionTickRate
	{
		protected get
		{
			return 0.05f;
		}
	}

	public override bool PositionTickFixedTime
	{
		protected get
		{
			return true;
		}
	}

	public override float GetNetworkTime()
	{
		return Time.fixedTime;
	}

	public float GetDesiredAltitude()
	{
		Vector3 vector = base.transform.position + base.transform.forward * 200f;
		return (TerrainMeta.HeightMap.GetHeight(base.transform.position) + TerrainMeta.HeightMap.GetHeight(vector) + TerrainMeta.HeightMap.GetHeight(vector + Vector3.right * 50f) + TerrainMeta.HeightMap.GetHeight(vector - Vector3.right * 50f) + TerrainMeta.HeightMap.GetHeight(vector + Vector3.forward * 50f) + TerrainMeta.HeightMap.GetHeight(vector - Vector3.forward * 50f)) / 6f + defaultAltitude;
	}

	public override void ServerInit()
	{
		base.ServerInit();
		Invoke(RetireToSunset, 600f);
		movePosition = base.transform.position;
		movePosition.y = defaultAltitude;
		base.transform.position = movePosition;
	}

	public void RetireToSunset()
	{
		isRetiring = true;
		movePosition = new Vector3(10000f, defaultAltitude, 10000f);
	}

	public void PickNewPatrolPoint()
	{
		movePosition = pathFinder.GetRandomPatrolPoint();
		float num = 0f;
		if (TerrainMeta.HeightMap != null)
		{
			num = TerrainMeta.HeightMap.GetHeight(movePosition);
		}
		movePosition.y = num + defaultAltitude;
	}

	private void FixedUpdate()
	{
		if (base.isClient)
		{
			return;
		}
		if (isRetiring && Vector3.Distance(base.transform.position, Vector3.zero) > 4900f)
		{
			Invoke(DelayedDestroy, 0f);
		}
		if (!IsInvoking(DelayedDestroy))
		{
			altitude = Mathf.Lerp(altitude, GetDesiredAltitude(), Time.fixedDeltaTime * 0.25f);
			if (Vector3Ex.Distance2D(movePosition, base.transform.position) < 10f)
			{
				PickNewPatrolPoint();
				blockTurningFor = 6f;
			}
			blockTurningFor -= Time.fixedDeltaTime;
			bool num = blockTurningFor > 0f;
			movePosition.y = altitude;
			Vector3 vector = Vector3Ex.Direction(movePosition, base.transform.position);
			if (num)
			{
				Vector3 position = base.transform.position;
				position.y = altitude;
				Vector3 vector2 = QuaternionEx.LookRotationForcedUp(base.transform.forward, Vector3.up) * Vector3.forward;
				vector = Vector3Ex.Direction(position + vector2 * 2000f, base.transform.position);
			}
			Vector3 forward = Vector3.Lerp(base.transform.forward, vector, Time.fixedDeltaTime * turnRate);
			base.transform.forward = forward;
			bool flag = Vector3.Dot(base.transform.right, vector) > 0.55f;
			bool flag2 = Vector3.Dot(-base.transform.right, vector) > 0.55f;
			SetFlag(Flags.Reserved1, flag);
			SetFlag(Flags.Reserved2, flag2);
			if (flag2 || flag)
			{
				turnSeconds += Time.fixedDeltaTime;
			}
			else
			{
				turnSeconds = 0f;
			}
			if (turnSeconds > 10f)
			{
				turnSeconds = 0f;
				blockTurningFor = 8f;
			}
			base.transform.position += base.transform.forward * speed * Time.fixedDeltaTime;
			nextMissileTime = Time.realtimeSinceStartup + 10f;
		}
	}

	public void DelayedDestroy()
	{
		Kill();
	}
}
