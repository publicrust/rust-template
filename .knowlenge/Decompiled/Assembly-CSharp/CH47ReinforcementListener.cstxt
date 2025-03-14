using UnityEngine;

public class CH47ReinforcementListener : BaseEntity
{
	public string listenString;

	public GameObjectRef heliPrefab;

	public float startDist = 300f;

	public override void OnEntityMessage(BaseEntity from, string msg)
	{
		if (msg == listenString)
		{
			Call();
		}
	}

	public void Call()
	{
		CH47HelicopterAIController component = GameManager.server.CreateEntity(heliPrefab.resourcePath).GetComponent<CH47HelicopterAIController>();
		if ((bool)component)
		{
			_ = TerrainMeta.Size;
			CH47LandingZone closest = CH47LandingZone.GetClosest(base.transform.position);
			Vector3 zero = Vector3.zero;
			zero.y = closest.transform.position.y;
			Vector3 vector = Vector3Ex.Direction2D(closest.transform.position, zero);
			Vector3 position = closest.transform.position + vector * startDist;
			position.y = closest.transform.position.y;
			component.transform.position = position;
			component.SetLandingTarget(closest.transform.position);
			component.Spawn();
		}
	}
}
