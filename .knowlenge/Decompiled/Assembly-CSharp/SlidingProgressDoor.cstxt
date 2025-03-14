using Facepunch;
using ProtoBuf;
using UnityEngine;

public class SlidingProgressDoor : ProgressDoor
{
	public Vector3 openPosition;

	public Vector3 closedPosition;

	public GameObject doorObject;

	public TriggerVehiclePush vehiclePhysBox;

	private float lastEnergyTime;

	private float lastServerUpdateTime;

	public override void Spawn()
	{
		base.Spawn();
		InvokeRepeating(ServerUpdate, 0f, 0.1f);
		if (vehiclePhysBox != null)
		{
			vehiclePhysBox.gameObject.SetActive(value: false);
		}
	}

	public override void NoEnergy()
	{
		base.NoEnergy();
	}

	public override void AddEnergy(float amount)
	{
		lastEnergyTime = Time.time;
		base.AddEnergy(amount);
	}

	public override bool ShouldUseCastNoClipChecks()
	{
		return true;
	}

	public void ServerUpdate()
	{
		if (!base.isServer)
		{
			return;
		}
		if (lastServerUpdateTime == 0f)
		{
			lastServerUpdateTime = Time.realtimeSinceStartup;
		}
		float num = Time.realtimeSinceStartup - lastServerUpdateTime;
		lastServerUpdateTime = Time.realtimeSinceStartup;
		if (Time.time > lastEnergyTime + 0.333f)
		{
			float b = energyForOpen * num / secondsToClose;
			float num2 = Mathf.Min(storedEnergy, b);
			if (vehiclePhysBox != null)
			{
				vehiclePhysBox.gameObject.SetActive(num2 > 0f && storedEnergy > 0f);
				if (vehiclePhysBox.gameObject.activeSelf && vehiclePhysBox.ContentsCount > 0)
				{
					num2 = 0f;
				}
			}
			storedEnergy -= num2;
			storedEnergy = Mathf.Clamp(storedEnergy, 0f, energyForOpen);
			if (num2 > 0f)
			{
				IOSlot[] array = outputs;
				foreach (IOSlot iOSlot in array)
				{
					if (iOSlot.connectedTo.Get() != null)
					{
						iOSlot.connectedTo.Get().IOInput(this, ioType, 0f - num2, iOSlot.connectedToSlot);
					}
				}
			}
		}
		UpdateProgress();
	}

	public override void UpdateProgress()
	{
		Vector3 localPosition = doorObject.transform.localPosition;
		float t = storedEnergy / energyForOpen;
		Vector3 vector = Vector3.Lerp(closedPosition, openPosition, t);
		doorObject.transform.localPosition = vector;
		if (base.isServer)
		{
			bool flag = Vector3.Distance(localPosition, vector) > 0.01f;
			SetFlag(Flags.Reserved1, flag);
			if (flag)
			{
				SendNetworkUpdate();
			}
		}
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		_ = info.msg.sphereEntity;
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.sphereEntity = Pool.Get<ProtoBuf.SphereEntity>();
		info.msg.sphereEntity.radius = storedEnergy;
	}
}
