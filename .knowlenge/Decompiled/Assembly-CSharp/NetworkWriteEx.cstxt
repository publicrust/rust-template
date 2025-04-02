using System.IO;
using Network;
using SilentOrbit.ProtocolBuffers;
using UnityEngine;

public static class NetworkWriteEx
{
	public static void WriteObject<T>(this NetWrite write, T obj)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		if (typeof(T) == typeof(Vector3))
		{
			Vector3 val = GenericsUtil.Cast<T, Vector3>(obj);
			write.Vector3(ref val);
			return;
		}
		if (typeof(T) == typeof(Vector4))
		{
			Vector4 val2 = GenericsUtil.Cast<T, Vector4>(obj);
			write.Vector4(ref val2);
			return;
		}
		if (typeof(T) == typeof(Ray))
		{
			Ray val3 = GenericsUtil.Cast<T, Ray>(obj);
			write.Ray(ref val3);
			return;
		}
		if (typeof(T) == typeof(float))
		{
			write.Float(GenericsUtil.Cast<T, float>(obj));
			return;
		}
		if (typeof(T) == typeof(short))
		{
			write.Int16(GenericsUtil.Cast<T, short>(obj));
			return;
		}
		if (typeof(T) == typeof(ushort))
		{
			write.UInt16(GenericsUtil.Cast<T, ushort>(obj));
			return;
		}
		if (typeof(T) == typeof(int))
		{
			write.Int32(GenericsUtil.Cast<T, int>(obj));
			return;
		}
		if (typeof(T) == typeof(uint))
		{
			write.UInt32(GenericsUtil.Cast<T, uint>(obj));
			return;
		}
		if (typeof(T) == typeof(byte[]))
		{
			write.Bytes(GenericsUtil.Cast<T, byte[]>(obj));
			return;
		}
		if (typeof(T) == typeof(long))
		{
			write.Int64(GenericsUtil.Cast<T, long>(obj));
			return;
		}
		if (typeof(T) == typeof(ulong))
		{
			write.UInt64(GenericsUtil.Cast<T, ulong>(obj));
			return;
		}
		if (typeof(T) == typeof(string))
		{
			write.String(GenericsUtil.Cast<T, string>(obj), false);
			return;
		}
		if (typeof(T) == typeof(sbyte))
		{
			write.Int8(GenericsUtil.Cast<T, sbyte>(obj));
			return;
		}
		if (typeof(T) == typeof(byte))
		{
			write.UInt8(GenericsUtil.Cast<T, byte>(obj));
			return;
		}
		if (typeof(T) == typeof(bool))
		{
			write.Bool(GenericsUtil.Cast<T, bool>(obj));
			return;
		}
		if (typeof(T) == typeof(Color))
		{
			Color val4 = GenericsUtil.Cast<T, Color>(obj);
			write.Color(ref val4);
			return;
		}
		if (typeof(T) == typeof(Color32))
		{
			Color32 val5 = GenericsUtil.Cast<T, Color32>(obj);
			write.Color32(ref val5);
			return;
		}
		if (typeof(T) == typeof(NetworkableId))
		{
			write.EntityID(GenericsUtil.Cast<T, NetworkableId>(obj));
			return;
		}
		if (typeof(T) == typeof(ItemContainerId))
		{
			write.ItemContainerID(GenericsUtil.Cast<T, ItemContainerId>(obj));
			return;
		}
		if (typeof(T) == typeof(ItemId))
		{
			write.ItemID(GenericsUtil.Cast<T, ItemId>(obj));
			return;
		}
		object obj2 = obj;
		IProto val6 = (IProto)((obj2 is IProto) ? obj2 : null);
		if (val6 != null)
		{
			val6.WriteToStream((Stream)(object)write);
			return;
		}
		T val7 = obj;
		Debug.LogError((object)("NetworkData.Write - no handler to write " + val7?.ToString() + " -> " + obj.GetType()));
	}
}
