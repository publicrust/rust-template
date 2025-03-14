using Facepunch;
using ProtoBuf;

public class HorseCorpse : LootableCorpse
{
	public int breedIndex;

	public Translate.Phrase lootPanelTitle;

	public override string playerName => lootPanelTitle.translated;

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.horse = Pool.Get<Horse>();
		info.msg.horse.breedIndex = breedIndex;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.horse != null)
		{
			breedIndex = info.msg.horse.breedIndex;
		}
	}
}
