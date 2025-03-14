using Rust.UI;
using UnityEngine;

public class TechTreeDialog : UIDialog, IInventoryChanged
{
	private const string techTreeLevelPrefKey = "techTreeLevel";

	private TechTreeData[] dataOptions;

	public float graphScale = 1f;

	public RustButton[] tierButtons;

	public GameObjectRef entryPrefab;

	public GameObjectRef groupPrefab;

	public GameObjectRef linePrefab;

	public RectTransform contents;

	public RectTransform contentParent;

	public TechTreeSelectedNodeUI selectedNodeUI;

	public float nodeSize = 128f;

	public float gridSize = 64f;

	public GameObjectRef unlockEffect;

	public RustText scrapCount;

	private Vector2 startPos = Vector2.zero;

	public ScrollRectZoom zoom;

	public TechTreeData data
	{
		get
		{
			if (dataOptions == null)
			{
				return null;
			}
			return dataOptions[selectedDataIndex];
		}
	}

	private int selectedDataIndex
	{
		get
		{
			return PlayerPrefs.GetInt("techTreeLevel", 0);
		}
		set
		{
			PlayerPrefs.SetInt("techTreeLevel", value);
		}
	}
}
