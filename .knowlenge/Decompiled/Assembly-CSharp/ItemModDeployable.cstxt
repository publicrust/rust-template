using Oxide.Core;
using UnityEngine;

public class ItemModDeployable : MonoBehaviour
{
	public GameObjectRef entityPrefab = new GameObjectRef();

	[Header("Tooltips")]
	public bool showCrosshair;

	public string UnlockAchievement;

	public Deployable GetDeployable(BaseEntity entity)
	{
		if (entity.gameManager.FindPrefab(entityPrefab.resourcePath) == null)
		{
			return null;
		}
		return entity.prefabAttribute.Find<Deployable>(entityPrefab.resourceID);
	}

	internal void OnDeployed(BaseEntity ent, BasePlayer player)
	{
		if (player.IsValid() && !string.IsNullOrEmpty(UnlockAchievement))
		{
			player.GiveAchievement(UnlockAchievement);
		}
		if (ent is BuildingPrivlidge buildingPrivlidge && Interface.CallHook("OnCupboardAuthorize", buildingPrivlidge, player) == null)
		{
			buildingPrivlidge.AddPlayer(player, player.userID);
		}
	}
}
