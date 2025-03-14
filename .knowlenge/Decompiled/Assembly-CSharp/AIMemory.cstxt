using UnityEngine;

public class AIMemory
{
	public AIMemoryBank<BaseEntity> Entity = new AIMemoryBank<BaseEntity>(MemoryBankType.Entity, 8);

	public AIMemoryBank<Vector3> Position = new AIMemoryBank<Vector3>(MemoryBankType.Position, 8);

	public AIMemoryBank<AIPoint> AIPoint = new AIMemoryBank<AIPoint>(MemoryBankType.AIPoint, 8);

	public void Clear()
	{
		Entity.Clear();
		Position.Clear();
		AIPoint.Clear();
	}
}
