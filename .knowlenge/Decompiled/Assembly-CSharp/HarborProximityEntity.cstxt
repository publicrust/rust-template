using UnityEngine;

public class HarborProximityEntity : BaseEntity
{
	public bool SupportChildDeployables;

	private static ListHashSet<HarborProximityEntity> harborEntities = new ListHashSet<HarborProximityEntity>();

	public override void ServerInit()
	{
		base.ServerInit();
		harborEntities.Add(this);
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		harborEntities.Remove(this);
	}

	public static HarborProximityEntity GetEntity(Vector3 worldPos)
	{
		foreach (HarborProximityEntity harborEntity in harborEntities)
		{
			if (Vector3.Distance(harborEntity.transform.position.WithY(worldPos.y), worldPos) < 3f)
			{
				return harborEntity;
			}
		}
		return null;
	}

	public override bool SupportsChildDeployables()
	{
		return SupportChildDeployables;
	}
}
