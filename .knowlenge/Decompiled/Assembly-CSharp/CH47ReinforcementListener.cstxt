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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		TryCall(heliPrefab.resourcePath, ((Component)this).transform.position, startDist);
	}

	public static bool TryCall(string resourcePath, Vector3 ourPos, float startDist)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		CH47HelicopterAIController component = ((Component)GameManager.server.CreateEntity(resourcePath)).GetComponent<CH47HelicopterAIController>();
		if (!Object.op_Implicit((Object)(object)component))
		{
			return false;
		}
		_ = TerrainMeta.Size;
		CH47LandingZone closest = CH47LandingZone.GetClosest(ourPos);
		if ((Object)(object)closest == (Object)null)
		{
			return false;
		}
		Vector3 zero = Vector3.zero;
		zero.y = ((Component)closest).transform.position.y;
		Vector3 val = Vector3Ex.Direction2D(((Component)closest).transform.position, zero);
		Vector3 position = ((Component)closest).transform.position + val * startDist;
		position.y = ((Component)closest).transform.position.y;
		((Component)component).transform.position = position;
		component.SetLandingTarget(((Component)closest).transform.position);
		component.Spawn();
		return true;
	}
}
