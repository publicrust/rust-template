using UnityEngine;

public class AnimalFootIK : MonoBehaviour
{
	public Transform[] Feet;

	public Animator animator;

	public float maxWeightDistance = 0.1f;

	public float minWeightDistance = 0.025f;

	public float actualFootOffset = 0.01f;

	public bool GroundSample(Vector3 origin, out RaycastHit hit)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		if (Physics.Raycast(origin + Vector3.up * 0.5f, Vector3.down, ref hit, 1f, 455155969))
		{
			return true;
		}
		return false;
	}

	public void Start()
	{
	}

	public AvatarIKGoal GoalFromIndex(int index)
	{
		return (AvatarIKGoal)(index switch
		{
			0 => 2, 
			1 => 3, 
			2 => 0, 
			3 => 1, 
			_ => 2, 
		});
	}

	private void OnAnimatorIK(int layerIndex)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		Debug.Log((object)"animal ik!");
		for (int i = 0; i < 4; i++)
		{
			Transform val = Feet[i];
			AvatarIKGoal val2 = GoalFromIndex(i);
			_ = Vector3.up;
			Vector3 position = ((Component)val).transform.position;
			float iKPositionWeight = animator.GetIKPositionWeight(val2);
			if (GroundSample(((Component)val).transform.position - Vector3.down * actualFootOffset, out var hit))
			{
				_ = ((RaycastHit)(ref hit)).normal;
				position = ((RaycastHit)(ref hit)).point;
				float num = Vector3.Distance(((Component)val).transform.position - Vector3.down * actualFootOffset, position);
				iKPositionWeight = 1f - Mathf.InverseLerp(minWeightDistance, maxWeightDistance, num);
				animator.SetIKPosition(val2, position + Vector3.up * actualFootOffset);
			}
			else
			{
				iKPositionWeight = 0f;
			}
			animator.SetIKPositionWeight(val2, iKPositionWeight);
		}
	}
}
