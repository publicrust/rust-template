using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class SelectedBlueprint : SingletonComponent<SelectedBlueprint>, IInventoryChanged
{
	public ItemBlueprint blueprint;

	public InputField craftAmountText;

	public GameObject ingredientGrid;

	public IconSkinPicker skinPicker;

	public Image iconImage;

	public RustText titleText;

	public RustText descriptionText;

	public CanvasGroup CraftArea;

	public Button CraftButton;

	public RustText CraftingTime;

	public RustText CraftingAmount;

	public GameObject TutorialCraftButtonHighlight;

	public Sprite FavouriteOnSprite;

	public Sprite FavouriteOffSprite;

	public Image FavouriteButtonStatusMarker;

	public GameObject[] workbenchReqs;

	private ItemInformationPanel[] informationPanels;

	public static bool isOpen
	{
		get
		{
			if (SingletonComponent<SelectedBlueprint>.Instance == null)
			{
				return false;
			}
			return SingletonComponent<SelectedBlueprint>.Instance.blueprint != null;
		}
	}
}
