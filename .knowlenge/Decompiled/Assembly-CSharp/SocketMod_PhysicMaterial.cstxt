using UnityEngine;

public class SocketMod_PhysicMaterial : SocketMod
{
	public PhysicMaterial[] ValidMaterials;

	private PhysicMaterial foundMaterial;

	public override bool DoCheck(Construction.Placement place)
	{
		if (Physics.Raycast(place.position + place.rotation.eulerAngles.normalized * 0.5f, -place.rotation.eulerAngles.normalized, out var hitInfo, 1f, 161546240, QueryTriggerInteraction.Ignore))
		{
			foundMaterial = ColliderEx.GetMaterialAt(hitInfo.collider, hitInfo.point);
			PhysicMaterial[] validMaterials = ValidMaterials;
			for (int i = 0; i < validMaterials.Length; i++)
			{
				if (validMaterials[i] == foundMaterial)
				{
					return true;
				}
			}
		}
		return false;
	}
}
