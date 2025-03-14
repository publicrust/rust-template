using UnityEngine;
using UnityEngine.UI;

public class GridLayoutGroupNeat : GridLayoutGroup
{
	private float IdealCellWidth(float cellSize)
	{
		float num = base.rectTransform.rect.x + (float)(base.padding.left + base.padding.right) * 0.5f;
		float num2 = Mathf.Floor(num / cellSize);
		return num / num2 - m_Spacing.x;
	}

	public override void SetLayoutHorizontal()
	{
		Vector2 vector = m_CellSize;
		m_CellSize.x = IdealCellWidth(vector.x);
		base.SetLayoutHorizontal();
		m_CellSize = vector;
	}

	public override void SetLayoutVertical()
	{
		Vector2 vector = m_CellSize;
		m_CellSize.x = IdealCellWidth(vector.x);
		base.SetLayoutVertical();
		m_CellSize = vector;
	}
}
