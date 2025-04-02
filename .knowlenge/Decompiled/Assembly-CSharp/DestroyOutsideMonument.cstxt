using System;
using UnityEngine;

public class DestroyOutsideMonument : FacepunchBehaviour
{
	[SerializeField]
	private BaseCombatEntity baseCombatEntity;

	[SerializeField]
	private float checkEvery = 10f;

	private MonumentInfo ourMonument;

	private Vector3 OurPos => ((Component)baseCombatEntity).transform.position;

	protected void OnEnable()
	{
		if ((Object)(object)ourMonument == (Object)null)
		{
			ourMonument = GetOurMonument();
		}
		if ((Object)(object)ourMonument == (Object)null)
		{
			DoOutsideMonument();
		}
		else
		{
			((FacepunchBehaviour)this).InvokeRandomized((Action)CheckPosition, checkEvery, checkEvery, checkEvery * 0.1f);
		}
	}

	protected void OnDisable()
	{
		((FacepunchBehaviour)this).CancelInvoke((Action)CheckPosition);
	}

	private MonumentInfo GetOurMonument()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		foreach (MonumentInfo monument in TerrainMeta.Path.Monuments)
		{
			if (monument.IsInBounds(OurPos))
			{
				return monument;
			}
		}
		return null;
	}

	private void CheckPosition()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)ourMonument == (Object)null)
		{
			DoOutsideMonument();
		}
		if (!ourMonument.IsInBounds(OurPos))
		{
			DoOutsideMonument();
		}
	}

	private void DoOutsideMonument()
	{
		baseCombatEntity.Kill(BaseNetworkable.DestroyMode.Gib);
	}
}
