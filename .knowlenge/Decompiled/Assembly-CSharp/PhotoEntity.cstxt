using System;
using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using Rust;

public class PhotoEntity : ImageStorageEntity, IUGCBrowserEntity
{
	public ulong PhotographerSteamId { get; private set; }

	public uint ImageCrc { get; private set; }

	protected override uint CrcToLoad => ImageCrc;

	public override bool ShouldTransferAssociatedFiles => true;

	public uint[] GetContentCRCs
	{
		get
		{
			if (ImageCrc == 0)
			{
				return Array.Empty<uint>();
			}
			return new uint[1] { ImageCrc };
		}
	}

	public UGCType ContentType => UGCType.ImageJpg;

	public List<ulong> EditingHistory
	{
		get
		{
			if (PhotographerSteamId == 0)
			{
				return new List<ulong>();
			}
			return new List<ulong> { PhotographerSteamId };
		}
	}

	public BaseNetworkable UgcEntity => this;

	public string ContentString => string.Empty;

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.photo != null)
		{
			PhotographerSteamId = info.msg.photo.photographerSteamId;
			ImageCrc = info.msg.photo.imageCrc;
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.photo = Pool.Get<Photo>();
		info.msg.photo.photographerSteamId = PhotographerSteamId;
		info.msg.photo.imageCrc = ImageCrc;
	}

	public void SetImageData(ulong steamId, byte[] data)
	{
		ImageCrc = FileStorage.server.Store(data, FileStorage.Type.jpg, net.ID);
		PhotographerSteamId = steamId;
	}

	internal override void DoServerDestroy()
	{
		base.DoServerDestroy();
		if (!Rust.Application.isQuitting && net != null)
		{
			FileStorage.server.RemoveAllByEntity(net.ID);
		}
	}

	public void ClearContent()
	{
		ImageCrc = 0u;
		SendNetworkUpdate();
	}
}
