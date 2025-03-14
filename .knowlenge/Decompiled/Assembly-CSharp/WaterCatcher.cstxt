using Oxide.Core;
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
		if (!IsFull() && Interface.CallHook("OnWaterCollect", this) == null)
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
		if (outputs.Length != 0)
		{
			IOEntity iOEntity = CheckPushLiquid(outputs[0].connectedTo.Get(), iAmount, this, IOEntity.backtracking * 2);
			if (iOEntity != null && iOEntity is LiquidContainer liquidContainer)
			{
				liquidContainer.inventory.AddItem(itemToCreate, iAmount, 0uL);
				return;
			}
		}
		base.inventory.AddItem(itemToCreate, iAmount, 0uL);
		UpdateOnFlag();
	}

	private IOEntity CheckPushLiquid(IOEntity connected, int amount, IOEntity fromSource, int depth)
	{
		if (depth <= 0 || itemToCreate == null)
		{
			return null;
		}
		if (connected == null)
		{
			return null;
		}
		Vector3 worldHandlePosition = Vector3.zero;
		IOEntity iOEntity = connected.FindGravitySource(ref worldHandlePosition, IOEntity.backtracking, ignoreSelf: true);
		if (iOEntity != null && !connected.AllowLiquidPassthrough(iOEntity, worldHandlePosition))
		{
			return null;
		}
		if (connected == this || ConsiderConnectedTo(connected))
		{
			return null;
		}
		if (connected.prefabID == 2150367216u)
		{
			return null;
		}
		IOSlot[] array = connected.outputs;
		foreach (IOSlot iOSlot in array)
		{
			IOEntity iOEntity2 = iOSlot.connectedTo.Get();
			Vector3 sourceWorldPosition = connected.transform.TransformPoint(iOSlot.handlePosition);
			if (iOEntity2 != null && iOEntity2 != fromSource && iOEntity2.AllowLiquidPassthrough(connected, sourceWorldPosition))
			{
				IOEntity iOEntity3 = CheckPushLiquid(iOEntity2, amount, fromSource, depth - 1);
				if (iOEntity3 != null)
				{
					return iOEntity3;
				}
			}
		}
		if (connected is LiquidContainer liquidContainer && liquidContainer.inventory.GetAmount(itemToCreate.itemid, onlyUsableAmounts: false) + amount < liquidContainer.maxStackSize)
		{
			return connected;
		}
		return null;
	}
}
