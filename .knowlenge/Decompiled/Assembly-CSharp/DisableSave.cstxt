using UnityEngine;

public class DisableSave : MonoBehaviour
{
	private void OnValidate()
	{
		BaseEntity component = ((Component)this).GetComponent<BaseEntity>();
		if ((Object)(object)component != (Object)null)
		{
			Debug.LogWarning((object)"DisableSave is attached to a GameObject but can't find entity");
		}
		else if (component.enableSaving)
		{
			Debug.LogError((object)"BaseEntity.enableSaving must be disabled for the DisableSave component to work");
		}
	}
}
