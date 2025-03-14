using Facepunch;
using ProtoBuf;

public class HorseCorpse : LootableCorpse
{
	public int breedIndex;

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.horse = Pool.Get<ProtoBuf.Horse>();
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
