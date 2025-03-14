using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	public GameObject ContactsButton;

	private void Update()
	{
		if (ContactsButton != null && RelationshipManager.contacts != ContactsButton.activeSelf)
		{
			ContactsButton.SetActive(RelationshipManager.contacts);
		}
	}
}
