using UnityEngine;

public class TrainCarFuelHatches : MonoBehaviour
{
	[SerializeField]
	private TrainCar owner;

	[SerializeField]
	private float animSpeed = 1f;

	[SerializeField]
	private Transform hatch1Col;

	[SerializeField]
	private Transform hatch1Vis;

	[SerializeField]
	private Transform hatch2Col;

	[SerializeField]
	private Transform hatch2Vis;

	[SerializeField]
	private Transform hatch3Col;

	[SerializeField]
	private Transform hatch3Vis;

	private const float closedXAngle = 0f;

	private const float openXAngle = -145f;

	[SerializeField]
	private SoundDefinition hatchOpenSoundDef;

	[SerializeField]
	private SoundDefinition hatchCloseSoundDef;

	private Vector3 _angles = Vector3.zero;

	private float _hatchLerp;

	private bool opening;

	private bool openingQueued;

	private bool isMoving;

	public void LinedUpStateChanged(bool linedUp)
	{
		openingQueued = linedUp;
		if (!isMoving)
		{
			opening = linedUp;
			_ = opening;
			isMoving = true;
			InvokeHandler.InvokeRepeating(this, MoveTick, 0f, 0f);
		}
	}

	private void MoveTick()
	{
		if (opening)
		{
			_hatchLerp += Time.deltaTime * animSpeed;
			if (_hatchLerp >= 1f)
			{
				EndMove();
			}
			else
			{
				SetAngleOnAll(_hatchLerp, closing: false);
			}
		}
		else
		{
			_hatchLerp += Time.deltaTime * animSpeed;
			if (_hatchLerp >= 1f)
			{
				EndMove();
			}
			else
			{
				SetAngleOnAll(_hatchLerp, closing: true);
			}
		}
	}

	private void EndMove()
	{
		_hatchLerp = 0f;
		if (openingQueued == opening)
		{
			InvokeHandler.CancelInvoke(this, MoveTick);
			isMoving = false;
		}
		else
		{
			opening = openingQueued;
		}
	}

	private void SetAngleOnAll(float lerpT, bool closing)
	{
		float angle;
		float angle2;
		float angle3;
		if (closing)
		{
			angle = LeanTween.easeOutBounce(-145f, 0f, Mathf.Clamp01(_hatchLerp * 1.15f));
			angle2 = LeanTween.easeOutBounce(-145f, 0f, _hatchLerp);
			angle3 = LeanTween.easeOutBounce(-145f, 0f, Mathf.Clamp01(_hatchLerp * 1.25f));
		}
		else
		{
			angle = LeanTween.easeOutBounce(0f, -145f, Mathf.Clamp01(_hatchLerp * 1.15f));
			angle2 = LeanTween.easeOutBounce(0f, -145f, _hatchLerp);
			angle3 = LeanTween.easeOutBounce(0f, -145f, Mathf.Clamp01(_hatchLerp * 1.25f));
		}
		SetAngle(hatch1Col, angle);
		SetAngle(hatch2Col, angle2);
		SetAngle(hatch3Col, angle3);
	}

	private void SetAngle(Transform transform, float angle)
	{
		_angles.x = angle;
		transform.localEulerAngles = _angles;
	}
}
