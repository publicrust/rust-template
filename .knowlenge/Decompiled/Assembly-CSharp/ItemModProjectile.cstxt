using Rust;
using UnityEngine;

public class ItemModProjectile : MonoBehaviour
{
	public GameObjectRef projectileObject = new GameObjectRef();

	public ItemModProjectileMod[] mods;

	public AmmoTypes ammoType;

	public int numProjectiles = 1;

	public float projectileSpread;

	public float projectileVelocity = 100f;

	public float projectileVelocitySpread;

	public bool useCurve;

	public AnimationCurve spreadScalar;

	public GameObjectRef attackEffectOverride;

	public float barrelConditionLoss;

	public string category = "bullet";

	public float GetRandomVelocity()
	{
		return projectileVelocity + Random.Range(0f - projectileVelocitySpread, projectileVelocitySpread);
	}

	public float GetSpreadScalar()
	{
		if (useCurve)
		{
			return spreadScalar.Evaluate(Random.Range(0f, 1f));
		}
		return 1f;
	}

	public float GetIndexedSpreadScalar(int shotIndex, int maxShots)
	{
		float num = 0f;
		if (shotIndex != -1)
		{
			float num2 = 1f / (float)maxShots;
			num = (float)shotIndex * num2;
		}
		else
		{
			num = Random.Range(0f, 1f);
		}
		return spreadScalar.Evaluate(num);
	}

	public float GetAverageVelocity()
	{
		return projectileVelocity;
	}

	public float GetMinVelocity()
	{
		return projectileVelocity - projectileVelocitySpread;
	}

	public float GetMaxVelocity()
	{
		return projectileVelocity + projectileVelocitySpread;
	}

	public bool IsAmmo(AmmoTypes ammo)
	{
		return (ammoType & ammo) != 0;
	}

	public virtual void ServerProjectileHit(HitInfo info)
	{
		if (mods == null)
		{
			return;
		}
		ItemModProjectileMod[] array = mods;
		foreach (ItemModProjectileMod itemModProjectileMod in array)
		{
			if (!(itemModProjectileMod == null))
			{
				itemModProjectileMod.ServerProjectileHit(info);
			}
		}
	}
}
