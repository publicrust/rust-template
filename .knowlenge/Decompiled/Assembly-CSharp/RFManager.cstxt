using System.Collections.Generic;
using Oxide.Core;
using UnityEngine;

public class RFManager
{
	private static readonly Dictionary<int, HashSet<IRFObject>> _listeners = new Dictionary<int, HashSet<IRFObject>>();

	private static readonly Dictionary<int, HashSet<IRFObject>> _broadcasters = new Dictionary<int, HashSet<IRFObject>>();

	private static readonly Dictionary<int, bool> _isFrequencyBroadcasting = new Dictionary<int, bool>();

	public static int minFreq = 1;

	public static int maxFreq = 999999;

	private static int reserveRangeMin = 4760;

	private static int reserveRangeMax = 4790;

	public static Translate.Phrase reservedFrequencyPhrase = new Translate.Phrase("rf.reservedfrequency", "Channels {0} to {1} are restricted");

	public static int ClampFrequency(int freq)
	{
		return Mathf.Clamp(freq, minFreq, maxFreq);
	}

	public static HashSet<IRFObject> GetListenerSet(int frequency)
	{
		frequency = ClampFrequency(frequency);
		if (!_listeners.TryGetValue(frequency, out var value))
		{
			value = new HashSet<IRFObject>();
			_listeners[frequency] = value;
		}
		return value;
	}

	public static HashSet<IRFObject> GetBroadcasterSet(int frequency)
	{
		frequency = ClampFrequency(frequency);
		if (!_broadcasters.TryGetValue(frequency, out var value))
		{
			value = new HashSet<IRFObject>();
			_broadcasters[frequency] = value;
		}
		return value;
	}

	public static void AddListener(int frequency, IRFObject obj)
	{
		frequency = ClampFrequency(frequency);
		if (Interface.CallHook("OnRfListenerAdd", obj, frequency) == null && GetListenerSet(frequency).Add(obj))
		{
			bool value;
			bool on = _isFrequencyBroadcasting.TryGetValue(frequency, out value) && value;
			obj.RFSignalUpdate(on);
			Interface.CallHook("OnRfListenerAdded", obj, frequency);
		}
	}

	public static void RemoveListener(int frequency, IRFObject obj)
	{
		frequency = ClampFrequency(frequency);
		if (Interface.CallHook("OnRfListenerRemove", obj, frequency) == null && GetListenerSet(frequency).Remove(obj))
		{
			obj.RFSignalUpdate(on: false);
			Interface.CallHook("OnRfListenerRemoved", obj, frequency);
		}
	}

	public static void AddBroadcaster(int frequency, IRFObject obj)
	{
		frequency = ClampFrequency(frequency);
		if (Interface.CallHook("OnRfBroadcasterAdd", obj, frequency) != null)
		{
			return;
		}
		HashSet<IRFObject> broadcasterSet = GetBroadcasterSet(frequency);
		if (broadcasterSet.RemoveWhere((IRFObject b) => b == null || !BaseEntityEx.IsValidEntityReference(b)) > 0)
		{
			Debug.LogWarning($"Found null entries in the RF broadcaster set for frequency {frequency}... cleaning up.");
		}
		if (broadcasterSet.Add(obj))
		{
			Interface.CallHook("OnRfBroadcasterAdded", obj, frequency);
			if (!_isFrequencyBroadcasting.TryGetValue(frequency, out var value) || !value)
			{
				_isFrequencyBroadcasting[frequency] = true;
				UpdateListenersForFrequency(frequency, isBroadcasting: true);
			}
		}
	}

	public static void RemoveBroadcaster(int frequency, IRFObject obj)
	{
		frequency = ClampFrequency(frequency);
		if (Interface.CallHook("OnRfBroadcasterRemove", obj, frequency) != null)
		{
			return;
		}
		HashSet<IRFObject> broadcasterSet = GetBroadcasterSet(frequency);
		if (broadcasterSet.RemoveWhere((IRFObject b) => b == null || !BaseEntityEx.IsValidEntityReference(b)) > 0)
		{
			Debug.LogWarning($"Found null entries in the RF broadcaster set for frequency {frequency}... cleaning up.");
		}
		if (broadcasterSet.Remove(obj))
		{
			Interface.CallHook("OnRfBroadcasterRemoved", obj, frequency);
			if (broadcasterSet.Count == 0)
			{
				_isFrequencyBroadcasting[frequency] = false;
				UpdateListenersForFrequency(frequency, isBroadcasting: false);
			}
		}
	}

	private static void UpdateListenersForFrequency(int frequency, bool isBroadcasting)
	{
		HashSet<IRFObject> listenerSet = GetListenerSet(frequency);
		listenerSet.RemoveWhere((IRFObject l) => l == null || !BaseEntityEx.IsValidEntityReference(l));
		foreach (IRFObject item in listenerSet)
		{
			item.RFSignalUpdate(isBroadcasting);
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
		player.ShowToast(GameTip.Styles.Error, reservedFrequencyPhrase, false, reserveRangeMin.ToString(), reserveRangeMax.ToString());
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
}
