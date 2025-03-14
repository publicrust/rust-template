using Network;
using Network.Visibility;
using UnityEngine;

public static class EffectNetwork
{
	public static void Send(Effect effect)
	{
		if (Net.sv == null || !Net.sv.IsConnected())
		{
			return;
		}
		using (TimeWarning.New("EffectNetwork.Send"))
		{
			Group group = null;
			if (!string.IsNullOrEmpty(effect.pooledString))
			{
				effect.pooledstringid = StringPool.Get(effect.pooledString);
			}
			if (effect.pooledstringid == 0)
			{
				Debug.Log("String ID is 0 - unknown effect " + effect.pooledString);
				return;
			}
			if (effect.broadcast)
			{
				NetWrite netWrite = Net.sv.StartWrite();
				netWrite.PacketID(Message.Type.Effect);
				effect.WriteToStream(netWrite);
				netWrite.Send(new SendInfo(BaseNetworkable.GlobalNetworkGroup.subscribers));
				return;
			}
			if (effect.targets != null)
			{
				NetWrite netWrite2 = Net.sv.StartWrite();
				netWrite2.PacketID(Message.Type.Effect);
				effect.WriteToStream(netWrite2);
				netWrite2.Send(new SendInfo(effect.targets));
				return;
			}
			if (effect.entity.IsValid)
			{
				BaseEntity baseEntity = BaseNetworkable.serverEntities.Find(effect.entity) as BaseEntity;
				if (!baseEntity.IsValid())
				{
					return;
				}
				group = baseEntity.net.group;
			}
			else
			{
				group = Net.sv.visibility.GetGroup(effect.worldPos);
			}
			if (group != null)
			{
				NetWrite netWrite3 = Net.sv.StartWrite();
				netWrite3.PacketID(Message.Type.Effect);
				effect.WriteToStream(netWrite3);
				netWrite3.Send(new SendInfo(group.subscribers));
			}
		}
	}

	public static void Send(Effect effect, Connection target)
	{
		effect.pooledstringid = StringPool.Get(effect.pooledString);
		if (effect.pooledstringid == 0)
		{
			Debug.LogWarning("EffectNetwork.Send - unpooled effect name: " + effect.pooledString);
			return;
		}
		NetWrite netWrite = Net.sv.StartWrite();
		netWrite.PacketID(Message.Type.Effect);
		effect.WriteToStream(netWrite);
		netWrite.Send(new SendInfo(target));
	}
}
