using Facepunch;
using UnityEngine;

public class UIPrefab : MonoBehaviour
{
	public GameObject prefabSource;

	internal GameObject createdGameObject;

	private void Awake()
	{
		if (!((Object)(object)prefabSource == (Object)null) && !((Object)(object)createdGameObject != (Object)null))
		{
			createdGameObject = Instantiate.GameObject(prefabSource, (Transform)null);
			((Object)createdGameObject).name = ((Object)prefabSource).name;
			createdGameObject.transform.SetParent(((Component)this).transform, false);
			createdGameObject.Identity();
		}
	}

	public void SetVisible(bool visible)
	{
		if (!((Object)(object)createdGameObject == (Object)null) && createdGameObject.activeSelf != visible)
		{
			createdGameObject.SetActive(visible);
		}
	}
}
