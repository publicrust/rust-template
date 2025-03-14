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
		TryCall(heliPrefab.resourcePath, base.transform.position, startDist);
	}

	public static bool TryCall(string resourcePath, Vector3 ourPos, float startDist)
	{
		CH47HelicopterAIController component = GameManager.server.CreateEntity(resourcePath).GetComponent<CH47HelicopterAIController>();
		if (!component)
		{
			return false;
		}
		_ = TerrainMeta.Size;
		CH47LandingZone closest = CH47LandingZone.GetClosest(ourPos);
		if (closest == null)
		{
			return false;
		}
		Vector3 zero = Vector3.zero;
		zero.y = closest.transform.position.y;
		Vector3 vector = Vector3Ex.Direction2D(closest.transform.position, zero);
		Vector3 position = closest.transform.position + vector * startDist;
		position.y = closest.transform.position.y;
		component.transform.position = position;
		component.SetLandingTarget(closest.transform.position);
		component.Spawn();
		return true;
	}
}
