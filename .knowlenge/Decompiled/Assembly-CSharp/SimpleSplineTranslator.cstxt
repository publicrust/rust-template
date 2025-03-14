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
		if (spline == null)
		{
			Debug.LogError("Can't traverse over a null spline. Please set the spline data first.");
			return;
		}
		float delta = speed * deltaTime;
		currentDistance = CalculateNextDistance(currentDistance, delta, direction);
	}

	public Vector3 PeekNextPosition(float delta = 0.1f, int dir = 1, bool getLocal = false)
	{
		if (spline == null)
		{
			Debug.LogError("Can't traverse over a null spline. Please set the spline data first.");
			return Vector3.zero;
		}
		float distance = CalculateNextDistance(currentDistance, delta, dir);
		Vector3 tangent;
		Vector3 vector = GetPositionAtDistance(distance, out tangent);
		vector += offset;
		if (!getLocal)
		{
			vector = spline.transform.TransformPoint(vector);
		}
		return vector;
	}

	public Vector3 PeekNextPositionFollowingDirection(float delta = 0.1f, bool getLocal = false)
	{
		return PeekNextPosition(delta, direction, getLocal);
	}

	public void GetCurrentPositionAndTangent(out Vector3 position, out Vector3 tangent, bool getLocal = false)
	{
		if (spline == null)
		{
			Debug.LogError("Can't traverse over a null spline. Please set the spline data first.");
			position = Vector3.zero;
			tangent = Vector3.zero;
			return;
		}
		position = GetPositionAtDistance(currentDistance, out tangent);
		position += offset;
		if (!getLocal)
		{
			position = spline.transform.TransformPoint(position);
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
		return splineData.GetPointAndTangentCubicHermite(distance, out tangent);
	}

	public SimpleSplineTranslator SetSpeed(float newSpeed)
	{
		speed = newSpeed;
		return this;
	}

	public SimpleSplineTranslator SetOffset(Vector3 offset)
	{
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
