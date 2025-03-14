using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Scriptable Object/Workshop Skin Meta", fileName = "meta.asset")]
public class WorkshopSkinBase : WorkshopBase
{
	public enum SkinType
	{
		TShirt,
		Pants,
		SleepingBag,
		Hoodie,
		LongTShirt,
		Cap,
		Beenie,
		Boots,
		Jacket,
		Balaclava,
		Boonie,
		SnowJacket,
		Bandana,
		AK47,
		BoltRifle,
		Revolver,
		Rock,
		Hammer,
		PipeShotgun,
		PumpShotgun,
		SemiAutoPistol,
		Thompson,
		WoodStorage,
		BucketHat,
		BurlapGloves,
		BurlapPants,
		BurlapShirt
	}

	public static string[] itemName = new string[27]
	{
		"tshirt", "pants", "sleepingbag", "hoodie", "tshirt.long", "hat.cap", "hat.beenie", "shoes.boots", "jacket", "mask.balaclava",
		"hat.boonie", "jacket.snow", "mask.bandana", "rifle.ak", "rifle.bolt", "pistol.revolver", "rock", "hammer", "shotgun.waterpipe", "shotgun.pump",
		"pistol.semiauto", "smg.thompson", "box.wooden.large", "bucket.helmet", "burlap.gloves", "burlap.trousers", "burlap.shirt"
	};

	[Header("Skin Setup")]
	public SkinType skinType;

	[FormerlySerializedAs("skinMaterial")]
	public Material skinMaterial0;

	public Material skinMaterial1;

	public Material skinMaterial2;

	public Material skinMaterial3;
}
