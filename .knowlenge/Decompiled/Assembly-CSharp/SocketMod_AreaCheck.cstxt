using UnityEngine;

public class SocketMod_AreaCheck : SocketMod
{
	public Bounds bounds = new Bounds(Vector3.zero, Vector3.one * 0.1f);

	public LayerMask layerMask;

	public bool wantsInside = true;

	private Translate.Phrase lastError = new Translate.Phrase();

	protected override Translate.Phrase ErrorPhrase => lastError;

	public static bool IsInArea(Vector3 position, Quaternion rotation, Bounds bounds, LayerMask layerMask, BaseEntity entity = null)
	{
		return GamePhysics.CheckOBBAndEntity(new OBB(position, rotation, bounds), layerMask.value, QueryTriggerInteraction.UseGlobal, entity);
	}

	public bool DoCheck(Vector3 position, Quaternion rotation, BaseEntity entity = null)
	{
		Vector3 position2 = position + rotation * worldPosition;
		Quaternion rotation2 = rotation * worldRotation;
		return IsInArea(position2, rotation2, bounds, layerMask, entity) == wantsInside;
	}

	public override bool DoCheck(Construction.Placement place)
	{
		bool flag = DoCheck(place.position, place.rotation);
		if (!flag)
		{
			lastError = ConstructionErrors.NotStableEnough;
			if ((int)layerMask == 2097152 || (int)layerMask == 136314880)
			{
				lastError = (wantsInside ? ConstructionErrors.MustPlaceOnConstruction : ConstructionErrors.CantPlaceOnConstruction);
			}
		}
		else if (wantsInside && ((int)layerMask & 0x8000000) == 0)
		{
			flag = !GamePhysics.CheckSphere(place.position, 5f, 134217728);
			if (!flag)
			{
				lastError = ConstructionErrors.InvalidAreaVehicleLarge;
			}
		}
		if (flag)
		{
			return true;
		}
		return false;
	}
}
