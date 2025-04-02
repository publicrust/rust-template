using System;
using UnityEngine;

public class TowConfig : PrefabAttribute
{
	[Serializable]
	public struct Configuration
	{
		public Vector2 AngularLimitsX;

		public float AngularLimitY;

		public float AngularLimitZ;
	}

	private static readonly Configuration DefaultConfig = new Configuration
	{
		AngularLimitsX = new Vector2(-80f, 80f),
		AngularLimitY = 60f,
		AngularLimitZ = 55f
	};

	public Configuration Config = DefaultConfig;

	protected override Type GetIndexedType()
	{
		return typeof(TowConfig);
	}

	public Configuration Combine(TowConfig other)
	{
		Configuration result = default(Configuration);
		Configuration config = other.Config;
		result.AngularLimitsX = new Vector2(Mathf.Max(Config.AngularLimitsX.x, config.AngularLimitsX.x), Mathf.Min(Config.AngularLimitsX.y, config.AngularLimitsX.y));
		result.AngularLimitY = Mathf.Min(Config.AngularLimitY, config.AngularLimitY);
		result.AngularLimitZ = Mathf.Min(Config.AngularLimitZ, config.AngularLimitZ);
		return result;
	}
}
