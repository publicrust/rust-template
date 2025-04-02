using System;
using Facepunch.BurstCloth.Jobs;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__7727290552441277134
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobParallelForTransformExtensions.EarlyJobInit<InitializeBoneStateJob>();
			IJobParallelForTransformExtensions.EarlyJobInit<InitializeSphereColliderStateJob>();
			IJobExtensions.EarlyJobInit<SimulatePositionsJob>();
			IJobParallelForTransformExtensions.EarlyJobInit<UpdateSkinConstraintsJob>();
			IJobParallelForTransformExtensions.EarlyJobInit<UpdateTransformsJob>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex);
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		CreateJobReflectionData();
	}
}
