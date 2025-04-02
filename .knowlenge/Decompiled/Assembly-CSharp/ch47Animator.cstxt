using UnityEngine;

public class ch47Animator : MonoBehaviour
{
	public Animator animator;

	public bool bottomDoorOpen;

	public bool landingGearDown;

	public bool leftDoorOpen;

	public bool rightDoorOpen;

	public bool rearDoorOpen;

	public bool rearDoorExtensionOpen;

	public Transform rearRotorBlade;

	public Transform frontRotorBlade;

	public float rotorBladeSpeed;

	public float wheelTurnSpeed;

	public float wheelTurnAngle;

	public SkinnedMeshRenderer[] blurredRotorBlades;

	public SkinnedMeshRenderer[] RotorBlades;

	private bool blurredRotorBladesEnabled;

	public float blurSpeedThreshold = 100f;

	private void Start()
	{
		EnableBlurredRotorBlades(enabled: false);
		animator.SetBool("rotorblade_stop", value: false);
	}

	public void SetDropDoorOpen(bool isOpen)
	{
		bottomDoorOpen = isOpen;
	}

	private void Update()
	{
		animator.SetBool("bottomdoor", bottomDoorOpen);
		animator.SetBool("landinggear", landingGearDown);
		animator.SetBool("leftdoor", leftDoorOpen);
		animator.SetBool("rightdoor", rightDoorOpen);
		animator.SetBool("reardoor", rearDoorOpen);
		animator.SetBool("reardoor_extension", rearDoorExtensionOpen);
		if (rotorBladeSpeed >= blurSpeedThreshold && !blurredRotorBladesEnabled)
		{
			EnableBlurredRotorBlades(enabled: true);
		}
		else if (rotorBladeSpeed < blurSpeedThreshold && blurredRotorBladesEnabled)
		{
			EnableBlurredRotorBlades(enabled: false);
		}
		if (rotorBladeSpeed <= 0f)
		{
			animator.SetBool("rotorblade_stop", value: true);
		}
		else
		{
			animator.SetBool("rotorblade_stop", value: false);
		}
	}

	private void LateUpdate()
	{
		float num = Time.deltaTime * rotorBladeSpeed * 15f;
		Vector3 localEulerAngles = frontRotorBlade.localEulerAngles;
		frontRotorBlade.localEulerAngles = new Vector3(localEulerAngles.x, localEulerAngles.y + num, localEulerAngles.z);
		localEulerAngles = rearRotorBlade.localEulerAngles;
		rearRotorBlade.localEulerAngles = new Vector3(localEulerAngles.x, localEulerAngles.y - num, localEulerAngles.z);
	}

	private void EnableBlurredRotorBlades(bool enabled)
	{
		blurredRotorBladesEnabled = enabled;
		SkinnedMeshRenderer[] array = blurredRotorBlades;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = enabled;
		}
		array = RotorBlades;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = !enabled;
		}
	}
}
