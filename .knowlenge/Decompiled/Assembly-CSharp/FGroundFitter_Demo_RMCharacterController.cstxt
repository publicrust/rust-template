using FIMSpace.Basics;
using FIMSpace.GroundFitter;
using UnityEngine;

public class FGroundFitter_Demo_RMCharacterController : FSimpleFitter
{
	protected FAnimationClips clips;

	protected Animator animator;

	private float gravity;

	protected override void Start()
	{
		base.Start();
		animator = GetComponentInChildren<Animator>();
		clips = new FAnimationClips(animator);
		clips.AddClip("Idle");
		clips.AddClip("Walk");
		clips.AddClip("RotateL");
		clips.AddClip("RotateR");
	}

	public void Update()
	{
		if ((bool)optionalCharContr)
		{
			if (optionalCharContr.isGrounded)
			{
				gravity = 0f;
			}
			else
			{
				gravity += Time.deltaTime * 10f;
				optionalCharContr.Move(Vector3.down * gravity * Time.deltaTime);
			}
		}
		if (Input.GetKey(KeyCode.A))
		{
			clips.CrossFade("RotateL");
		}
		else if (Input.GetKey(KeyCode.D))
		{
			clips.CrossFade("RotateR");
		}
		else if (Input.GetKey(KeyCode.W))
		{
			clips.CrossFade("Walk");
		}
		else
		{
			clips.CrossFade("Idle");
		}
	}
}
