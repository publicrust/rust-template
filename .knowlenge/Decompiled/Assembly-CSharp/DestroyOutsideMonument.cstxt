using UnityEngine;

public class DestroyOutsideMonument : FacepunchBehaviour
{
	[SerializeField]
	private BaseCombatEntity baseCombatEntity;

	[SerializeField]
	private float checkEvery = 10f;

	private MonumentInfo ourMonument;

	private Vector3 OurPos => baseCombatEntity.transform.position;

	protected void OnEnable()
	{
		if (ourMonument == null)
		{
			ourMonument = GetOurMonument();
		}
		if (ourMonument == null)
		{
			DoOutsideMonument();
		}
		else
		{
			InvokeRandomized(CheckPosition, checkEvery, checkEvery, checkEvery * 0.1f);
		}
	}

	protected void OnDisable()
	{
		CancelInvoke(CheckPosition);
	}

	private MonumentInfo GetOurMonument()
	{
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
		if (ourMonument == null)
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
