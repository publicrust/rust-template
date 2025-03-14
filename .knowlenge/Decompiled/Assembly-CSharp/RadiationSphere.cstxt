using System.Collections.Generic;
using ConVar;
using UnityEngine;

public class RadiationSphere : BaseEntity
{
	private struct RadiationLight
	{
		public IOEntity Light;

		public Color OriginalColor;
	}

	public AnimationCurve RadiationCurve;

	public float InvokeDelay = 5f;

	public List<IOEntity> RadiationLights = new List<IOEntity>();

	private float timeStarted;

	private TriggerRadiation[] radiationTriggers;

	public static List<RadiationSphere> All { get; private set; } = new List<RadiationSphere>();

	public override void ServerInit()
	{
		base.ServerInit();
		radiationTriggers = GetComponentsInChildren<TriggerRadiation>();
		InvokeRandomized(UpdateRadiation, InvokeDelay, InvokeDelay, InvokeDelay / 10f);
		All.Add(this);
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		All.Remove(this);
	}

	public void RestartRadiation()
	{
		timeStarted = UnityEngine.Time.time;
	}

	public void StopRadation()
	{
		timeStarted = 0f;
	}

	public void UpdateRadiation()
	{
		float num = RadiationCurve.Evaluate((UnityEngine.Time.time - timeStarted) / 60f * Server.oilrig_radiation_time_scale) * Server.oilrig_radiation_amount_scale;
		if (timeStarted == 0f)
		{
			num = 0f;
		}
		TriggerRadiation[] array = radiationTriggers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].RadiationAmountOverride = num;
		}
		SetLights(num > Server.oilrig_radiation_alarm_threshold);
	}

	private void SetLights(bool state)
	{
		foreach (IOEntity radiationLight in RadiationLights)
		{
			if (!(radiationLight == null))
			{
				radiationLight.SetFlag(Flags.Reserved8, state);
			}
		}
	}

	public override void OnEntityMessage(BaseEntity from, string msg)
	{
		if (msg == "HackingStarted")
		{
			RestartRadiation();
		}
	}

	public void OnPuzzleReset()
	{
		StopRadation();
	}
}
