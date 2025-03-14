#define UNITY_ASSERTIONS
using System;
using System.Collections.Generic;
using ConVar;
using Facepunch;
using Network;
using ProtoBuf;
using UnityEngine;
using UnityEngine.Assertions;

public class ZiplineLaunchPoint : BaseEntity
{
	public Transform LineDeparturePoint;

	public LineRenderer ZiplineRenderer;

	public Collider MountCollider;

	public BoxCollider[] BuildingBlocks;

	public BoxCollider[] PointBuildingBlocks;

	public SpawnableBoundsBlocker[] SpawnableBoundsBlockers;

	public GameObjectRef MountableRef;

	public float LineSlackAmount = 2f;

	public bool RegenLine;

	public List<Vector3> ziplineTargets = new List<Vector3>();

	private List<Vector3> linePoints;

	public GameObjectRef ArrivalPointRef;

	public override bool OnRpcMessage(BasePlayer player, uint rpc, Message msg)
	{
		using (TimeWarning.New("ZiplineLaunchPoint.OnRpcMessage"))
		{
			if (rpc == 2256922575u && player != null)
			{
				Assert.IsTrue(player.isServer, "SV_RPC Message is using a clientside player!");
				if (Global.developer > 2)
				{
					Debug.Log(string.Concat("SV_RPCMessage: ", player, " - MountPlayer "));
				}
				using (TimeWarning.New("MountPlayer"))
				{
					using (TimeWarning.New("Conditions"))
					{
						if (!RPC_Server.CallsPerSecond.Test(2256922575u, "MountPlayer", this, player, 2uL))
						{
							return true;
						}
						if (!RPC_Server.IsVisible.Test(2256922575u, "MountPlayer", this, player, 3f))
						{
							return true;
						}
					}
					try
					{
						using (TimeWarning.New("Call"))
						{
							RPCMessage rPCMessage = default(RPCMessage);
							rPCMessage.connection = msg.connection;
							rPCMessage.player = player;
							rPCMessage.read = msg.read;
							RPCMessage msg2 = rPCMessage;
							MountPlayer(msg2);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						player.Kick("RPC Error in MountPlayer");
					}
				}
				return true;
			}
		}
		return base.OnRpcMessage(player, rpc, msg);
	}

	public override void ResetState()
	{
		base.ResetState();
		ziplineTargets.Clear();
		linePoints = null;
	}

	public override void PostMapEntitySpawn()
	{
		base.PostMapEntitySpawn();
		FindZiplineTarget(ref ziplineTargets);
		CalculateZiplinePoints(ziplineTargets, ref linePoints);
		if (ziplineTargets.Count == 0)
		{
			Kill();
			return;
		}
		if (Vector3.Distance(linePoints[0], linePoints[linePoints.Count - 1]) > 100f && ArrivalPointRef != null && ArrivalPointRef.isValid)
		{
			ZiplineArrivalPoint obj = base.gameManager.CreateEntity(ArrivalPointRef.resourcePath, linePoints[linePoints.Count - 1]) as ZiplineArrivalPoint;
			obj.SetPositions(linePoints);
			obj.Spawn();
		}
		UpdateBuildingBlocks();
		SendNetworkUpdate();
	}

	public void FindZiplineTarget(ref List<Vector3> foundPositions)
	{
		foundPositions.Clear();
		Vector3 position = LineDeparturePoint.position;
		List<ZiplineTarget> list = Facepunch.Pool.GetList<ZiplineTarget>();
		GamePhysics.OverlapSphere(position + base.transform.forward * 200f, 200f, list, 1218511105);
		ZiplineTarget ziplineTarget = null;
		float num = float.MaxValue;
		float num2 = 3f;
		foreach (ZiplineTarget item in list)
		{
			if (item.IsChainPoint)
			{
				continue;
			}
			Vector3 position2 = item.transform.position;
			float num3 = Vector3.Dot((position2.WithY(position.y) - position).normalized, base.transform.forward);
			float num4 = Vector3.Distance(position, position2);
			if (!(num3 > 0.2f) || !item.IsValidPosition(position) || !(position.y + num2 > position2.y) || !(num4 > 10f) || !(num4 < num))
			{
				continue;
			}
			if (CheckLineOfSight(position, position2))
			{
				num = num4;
				ziplineTarget = item;
				foundPositions.Clear();
				foundPositions.Add(ziplineTarget.transform.position);
				continue;
			}
			foreach (ZiplineTarget item2 in list)
			{
				if (!item2.IsChainPoint || !item2.IsValidChainPoint(position, position2))
				{
					continue;
				}
				bool flag = CheckLineOfSight(position, item2.transform.position);
				bool flag2 = CheckLineOfSight(item2.transform.position, position2);
				if (flag && flag2)
				{
					num = num4;
					ziplineTarget = item;
					foundPositions.Clear();
					foundPositions.Add(item2.transform.position);
					foundPositions.Add(ziplineTarget.transform.position);
				}
				else
				{
					if (!flag)
					{
						continue;
					}
					foreach (ZiplineTarget item3 in list)
					{
						if (!(item3 == item2) && item3.IsValidChainPoint(item2.Target.position, item.Target.position))
						{
							bool num5 = CheckLineOfSight(item2.transform.position, item3.transform.position);
							bool flag3 = CheckLineOfSight(item3.transform.position, item.transform.position);
							if (num5 && flag3)
							{
								num = num4;
								ziplineTarget = item;
								foundPositions.Clear();
								foundPositions.Add(item2.transform.position);
								foundPositions.Add(item3.transform.position);
								foundPositions.Add(ziplineTarget.transform.position);
							}
						}
					}
				}
			}
		}
	}

	public bool CheckLineOfSight(Vector3 from, Vector3 to)
	{
		Vector3 vector = CalculateLineMidPoint(from, to) - Vector3.up * 0.75f;
		if (GamePhysics.LineOfSightRadius(from, to, 1218511105, 0.5f, 2f) && GamePhysics.LineOfSightRadius(from, vector, 1218511105, 0.5f, 2f))
		{
			return GamePhysics.LineOfSightRadius(vector, to, 1218511105, 0.5f, 2f);
		}
		return false;
	}

	[RPC_Server]
	[RPC_Server.IsVisible(3f)]
	[RPC_Server.CallsPerSecond(2uL)]
	public void MountPlayer(RPCMessage msg)
	{
		if (IsBusy() || msg.player == null || msg.player.Distance(LineDeparturePoint.position) > 3f || !IsPlayerFacingValidDirection(msg.player) || ziplineTargets.Count == 0)
		{
			return;
		}
		Vector3 position = LineDeparturePoint.position;
		Quaternion lineStartRot = Quaternion.LookRotation((ziplineTargets[0].WithY(position.y) - position).normalized);
		Quaternion rot = Quaternion.LookRotation((position - msg.player.transform.position.WithY(position.y)).normalized);
		ZiplineMountable ziplineMountable = base.gameManager.CreateEntity(MountableRef.resourcePath, msg.player.transform.position + Vector3.up * 2.1f, rot) as ZiplineMountable;
		if (ziplineMountable != null)
		{
			CalculateZiplinePoints(ziplineTargets, ref linePoints);
			ziplineMountable.SetDestination(linePoints, position, lineStartRot);
			ziplineMountable.Spawn();
			ziplineMountable.MountPlayer(msg.player);
			if (msg.player.GetMounted() != ziplineMountable)
			{
				ziplineMountable.Kill();
			}
			SetFlag(Flags.Busy, b: true);
			Invoke(ClearBusy, 2f);
		}
	}

	public void ClearBusy()
	{
		SetFlag(Flags.Busy, b: false);
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.msg.zipline == null)
		{
			info.msg.zipline = Facepunch.Pool.Get<Zipline>();
		}
		info.msg.zipline.destinationPoints = Facepunch.Pool.GetList<VectorData>();
		foreach (Vector3 ziplineTarget in ziplineTargets)
		{
			info.msg.zipline.destinationPoints.Add(new VectorData(ziplineTarget.x, ziplineTarget.y, ziplineTarget.z));
		}
	}

	[ServerVar(ServerAdmin = true)]
	public static void report(ConsoleSystem.Arg arg)
	{
		float num = 0f;
		int num2 = 0;
		int num3 = 0;
		foreach (BaseNetworkable serverEntity in BaseNetworkable.serverEntities)
		{
			if (serverEntity is ZiplineLaunchPoint ziplineLaunchPoint)
			{
				float lineLength = ziplineLaunchPoint.GetLineLength();
				num2++;
				num += lineLength;
			}
			else if (serverEntity is ZiplineArrivalPoint)
			{
				num3++;
			}
		}
		arg.ReplyWith($"{num2} ziplines, total distance: {num:F2}, avg length: {num / (float)num2:F2}, arrival points: {num3}");
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
		if (info.msg.zipline == null)
		{
			return;
		}
		ziplineTargets.Clear();
		foreach (VectorData destinationPoint in info.msg.zipline.destinationPoints)
		{
			ziplineTargets.Add(destinationPoint);
		}
	}

	private void CalculateZiplinePoints(List<Vector3> targets, ref List<Vector3> points)
	{
		if (points == null && targets.Count != 0)
		{
			Vector3[] array = new Vector3[targets.Count + 1];
			array[0] = LineDeparturePoint.position;
			for (int i = 0; i < targets.Count; i++)
			{
				array[i + 1] = targets[i];
			}
			float[] array2 = new float[array.Length];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = LineSlackAmount;
			}
			points = Facepunch.Pool.GetList<Vector3>();
			Bezier.ApplyLineSlack(array, array2, ref points, 25);
		}
	}

	public Vector3 CalculateLineMidPoint(Vector3 start, Vector3 endPoint)
	{
		Vector3 result = Vector3.Lerp(start, endPoint, 0.5f);
		result.y -= LineSlackAmount;
		return result;
	}

	public void UpdateBuildingBlocks()
	{
		BoxCollider[] buildingBlocks = BuildingBlocks;
		for (int i = 0; i < buildingBlocks.Length; i++)
		{
			buildingBlocks[i].gameObject.SetActive(value: false);
		}
		buildingBlocks = PointBuildingBlocks;
		for (int i = 0; i < buildingBlocks.Length; i++)
		{
			buildingBlocks[i].gameObject.SetActive(value: false);
		}
		SpawnableBoundsBlocker[] spawnableBoundsBlockers = SpawnableBoundsBlockers;
		for (int i = 0; i < spawnableBoundsBlockers.Length; i++)
		{
			spawnableBoundsBlockers[i].gameObject.SetActive(value: false);
		}
		int num = 0;
		if (ziplineTargets.Count <= 0)
		{
			return;
		}
		Vector3 vector = Vector3.zero;
		int startIndex2 = 0;
		for (int j = 0; j < linePoints.Count; j++)
		{
			if (j == 0 || (base.isClient && j == 1))
			{
				continue;
			}
			Vector3 vector2 = linePoints[j];
			Vector3 normalized = (vector2 - linePoints[j - 1].WithY(vector2.y)).normalized;
			if (vector != Vector3.zero && Vector3.Dot(normalized, vector) < 0.98f)
			{
				if (num < BuildingBlocks.Length)
				{
					SetUpBuildingBlock(BuildingBlocks[num], PointBuildingBlocks[num], SpawnableBoundsBlockers[num++], startIndex2, j - 1);
				}
				startIndex2 = j - 1;
			}
			vector = normalized;
		}
		if (num < BuildingBlocks.Length)
		{
			SetUpBuildingBlock(BuildingBlocks[num], PointBuildingBlocks[num], SpawnableBoundsBlockers[num], startIndex2, linePoints.Count - 1);
		}
		void SetUpBuildingBlock(BoxCollider longCollider, BoxCollider pointCollider, SpawnableBoundsBlocker spawnBlocker, int startIndex, int endIndex)
		{
			Vector3 vector3 = linePoints[startIndex];
			Vector3 vector4 = linePoints[endIndex];
			Vector3 vector5 = Vector3.zero;
			Quaternion rotation = Quaternion.LookRotation((vector3 - vector4).normalized, Vector3.up);
			Vector3 position = Vector3.Lerp(vector3, vector4, 0.5f);
			longCollider.transform.position = position;
			longCollider.transform.rotation = rotation;
			for (int k = startIndex; k < endIndex; k++)
			{
				Vector3 vector6 = longCollider.transform.InverseTransformPoint(linePoints[k]);
				if (vector6.y < vector5.y)
				{
					vector5 = vector6;
				}
			}
			float num2 = Mathf.Abs(vector5.y) + 2f;
			float z = Vector3.Distance(vector3, vector4);
			Vector3 size = (spawnBlocker.BoxCollider.size = new Vector3(0.5f, num2, z) + Vector3.one);
			longCollider.size = size;
			size = (spawnBlocker.BoxCollider.center = new Vector3(0f, 0f - num2 * 0.5f, 0f));
			longCollider.center = size;
			longCollider.gameObject.SetActive(value: true);
			pointCollider.transform.position = linePoints[endIndex];
			pointCollider.gameObject.SetActive(value: true);
			spawnBlocker.gameObject.SetActive(value: true);
			if (base.isServer)
			{
				spawnBlocker.ClearTrees();
			}
		}
	}

	public bool IsPlayerFacingValidDirection(BasePlayer ply)
	{
		return Vector3.Dot(ply.eyes.HeadForward(), base.transform.forward) > 0.2f;
	}

	public float GetLineLength()
	{
		if (linePoints == null)
		{
			return 0f;
		}
		float num = 0f;
		for (int i = 0; i < linePoints.Count - 1; i++)
		{
			num += Vector3.Distance(linePoints[i], linePoints[i + 1]);
		}
		return num;
	}
}
