using Rust;
using UnityEngine;

public class ItemModSound : ItemMod
{
	public enum Type
	{
		OnAttachToWeapon
	}

	public GameObjectRef effect = new GameObjectRef();

	public Type actionType;

	public override void OnParentChanged(Item item)
	{
		if (!Rust.Application.isLoadingSave && actionType == Type.OnAttachToWeapon && item.parentItem != null && item.parentItem.info.category == ItemCategory.Weapon)
		{
			BasePlayer ownerPlayer = item.parentItem.GetOwnerPlayer();
			if (!(ownerPlayer == null))
			{
				Effect.server.Run(effect.resourcePath, ownerPlayer, 0u, Vector3.zero, Vector3.zero);
			}
		}
	}
}
