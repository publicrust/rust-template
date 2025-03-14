using System.Collections.Generic;
using Facepunch;
using ProtoBuf;
using UnityEngine;

public class WaypointRace : BaseEntity
{
	private class PendingRaceResults
	{
		private class Completion
		{
			public List<BasePlayer> players = new List<BasePlayer>();

			public float time;

			public bool valid;
		}

		private List<Completion> Completions = new List<Completion>();

		public int totalParticipants;

		public int RegisterCompletion(List<BasePlayer> forPlayers, float time, bool valid)
		{
			Completion completion = new Completion();
			foreach (BasePlayer forPlayer in forPlayers)
			{
				completion.players.Add(forPlayer);
			}
			completion.time = time;
			completion.valid = valid;
			Completions.Add(completion);
			if (Completions.Count == totalParticipants)
			{
				TextTable textTable = new TextTable();
				textTable.AddColumns("Place", "Players", "Time");
				for (int i = 0; i < Completions.Count; i++)
				{
					Completion completion2 = Completions[i];
					if (!completion2.valid)
					{
						continue;
					}
					string text = "";
					foreach (BasePlayer player in completion2.players)
					{
						text = text + player.displayName + ",";
					}
					textTable.AddRow($"P{i + 1}", text, completion2.time.SnapTo(0.1f).ToString());
				}
				string msg = textTable.ToString();
				foreach (Completion completion3 in Completions)
				{
					foreach (BasePlayer player2 in completion3.players)
					{
						player2.ChatMessage(msg);
					}
				}
			}
			return Completions.Count;
		}
	}

	public float WaypointRadius = 10f;

	public RaceWaypointVisual TargetWaypointVisual;

	public RaceWaypointVisual NextWaypointVisual;

	private List<Vector3> racePoints = new List<Vector3>();

	private EntityRef<BaseVehicle> racingVehicle;

	private int currentWaypoint;

	public static Translate.Phrase stageNotifyPhrase = new Translate.Phrase("race_notify", "Reached checkpoint {0}/{1} : {2}s");

	public static Translate.Phrase raceCompletePhrase = new Translate.Phrase("race_complete", "Finished race {0}/{1} in {2}s");

	private PendingRaceResults raceResults;

	private TimeSince startTime;

	[ServerVar(Saved = true, Help = "How long a race can go until it times out (in seconds)")]
	public static float raceTimeout = 900f;

	[ServerVar]
	public static void startRace(ConsoleSystem.Arg arg)
	{
		string @string = arg.GetString(0);
		List<Transform> obj = Pool.Get<List<Transform>>();
		WaypointRaceTarget.GetWaypoints(@string, obj);
		if (obj.Count == 0)
		{
			arg.ReplyWith("Couldn't find any waypoints for " + @string + ", is the name correct?");
			return;
		}
		Debug.Log($"Starting race {@string} with {obj.Count} waypoints");
		List<BasePlayer> obj2 = Pool.Get<List<BasePlayer>>();
		Vis.Entities(obj[0].position, 30f, obj2, 131072);
		List<BaseVehicle> obj3 = Pool.Get<List<BaseVehicle>>();
		for (int i = 0; i < obj2.Count; i++)
		{
			if (obj2[i].isClient)
			{
				obj2.RemoveAt(i);
				i--;
				continue;
			}
			if (!obj2[i].isMounted)
			{
				Debug.Log("Remove player " + obj2[i].displayName + " from race, not mounted");
				obj2.RemoveAt(i);
				i--;
				continue;
			}
			BaseMountable mounted = obj2[i].GetMounted();
			if (mounted == null || mounted.VehicleParent() == null)
			{
				Debug.Log("Remove player " + obj2[i].displayName + " from race, no vehicle");
				obj2.RemoveAt(i);
				i--;
				continue;
			}
			BaseVehicle baseVehicle = mounted.VehicleParent();
			if (!baseVehicle.IsDriver(obj2[i]))
			{
				Debug.Log("Remove player " + obj2[i].displayName + " from race, not a driver");
				obj2.RemoveAt(i);
				i--;
			}
			else if (!obj3.Contains(baseVehicle))
			{
				obj3.Add(baseVehicle);
			}
		}
		PendingRaceResults results = new PendingRaceResults
		{
			totalParticipants = obj3.Count
		};
		foreach (BaseVehicle item in obj3)
		{
			WaypointRace obj4 = GameManager.server.CreateEntity("assets/prefabs/misc/waypointrace/waypointrace.prefab", item.transform.position, Quaternion.identity) as WaypointRace;
			obj4.Setup(obj, item, results);
			obj4.Spawn();
		}
		Pool.FreeUnmanaged(ref obj2);
		Pool.FreeUnmanaged(ref obj3);
		Pool.FreeUnmanaged(ref obj);
	}

	private void Setup(List<Transform> waypoints, BaseVehicle participant, PendingRaceResults results)
	{
		racingVehicle.Set(participant);
		foreach (Transform waypoint in waypoints)
		{
			racePoints.Add(waypoint.position);
		}
		raceResults = results;
		startTime = 0f;
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		if (info.msg.waypointRace == null)
		{
			info.msg.waypointRace = Pool.Get<ProtoBuf.WaypointRace>();
		}
		info.msg.waypointRace.positions = Pool.Get<List<Vector3>>();
		info.msg.waypointRace.positions.Clear();
		foreach (Vector3 racePoint in racePoints)
		{
			info.msg.waypointRace.positions.Add(racePoint);
		}
		info.msg.waypointRace.racingVehicle = racingVehicle.uid;
		info.msg.waypointRace.currentWaypoint = currentWaypoint;
	}

	public override void Load(LoadInfo info)
	{
		base.Load(info);
	}

	private void Update()
	{
		if (!base.isServer)
		{
			return;
		}
		BaseVehicle baseVehicle = racingVehicle.Get(base.isServer);
		if (baseVehicle == null || baseVehicle.IsDestroyed || baseVehicle.IsDead() || (float)startTime > raceTimeout)
		{
			raceResults.RegisterCompletion(new List<BasePlayer>(), startTime, valid: false);
			Kill();
			return;
		}
		base.transform.position = baseVehicle.transform.position;
		if (racePoints.Count <= currentWaypoint + 1)
		{
			return;
		}
		Vector3 vector = racePoints[currentWaypoint + 1];
		if (!((baseVehicle.transform.position - vector).sqrMagnitude <= WaypointRadius * WaypointRadius))
		{
			return;
		}
		currentWaypoint++;
		List<BasePlayer> obj = Pool.Get<List<BasePlayer>>();
		baseVehicle.GetMountedPlayers(obj);
		if (currentWaypoint >= racePoints.Count - 1)
		{
			int num = raceResults.RegisterCompletion(obj, startTime, valid: true);
			foreach (BasePlayer item in obj)
			{
				item.ShowToast(GameTip.Styles.Blue_Normal, raceCompletePhrase, false, num.ToString(), raceResults.totalParticipants.ToString(), MathEx.SnapTo(startTime, 0.1f).ToString());
			}
			Kill();
		}
		else
		{
			foreach (BasePlayer item2 in obj)
			{
				item2.ShowToast(GameTip.Styles.Blue_Normal, stageNotifyPhrase, false, currentWaypoint.ToString(), (racePoints.Count - 1).ToString(), MathEx.SnapTo(startTime, 0.1f).ToString());
			}
			SendNetworkUpdate();
		}
		Pool.FreeUnmanaged(ref obj);
	}
}
