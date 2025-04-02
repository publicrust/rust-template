using UnityEngine;

public class DisableSave : MonoBehaviour
{
	private void OnValidate()
	{
		BaseEntity component = GetComponent<BaseEntity>();
		if (component != null)
		{
			Debug.LogWarning("DisableSave is attached to a GameObject but can't find entity");
		}
		else if (component.enableSaving)
		{
			Debug.LogError("BaseEntity.enableSaving must be disabled for the DisableSave component to work");
		}
	}
}
