using System.Collections.Generic;
using UnityEngine;

public class TechTreeDialog : UIDialog, IInventoryChanged
{
	public TechTreeData data;

	public float graphScale = 1f;

	public TechTreeEntry entryPrefab;

	public TechTreeGroup groupPrefab;

	public TechTreeLine linePrefab;

	public RectTransform contents;

	public RectTransform contentParent;

	public TechTreeSelectedNodeUI selectedNodeUI;

	public float nodeSize = 128f;

	public float gridSize = 64f;

	public GameObjectRef unlockEffect;

	private Vector2 startPos = Vector2.zero;

	public List<int> processed = new List<int>();

	public Dictionary<int, TechTreeWidget> widgets = new Dictionary<int, TechTreeWidget>();

	public List<TechTreeLine> lines = new List<TechTreeLine>();

	public ScrollRectZoom zoom;
}
