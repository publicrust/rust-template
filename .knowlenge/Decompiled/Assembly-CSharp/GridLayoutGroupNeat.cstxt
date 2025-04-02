using UnityEngine;
using UnityEngine.UI;

public class GridLayoutGroupNeat : GridLayoutGroup
{
	private float IdealCellWidth(float cellSize)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		Rect rect = ((LayoutGroup)this).rectTransform.rect;
		float num = ((Rect)(ref rect)).x + (float)(((LayoutGroup)this).padding.left + ((LayoutGroup)this).padding.right) * 0.5f;
		float num2 = Mathf.Floor(num / cellSize);
		return num / num2 - base.m_Spacing.x;
	}

	public override void SetLayoutHorizontal()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		Vector2 cellSize = base.m_CellSize;
		base.m_CellSize.x = IdealCellWidth(cellSize.x);
		((GridLayoutGroup)this).SetLayoutHorizontal();
		base.m_CellSize = cellSize;
	}

	public override void SetLayoutVertical()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		Vector2 cellSize = base.m_CellSize;
		base.m_CellSize.x = IdealCellWidth(cellSize.x);
		((GridLayoutGroup)this).SetLayoutVertical();
		base.m_CellSize = cellSize;
	}
}
