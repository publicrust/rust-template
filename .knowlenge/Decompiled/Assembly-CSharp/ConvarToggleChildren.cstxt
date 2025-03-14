using UnityEngine;

public class ConvarToggleChildren : MonoBehaviour
{
	public string ConvarName;

	public string ConvarEnabled = "True";

	private bool state;

	private ConsoleSystem.Command Command;

	protected void Awake()
	{
		Command = ConsoleSystem.Index.Client.Find(ConvarName);
		if (Command == null)
		{
			Command = ConsoleSystem.Index.Server.Find(ConvarName);
		}
		if (Command != null)
		{
			SetState(Command.String == ConvarEnabled);
		}
	}

	protected void Update()
	{
		if (Command != null)
		{
			bool flag = Command.String == ConvarEnabled;
			if (state != flag)
			{
				SetState(flag);
			}
		}
	}

	private void SetState(bool newState)
	{
		foreach (Transform item in base.transform)
		{
			item.gameObject.SetActive(newState);
		}
		state = newState;
	}
}
