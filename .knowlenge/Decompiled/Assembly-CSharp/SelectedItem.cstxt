using System.Collections.Generic;
using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class SelectedItem : SingletonComponent<SelectedItem>, IInventoryChanged
{
	public static readonly Translate.Phrase DropTitle = new Translate.Phrase("drop", "Drop");

	public static readonly Translate.Phrase DropDesc = new Translate.Phrase("drop_desc");

	public Image icon;

	public Image iconSplitter;

	public RustText title;

	public RustText description;

	public GameObject splitPanel;

	public GameObject itemProtection;

	public GameObject OwnershipContainer;

	public ItemOwnershipPanel OwnershipItem;

	private List<ItemOwnershipPanel> ownershipPanels = new List<ItemOwnershipPanel>();

	public GameObject menuOption;

	public GameObject optionsParent;

	public GameObject innerPanelContainer;
}
