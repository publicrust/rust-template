using Facepunch;
using Network;
using ProtoBuf;

public class PlayerModifiers : BaseModifiers<BasePlayer>
{
	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("PlayerModifiers.OnRpcMessage"))
		{
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void ServerUpdate(BaseCombatEntity ownerEntity)
	{
		base.ServerUpdate(ownerEntity);
		SendChangesToClient();
	}

	public ProtoBuf.PlayerModifiers Save()
	{
		ProtoBuf.PlayerModifiers playerModifiers = Pool.Get<ProtoBuf.PlayerModifiers>();
		playerModifiers.modifiers = Pool.GetList<ProtoBuf.Modifier>();
		foreach (Modifier item in All)
		{
			if (item != null)
			{
				playerModifiers.modifiers.Add(item.Save());
			}
		}
		return playerModifiers;
	}

	public void Load(ProtoBuf.PlayerModifiers m)
	{
		RemoveAll();
		if (m == null || m.modifiers == null)
		{
			return;
		}
		foreach (ProtoBuf.Modifier modifier2 in m.modifiers)
		{
			if (modifier2 != null)
			{
				Modifier modifier = new Modifier();
				modifier.Init((Modifier.ModifierType)modifier2.type, (Modifier.ModifierSource)modifier2.source, modifier2.value, modifier2.duration, modifier2.timeRemaing);
				Add(modifier);
			}
		}
	}

	public void SendChangesToClient()
	{
		if (!dirty)
		{
			return;
		}
		SetDirty(flag: false);
		using ProtoBuf.PlayerModifiers arg = Save();
		base.baseEntity.ClientRPCPlayer(null, base.baseEntity, "UpdateModifiers", arg);
	}
}
