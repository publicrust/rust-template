using System.Collections.Generic;
using UnityEngine;

public class CullingVolume : MonoBehaviour, IClientComponent
{
	[Tooltip("Override occludee root from children of this object (default) to children of any other object.")]
	public GameObject OccludeeRoot;

	[Tooltip("Invert visibility. False will show occludes. True will hide them.")]
	public bool Invert;

	[Tooltip("A portal in the culling volume chain does not toggle objects visible, it merely signals the non-portal volumes to hide their occludees.")]
	public bool Portal;

	[Tooltip("Secondary culling volumes, connected to this one, that will get signaled when this trigger is activated.")]
	public List<CullingVolume> Connections = new List<CullingVolume>();
}
