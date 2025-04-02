using UnityEngine;

public class AddToAlphaMap : ProceduralObject
{
	public Bounds bounds = new Bounds(Vector3.zero, Vector3.one);

	public override void Process()
	{
		OBB oBB = new OBB(base.transform, bounds);
		Vector3 point = oBB.GetPoint(-1f, 0f, -1f);
		Vector3 point2 = oBB.GetPoint(1f, 0f, -1f);
		Vector3 point3 = oBB.GetPoint(-1f, 0f, 1f);
		Vector3 point4 = oBB.GetPoint(1f, 0f, 1f);
		TerrainMeta.AlphaMap.ForEachParallel(point, point2, point3, point4, delegate(int x, int z)
		{
			TerrainMeta.AlphaMap.SetAlpha(x, z, 0f);
		});
		GameManager.Destroy(this);
	}
}
