using UnityEngine;

public class SocketMod_InWater : SocketMod
{
	public bool wantsInWater = true;

	public static Translate.Phrase WantsWaterPhrase = new Translate.Phrase("error_inwater_wants", "Must be placed in water");

	public static Translate.Phrase NoWaterPhrase = new Translate.Phrase("error_inwater", "Can't be placed in water");

	private void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = Color.cyan;
		Gizmos.DrawSphere(Vector3.zero, 0.1f);
	}

	public override bool DoCheck(Construction.Placement place)
	{
		Vector3 vector = place.position + place.rotation * worldPosition;
		bool flag = WaterLevel.Test(vector);
		if (!flag && wantsInWater && GamePhysics.CheckSphere(vector, 0.1f, 16))
		{
			flag = true;
		}
		if (flag == wantsInWater)
		{
			return true;
		}
		if (wantsInWater)
		{
			Construction.lastPlacementError = WantsWaterPhrase.translated;
		}
		else
		{
			Construction.lastPlacementError = NoWaterPhrase.translated;
		}
		return false;
	}
}
