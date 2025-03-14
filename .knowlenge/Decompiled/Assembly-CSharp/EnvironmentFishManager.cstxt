using System;
using System.Collections.Generic;

public class EnvironmentFishManager : BaseMonoBehaviour, IClientComponent
{
	[Serializable]
	public class FishTypeInstance
	{
		public GameObjectRef prefab;

		public bool shouldSchool;

		public float populationScale;

		public bool freshwater;

		public bool seawater = true;

		public float minDepth = 3f;

		public float maxDepth = 100f;

		public List<EnvironmentFish> activeFish;

		public List<EnvironmentFish> sleeping;
	}

	public FishTypeInstance[] fishTypes;
}
