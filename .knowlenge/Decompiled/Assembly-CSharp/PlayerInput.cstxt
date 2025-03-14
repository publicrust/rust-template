using System;
using Rust;

public class PlayerInput : EntityComponent<BasePlayer>
{
	public InputState state = new InputState();

	[NonSerialized]
	public bool hadInputBuffer = true;

	protected void OnDisable()
	{
		if (!Application.isQuitting)
		{
			state.Clear();
		}
	}
}
