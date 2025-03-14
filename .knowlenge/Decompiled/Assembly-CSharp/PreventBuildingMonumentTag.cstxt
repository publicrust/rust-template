using UnityEngine;

public class PreventBuildingMonumentTag : MonoBehaviour
{
	public bool autoFindMonument;

	[SerializeField]
	private MonumentInfo AttachedMonument;

	public MonumentInfo GetAttachedMonument()
	{
		if (autoFindMonument && AttachedMonument == null)
		{
			MonumentInfo attachedMonument = TerrainMeta.Path.FindClosest(TerrainMeta.Path.Monuments, base.transform.position);
			AttachedMonument = attachedMonument;
		}
		return AttachedMonument;
	}

	public void SetMonument(MonumentInfo monument)
	{
		AttachedMonument = monument;
	}
}
