public class BaseSaddle : BaseMountable
{
	public BaseRidableAnimal animal;

	public override void PlayerServerInput(InputState inputState, BasePlayer player)
	{
		if (!(player != _mounted) && (bool)animal)
		{
			animal.RiderInput(inputState, player);
		}
	}

	public void SetAnimal(BaseRidableAnimal newAnimal)
	{
		animal = newAnimal;
	}
}
