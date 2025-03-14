using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Rust/MaterialEffect")]
public class MaterialEffect : ScriptableObject
{
	[Serializable]
	public class Entry
	{
		public PhysicMaterial Material;

		public GameObjectRef Effect;

		public SoundDefinition SoundDefinition;
	}

	public GameObjectRef DefaultEffect;

	public SoundDefinition DefaultSoundDefinition;

	public Entry[] Entries;

	public int waterFootstepIndex = -1;

	public Entry deepWaterEntry;

	public float deepWaterDepth = -1f;

	public Entry submergedWaterEntry;

	public float submergedWaterDepth = -1f;

	public bool ScaleVolumeWithSpeed;

	public AnimationCurve SpeedGainCurve;

	public Entry GetEntryFromMaterial(PhysicMaterial mat)
	{
		Entry[] entries = Entries;
		foreach (Entry entry in entries)
		{
			if (entry.Material == mat)
			{
				return entry;
			}
		}
		return null;
	}

	public Entry GetWaterEntry()
	{
		if (waterFootstepIndex == -1)
		{
			for (int i = 0; i < Entries.Length; i++)
			{
				if (Entries[i].Material.name == "Water")
				{
					waterFootstepIndex = i;
					break;
				}
			}
		}
		if (waterFootstepIndex != -1)
		{
			return Entries[waterFootstepIndex];
		}
		Debug.LogWarning("Unable to find water effect for :" + base.name);
		return null;
	}

	public void SpawnOnRay(Ray ray, int mask, float length = 0.5f, Vector3 forward = default(Vector3), float speed = 0f)
	{
		if (!GamePhysics.Trace(ray, 0f, out var hitInfo, length, mask))
		{
			Effect.client.Run(DefaultEffect.resourcePath, ray.origin, ray.direction * -1f, forward);
			if (DefaultSoundDefinition != null)
			{
				PlaySound(DefaultSoundDefinition, hitInfo.point, speed);
			}
			return;
		}
		WaterLevel.WaterInfo waterInfo = WaterLevel.GetWaterInfo(ray.origin, waves: true, volumes: false);
		if (waterInfo.isValid)
		{
			Vector3 vector = new Vector3(ray.origin.x, waterInfo.surfaceLevel, ray.origin.z);
			Entry waterEntry = GetWaterEntry();
			if (submergedWaterDepth > 0f && waterInfo.currentDepth >= submergedWaterDepth)
			{
				waterEntry = submergedWaterEntry;
			}
			else if (deepWaterDepth > 0f && waterInfo.currentDepth >= deepWaterDepth)
			{
				waterEntry = deepWaterEntry;
			}
			if (waterEntry != null)
			{
				Effect.client.Run(waterEntry.Effect.resourcePath, vector, Vector3.up);
				if (waterEntry.SoundDefinition != null)
				{
					PlaySound(waterEntry.SoundDefinition, vector, speed);
				}
			}
			return;
		}
		PhysicMaterial materialAt = ColliderEx.GetMaterialAt(hitInfo.collider, hitInfo.point);
		Entry entryFromMaterial = GetEntryFromMaterial(materialAt);
		if (entryFromMaterial == null)
		{
			Effect.client.Run(DefaultEffect.resourcePath, hitInfo.point, hitInfo.normal, forward);
			if (DefaultSoundDefinition != null)
			{
				PlaySound(DefaultSoundDefinition, hitInfo.point, speed);
			}
		}
		else
		{
			Effect.client.Run(entryFromMaterial.Effect.resourcePath, hitInfo.point, hitInfo.normal, forward);
			if (entryFromMaterial.SoundDefinition != null)
			{
				PlaySound(entryFromMaterial.SoundDefinition, hitInfo.point, speed);
			}
		}
	}

	public void PlaySound(SoundDefinition definition, Vector3 position, float velocity = 0f)
	{
	}
}
