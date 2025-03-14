using UnityEngine;

public class TweakUIBase : MonoBehaviour
{
	public string convarName = "effects.motionblur";

	public bool ApplyImmediatelyOnChange = true;

	internal ConsoleSystem.Command conVar;

	private void Awake()
	{
		Init();
	}

	protected virtual void Init()
	{
		conVar = ConsoleSystem.Index.Client.Find(convarName);
		if (conVar == null)
		{
			Debug.LogWarning("TweakUI Convar Missing: " + convarName, base.gameObject);
		}
	}

	public virtual void OnApplyClicked()
	{
		if (!ApplyImmediatelyOnChange)
		{
			SetConvarValue();
		}
	}

	public virtual void UnapplyChanges()
	{
		if (!ApplyImmediatelyOnChange)
		{
			ResetToConvar();
		}
	}

	public virtual void ResetToConvar()
	{
	}

	protected virtual void SetConvarValue()
	{
	}
}
