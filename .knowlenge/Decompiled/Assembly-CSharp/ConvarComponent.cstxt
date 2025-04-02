using System;
using System.Collections.Generic;
using Rust;
using UnityEngine;

public class ConvarComponent : MonoBehaviour
{
	[Serializable]
	public class ConvarEvent
	{
		public string convar;

		public string on;

		public MonoBehaviour component;

		internal Command cmd;

		public void OnEnable()
		{
			cmd = Client.Find(convar);
			if (cmd == null)
			{
				cmd = Server.Find(convar);
			}
			if (cmd != null)
			{
				cmd.OnValueChanged += cmd_OnValueChanged;
				cmd_OnValueChanged(cmd);
			}
		}

		private void cmd_OnValueChanged(Command obj)
		{
			if (!((Object)(object)component == (Object)null))
			{
				bool flag = obj.String == on;
				if (((Behaviour)component).enabled != flag)
				{
					((Behaviour)component).enabled = flag;
				}
			}
		}

		public void OnDisable()
		{
			if (!Application.isQuitting && cmd != null)
			{
				cmd.OnValueChanged -= cmd_OnValueChanged;
			}
		}
	}

	public bool runOnServer = true;

	public bool runOnClient = true;

	public List<ConvarEvent> List = new List<ConvarEvent>();

	protected void OnEnable()
	{
		if (!ShouldRun())
		{
			return;
		}
		foreach (ConvarEvent item in List)
		{
			item.OnEnable();
		}
	}

	protected void OnDisable()
	{
		if (Application.isQuitting || !ShouldRun())
		{
			return;
		}
		foreach (ConvarEvent item in List)
		{
			item.OnDisable();
		}
	}

	private bool ShouldRun()
	{
		if (!runOnServer)
		{
			return false;
		}
		return true;
	}
}
