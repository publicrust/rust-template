using TMPro;
using UnityEngine;

public class MenuTip : MonoBehaviour
{
	public TextMeshProUGUI text;

	public LoadingScreen screen;

	public static Translate.Phrase[] MenuTips = new Translate.Phrase[33]
	{
		new TokenisedPhrase("menutip_bag", "Don't forget to create a sleeping bag! You can pick which one to respawn at on the death screen."),
		new TokenisedPhrase("menutip_baggive", "You can give a sleeping bag to a steam friend."),
		new TokenisedPhrase("menutip_sneakanimal", "Some animals have blind spots. Sneak up from behind to get close enough to make the kill."),
		new TokenisedPhrase("menutip_humanmeat", "Human meat will severely dehydrate you."),
		new TokenisedPhrase("menutip_hammerpickup", "You can use the Hammer tool to pick up objects. Providing they are unlocked and/or opened."),
		new TokenisedPhrase("menutip_seedsun", "Ensure seeds are placed in full sunlight for faster growth."),
		new TokenisedPhrase("menutip_lakeriverdrink", "You can drink from lakes and rivers to recover a portion of your health."),
		new TokenisedPhrase("menutip_cookmeat", "Cook meat in a campfire to increase its healing abilities."),
		new TokenisedPhrase("menutip_rotatedeployables", "Rotate deployables before placing them by pressing [R]"),
		new TokenisedPhrase("menutip_repairblocked", "You cannot repair or upgrade building parts for 30 seconds after they've been damaged."),
		new TokenisedPhrase("menutip_hammerrepair", "Hit objects with your hammer to repair them, providing you have the necessary resources."),
		new TokenisedPhrase("menutip_altlook", "Hold [+altlook] to check your surroundings."),
		new TokenisedPhrase("menutip_upkeepwarning", "The larger you expand your base the more it'll cost to upkeep"),
		new TokenisedPhrase("menutip_report", "If you wish to report any in-game issues try pressing F7"),
		new TokenisedPhrase("menutip_radwash", "Submerge yourself in water and slosh around to remove radiation"),
		new TokenisedPhrase("menutip_switchammo", "Switch between ammo types by holding the [+reload] key"),
		new TokenisedPhrase("menutip_riverplants", "Edible plants are commonly found on river sides."),
		new TokenisedPhrase("menutip_buildwarnmonument", "Building near monuments may attract unwanted attention."),
		new TokenisedPhrase("menutip_vending", "Sell your unwanted items safely by crafting a vending machine."),
		new TokenisedPhrase("menutip_switchammo", "Switch between ammo types by holding the [+reload] key."),
		new TokenisedPhrase("menutip_oretip", "Stone and Ore Nodes are most commonly found around cliffs, mountains and other rock formations."),
		new TokenisedPhrase("menutip_crouchwalk", "Crouching allows you to move silently."),
		new TokenisedPhrase("menutip_accuracy", "Standing still or crouching while shooting increases accuracy."),
		new TokenisedPhrase("menutip_crashharvest", "You can harvest metal from helicopter and apc crash sites."),
		new TokenisedPhrase("menutip_canmelt", "You can melt Empty Cans in a campfire to receive Metal Fragments."),
		new TokenisedPhrase("menutip_stacksplit", "You can split a stack of items in half by holding [Middle Mouse] and dragging"),
		new TokenisedPhrase("menutip_divesite", "Floating Bottles on the ocean indicate a potential dive site, You may find treasure below"),
		new TokenisedPhrase("menutip_craftingqueue", "You can move crafting items to the front of the crafting queue by right clicking on the item in the crafting queue"),
		new TokenisedPhrase("menutip_thirdsplit", "You can split stacks of items into a third by holding Shift and [Middle Mouse] dragging"),
		new TokenisedPhrase("menutip_removeitemquickcraft", "You can cancel crafting an item by right clicking the item in the quick craft menu"),
		new TokenisedPhrase("menutip_quickcraftmulti", "[Middle Mouse] an item in quick craft menu will add 5x to your crafting queue"),
		new TokenisedPhrase("menutip_inputsplit", "You can split items by the exact amount by right clicking the split bar"),
		new TokenisedPhrase("menutip_gestures", "Cheer on your friends by pressing [+gestures] to open the gesture menu")
	};

	private int currentTipIndex;

	private float nextTipTime;

	public void OnEnable()
	{
		currentTipIndex = Random.Range(0, MenuTips.Length);
	}

	public void Update()
	{
		if (LoadingScreen.isOpen && Time.realtimeSinceStartup >= nextTipTime)
		{
			currentTipIndex++;
			if (currentTipIndex >= MenuTips.Length)
			{
				currentTipIndex = 0;
			}
			nextTipTime = Time.realtimeSinceStartup + 6f;
			UpdateTip();
		}
	}

	public void UpdateTip()
	{
		text.text = MenuTips[currentTipIndex].translated;
	}
}
