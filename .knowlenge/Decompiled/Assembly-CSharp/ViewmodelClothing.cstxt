using System.Linq;
using Facepunch;
using Rust.Workshop;
using UnityEngine;

public class ViewmodelClothing : MonoBehaviour
{
	public SkeletonSkin[] SkeletonSkins;

	internal void CopyToSkeleton(Skeleton skeleton, GameObject parent, Item item)
	{
		SkeletonSkin[] skeletonSkins = SkeletonSkins;
		foreach (SkeletonSkin obj in skeletonSkins)
		{
			GameObject gameObject = new GameObject();
			gameObject.transform.parent = parent.transform;
			obj.DuplicateAndRetarget(gameObject, skeleton).updateWhenOffscreen = true;
			if (item != null && item.skin != 0)
			{
				ItemSkinDirectory.Skin skin = item.info.skins.FirstOrDefault((ItemSkinDirectory.Skin x) => (ulong)x.id == item.skin);
				if (skin.id == 0 && item.skin != 0)
				{
					Rust.Workshop.WorkshopSkin.Apply(gameObject, item.skin);
					break;
				}
				if ((ulong)skin.id != item.skin)
				{
					break;
				}
				ItemSkin itemSkin = skin.invItem as ItemSkin;
				if (itemSkin == null)
				{
					break;
				}
				itemSkin.ApplySkin(gameObject);
			}
		}
	}
}
