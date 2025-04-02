using UnityEngine;

[CreateAssetMenu(menuName = "Rust/NPCVendingOrderManifest")]
public class NPCVendingOrderManifest : ScriptableObject
{
	public NPCVendingOrder[] orderList;

	public int GetIndex(NPCVendingOrder sample)
	{
		if ((Object)(object)sample == (Object)null)
		{
			return -1;
		}
		for (int i = 0; i < orderList.Length; i++)
		{
			NPCVendingOrder nPCVendingOrder = orderList[i];
			if ((Object)(object)sample == (Object)(object)nPCVendingOrder)
			{
				return i;
			}
		}
		return -1;
	}

	public NPCVendingOrder GetFromIndex(int index)
	{
		if (orderList == null)
		{
			return null;
		}
		if (index < 0)
		{
			return null;
		}
		if (index >= orderList.Length)
		{
			return null;
		}
		return orderList[index];
	}
}
