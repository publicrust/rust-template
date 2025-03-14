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

	private Quaternion[] horizontalRotations = new Quaternion[1] { Quaternion.Euler(0f, 0f, 0f) };

	private Quaternion[] pillarRotations = new Quaternion[4]
	{
		Quaternion.Euler(0f, 0f, 0f),
		Quaternion.Euler(0f, 90f, 0f),
		Quaternion.Euler(0f, 180f, 0f),
		Quaternion.Euler(0f, 270f, 0f)
	};

	private Quaternion[] verticalRotations = new Quaternion[8]
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
			Prefab<DungeonBaseLink>[] array = Prefab.Load<DungeonBaseLink>("assets/bundled/prefabs/autospawn/" + EntranceFolder, null, null, useProbabilities: true, useWorldConfig: false);
			if (array == null)
			{
				return;
			}
			Prefab<DungeonBaseLink>[] array2 = Prefab.Load<DungeonBaseLink>("assets/bundled/prefabs/autospawn/" + LinkFolder, null, null, useProbabilities: true, useWorldConfig: false);
			if (array2 == null)
			{
				return;
			}
			Prefab<DungeonBaseLink>[] array3 = Prefab.Load<DungeonBaseLink>("assets/bundled/prefabs/autospawn/" + EndFolder, null, null, useProbabilities: true, useWorldConfig: false);
			if (array3 == null)
			{
				return;
			}
			Prefab<DungeonBaseTransition>[] array4 = Prefab.Load<DungeonBaseTransition>("assets/bundled/prefabs/autospawn/" + TransitionFolder, null, null, useProbabilities: true, useWorldConfig: false);
			if (array4 == null)
			{
				return;
			}
			foreach (DungeonBaseInfo item in TerrainMeta.Path ? TerrainMeta.Path.DungeonBaseEntrances : null)
			{
				TerrainPathConnect[] componentsInChildren = item.GetComponentsInChildren<TerrainPathConnect>(includeInactive: true);
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
					segmentStart.position = item.transform.position;
					segmentStart.rotation = item.transform.rotation;
					segmentStart.link = item.GetComponentInChildren<DungeonBaseLink>();
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
						list = list.OrderByDescending((DungeonSegment x) => (x.position - segmentStart.position).SqrMagnitude2D()).ToList();
						PlaceSegments(ref seed2, 1, 4, 2, attachToFemale: true, attachToMale: false, list, array);
					}
					if (list.Count > 25)
					{
						DungeonSegment segmentEnd = list[list.Count - 1];
						list = list.OrderByDescending((DungeonSegment x) => Mathf.Min((x.position - segmentStart.position).SqrMagnitude2D(), (x.position - segmentEnd.position).SqrMagnitude2D())).ToList();
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
			if ((bool)TerrainMeta.Path)
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
		return SocketMatches(segments, segment.link, segment.position, segment.rotation) == segment.link.Sockets.Count;
	}

	private bool NeighbourMatches(List<DungeonSegment> segments, DungeonBaseTransition transition, Vector3 transitionPos, Quaternion transitionRot)
	{
		bool flag = false;
		bool flag2 = false;
		foreach (DungeonSegment segment in segments)
		{
			if (segment.link == null)
			{
				if ((segment.position - transitionPos).sqrMagnitude < 0.01f)
				{
					flag = false;
					flag2 = false;
				}
				continue;
			}
			foreach (DungeonBaseSocket socket in segment.link.Sockets)
			{
				if ((segment.position + segment.rotation * socket.transform.localPosition - transitionPos).sqrMagnitude < 0.01f)
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
		int num = 0;
		foreach (DungeonSegment segment in segments)
		{
			foreach (DungeonBaseSocket socket in segment.link.Sockets)
			{
				Vector3 vector = segment.position + segment.rotation * socket.transform.localPosition;
				foreach (DungeonBaseSocket socket2 in link.Sockets)
				{
					if (!(socket == socket2))
					{
						Vector3 vector2 = linkPos + linkRot * socket2.transform.localPosition;
						if ((vector - vector2).sqrMagnitude < 0.01f)
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
		foreach (DungeonSegment segment in segments)
		{
			foreach (DungeonBaseSocket socket2 in segment.link.Sockets)
			{
				if (!(socket2 == socket) && (segment.position + segment.rotation * socket2.transform.localPosition - socketPos).sqrMagnitude < 0.01f)
				{
					return true;
				}
			}
		}
		return false;
	}

	private int CountLocal(List<DungeonSegment> segments, DungeonBaseLink link)
	{
		int num = 0;
		if (link == null)
		{
			return num;
		}
		foreach (DungeonSegment segment in segments)
		{
			if (!(segment.link == null))
			{
				if (segment.link == link)
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
		if (link == null)
		{
			return num;
		}
		foreach (DungeonSegment segment in segments)
		{
			if (!(segment.link == null))
			{
				if (segment.link == link)
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
			if (!(item.link == null))
			{
				if (item.link == link)
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
		foreach (DungeonVolume volume in link.Volumes)
		{
			OBB bounds = volume.GetBounds(linkPos, linkRot, VolumeExtrudeNegative);
			OBB bounds2 = volume.GetBounds(linkPos, linkRot, VolumeExtrudePositive);
			foreach (DungeonSegment segment in segments)
			{
				foreach (DungeonVolume volume2 in segment.link.Volumes)
				{
					OBB bounds3 = volume2.GetBounds(segment.position, segment.rotation, VolumeExtrudeNegative);
					if (bounds.Intersects(bounds3))
					{
						return true;
					}
				}
				foreach (DungeonBaseSocket socket in segment.link.Sockets)
				{
					Vector3 vector = segment.position + segment.rotation * socket.transform.localPosition;
					if (!bounds2.Contains(vector))
					{
						continue;
					}
					bool flag = false;
					foreach (DungeonBaseSocket socket2 in link.Sockets)
					{
						Vector3 vector2 = linkPos + linkRot * socket2.transform.localPosition;
						if ((vector - vector2).sqrMagnitude < 0.01f)
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
					Vector3 vector3 = linkPos + linkRot * socket3.transform.localPosition;
					if (!bounds4.Contains(vector3))
					{
						continue;
					}
					bool flag2 = false;
					foreach (DungeonBaseSocket socket4 in segment2.link.Sockets)
					{
						if ((segment2.position + segment2.rotation * socket4.transform.localPosition - vector3).sqrMagnitude < 0.01f)
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
				Vector3 vector = dungeonSegment.position + dungeonSegment.rotation * dungeonBaseSocket.transform.localPosition;
				Quaternion quaternion = dungeonSegment.rotation * dungeonBaseSocket.transform.localRotation;
				if (IsOccupied(segments, dungeonBaseSocket, vector, quaternion))
				{
					continue;
				}
				ArrayEx.Shuffle(prefabs, ref seed);
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
					if (Place(ref seed, segments, dungeonBaseSocket, vector, quaternion, prefab, rotationList, out linkSocket, out linkPos, out linkRot, out linkScore) && (component.MaxCountLocal <= 0 || CountLocal(segments, component) < component.MaxCountLocal) && (component.MaxCountGlobal <= 0 || CountGlobal(segments, component) < component.MaxCountGlobal))
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
		int count = segments.Count;
		for (int i = 0; i < count; i++)
		{
			DungeonSegment dungeonSegment = segments[i];
			int num = SeedRandom.Range(ref seed, 0, dungeonSegment.link.Sockets.Count);
			for (int j = 0; j < dungeonSegment.link.Sockets.Count; j++)
			{
				DungeonBaseSocket dungeonBaseSocket = dungeonSegment.link.Sockets[(j + num) % dungeonSegment.link.Sockets.Count];
				Vector3 vector = dungeonSegment.position + dungeonSegment.rotation * dungeonBaseSocket.transform.localPosition;
				Quaternion quaternion = dungeonSegment.rotation * dungeonBaseSocket.transform.localRotation;
				ArrayEx.Shuffle(prefabs, ref seed);
				foreach (Prefab<DungeonBaseTransition> prefab in prefabs)
				{
					if (dungeonBaseSocket.Type == prefab.Component.Type && NeighbourMatches(segments, prefab.Component, vector, quaternion))
					{
						DungeonSegment dungeonSegment2 = new DungeonSegment();
						dungeonSegment2.position = vector;
						dungeonSegment2.rotation = quaternion;
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
			ArrayEx.Shuffle(rotations, ref seed);
			foreach (Quaternion quaternion in rotations)
			{
				Quaternion quaternion2 = Quaternion.FromToRotation(-dungeonBaseSocket.transform.forward, targetRot * Vector3.forward);
				if (dungeonBaseSocket.Type != DungeonBaseSocketType.Vertical)
				{
					quaternion2 = QuaternionEx.LookRotationForcedUp(quaternion2 * Vector3.forward, Vector3.up);
				}
				Quaternion quaternion3 = quaternion * quaternion2;
				Vector3 vector = targetPos - quaternion3 * dungeonBaseSocket.transform.localPosition;
				if (!IsBlocked(segments, component, vector, quaternion3))
				{
					int num2 = SocketMatches(segments, component, vector, quaternion3);
					if (num2 > linkScore && prefab.CheckEnvironmentVolumesOutsideTerrain(vector, quaternion3, Vector3.one, EnvironmentType.UnderwaterLab, 1f))
					{
						linkSocket = dungeonBaseSocket;
						linkPos = vector;
						linkRot = quaternion3;
						linkScore = num2;
					}
				}
			}
		}
		return linkScore > 0;
	}

	public static void SetupAI()
	{
		if (TerrainMeta.Path == null || TerrainMeta.Path.DungeonBaseEntrances == null)
		{
			return;
		}
		foreach (DungeonBaseInfo dungeonBaseEntrance in TerrainMeta.Path.DungeonBaseEntrances)
		{
			if (dungeonBaseEntrance == null)
			{
				continue;
			}
			List<AIInformationZone> list = new List<AIInformationZone>();
			int num = 0;
			AIInformationZone componentInChildren = dungeonBaseEntrance.GetComponentInChildren<AIInformationZone>();
			if (componentInChildren != null)
			{
				list.Add(componentInChildren);
				num++;
			}
			foreach (GameObject link in dungeonBaseEntrance.GetComponent<DungeonBaseInfo>().Links)
			{
				AIInformationZone componentInChildren2 = link.GetComponentInChildren<AIInformationZone>();
				if (!(componentInChildren2 == null))
				{
					list.Add(componentInChildren2);
					num++;
				}
			}
			GameObject gameObject = new GameObject("AIZ");
			gameObject.transform.position = dungeonBaseEntrance.gameObject.transform.position;
			AIInformationZone aIInformationZone = AIInformationZone.Merge(list, gameObject);
			aIInformationZone.ShouldSleepAI = true;
			gameObject.transform.SetParent(dungeonBaseEntrance.gameObject.transform);
			GameObject obj = new GameObject("WakeTrigger");
			obj.transform.position = gameObject.transform.position + aIInformationZone.bounds.center;
			obj.transform.localScale = aIInformationZone.bounds.extents + new Vector3(100f, 100f, 100f);
			obj.AddComponent<BoxCollider>().isTrigger = true;
			obj.layer = LayerMask.NameToLayer("Trigger");
			obj.transform.SetParent(dungeonBaseEntrance.gameObject.transform);
			TriggerWakeAIZ triggerWakeAIZ = obj.AddComponent<TriggerWakeAIZ>();
			triggerWakeAIZ.interestLayers = LayerMask.GetMask("Player (Server)");
			triggerWakeAIZ.Init(aIInformationZone);
		}
	}
}
