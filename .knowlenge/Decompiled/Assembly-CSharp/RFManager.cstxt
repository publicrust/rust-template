using System.Collections.Generic;
using Oxide.Core;
using UnityEngine;

public class RFManager
{
	public static Dictionary<int, List<IRFObject>> _listeners = new Dictionary<int, List<IRFObject>>();

	public static Dictionary<int, List<IRFObject>> _broadcasters = new Dictionary<int, List<IRFObject>>();

	public static int minFreq = 1;

	public static int maxFreq = 9999;

	private static int reserveRangeMin = 4760;

	private static int reserveRangeMax = 4790;

	public static string reserveString = "Channels " + reserveRangeMin + " to " + reserveRangeMax + " are restricted.";

	public static int ClampFrequency(int freq)
	{
		return Mathf.Clamp(freq, minFreq, maxFreq);
	}

	public static List<IRFObject> GetListenList(int frequency)
	{
		frequency = ClampFrequency(frequency);
		List<IRFObject> value = null;
		if (!_listeners.TryGetValue(frequency, out value))
		{
			value = new List<IRFObject>();
			_listeners.Add(frequency, value);
		}
		return value;
	}

	public static List<IRFObject> GetBroadcasterList(int frequency)
	{
		frequency = ClampFrequency(frequency);
		List<IRFObject> value = null;
		if (!_broadcasters.TryGetValue(frequency, out value))
		{
			value = new List<IRFObject>();
			_broadcasters.Add(frequency, value);
		}
		return value;
	}

	public static void AddListener(int frequency, IRFObject obj)
	{
		frequency = ClampFrequency(frequency);
		if (Interface.CallHook("OnRfListenerAdd", obj, frequency) == null)
		{
			List<IRFObject> listenList = GetListenList(frequency);
			if (listenList.Contains(obj))
			{
				Debug.Log("adding same listener twice");
				return;
			}
			listenList.Add(obj);
			MarkFrequencyDirty(frequency);
			Interface.CallHook("OnRfListenerAdded", obj, frequency);
		}
	}

	public static void RemoveListener(int frequency, IRFObject obj)
	{
		frequency = ClampFrequency(frequency);
		if (Interface.CallHook("OnRfListenerRemove", obj, frequency) == null)
		{
			List<IRFObject> listenList = GetListenList(frequency);
			if (listenList.Contains(obj))
			{
				listenList.Remove(obj);
			}
			obj.RFSignalUpdate(on: false);
			Interface.CallHook("OnRfListenerRemoved", obj, frequency);
		}
	}

	public static void AddBroadcaster(int frequency, IRFObject obj)
	{
		frequency = ClampFrequency(frequency);
		if (Interface.CallHook("OnRfBroadcasterAdd", obj, frequency) == null)
		{
			List<IRFObject> broadcasterList = GetBroadcasterList(frequency);
			if (!broadcasterList.Contains(obj))
			{
				broadcasterList.Add(obj);
				MarkFrequencyDirty(frequency);
				Interface.CallHook("OnRfBroadcasterAdded", obj, frequency);
			}
		}
	}

	public static void RemoveBroadcaster(int frequency, IRFObject obj)
	{
		frequency = ClampFrequency(frequency);
		if (Interface.CallHook("OnRfBroadcasterRemove", obj, frequency) == null)
		{
			List<IRFObject> broadcasterList = GetBroadcasterList(frequency);
			if (broadcasterList.Contains(obj))
			{
				broadcasterList.Remove(obj);
			}
			MarkFrequencyDirty(frequency);
			Interface.CallHook("OnRfBroadcasterRemoved", obj, frequency);
		}
	}

	public static bool IsReserved(int frequency)
	{
		if (frequency >= reserveRangeMin && frequency <= reserveRangeMax)
		{
			return true;
		}
		return false;
	}

	public static void ReserveErrorPrint(BasePlayer player)
	{
		player.ChatMessage(reserveString);
	}

	public static void ChangeFrequency(int oldFrequency, int newFrequency, IRFObject obj, bool isListener, bool isOn = true)
	{
		newFrequency = ClampFrequency(newFrequency);
		if (isListener)
		{
			RemoveListener(oldFrequency, obj);
			if (isOn)
			{
				AddListener(newFrequency, obj);
			}
		}
		else
		{
			RemoveBroadcaster(oldFrequency, obj);
			if (isOn)
			{
				AddBroadcaster(newFrequency, obj);
			}
		}
	}

	public static void MarkFrequencyDirty(int frequency)
	{
		frequency = ClampFrequency(frequency);
		List<IRFObject> broadcasterList = GetBroadcasterList(frequency);
		List<IRFObject> listenList = GetListenList(frequency);
		bool flag = broadcasterList.Count > 0;
		bool flag2 = false;
		bool flag3 = false;
		for (int num = listenList.Count - 1; num >= 0; num--)
		{
			IRFObject iRFObject = listenList[num];
			if (!BaseEntityEx.IsValidEntityReference(iRFObject))
			{
				flag2 = true;
			}
			else
			{
				if (flag)
				{
					flag = false;
					foreach (IRFObject item in broadcasterList)
					{
						if (!BaseEntityEx.IsValidEntityReference(item))
						{
							flag3 = true;
						}
						else if (Vector3.Distance(item.GetPosition(), iRFObject.GetPosition()) <= item.GetMaxRange())
						{
							flag = true;
							break;
						}
					}
				}
				iRFObject.RFSignalUpdate(flag);
			}
		}
		if (flag2)
		{
			Debug.LogWarning("Found null entries in the RF listener list for frequency " + frequency + "... cleaning up.");
			for (int num2 = listenList.Count - 1; num2 >= 0; num2--)
			{
				if (listenList[num2] == null)
				{
					listenList.RemoveAt(num2);
				}
			}
		}
		if (!flag3)
		{
			return;
		}
		Debug.LogWarning("Found null entries in the RF broadcaster list for frequency " + frequency + "... cleaning up.");
		for (int num3 = broadcasterList.Count - 1; num3 >= 0; num3--)
		{
			if (broadcasterList[num3] == null)
			{
				broadcasterList.RemoveAt(num3);
			}
		}
	}
}
