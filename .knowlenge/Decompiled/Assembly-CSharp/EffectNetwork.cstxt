using System;
using System.IO;
using Network;
using Network.Visibility;
using UnityEngine;

public static class EffectNetwork
{
	public static void Send(Effect effect)
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		if (Net.sv == null || !((BaseNetwork)Net.sv).IsConnected())
		{
			return;
		}
		TimeWarning val = TimeWarning.New("EffectNetwork.Send", 0);
		try
		{
			Group val2 = null;
			if (!string.IsNullOrEmpty(effect.pooledString))
			{
				((EffectData)effect).pooledstringid = StringPool.Get(effect.pooledString);
			}
			if (((EffectData)effect).pooledstringid == 0)
			{
				Debug.Log((object)("String ID is 0 - unknown effect " + effect.pooledString));
				return;
			}
			if (effect.broadcast)
			{
				NetWrite val3 = ((BaseNetwork)Net.sv).StartWrite();
				val3.PacketID((Type)13);
				((EffectData)effect).WriteToStream((Stream)(object)val3);
				val3.Send(new SendInfo(BaseNetworkable.GlobalNetworkGroup.subscribers));
				return;
			}
			if (effect.targets != null)
			{
				NetWrite val4 = ((BaseNetwork)Net.sv).StartWrite();
				val4.PacketID((Type)13);
				((EffectData)effect).WriteToStream((Stream)(object)val4);
				val4.Send(new SendInfo(effect.targets));
				return;
			}
			if (((NetworkableId)(ref ((EffectData)effect).entity)).IsValid)
			{
				BaseEntity baseEntity = BaseNetworkable.serverEntities.Find(((EffectData)effect).entity) as BaseEntity;
				if (!baseEntity.IsValid())
				{
					return;
				}
				val2 = baseEntity.net.group;
			}
			else
			{
				val2 = Net.sv.visibility.GetGroup(effect.worldPos);
			}
			if (val2 != null)
			{
				NetWrite val5 = ((BaseNetwork)Net.sv).StartWrite();
				val5.PacketID((Type)13);
				((EffectData)effect).WriteToStream((Stream)(object)val5);
				val5.Send(new SendInfo(val2.subscribers));
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void Send(Effect effect, Connection target)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		((EffectData)effect).pooledstringid = StringPool.Get(effect.pooledString);
		if (((EffectData)effect).pooledstringid == 0)
		{
			Debug.LogWarning((object)("EffectNetwork.Send - unpooled effect name: " + effect.pooledString));
			return;
		}
		NetWrite val = ((BaseNetwork)Net.sv).StartWrite();
		val.PacketID((Type)13);
		((EffectData)effect).WriteToStream((Stream)(object)val);
		val.Send(new SendInfo(target));
	}
}
