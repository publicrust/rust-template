using EZhex1991.EZSoftBone;
using UnityEngine;

public class GhostSheetSystemSpaceUpdater : MonoBehaviour, IClientComponent
{
	private EZSoftBone[] ezSoftBones;

	private BasePlayer player;

	public void Awake()
	{
		ezSoftBones = GetComponents<EZSoftBone>();
		player = GameObjectEx.ToBaseEntity(base.gameObject) as BasePlayer;
	}

	public void Update()
	{
		if (ezSoftBones == null || ezSoftBones.Length == 0 || player == null)
		{
			return;
		}
		BaseMountable mounted = player.GetMounted();
		if (mounted != null)
		{
			SetSimulateSpace(mounted.transform, collisionEnabled: false);
			return;
		}
		BaseEntity parentEntity = player.GetParentEntity();
		if (parentEntity != null)
		{
			SetSimulateSpace(parentEntity.transform, collisionEnabled: true);
		}
		else
		{
			SetSimulateSpace(null, collisionEnabled: true);
		}
	}

	private void SetSimulateSpace(Transform transform, bool collisionEnabled)
	{
		for (int i = 0; i < ezSoftBones.Length; i++)
		{
			EZSoftBone obj = ezSoftBones[i];
			obj.simulateSpace = transform;
			obj.collisionEnabled = collisionEnabled;
		}
	}
}
