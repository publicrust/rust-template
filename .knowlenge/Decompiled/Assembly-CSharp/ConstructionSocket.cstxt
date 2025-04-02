using UnityEngine;

public class ConstructionSocket : Socket_Base
{
	public enum Type
	{
		None,
		Foundation,
		Floor,
		Misc,
		Doorway,
		Wall,
		Block,
		Ramp,
		StairsTriangle,
		Stairs,
		FloorFrameTriangle,
		Window,
		Shutters,
		WallFrame,
		FloorFrame,
		WindowDressing,
		DoorDressing,
		Elevator,
		DoubleDoorDressing
	}

	public Type socketType;

	public int rotationDegrees;

	public int rotationOffset;

	public bool restrictPlacementRotation;

	public bool restrictPlacementAngle;

	public float faceAngle;

	public float angleAllowed = 150f;

	public bool wantsInside;

	[Range(0f, 1f)]
	public float support = 1f;

	private static readonly Vector3[] outsideLookupDirs = new Vector3[4]
	{
		new Vector3(0f, 1f, 0f).normalized,
		new Vector3(1f, 0f, 0f).normalized,
		new Vector3(0f, 0f, 1f).normalized,
		new Vector3(0f, 0f, -1f).normalized
	};

	private void OnDrawGizmos()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = Color.red;
		Gizmos.DrawLine(Vector3.zero, Vector3.forward * 0.6f);
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(Vector3.zero, Vector3.right * 0.1f);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(Vector3.zero, Vector3.up * 0.1f);
		Gizmos.DrawIcon(base.transform.position, "light_circle_green.png", allowScaling: false);
	}

	private void OnDrawGizmosSelected()
	{
		if (female)
		{
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawWireCube(selectCenter, selectSize);
		}
	}

	public override bool TestTarget(Construction.Target target)
	{
		if (!base.TestTarget(target))
		{
			return false;
		}
		return IsCompatible(target.socket);
	}

	public override bool IsCompatible(Socket_Base socket)
	{
		if (!base.IsCompatible(socket))
		{
			return false;
		}
		ConstructionSocket constructionSocket = socket as ConstructionSocket;
		if (constructionSocket == null)
		{
			return false;
		}
		if (constructionSocket.socketType == Type.None || socketType == Type.None)
		{
			return false;
		}
		if (constructionSocket.socketType != socketType)
		{
			return false;
		}
		return true;
	}

	public override bool CanConnect(Vector3 position, Quaternion rotation, Socket_Base socket, Vector3 socketPosition, Quaternion socketRotation)
	{
		if (!base.CanConnect(position, rotation, socket, socketPosition, socketRotation))
		{
			return false;
		}
		Matrix4x4 matrix4x = Matrix4x4.TRS(position, rotation, Vector3.one);
		Matrix4x4 matrix4x2 = Matrix4x4.TRS(socketPosition, socketRotation, Vector3.one);
		Vector3 a = matrix4x.MultiplyPoint3x4(worldPosition);
		Vector3 b = matrix4x2.MultiplyPoint3x4(socket.worldPosition);
		if (Vector3.Distance(a, b) > 0.02f)
		{
			return false;
		}
		Vector3 vector = matrix4x.MultiplyVector(worldRotation * Vector3.forward);
		Vector3 vector2 = matrix4x2.MultiplyVector(socket.worldRotation * Vector3.forward);
		float num = Vector3.Angle(vector, vector2);
		if (male && female)
		{
			num = Mathf.Min(num, Vector3.Angle(-vector, vector2));
		}
		if (socket.male && socket.female)
		{
			num = Mathf.Min(num, Vector3.Angle(vector, -vector2));
		}
		if (num > 2f)
		{
			return false;
		}
		return true;
	}

	public bool TestRestrictedAngles(Vector3 suggestedPos, Quaternion suggestedAng, Construction.Target target)
	{
		if (restrictPlacementAngle)
		{
			Quaternion quaternion = Quaternion.Euler(0f, faceAngle, 0f) * suggestedAng;
			float num = target.ray.direction.XZ3D().DotDegrees(quaternion * Vector3.forward);
			if (num > angleAllowed * 0.5f)
			{
				return false;
			}
			if (num < angleAllowed * -0.5f)
			{
				return false;
			}
		}
		return true;
	}

	public override Construction.Placement DoPlacement(Construction.Target target)
	{
		if (!target.entity || !target.entity.transform)
		{
			return default(Construction.Placement);
		}
		if (!CanConnectToEntity(target))
		{
			return default(Construction.Placement);
		}
		ConstructionSocket constructionSocket = target.socket as ConstructionSocket;
		Vector3 vector = target.GetWorldPosition();
		Quaternion quaternion = target.GetWorldRotation(female: true);
		if (constructionSocket != null && !IsCompatible(constructionSocket))
		{
			return default(Construction.Placement);
		}
		if (wantsInside)
		{
			Vector3 pos = target.entity.transform.position + localPosition + target.entity.transform.right * 0.2f;
			if (IsOutside(pos, target.entity.transform))
			{
				Construction.lastPlacementError = ConstructionErrors.WantsInside;
				return default(Construction.Placement);
			}
		}
		if (rotationDegrees > 0 && (constructionSocket == null || !constructionSocket.restrictPlacementRotation))
		{
			Construction.Placement placement = new Construction.Placement(target);
			float num = float.MaxValue;
			float num2 = 0f;
			for (int i = 0; i < 360; i += rotationDegrees)
			{
				Quaternion quaternion2 = Quaternion.Euler(0f, rotationOffset + i, 0f);
				Vector3 direction = target.ray.direction;
				Vector3 to = quaternion2 * quaternion * Vector3.up;
				float num3 = Vector3.Angle(direction, to);
				if (num3 < num)
				{
					num = num3;
					num2 = i;
				}
			}
			for (int j = 0; j < 360; j += rotationDegrees)
			{
				Quaternion quaternion3 = quaternion * Quaternion.Inverse(rotation);
				Quaternion quaternion4 = Quaternion.Euler(target.rotation);
				Quaternion quaternion5 = Quaternion.Euler(0f, (float)(rotationOffset + j) + num2, 0f);
				Quaternion quaternion6 = quaternion4 * quaternion5 * quaternion3;
				Vector3 vector2 = quaternion6 * position;
				placement.position = vector - vector2;
				placement.rotation = quaternion6;
				if (CheckSocketMods(ref placement))
				{
					return placement;
				}
			}
		}
		Construction.Placement result = new Construction.Placement(target);
		Quaternion quaternion7 = quaternion * Quaternion.Inverse(rotation);
		if (ShouldInheritFemaleSocketRotation(socketType))
		{
			Quaternion quaternion8 = Quaternion.Euler(target.rotation);
			quaternion7 *= quaternion8;
		}
		Vector3 vector3 = quaternion7 * position;
		result.position = vector - vector3;
		result.rotation = quaternion7;
		if (!TestRestrictedAngles(vector, quaternion, target))
		{
			return default(Construction.Placement);
		}
		return result;
	}

	protected virtual bool CanConnectToEntity(Construction.Target target)
	{
		return true;
	}

	private bool ShouldInheritFemaleSocketRotation(Type type)
	{
		if (type != Type.WallFrame && type != Type.Doorway && type != Type.FloorFrameTriangle && type != Type.FloorFrame)
		{
			return type == Type.Shutters;
		}
		return true;
	}

	public bool IsOutside(Vector3 pos, Transform tr)
	{
		float num = 5f;
		for (int i = 0; i < outsideLookupDirs.Length; i++)
		{
			Vector3 vector = tr.TransformDirection(outsideLookupDirs[i]);
			Vector3 origin = pos + vector * num;
			if (!Physics.Raycast(new Ray(origin, -vector), num - 0.5f, 2097152))
			{
				return true;
			}
		}
		return false;
	}
}
