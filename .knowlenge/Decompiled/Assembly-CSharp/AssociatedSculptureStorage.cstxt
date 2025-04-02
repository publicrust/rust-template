using Facepunch;
using ProtoBuf;

public class AssociatedSculptureStorage : BaseEntity
{
	public uint Crc;

	public void InitFromSculpture(uint crc, NetworkableId id)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		Crc = crc;
		FileStorage.server.ReassignEntityId(id, net.ID);
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.baseSculpture = Pool.Get<BaseSculpture>();
		info.msg.baseSculpture.crc = Crc;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		Crc = (uint)(((int?)info.msg.baseSculpture?.crc) ?? (-1));
	}
}
