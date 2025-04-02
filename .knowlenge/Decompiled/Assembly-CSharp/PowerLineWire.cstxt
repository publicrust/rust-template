using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Procedural/Mega Wire")]
public class PowerLineWire : MonoBehaviour
{
	public List<Transform> poles = new List<Transform>();

	public List<PowerLineWireConnectionDef> connections = new List<PowerLineWireConnectionDef>();

	public List<PowerLineWireSpan> spans = new List<PowerLineWireSpan>();

	public void Copy(PowerLineWire from, PowerLineWireConnectionHelper helper)
	{
		connections.Clear();
		if (Object.op_Implicit((Object)(object)helper))
		{
			for (int i = 0; i < helper.connections.Count; i++)
			{
				connections.Add(new PowerLineWireConnectionDef(helper.connections[i]));
			}
		}
		else
		{
			for (int j = 0; j < from.connections.Count; j++)
			{
				connections.Add(new PowerLineWireConnectionDef(from.connections[j]));
			}
		}
	}

	public static PowerLineWire Create(PowerLineWire wire, List<GameObject> objs, GameObjectRef wirePrefab, string name, PowerLineWire copyfrom, float wiresize, float str)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		if (objs != null && objs.Count > 1)
		{
			GameObject val = null;
			if ((Object)(object)wire == (Object)null)
			{
				val = new GameObject();
				((Object)val).name = name;
				wire = val.AddComponent<PowerLineWire>();
			}
			else
			{
				val = ((Component)wire).gameObject;
			}
			wire.poles.Clear();
			wire.spans.Clear();
			wire.connections.Clear();
			wire.poles.Add(objs[0].transform);
			for (int i = 0; i < objs.Count - 1; i++)
			{
				GameObject val2 = new GameObject
				{
					name = name + " Span Mesh " + i
				};
				val2.transform.parent = val.transform;
				PowerLineWireSpan powerLineWireSpan = val2.AddComponent<PowerLineWireSpan>();
				powerLineWireSpan.wirePrefab = wirePrefab;
				powerLineWireSpan.start = objs[i].transform;
				powerLineWireSpan.end = objs[i + 1].transform;
				wire.spans.Add(powerLineWireSpan);
				wire.poles.Add(objs[i + 1].transform);
			}
			PowerLineWireConnectionHelper component = objs[0].GetComponent<PowerLineWireConnectionHelper>();
			if (Object.op_Implicit((Object)(object)copyfrom))
			{
				wire.Copy(copyfrom, component);
			}
			else if (Object.op_Implicit((Object)(object)component))
			{
				wire.Copy(wire, component);
			}
			else
			{
				PowerLineWireConnectionDef item = new PowerLineWireConnectionDef();
				wire.connections.Add(item);
			}
			if (wiresize != 1f)
			{
				for (int j = 0; j < wire.connections.Count; j++)
				{
					wire.connections[j].radius *= wiresize;
				}
			}
			wire.Init();
		}
		return wire;
	}

	public void Init()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < spans.Count; i++)
		{
			PowerLineWireSpan powerLineWireSpan = spans[i];
			powerLineWireSpan.connections.Clear();
			for (int j = 0; j < connections.Count; j++)
			{
				PowerLineWireConnection powerLineWireConnection = new PowerLineWireConnection
				{
					start = powerLineWireSpan.start,
					end = powerLineWireSpan.end,
					inOffset = connections[j].inOffset,
					outOffset = connections[j].outOffset,
					radius = connections[j].radius
				};
				PowerLineWireConnectionHelper component = ((Component)powerLineWireSpan.start).GetComponent<PowerLineWireConnectionHelper>();
				PowerLineWireConnectionHelper component2 = ((Component)powerLineWireSpan.end).GetComponent<PowerLineWireConnectionHelper>();
				powerLineWireConnection.inOffset = component2.connections[j].inOffset;
				powerLineWireConnection.outOffset = component.connections[j].outOffset;
				if (!component.connections[j].hidden && !component2.connections[j].hidden)
				{
					powerLineWireSpan.connections.Add(powerLineWireConnection);
				}
			}
			powerLineWireSpan.Init(this);
		}
	}
}
