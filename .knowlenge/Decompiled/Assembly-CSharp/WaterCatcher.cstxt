using UnityEngine;

public class WaterCatcher : LiquidContainer
{
	[Header("Water Catcher")]
	public ItemDefinition itemToCreate;

	public float maxItemToCreate = 10f;

	[Header("Outside Test")]
	public Vector3 rainTestPosition = new Vector3(0f, 1f, 0f);

	public float rainTestSize = 1f;

	public const float collectInterval = 60f;

	public override void ServerInit()
	{
		base.ServerInit();
		AddResource(1);
		InvokeRandomized(CollectWater, 60f, 60f, 6f);
	}

	public void CollectWater()
	{
		if (!IsFull())
		{
			float num = 0.25f;
			num += Climate.GetFog(base.transform.position) * 2f;
			if (TestIsOutside())
			{
				num += Climate.GetRain(base.transform.position);
				num += Climate.GetSnow(base.transform.position) * 0.5f;
			}
			AddResource(Mathf.CeilToInt(maxItemToCreate * num));
		}
	}

	public bool IsFull()
	{
		if (base.inventory.itemList.Count == 0)
		{
			return false;
		}
		if (base.inventory.itemList[0].amount < base.inventory.maxStackSize)
		{
			return false;
		}
		return true;
	}

	public bool TestIsOutside()
	{
		return !Physics.SphereCast(new Ray(base.transform.localToWorldMatrix.MultiplyPoint3x4(rainTestPosition), Vector3.up), rainTestSize, 256f, 161546513);
	}

	public void AddResource(int iAmount)
	{
		base.inventory.AddItem(itemToCreate, iAmount, 0uL);
		UpdateOnFlag();
	}
}
