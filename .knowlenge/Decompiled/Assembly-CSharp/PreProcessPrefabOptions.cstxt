public struct PreProcessPrefabOptions
{
	public static readonly PreProcessPrefabOptions Default;

	public static readonly PreProcessPrefabOptions Default_NoResetPosition;

	public static readonly PreProcessPrefabOptions Scene2Scene;

	public static readonly PreProcessPrefabOptions Scene2Scene_Runtime;

	public bool ResetLocalTransform;

	public bool StripComponents;

	public bool StripEmptyChildren;

	public bool PreProcess;

	public bool PostProcess;

	public bool UpdateMeshCooking;

	static PreProcessPrefabOptions()
	{
		Default = new PreProcessPrefabOptions
		{
			ResetLocalTransform = true,
			StripComponents = true,
			StripEmptyChildren = true,
			PreProcess = true,
			PostProcess = true,
			UpdateMeshCooking = true
		};
		Scene2Scene = new PreProcessPrefabOptions
		{
			ResetLocalTransform = true,
			StripComponents = true,
			StripEmptyChildren = true,
			UpdateMeshCooking = true
		};
		Default_NoResetPosition = Default;
		Default_NoResetPosition.ResetLocalTransform = false;
		Scene2Scene_Runtime = Default;
	}
}
