using Facepunch;
using ProtoBuf;

public class AssociatedSculptureStorage : BaseEntity
{
	public uint Crc;

	public void InitFromSculpture(uint crc, NetworkableId id)
	{
		Crc = crc;
		FileStorage.server.ReassignEntityId(id, net.ID);
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.baseSculpture = Pool.Get<ProtoBuf.BaseSculpture>();
		info.msg.baseSculpture.crc = Crc;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		Crc = (uint)(((int?)info.msg.baseSculpture?.crc) ?? (-1));
	}
}
