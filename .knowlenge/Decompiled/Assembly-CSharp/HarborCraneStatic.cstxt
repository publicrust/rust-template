using Facepunch;
using ProtoBuf;
using UnityEngine;

public class HarborCraneStatic : HarborCrane
{
	public float StartingDepth;

	public float StartingHeight;

	public float StartingAngle;

	public Transform HangingLadder;

	public override void PostMapEntitySpawn()
	{
		base.PostMapEntitySpawn();
		SetArmPos(StartingAngle, StartingHeight, StartingDepth);
	}

	public override void Save(SaveInfo info)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		base.Save(info);
		info.msg.harborCrane = Pool.Get<HarborCrane>();
		info.msg.harborCrane.depth = CraneGrab.localPosition.x;
		info.msg.harborCrane.height = CraneGrab.localPosition.y;
		info.msg.harborCrane.yaw = ArmRoot.localEulerAngles.z;
	}

	private void SetArmPos(float angle, float height, float depth)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		ArmRoot.localEulerAngles = new Vector3(0f, 0f, angle);
		CraneGrab.localPosition = new Vector3(depth, height, 0f);
		HangingLadder.rotation = Quaternion.LookRotation(((Component)this).transform.right, Vector3.up);
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.harborCrane != null)
		{
			SetArmPos(info.msg.harborCrane.yaw, info.msg.harborCrane.height, info.msg.harborCrane.depth);
		}
	}
}
