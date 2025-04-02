using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateDungeonBase : ProceduralComponent
{
	private class DungeonSegment
	{
		public Vector3 position;

		public Quaternion rotation;

		public Prefab prefab;

		public DungeonBaseLink link;

		public int score;

		public int cost;

		public int floor;
	}

	public string EntranceFolder = string.Empty;

	public string LinkFolder = string.Empty;

	public string EndFolder = string.Empty;

	public string TransitionFolder = string.Empty;

	public InfrastructureType ConnectionType = InfrastructureType.UnderwaterLab;

	private static Vector3 VolumeExtrudePositive = Vector3.one * 0.01f;

	private static Vector3 VolumeExtrudeNegative = Vector3.one * -0.01f;

	private const int MaxCount = int.MaxValue;

	private const int MaxDepth = 3;

	private const int MaxFloor = 2;

	private List<DungeonSegment> segmentsTotal = new List<DungeonSegment>();

	private Quaternion[] horizontalRotations = (Quaternion[])(object)new Quaternion[1] { Quaternion.Euler(0f, 0f, 0f) };

	private Quaternion[] pillarRotations = (Quaternion[])(object)new Quaternion[4]
	{
		Quaternion.Euler(0f, 0f, 0f),
		Quaternion.Euler(0f, 90f, 0f),
		Quaternion.Euler(0f, 180f, 0f),
		Quaternion.Euler(0f, 270f, 0f)
	};

	private Quaternion[] verticalRotations = (Quaternion[])(object)new Quaternion[8]
	{
		Quaternion.Euler(0f, 0f, 0f),
		Quaternion.Euler(0f, 45f, 0f),
		Quaternion.Euler(0f, 90f, 0f),
		Quaternion.Euler(0f, 135f, 0f),
		Quaternion.Euler(0f, 180f, 0f),
		Quaternion.Euler(0f, 225f, 0f),
		Quaternion.Euler(0f, 270f, 0f),
		Quaternion.Euler(0f, 315f, 0f)
	};

	public override bool RunOnCache => true;

	public override void Process(uint seed)
	{
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		if (World.Cached)
		{
			TerrainMeta.Path.DungeonBaseRoot = HierarchyUtil.GetRoot("DungeonBase");
		}
		else if (World.Networked)
		{
			World.Spawn("DungeonBase");
			TerrainMeta.Path.DungeonBaseRoot = HierarchyUtil.GetRoot("DungeonBase");
		}
		else
		{
			if (ConnectionType == InfrastructureType.UnderwaterLab && !World.Config.UnderwaterLabs)
			{
				return;
			}
			Prefab<DungeonBaseLink>[] array = Prefab.Load<DungeonBaseLink>("assets/bundled/prefabs/autospawn/" + EntranceFolder, (GameManager)null, (PrefabAttribute.Library)null, useProbabilities: true, useWorldConfig: false);
			if (array == null)
			{
				return;
			}
			Prefab<DungeonBaseLink>[] array2 = Prefab.Load<DungeonBaseLink>("assets/bundled/prefabs/autospawn/" + LinkFolder, (GameManager)null, (PrefabAttribute.Library)null, useProbabilities: true, useWorldConfig: false);
			if (array2 == null)
			{
				return;
			}
			Prefab<DungeonBaseLink>[] array3 = Prefab.Load<DungeonBaseLink>("assets/bundled/prefabs/autospawn/" + EndFolder, (GameManager)null, (PrefabAttribute.Library)null, useProbabilities: true, useWorldConfig: false);
			if (array3 == null)
			{
				return;
			}
			Prefab<DungeonBaseTransition>[] array4 = Prefab.Load<DungeonBaseTransition>("assets/bundled/prefabs/autospawn/" + TransitionFolder, (GameManager)null, (PrefabAttribute.Library)null, useProbabilities: true, useWorldConfig: false);
			if (array4 == null)
			{
				return;
			}
			foreach (DungeonBaseInfo item in Object.op_Implicit((Object)(object)TerrainMeta.Path) ? TerrainMeta.Path.DungeonBaseEntrances : null)
			{
				TerrainPathConnect[] componentsInChildren = ((Component)item).GetComponentsInChildren<TerrainPathConnect>(true);
				foreach (TerrainPathConnect obj in componentsInChildren)
				{
					if (obj.Type != ConnectionType)
					{
						continue;
					}
					uint seed2 = seed++;
					List<DungeonSegment> list = new List<DungeonSegment>();
					DungeonSegment segmentStart = new DungeonSegment();
					int num = 0;
					segmentStart.position = ((Component)item).transform.position;
					segmentStart.rotation = ((Component)item).transform.rotation;
					segmentStart.link = ((Component)item).GetComponentInChildren<DungeonBaseLink>();
					segmentStart.cost = 0;
					segmentStart.floor = 0;
					for (int j = 0; j < 25; j++)
					{
						List<DungeonSegment> list2 = new List<DungeonSegment>();
						list2.Add(segmentStart);
						PlaceSegments(ref seed2, int.MaxValue, 3, 2, attachToFemale: true, attachToMale: false, list2, array2);
						int num2 = list2.Count((DungeonSegment x) => x.link.MaxCountLocal != -1);
						if (num2 > num || (num2 == num && list2.Count > list.Count))
						{
							list = list2;
							num = num2;
						}
					}
					if (list.Count > 5)
					{
						list = list.OrderByDescending((DungeonSegment x) => Vector3Ex.SqrMagnitude2D(x.position - segmentStart.position)).ToList();
						PlaceSegments(ref seed2, 1, 4, 2, attachToFemale: true, attachToMale: false, list, array);
					}
					if (list.Count > 25)
					{
						DungeonSegment segmentEnd = list[list.Count - 1];
						list = list.OrderByDescending((DungeonSegment x) => Mathf.Min(Vector3Ex.SqrMagnitude2D(x.position - segmentStart.position), Vector3Ex.SqrMagnitude2D(x.position - segmentEnd.position))).ToList();
						PlaceSegments(ref seed2, 1, 5, 2, attachToFemale: true, attachToMale: false, list, array);
					}
					bool flag = true;
					while (flag)
					{
						flag = false;
						for (int k = 0; k < list.Count; k++)
						{
							DungeonSegment dungeonSegment = list[k];
							if (dungeonSegment.link.Cost <= 0 && !IsFullyOccupied(list, dungeonSegment))
							{
								list.RemoveAt(k--);
								flag = true;
							}
						}
					}
					PlaceSegments(ref seed2, int.MaxValue, int.MaxValue, 3, attachToFemale: true, attachToMale: true, list, array3);
					PlaceTransitions(ref seed2, list, array4);
					segmentsTotal.AddRange(list);
				}
			}
			foreach (DungeonSegment item2 in segmentsTotal)
			{
				if (item2.prefab != null)
				{
					World.AddPrefab("DungeonBase", item2.prefab, item2.position, item2.rotation, Vector3.one);
				}
			}
			if (Object.op_Implicit((Object)(object)TerrainMeta.Path))
			{
				TerrainMeta.Path.DungeonBaseRoot = HierarchyUtil.GetRoot("DungeonBase");
			}
		}
	}

	private Quaternion[] GetRotationList(DungeonBaseSocketType type)
	{
		return type switch
		{
			DungeonBaseSocketType.Horizontal => horizontalRotations, 
			DungeonBaseSocketType.Vertical => verticalRotations, 
			DungeonBaseSocketType.Pillar => pillarRotations, 
			_ => null, 
		};
	}

	private int GetSocketFloor(DungeonBaseSocketType type)
	{
		if (type != DungeonBaseSocketType.Vertical)
		{
			return 0;
		}
		return 1;
	}

	private bool IsFullyOccupied(List<DungeonSegment> segments, DungeonSegment segment)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		return SocketMatches(segments, segment.link, segment.position, segment.rotation) == segment.link.Sockets.Count;
	}

	private bool NeighbourMatches(List<DungeonSegment> segments, DungeonBaseTransition transition, Vector3 transitionPos, Quaternion transitionRot)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		bool flag2 = false;
		foreach (DungeonSegment segment in segments)
		{
			Vector3 val;
			if ((Object)(object)segment.link == (Object)null)
			{
				val = segment.position - transitionPos;
				if (((Vector3)(ref val)).sqrMagnitude < 0.01f)
				{
					flag = false;
					flag2 = false;
				}
				continue;
			}
			foreach (DungeonBaseSocket socket in segment.link.Sockets)
			{
				val = segment.position + segment.rotation * ((Component)socket).transform.localPosition - transitionPos;
				if (((Vector3)(ref val)).sqrMagnitude < 0.01f)
				{
					if (!flag && segment.link.Type == transition.Neighbour1)
					{
						flag = true;
					}
					else if (!flag2 && segment.link.Type == transition.Neighbour2)
					{
						flag2 = true;
					}
				}
			}
		}
		return flag && flag2;
	}

	private int SocketMatches(List<DungeonSegment> segments, DungeonBaseLink link, Vector3 linkPos, Quaternion linkRot)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		foreach (DungeonSegment segment in segments)
		{
			foreach (DungeonBaseSocket socket in segment.link.Sockets)
			{
				Vector3 val = segment.position + segment.rotation * ((Component)socket).transform.localPosition;
				foreach (DungeonBaseSocket socket2 in link.Sockets)
				{
					if (!((Object)(object)socket == (Object)(object)socket2))
					{
						Vector3 val2 = linkPos + linkRot * ((Component)socket2).transform.localPosition;
						Vector3 val3 = val - val2;
						if (((Vector3)(ref val3)).sqrMagnitude < 0.01f)
						{
							num++;
						}
					}
				}
			}
		}
		return num;
	}

	private bool IsOccupied(List<DungeonSegment> segments, DungeonBaseSocket socket, Vector3 socketPos, Quaternion socketRot)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		foreach (DungeonSegment segment in segments)
		{
			foreach (DungeonBaseSocket socket2 in segment.link.Sockets)
			{
				if (!((Object)(object)socket2 == (Object)(object)socket))
				{
					Vector3 val = segment.position + segment.rotation * ((Component)socket2).transform.localPosition - socketPos;
					if (((Vector3)(ref val)).sqrMagnitude < 0.01f)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private int CountLocal(List<DungeonSegment> segments, DungeonBaseLink link)
	{
		int num = 0;
		if ((Object)(object)link == (Object)null)
		{
			return num;
		}
		foreach (DungeonSegment segment in segments)
		{
			if (!((Object)(object)segment.link == (Object)null))
			{
				if ((Object)(object)segment.link == (Object)(object)link)
				{
					num++;
				}
				else if (segment.link.MaxCountIdentifier >= 0 && segment.link.MaxCountIdentifier == link.MaxCountIdentifier)
				{
					num++;
				}
			}
		}
		return num;
	}

	private int CountGlobal(List<DungeonSegment> segments, DungeonBaseLink link)
	{
		int num = 0;
		if ((Object)(object)link == (Object)null)
		{
			return num;
		}
		foreach (DungeonSegment segment in segments)
		{
			if (!((Object)(object)segment.link == (Object)null))
			{
				if ((Object)(object)segment.link == (Object)(object)link)
				{
					num++;
				}
				else if (segment.link.MaxCountIdentifier >= 0 && segment.link.MaxCountIdentifier == link.MaxCountIdentifier)
				{
					num++;
				}
			}
		}
		foreach (DungeonSegment item in segmentsTotal)
		{
			if (!((Object)(object)item.link == (Object)null))
			{
				if ((Object)(object)item.link == (Object)(object)link)
				{
					num++;
				}
				else if (item.link.MaxCountIdentifier >= 0 && item.link.MaxCountIdentifier == link.MaxCountIdentifier)
				{
					num++;
				}
			}
		}
		return num;
	}

	private bool IsBlocked(List<DungeonSegment> segments, DungeonBaseLink link, Vector3 linkPos, Quaternion linkRot)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val3;
		foreach (DungeonVolume volume in link.Volumes)
		{
			OBB bounds = volume.GetBounds(linkPos, linkRot, VolumeExtrudeNegative);
			OBB bounds2 = volume.GetBounds(linkPos, linkRot, VolumeExtrudePositive);
			foreach (DungeonSegment segment in segments)
			{
				foreach (DungeonVolume volume2 in segment.link.Volumes)
				{
					OBB bounds3 = volume2.GetBounds(segment.position, segment.rotation, VolumeExtrudeNegative);
					if (((OBB)(ref bounds)).Intersects(bounds3))
					{
						return true;
					}
				}
				foreach (DungeonBaseSocket socket in segment.link.Sockets)
				{
					Vector3 val = segment.position + segment.rotation * ((Component)socket).transform.localPosition;
					if (!((OBB)(ref bounds2)).Contains(val))
					{
						continue;
					}
					bool flag = false;
					foreach (DungeonBaseSocket socket2 in link.Sockets)
					{
						Vector3 val2 = linkPos + linkRot * ((Component)socket2).transform.localPosition;
						val3 = val - val2;
						if (((Vector3)(ref val3)).sqrMagnitude < 0.01f)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						return true;
					}
				}
			}
		}
		foreach (DungeonSegment segment2 in segments)
		{
			foreach (DungeonVolume volume3 in segment2.link.Volumes)
			{
				OBB bounds4 = volume3.GetBounds(segment2.position, segment2.rotation, VolumeExtrudePositive);
				foreach (DungeonBaseSocket socket3 in link.Sockets)
				{
					Vector3 val4 = linkPos + linkRot * ((Component)socket3).transform.localPosition;
					if (!((OBB)(ref bounds4)).Contains(val4))
					{
						continue;
					}
					bool flag2 = false;
					foreach (DungeonBaseSocket socket4 in segment2.link.Sockets)
					{
						val3 = segment2.position + segment2.rotation * ((Component)socket4).transform.localPosition - val4;
						if (((Vector3)(ref val3)).sqrMagnitude < 0.01f)
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private void PlaceSegments(ref uint seed, int count, int budget, int floors, bool attachToFemale, bool attachToMale, List<DungeonSegment> segments, Prefab<DungeonBaseLink>[] prefabs)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		for (int i = 0; i < segments.Count; i++)
		{
			DungeonSegment dungeonSegment = segments[i];
			if (dungeonSegment.cost >= budget)
			{
				continue;
			}
			int num2 = SeedRandom.Range(ref seed, 0, dungeonSegment.link.Sockets.Count);
			for (int j = 0; j < dungeonSegment.link.Sockets.Count; j++)
			{
				DungeonBaseSocket dungeonBaseSocket = dungeonSegment.link.Sockets[(j + num2) % dungeonSegment.link.Sockets.Count];
				if (!(dungeonBaseSocket.Female && attachToFemale) && !(dungeonBaseSocket.Male && attachToMale))
				{
					continue;
				}
				Vector3 val = dungeonSegment.position + dungeonSegment.rotation * ((Component)dungeonBaseSocket).transform.localPosition;
				Quaternion val2 = dungeonSegment.rotation * ((Component)dungeonBaseSocket).transform.localRotation;
				if (IsOccupied(segments, dungeonBaseSocket, val, val2))
				{
					continue;
				}
				prefabs.Shuffle(ref seed);
				DungeonSegment dungeonSegment2 = null;
				Quaternion[] rotationList = GetRotationList(dungeonBaseSocket.Type);
				foreach (Prefab<DungeonBaseLink> prefab in prefabs)
				{
					DungeonBaseLink component = prefab.Component;
					if (component.MaxCountLocal == 0 || component.MaxCountGlobal == 0 || (component.MaxFloor >= 0 && dungeonSegment.floor > component.MaxFloor))
					{
						continue;
					}
					int num3 = dungeonSegment.cost + component.Cost;
					if (num3 > budget)
					{
						continue;
					}
					int num4 = dungeonSegment.floor + GetSocketFloor(dungeonBaseSocket.Type);
					if (num4 > floors)
					{
						continue;
					}
					DungeonBaseSocket linkSocket = null;
					Vector3 linkPos = Vector3.zero;
					Quaternion linkRot = Quaternion.identity;
					int linkScore = 0;
					if (Place(ref seed, segments, dungeonBaseSocket, val, val2, prefab, rotationList, out linkSocket, out linkPos, out linkRot, out linkScore) && (component.MaxCountLocal <= 0 || CountLocal(segments, component) < component.MaxCountLocal) && (component.MaxCountGlobal <= 0 || CountGlobal(segments, component) < component.MaxCountGlobal))
					{
						DungeonSegment dungeonSegment3 = new DungeonSegment();
						dungeonSegment3.position = linkPos;
						dungeonSegment3.rotation = linkRot;
						dungeonSegment3.prefab = prefab;
						dungeonSegment3.link = component;
						dungeonSegment3.score = linkScore;
						dungeonSegment3.cost = num3;
						dungeonSegment3.floor = num4;
						if (dungeonSegment2 == null || dungeonSegment2.score < dungeonSegment3.score)
						{
							dungeonSegment2 = dungeonSegment3;
						}
					}
				}
				if (dungeonSegment2 != null)
				{
					segments.Add(dungeonSegment2);
					num++;
					if (num >= count)
					{
						return;
					}
				}
			}
		}
	}

	private void PlaceTransitions(ref uint seed, List<DungeonSegment> segments, Prefab<DungeonBaseTransition>[] prefabs)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		int count = segments.Count;
		for (int i = 0; i < count; i++)
		{
			DungeonSegment dungeonSegment = segments[i];
			int num = SeedRandom.Range(ref seed, 0, dungeonSegment.link.Sockets.Count);
			for (int j = 0; j < dungeonSegment.link.Sockets.Count; j++)
			{
				DungeonBaseSocket dungeonBaseSocket = dungeonSegment.link.Sockets[(j + num) % dungeonSegment.link.Sockets.Count];
				Vector3 val = dungeonSegment.position + dungeonSegment.rotation * ((Component)dungeonBaseSocket).transform.localPosition;
				Quaternion val2 = dungeonSegment.rotation * ((Component)dungeonBaseSocket).transform.localRotation;
				prefabs.Shuffle(ref seed);
				foreach (Prefab<DungeonBaseTransition> prefab in prefabs)
				{
					if (dungeonBaseSocket.Type == prefab.Component.Type && NeighbourMatches(segments, prefab.Component, val, val2))
					{
						DungeonSegment dungeonSegment2 = new DungeonSegment();
						dungeonSegment2.position = val;
						dungeonSegment2.rotation = val2;
						dungeonSegment2.prefab = prefab;
						dungeonSegment2.link = null;
						dungeonSegment2.score = 0;
						dungeonSegment2.cost = 0;
						dungeonSegment2.floor = 0;
						segments.Add(dungeonSegment2);
						break;
					}
				}
			}
		}
	}

	private bool Place(ref uint seed, List<DungeonSegment> segments, DungeonBaseSocket targetSocket, Vector3 targetPos, Quaternion targetRot, Prefab<DungeonBaseLink> prefab, Quaternion[] rotations, out DungeonBaseSocket linkSocket, out Vector3 linkPos, out Quaternion linkRot, out int linkScore)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		linkSocket = null;
		linkPos = Vector3.one;
		linkRot = Quaternion.identity;
		linkScore = 0;
		DungeonBaseLink component = prefab.Component;
		int num = SeedRandom.Range(ref seed, 0, component.Sockets.Count);
		for (int i = 0; i < component.Sockets.Count; i++)
		{
			DungeonBaseSocket dungeonBaseSocket = component.Sockets[(i + num) % component.Sockets.Count];
			if (dungeonBaseSocket.Type != targetSocket.Type || ((!dungeonBaseSocket.Male || !targetSocket.Female) && (!dungeonBaseSocket.Female || !targetSocket.Male)))
			{
				continue;
			}
			rotations.Shuffle(ref seed);
			foreach (Quaternion val in rotations)
			{
				Quaternion val2 = Quaternion.FromToRotation(-((Component)dungeonBaseSocket).transform.forward, targetRot * Vector3.forward);
				if (dungeonBaseSocket.Type != DungeonBaseSocketType.Vertical)
				{
					val2 = QuaternionEx.LookRotationForcedUp(val2 * Vector3.forward, Vector3.up);
				}
				Quaternion val3 = val * val2;
				Vector3 val4 = targetPos - val3 * ((Component)dungeonBaseSocket).transform.localPosition;
				if (!IsBlocked(segments, component, val4, val3))
				{
					int num2 = SocketMatches(segments, component, val4, val3);
					if (num2 > linkScore && prefab.CheckEnvironmentVolumesOutsideTerrain(val4, val3, Vector3.one, EnvironmentType.UnderwaterLab, 1f))
					{
						linkSocket = dungeonBaseSocket;
						linkPos = val4;
						linkRot = val3;
						linkScore = num2;
					}
				}
			}
		}
		return linkScore > 0;
	}

	public static void SetupAI()
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)TerrainMeta.Path == (Object)null || TerrainMeta.Path.DungeonBaseEntrances == null)
		{
			return;
		}
		foreach (DungeonBaseInfo dungeonBaseEntrance in TerrainMeta.Path.DungeonBaseEntrances)
		{
			if ((Object)(object)dungeonBaseEntrance == (Object)null)
			{
				continue;
			}
			List<AIInformationZone> list = new List<AIInformationZone>();
			int num = 0;
			AIInformationZone componentInChildren = ((Component)dungeonBaseEntrance).GetComponentInChildren<AIInformationZone>();
			if ((Object)(object)componentInChildren != (Object)null)
			{
				list.Add(componentInChildren);
				num++;
			}
			foreach (GameObject link in ((Component)dungeonBaseEntrance).GetComponent<DungeonBaseInfo>().Links)
			{
				AIInformationZone componentInChildren2 = link.GetComponentInChildren<AIInformationZone>();
				if (!((Object)(object)componentInChildren2 == (Object)null))
				{
					list.Add(componentInChildren2);
					num++;
				}
			}
			GameObject val = new GameObject("AIZ");
			val.transform.position = ((Component)dungeonBaseEntrance).gameObject.transform.position;
			AIInformationZone aIInformationZone = AIInformationZone.Merge(list, val);
			aIInformationZone.ShouldSleepAI = true;
			val.transform.SetParent(((Component)dungeonBaseEntrance).gameObject.transform);
			GameObject val2 = new GameObject("WakeTrigger");
			val2.transform.position = val.transform.position + ((Bounds)(ref aIInformationZone.bounds)).center;
			val2.transform.localScale = ((Bounds)(ref aIInformationZone.bounds)).extents + new Vector3(100f, 100f, 100f);
			((Collider)val2.AddComponent<BoxCollider>()).isTrigger = true;
			val2.layer = LayerMask.NameToLayer("Trigger");
			val2.transform.SetParent(((Component)dungeonBaseEntrance).gameObject.transform);
			TriggerWakeAIZ triggerWakeAIZ = val2.AddComponent<TriggerWakeAIZ>();
			triggerWakeAIZ.interestLayers = LayerMask.op_Implicit(LayerMask.GetMask(new string[1] { "Player (Server)" }));
			triggerWakeAIZ.Init(aIInformationZone);
		}
	}
}
