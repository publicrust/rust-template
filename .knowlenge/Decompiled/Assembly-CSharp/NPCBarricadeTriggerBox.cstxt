using ConVar;
using UnityEngine;

public class NPCBarricadeTriggerBox : MonoBehaviour
{
	private Barricade target;

	private static int playerServerLayer = -1;

	public void Setup(Barricade t)
	{
		target = t;
		base.transform.SetParent(target.transform, worldPositionStays: false);
		base.gameObject.layer = 18;
		BoxCollider boxCollider = base.gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = true;
		boxCollider.center = Vector3.zero;
		boxCollider.size = Vector3.one * AI.npc_door_trigger_size + Vector3.right * target.bounds.size.x;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (target == null || target.isClient)
		{
			return;
		}
		if (playerServerLayer < 0)
		{
			playerServerLayer = LayerMask.NameToLayer("Player (Server)");
		}
		if ((other.gameObject.layer & playerServerLayer) > 0)
		{
			BasePlayer component = other.gameObject.GetComponent<BasePlayer>();
			if (component != null && component.IsNpc && !(component is BasePet))
			{
				target.Kill(BaseNetworkable.DestroyMode.Gib);
			}
		}
	}
}
