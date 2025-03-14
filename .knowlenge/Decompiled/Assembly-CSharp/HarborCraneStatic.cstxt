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
		base.Save(info);
		info.msg.harborCrane = Pool.Get<ProtoBuf.HarborCrane>();
		info.msg.harborCrane.depth = CraneGrab.localPosition.x;
		info.msg.harborCrane.height = CraneGrab.localPosition.y;
		info.msg.harborCrane.yaw = ArmRoot.localEulerAngles.z;
	}

	private void SetArmPos(float angle, float height, float depth)
	{
		ArmRoot.localEulerAngles = new Vector3(0f, 0f, angle);
		CraneGrab.localPosition = new Vector3(depth, height, 0f);
		HangingLadder.rotation = Quaternion.LookRotation(base.transform.right, Vector3.up);
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
