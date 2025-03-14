using UnityEngine;

public class HLODBounds : MonoBehaviour, IEditorComponent
{
	[Tooltip("The bounds that this HLOD will cover. This should not overlap with any other HLODs")]
	public Bounds MeshBounds = new Bounds(Vector3.zero, new Vector3(50f, 25f, 50f));

	[Tooltip("Assets created will use this prefix. Make sure multiple HLODS in a scene have different prefixes")]
	public string MeshPrefix = "root";

	[Tooltip("The point from which to calculate the HLOD. Any RendererLODs that are visible at this distance will baked into the HLOD mesh")]
	public float CullDistance = 100f;

	[Tooltip("If set, the lod will take over at this distance instead of the CullDistance (eg. we make a model based on what this area looks like at 200m but we actually want it take over rendering at 300m)")]
	public float OverrideLodDistance;

	[Tooltip("Any renderers below this height will considered culled even if they are visible from a distance. Good for underground areas")]
	public float CullBelowHeight;

	[Tooltip("Optimises the mesh produced by removing non-visible and small faces. Can turn it off during dev but should be on for final builds")]
	public bool ApplyMeshTrimming = true;

	public MeshTrimSettings Settings = MeshTrimSettings.Default;

	public LODComponent DebugComponent;

	public bool ShowTrimSettings;

	[Tooltip("Prints out information about what the baker is doing, helpful for diagnosing errors")]
	public bool DebugMode;
}
