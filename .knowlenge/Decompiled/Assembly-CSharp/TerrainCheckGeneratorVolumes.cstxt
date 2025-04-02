using UnityEngine;

public class TerrainCheckGeneratorVolumes : MonoBehaviour, IEditorComponent
{
	public float PlacementRadius;

	public float PlacementOffset;

	protected void OnDrawGizmosSelected()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 1f);
		GizmosUtil.DrawWireCircleY(((Component)this).transform.position, PlacementRadius);
	}
}
