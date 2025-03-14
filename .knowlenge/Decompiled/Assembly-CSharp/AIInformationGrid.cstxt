using UnityEngine;

public class AIInformationGrid : MonoBehaviour
{
	public int CellSize = 10;

	public Bounds BoundingBox;

	public AIInformationCell[] Cells;

	private Vector3 origin;

	private int xCellCount;

	private int zCellCount;

	private const int maxPointResults = 2048;

	private AIMovePoint[] movePointResults = new AIMovePoint[2048];

	private AICoverPoint[] coverPointResults = new AICoverPoint[2048];

	private const int maxCellResults = 512;

	private AIInformationCell[] resultCells = new AIInformationCell[512];

	[ContextMenu("Init")]
	public void Init()
	{
		AIInformationZone component = GetComponent<AIInformationZone>();
		if (component == null)
		{
			Debug.LogWarning("Unable to Init AIInformationGrid, no AIInformationZone found!");
			return;
		}
		BoundingBox = component.bounds;
		BoundingBox.center = base.transform.position + component.bounds.center + new Vector3(0f, BoundingBox.extents.y, 0f);
		float num = BoundingBox.extents.x * 2f;
		float num2 = BoundingBox.extents.z * 2f;
		xCellCount = (int)Mathf.Ceil(num / (float)CellSize);
		zCellCount = (int)Mathf.Ceil(num2 / (float)CellSize);
		Cells = new AIInformationCell[xCellCount * zCellCount];
		Vector3 vector = (origin = BoundingBox.min);
		vector.x = BoundingBox.min.x + (float)CellSize / 2f;
		vector.z = BoundingBox.min.z + (float)CellSize / 2f;
		for (int i = 0; i < zCellCount; i++)
		{
			for (int j = 0; j < xCellCount; j++)
			{
				Vector3 center = vector;
				Bounds bounds = new Bounds(center, new Vector3(CellSize, BoundingBox.extents.y * 2f, CellSize));
				Cells[GetIndex(j, i)] = new AIInformationCell(bounds, base.gameObject, j, i);
				vector.x += CellSize;
			}
			vector.x = BoundingBox.min.x + (float)CellSize / 2f;
			vector.z += CellSize;
		}
	}

	private int GetIndex(int x, int z)
	{
		return z * xCellCount + x;
	}

	public AIInformationCell CellAt(int x, int z)
	{
		return Cells[GetIndex(x, z)];
	}

	public AIMovePoint[] GetMovePointsInRange(Vector3 position, float maxRange, out int pointCount)
	{
		pointCount = 0;
		int cellCount;
		AIInformationCell[] cellsInRange = GetCellsInRange(position, maxRange, out cellCount);
		if (cellCount > 0)
		{
			for (int i = 0; i < cellCount; i++)
			{
				if (cellsInRange[i] == null)
				{
					continue;
				}
				foreach (AIMovePoint item in cellsInRange[i].MovePoints.Items)
				{
					movePointResults[pointCount] = item;
					pointCount++;
				}
			}
		}
		return movePointResults;
	}

	public AICoverPoint[] GetCoverPointsInRange(Vector3 position, float maxRange, out int pointCount)
	{
		pointCount = 0;
		int cellCount;
		AIInformationCell[] cellsInRange = GetCellsInRange(position, maxRange, out cellCount);
		if (cellCount > 0)
		{
			for (int i = 0; i < cellCount; i++)
			{
				if (cellsInRange[i] == null)
				{
					continue;
				}
				foreach (AICoverPoint item in cellsInRange[i].CoverPoints.Items)
				{
					coverPointResults[pointCount] = item;
					pointCount++;
				}
			}
		}
		return coverPointResults;
	}

	public AIInformationCell[] GetCellsInRange(Vector3 position, float maxRange, out int cellCount)
	{
		cellCount = 0;
		int num = (int)(maxRange / (float)CellSize);
		AIInformationCell cell = GetCell(position);
		if (cell == null)
		{
			return resultCells;
		}
		int num2 = Mathf.Max(cell.X - num, 0);
		int num3 = Mathf.Min(cell.X + num, xCellCount - 1);
		int num4 = Mathf.Max(cell.Z - num, 0);
		int num5 = Mathf.Min(cell.Z + num, zCellCount - 1);
		for (int i = num4; i <= num5; i++)
		{
			for (int j = num2; j <= num3; j++)
			{
				resultCells[cellCount] = CellAt(j, i);
				cellCount++;
				if (cellCount >= 512)
				{
					return resultCells;
				}
			}
		}
		return resultCells;
	}

	public AIInformationCell GetCell(Vector3 position)
	{
		if (Cells == null)
		{
			return null;
		}
		Vector3 vector = position - origin;
		if (vector.x < 0f || vector.z < 0f)
		{
			return null;
		}
		int num = (int)(vector.x / (float)CellSize);
		int num2 = (int)(vector.z / (float)CellSize);
		if (num < 0 || num >= xCellCount)
		{
			return null;
		}
		if (num2 < 0 || num2 >= zCellCount)
		{
			return null;
		}
		return CellAt(num, num2);
	}

	public void OnDrawGizmos()
	{
		DebugDraw();
	}

	public void DebugDraw()
	{
		if (Cells != null)
		{
			AIInformationCell[] cells = Cells;
			for (int i = 0; i < cells.Length; i++)
			{
				cells[i]?.DebugDraw(Color.white, points: false);
			}
		}
	}
}
