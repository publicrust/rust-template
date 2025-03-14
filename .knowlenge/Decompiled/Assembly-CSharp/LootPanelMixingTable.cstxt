using UnityEngine;
using UnityEngine.UI;

public class LootPanelMixingTable : LootPanel, IInventoryChanged
{
	public GameObject controlsOn;

	public GameObject controlsOff;

	public Button StartMixingButton;

	public InfoBar ProgressBar;

	public GameObjectRef recipeItemPrefab;

	public RectTransform recipeContentRect;

	public ScrollRect ScrollView;

	public static readonly Translate.Phrase MixingPhrase = new Translate.Phrase("mixingtable.mixing", "Mixing... {0} seconds remaining");

	public static readonly Translate.Phrase CookingPhrase = new Translate.Phrase("cookingworkbench.cooking", "Cooking... {0} seconds remaining");
}
