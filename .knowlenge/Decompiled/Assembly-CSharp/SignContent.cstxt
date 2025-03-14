using System.Collections.Generic;
using Facepunch;
using ProtoBuf;

public class SignContent : ImageStorageEntity, IUGCBrowserEntity
{
	private uint[] textureIDs = new uint[1];

	private List<ulong> editHistory = new List<ulong>();

	protected override uint CrcToLoad => textureIDs[0];

	protected override FileStorage.Type StorageType => FileStorage.Type.png;

	public UGCType ContentType => UGCType.ImagePng;

	public uint[] GetContentCRCs => textureIDs;

	public FileStorage.Type FileType => StorageType;

	public List<ulong> EditingHistory => editHistory;

	public BaseNetworkable UgcEntity => this;

	public void CopyInfoFromSign(ISignage s, IUGCBrowserEntity b)
	{
		uint[] textureCRCs = s.GetTextureCRCs();
		textureIDs = new uint[textureCRCs.Length];
		textureCRCs.CopyTo(textureIDs, 0);
		editHistory.Clear();
		foreach (ulong item in b.EditingHistory)
		{
			editHistory.Add(item);
		}
		FileStorage.server.ReassignEntityId(s.NetworkID, net.ID);
	}

	public void CopyInfoToSign(ISignage s, IUGCBrowserEntity b)
	{
		FileStorage.server.ReassignEntityId(net.ID, s.NetworkID);
		s.SetTextureCRCs(textureIDs);
		b.EditingHistory.Clear();
		foreach (ulong item in editHistory)
		{
			b.EditingHistory.Add(item);
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.msg.paintableSign == null)
		{
			info.msg.paintableSign = Pool.Get<PaintableSign>();
		}
		info.msg.paintableSign.crcs = Pool.GetList<uint>();
		uint[] array = textureIDs;
		foreach (uint item in array)
		{
			info.msg.paintableSign.crcs.Add(item);
		}
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		FileStorage.server.RemoveAllByEntity(net.ID);
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.paintableSign != null)
		{
			textureIDs = new uint[info.msg.paintableSign.crcs.Count];
			for (int i = 0; i < info.msg.paintableSign.crcs.Count; i++)
			{
				textureIDs[i] = info.msg.paintableSign.crcs[i];
			}
		}
	}

	public void ClearContent()
	{
		Kill();
	}
}
