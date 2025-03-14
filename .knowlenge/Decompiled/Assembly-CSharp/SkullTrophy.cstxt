using Facepunch;
using ntw.CurvedTextMeshPro;
using ProtoBuf;
using Rust.UI;
using UnityEngine;

public class SkullTrophy : StorageContainer
{
	public RustText NameText;

	public TextProOnACircle CircleModifier;

	public int AngleModifierMinCharCount = 3;

	public int AngleModifierMaxCharCount = 20;

	public int AngleModifierMinArcAngle = 20;

	public int AngleModifierMaxArcAngle = 45;

	public float SunsetTime = 18f;

	public float SunriseTime = 5f;

	public MeshRenderer[] SkullRenderers;

	public Material[] DaySkull;

	public Material[] NightSkull;

	public Material[] NoSkull;

	public override void OnItemAddedOrRemoved(Item item, bool added)
	{
		base.OnItemAddedOrRemoved(item, added);
		SendNetworkUpdate();
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (base.inventory != null && base.inventory.itemList.Count == 1)
		{
			info.msg.skullTrophy = Pool.Get<ProtoBuf.SkullTrophy>();
			info.msg.skullTrophy.playerName = base.inventory.itemList[0].name;
		}
		else if (info.msg.skullTrophy != null)
		{
			info.msg.skullTrophy.playerName = string.Empty;
		}
	}
}
