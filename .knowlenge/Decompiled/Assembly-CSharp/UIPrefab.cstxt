using Facepunch;
using UnityEngine;

public class UIPrefab : MonoBehaviour
{
	public GameObject prefabSource;

	internal GameObject createdGameObject;

	private void Awake()
	{
		if (!(prefabSource == null) && !(createdGameObject != null))
		{
			createdGameObject = Facepunch.Instantiate.GameObject(prefabSource);
			createdGameObject.name = prefabSource.name;
			createdGameObject.transform.SetParent(base.transform, worldPositionStays: false);
			TransformEx.Identity(createdGameObject);
		}
	}

	public void SetVisible(bool visible)
	{
		if (!(createdGameObject == null) && createdGameObject.activeSelf != visible)
		{
			createdGameObject.SetActive(visible);
		}
	}
}
