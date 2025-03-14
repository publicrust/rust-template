#define UNITY_ASSERTIONS
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(menuName = "Rust/Convar Controlled Spawn Population")]
public class ConvarControlledSpawnPopulation : DensitySpawnPopulation
{
	[Header("Convars")]
	public string PopulationConvar;

	private ConsoleSystem.Command _command;

	protected ConsoleSystem.Command Command
	{
		get
		{
			if (_command == null)
			{
				_command = ConsoleSystem.Index.Server.Find(PopulationConvar);
				Assert.IsNotNull(_command, $"{this} has missing convar {PopulationConvar}");
			}
			return _command;
		}
	}

	public override float TargetDensity => Command.AsFloat;
}
