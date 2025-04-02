using System;
using System.Collections.Generic;
using UnityEngine;

public class SeekerTarget
{
	public enum SeekerStrength
	{
		OFF = 0,
		LOW = 100,
		MEDIUM = 200,
		HIGH = 1000,
		HIGHEST = 1000
	}

	public interface ISeekerTargetOwner
	{
		Vector3 CenterPoint();

		bool InSafeZone();

		bool IsValidHomingTarget();

		bool IsVisible(Vector3 position, float maxDistance = float.PositiveInfinity);

		void OnEntityMessage(BaseEntity from, string msg);
	}

	[NonSerialized]
	public SeekerStrength strength;

	public ISeekerTargetOwner owner;

	private static Dictionary<ISeekerTargetOwner, SeekerTarget> seekerTargets = new Dictionary<ISeekerTargetOwner, SeekerTarget>();

	public bool IsValidTarget()
	{
		if (owner.IsUnityNull())
		{
			return false;
		}
		if (!owner.InSafeZone())
		{
			return owner.IsValidHomingTarget();
		}
		return false;
	}

	public bool TryGetPosition(out Vector3 result)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		if (owner.IsUnityNull())
		{
			result = Vector3.zero;
			return false;
		}
		result = owner.CenterPoint();
		return true;
	}

	public void SendOwnerMessage(BaseEntity from, string message)
	{
		if (!owner.IsUnityNull())
		{
			owner.OnEntityMessage(from, message);
		}
	}

	public static SeekerTarget GetBestForPoint(Vector3 from, Vector3 forward, float maxCone, float maxDist, SeekerStrength minStrength = SeekerStrength.LOW)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		SeekerTarget result = null;
		float num = 0f;
		foreach (KeyValuePair<ISeekerTargetOwner, SeekerTarget> seekerTarget in seekerTargets)
		{
			ISeekerTargetOwner key = seekerTarget.Key;
			SeekerTarget value = seekerTarget.Value;
			if (value.strength < minStrength || !value.IsValidTarget() || !value.TryGetPosition(out var result2))
			{
				continue;
			}
			Vector3 val = Vector3Ex.Direction(result2, from);
			float num2 = Vector3.Dot(forward, val);
			float num3 = Vector3.Distance(result2, from);
			if (num3 < maxDist && num2 > maxCone)
			{
				float num4 = 1f - num3 / maxDist * 0.3f;
				float num5 = num2 / maxCone * 1f;
				float num6 = (float)value.strength / 1000f * 0.5f;
				float num7 = num4 + num5 + num6;
				if (num7 > num && key.IsVisible(from, maxDist))
				{
					result = value;
					num = num7;
				}
			}
		}
		return result;
	}

	public static void SetSeekerTarget(ISeekerTargetOwner toAdd, SeekerStrength strength)
	{
		if (strength == SeekerStrength.OFF)
		{
			if (seekerTargets.ContainsKey(toAdd))
			{
				seekerTargets.Remove(toAdd);
			}
		}
		else if (!seekerTargets.ContainsKey(toAdd))
		{
			SeekerTarget value = new SeekerTarget
			{
				strength = strength,
				owner = toAdd
			};
			seekerTargets.Add(toAdd, value);
		}
	}
}
