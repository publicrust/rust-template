using UnityEngine;

public class PreventBuildingMonumentTag : MonoBehaviour
{
	public bool autoFindMonument;

	[SerializeField]
	private MonumentInfo AttachedMonument;

	public MonumentInfo GetAttachedMonument()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (autoFindMonument && (Object)(object)AttachedMonument == (Object)null)
		{
			MonumentInfo attachedMonument = TerrainMeta.Path.FindClosest(TerrainMeta.Path.Monuments, ((Component)this).transform.position);
			AttachedMonument = attachedMonument;
		}
		return AttachedMonument;
	}

	public void SetMonument(MonumentInfo monument)
	{
		AttachedMonument = monument;
	}
}
