using UnityEngine;

public class ArcadeEntityController : BaseMonoBehaviour
{
	public BaseArcadeGame parentGame;

	public ArcadeEntity arcadeEntity;

	public ArcadeEntity sourceEntity;

	public Vector3 heading
	{
		get
		{
			return arcadeEntity.heading;
		}
		set
		{
			arcadeEntity.heading = value;
		}
	}

	public Vector3 positionLocal
	{
		get
		{
			return arcadeEntity.transform.localPosition;
		}
		set
		{
			arcadeEntity.transform.localPosition = value;
		}
	}

	public Vector3 positionWorld
	{
		get
		{
			return arcadeEntity.transform.position;
		}
		set
		{
			arcadeEntity.transform.position = value;
		}
	}
}
