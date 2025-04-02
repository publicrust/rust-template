using System.Collections.Generic;
using UnityEngine;

public class PowerLineWireSpan : MonoBehaviour
{
	public GameObjectRef wirePrefab;

	public Transform start;

	public Transform end;

	public float WireLength;

	public List<PowerLineWireConnection> connections = new List<PowerLineWireConnection>();

	public void Init(PowerLineWire wire)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)start) && Object.op_Implicit((Object)(object)end))
		{
			WireLength = Vector3.Distance(start.position, end.position);
			for (int i = 0; i < connections.Count; i++)
			{
				Vector3 val = start.TransformPoint(connections[i].outOffset);
				Vector3 val2 = end.TransformPoint(connections[i].inOffset);
				Vector3 val3 = val - val2;
				WireLength = ((Vector3)(ref val3)).magnitude;
				GameObject obj = wirePrefab.Instantiate(((Component)this).transform);
				((Object)obj).name = "WIRE";
				obj.transform.position = Vector3.Lerp(val, val2, 0.5f);
				obj.transform.LookAt(val2);
				obj.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(val, val2));
				obj.SetActive(true);
			}
		}
	}
}
