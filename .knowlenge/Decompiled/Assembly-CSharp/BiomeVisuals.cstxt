using System;
using UnityEngine;

public class BiomeVisuals : MonoBehaviour
{
	[Serializable]
	public class EnvironmentVolumeOverride
	{
		public EnvironmentType Environment;

		public Enum Biome;
	}

	public GameObject Arid;

	public GameObject Temperate;

	public GameObject Tundra;

	public GameObject Arctic;

	public bool OverrideBiome;

	public Enum ToOverride;

	[Horizontal(2, -1)]
	public EnvironmentVolumeOverride[] EnvironmentVolumeOverrides;

	protected void Start()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected I4, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected I4, but got Unknown
		int num = (((Object)(object)TerrainMeta.BiomeMap != (Object)null) ? TerrainMeta.BiomeMap.GetBiomeMaxType(((Component)this).transform.position) : 2);
		if (OverrideBiome)
		{
			num = (int)ToOverride;
		}
		else if (EnvironmentVolumeOverrides.Length != 0)
		{
			EnvironmentType environmentType = EnvironmentManager.Get(((Component)this).transform.position);
			EnvironmentVolumeOverride[] environmentVolumeOverrides = EnvironmentVolumeOverrides;
			foreach (EnvironmentVolumeOverride environmentVolumeOverride in environmentVolumeOverrides)
			{
				if ((environmentType & environmentVolumeOverride.Environment) != 0)
				{
					num = (int)environmentVolumeOverride.Biome;
					break;
				}
			}
		}
		switch (num)
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
		bool shouldDestroy = !((Component)this).gameObject.SupportsPoolingInParent();
		ApplyChoice(selection, Arid, shouldDestroy);
		ApplyChoice(selection, Temperate, shouldDestroy);
		ApplyChoice(selection, Tundra, shouldDestroy);
		ApplyChoice(selection, Arctic, shouldDestroy);
		if ((Object)(object)selection != (Object)null)
		{
			selection.SetActive(true);
		}
		GameManager.Destroy((Component)(object)this);
	}

	private void ApplyChoice(GameObject selection, GameObject target, bool shouldDestroy)
	{
		if ((Object)(object)target != (Object)null && (Object)(object)target != (Object)(object)selection)
		{
			if (shouldDestroy)
			{
				GameManager.Destroy(target);
			}
			else
			{
				target.SetActive(false);
			}
		}
	}
}
