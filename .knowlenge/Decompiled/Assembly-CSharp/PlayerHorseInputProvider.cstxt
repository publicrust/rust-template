public class PlayerHorseInputProvider : IHorseInputProvider
{
	public BasePlayer player;

	public PlayerHorseInputProvider(BasePlayer player)
	{
		this.player = player;
	}

	public float GetMoveInput()
	{
		float result = 0f;
		if (player.serverInput.IsDown(BUTTON.FORWARD))
		{
			result = 1f;
		}
		else if (player.serverInput.IsDown(BUTTON.BACKWARD))
		{
			result = -1f;
		}
		return result;
	}

	public float GetSteerInput()
	{
		float result = 0f;
		if (player.serverInput.IsDown(BUTTON.LEFT))
		{
			result = -1f;
		}
		else if (player.serverInput.IsDown(BUTTON.RIGHT))
		{
			result = 1f;
		}
		return result;
	}
}
