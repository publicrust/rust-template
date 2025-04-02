using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(menuName = "Rust/Convar Controlled Spawn Population")]
public class ConvarControlledSpawnPopulation : DensitySpawnPopulation
{
	[Header("Convars")]
	public string PopulationConvar;

	private Command _command;

	protected Command Command
	{
		get
		{
			if (_command == null)
			{
				_command = Server.Find(PopulationConvar);
				Assert.IsNotNull<Command>(_command, $"{this} has missing convar {PopulationConvar}");
			}
			return _command;
		}
	}

	public override float TargetDensity => Command.AsFloat;
}
