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
		if ((bool)helper)
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
		if (objs != null && objs.Count > 1)
		{
			GameObject gameObject = null;
			if (wire == null)
			{
				gameObject = new GameObject();
				gameObject.name = name;
				wire = gameObject.AddComponent<PowerLineWire>();
			}
			else
			{
				gameObject = wire.gameObject;
			}
			wire.poles.Clear();
			wire.spans.Clear();
			wire.connections.Clear();
			wire.poles.Add(objs[0].transform);
			for (int i = 0; i < objs.Count - 1; i++)
			{
				GameObject obj = new GameObject();
				obj.name = name + " Span Mesh " + i;
				obj.transform.parent = gameObject.transform;
				PowerLineWireSpan powerLineWireSpan = obj.AddComponent<PowerLineWireSpan>();
				powerLineWireSpan.wirePrefab = wirePrefab;
				powerLineWireSpan.start = objs[i].transform;
				powerLineWireSpan.end = objs[i + 1].transform;
				wire.spans.Add(powerLineWireSpan);
				wire.poles.Add(objs[i + 1].transform);
			}
			PowerLineWireConnectionHelper component = objs[0].GetComponent<PowerLineWireConnectionHelper>();
			if ((bool)copyfrom)
			{
				wire.Copy(copyfrom, component);
			}
			else if ((bool)component)
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
				PowerLineWireConnectionHelper component = powerLineWireSpan.start.GetComponent<PowerLineWireConnectionHelper>();
				PowerLineWireConnectionHelper component2 = powerLineWireSpan.end.GetComponent<PowerLineWireConnectionHelper>();
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
