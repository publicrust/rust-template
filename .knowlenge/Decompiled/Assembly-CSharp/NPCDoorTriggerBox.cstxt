using ConVar;
using UnityEngine;

public class NPCDoorTriggerBox : MonoBehaviour
{
	private Door door;

	private static int playerServerLayer = -1;

	public void Setup(Door d)
	{
		door = d;
		base.transform.SetParent(door.transform, worldPositionStays: false);
		base.gameObject.layer = 18;
		BoxCollider boxCollider = base.gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = true;
		boxCollider.center = Vector3.zero;
		boxCollider.size = Vector3.one * AI.npc_door_trigger_size;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (door == null || door.isClient || door.IsLocked() || (!door.isSecurityDoor && door.IsOpen()) || (door.isSecurityDoor && !door.IsOpen()))
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
			if (component != null && component.IsNpc && !door.isSecurityDoor)
			{
				door.SetOpen(open: true);
			}
		}
	}
}
