using UnityEngine;

public class DungeonConditionalModel : MonoBehaviour
{
	public MapLayer Layer;

	private void Start()
	{
		foreach (Transform child in TransformEx.GetChildren(base.transform))
		{
			child.gameObject.SetActive(!World.Config.BelowGroundRails);
		}
	}
}
