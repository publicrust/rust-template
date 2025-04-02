using UnityEngine;

public class IceFence : GraveyardFence
{
	public GameObject[] styles;

	private bool init;

	public AdaptMeshToTerrain snowMesh;

	public int GetStyleFromID()
	{
		uint num = (uint)net.ID.Value;
		return SeedRandom.Range(ref num, 0, styles.Length);
	}

	public override void ServerInit()
	{
		base.ServerInit();
		InitStyle();
		UpdatePillars();
	}

	public void InitStyle()
	{
		if (!init)
		{
			SetStyle(GetStyleFromID());
		}
	}

	public void SetStyle(int style)
	{
		GameObject[] array = styles;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(false);
		}
		styles[style].gameObject.SetActive(true);
	}

	public override void UpdatePillars()
	{
		base.UpdatePillars();
	}
}
