using UnityEngine;

public class BiomeVisuals : MonoBehaviour
{
	public GameObject Arid;

	public GameObject Temperate;

	public GameObject Tundra;

	public GameObject Arctic;

	protected void Start()
	{
		switch ((TerrainMeta.BiomeMap != null) ? TerrainMeta.BiomeMap.GetBiomeMaxType(base.transform.position) : 2)
		{
		case 1:
			SetChoice(Arid);
			break;
		case 2:
			SetChoice(Temperate);
			break;
		case 4:
			SetChoice(Tundra);
			break;
		case 8:
			SetChoice(Arctic);
			break;
		}
	}

	private void SetChoice(GameObject selection)
	{
		bool shouldDestroy = !PoolableEx.SupportsPoolingInParent(base.gameObject);
		ApplyChoice(selection, Arid, shouldDestroy);
		ApplyChoice(selection, Temperate, shouldDestroy);
		ApplyChoice(selection, Tundra, shouldDestroy);
		ApplyChoice(selection, Arctic, shouldDestroy);
		if (selection != null)
		{
			selection.SetActive(value: true);
		}
		GameManager.Destroy(this);
	}

	private void ApplyChoice(GameObject selection, GameObject target, bool shouldDestroy)
	{
		if (target != null && target != selection)
		{
			if (shouldDestroy)
			{
				GameManager.Destroy(target);
			}
			else
			{
				target.SetActive(value: false);
			}
		}
	}
}
