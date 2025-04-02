using UnityEngine;

public class SimpleSplineTranslator
{
	private WorldSpline spline;

	private WorldSplineData splineData;

	private float currentDistance;

	private float speed;

	private bool loop;

	private Vector3 offset;

	private int direction;

	public int Direction;

	public float Speed => speed;

	public Vector3 Offset => offset;

	public float CurrentDistance => currentDistance;

	public bool Loop => loop;

	public SimpleSplineTranslator(WorldSpline spline, float speed, int direction = 1, bool loop = false)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		this.spline = spline;
		this.speed = speed;
		this.loop = loop;
		this.direction = direction;
		splineData = spline.GetData();
		offset = Vector3.zero;
		currentDistance = ((direction == 1) ? 0f : splineData.Length);
	}

	public SimpleSplineTranslator()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		spline = null;
		splineData = null;
		speed = 0f;
		loop = false;
		direction = 1;
		offset = Vector3.zero;
		currentDistance = 0f;
	}

	public void Update(float deltaTime)
	{
		if ((Object)(object)spline == (Object)null)
		{
			Debug.LogError((object)"Can't traverse over a null spline. Please set the spline data first.");
			return;
		}
		float delta = speed * deltaTime;
		currentDistance = CalculateNextDistance(currentDistance, delta, direction);
	}

	public Vector3 PeekNextPosition(float delta = 0.1f, int dir = 1, bool getLocal = false)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)spline == (Object)null)
		{
			Debug.LogError((object)"Can't traverse over a null spline. Please set the spline data first.");
			return Vector3.zero;
		}
		float distance = CalculateNextDistance(currentDistance, delta, dir);
		Vector3 positionAtDistance = GetPositionAtDistance(distance, out var _);
		positionAtDistance += offset;
		if (!getLocal)
		{
			positionAtDistance = ((Component)spline).transform.TransformPoint(positionAtDistance);
		}
		return positionAtDistance;
	}

	public Vector3 PeekNextPositionFollowingDirection(float delta = 0.1f, bool getLocal = false)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		return PeekNextPosition(delta, direction, getLocal);
	}

	public void GetCurrentPositionAndTangent(out Vector3 position, out Vector3 tangent, bool getLocal = false)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)spline == (Object)null)
		{
			Debug.LogError((object)"Can't traverse over a null spline. Please set the spline data first.");
			position = Vector3.zero;
			tangent = Vector3.zero;
			return;
		}
		position = GetPositionAtDistance(currentDistance, out tangent);
		position += offset;
		if (!getLocal)
		{
			position = ((Component)spline).transform.TransformPoint(position);
		}
	}

	private float CalculateNextDistance(float currentDistance, float delta, float dir)
	{
		float num = currentDistance + delta * dir;
		if (loop)
		{
			return num % splineData.Length;
		}
		return Mathf.Clamp(num, 0f, splineData.Length);
	}

	public float GetEnd()
	{
		if (direction == 1)
		{
			return splineData.Length;
		}
		return 0f;
	}

	public float GetStart()
	{
		if (direction == -1)
		{
			return splineData.Length;
		}
		return 0f;
	}

	public Vector3 GetPositionAtDistance(float distance, out Vector3 tangent)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return splineData.GetPointAndTangentCubicHermite(distance, out tangent);
	}

	public SimpleSplineTranslator SetSpeed(float newSpeed)
	{
		speed = newSpeed;
		return this;
	}

	public SimpleSplineTranslator SetOffset(Vector3 offset)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		this.offset = offset;
		return this;
	}

	public SimpleSplineTranslator SetCurrentDistance(float distance)
	{
		currentDistance = Mathf.Clamp(distance, 0f, splineData.Length);
		return this;
	}

	public SimpleSplineTranslator CalculateStartingDistance()
	{
		currentDistance = GetStart();
		return this;
	}

	public SimpleSplineTranslator Reset()
	{
		currentDistance = 0f;
		return this;
	}

	public SimpleSplineTranslator SetSpline(WorldSpline spline)
	{
		this.spline = spline;
		splineData = spline.GetData();
		return this;
	}

	public SimpleSplineTranslator SetDirection(int direction)
	{
		this.direction = direction;
		return this;
	}

	public float GetCurrentDistance()
	{
		return currentDistance;
	}
}
