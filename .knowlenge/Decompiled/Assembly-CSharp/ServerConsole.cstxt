using System;
using ConVar;
using Facepunch;
using Facepunch.Extend;
using Network;
using UnityEngine;
using Windows;

public class ServerConsole : SingletonComponent<ServerConsole>
{
	private ConsoleWindow console;

	private ConsoleInput input;

	private float nextUpdate;

	private static bool consoleEnabled => !CommandLine.HasSwitch("-noconsole");

	private DateTime currentGameTime
	{
		get
		{
			if (!TOD_Sky.Instance)
			{
				return DateTime.Now;
			}
			return TOD_Sky.Instance.Cycle.DateTime;
		}
	}

	private int currentPlayerCount => BasePlayer.activePlayerList.Count;

	private int maxPlayerCount => ConVar.Server.maxplayers;

	private int currentEntityCount => BaseNetworkable.serverEntities.Count;

	private int currentSleeperCount => BasePlayer.sleepingPlayerList.Count;

	public void OnEnable()
	{
		if (!consoleEnabled)
		{
			base.enabled = false;
			return;
		}
		console = new ConsoleWindow();
		input = new ConsoleInput();
		console.Initialize();
		input.OnInputText += OnInputText;
		Output.OnMessage += HandleLog;
		input.ClearLine(System.Console.WindowHeight);
		for (int i = 0; i < System.Console.WindowHeight; i++)
		{
			System.Console.WriteLine("");
		}
	}

	private void OnDisable()
	{
		Output.OnMessage -= HandleLog;
		if (input != null)
		{
			input.OnInputText -= OnInputText;
		}
		console?.Shutdown();
	}

	private void OnInputText(string obj)
	{
		ConsoleSystem.Run(ConsoleSystem.Option.Server, obj);
	}

	public static void PrintColoured(params object[] objects)
	{
		if (SingletonComponent<ServerConsole>.Instance == null || SingletonComponent<ServerConsole>.Instance.input == null)
		{
			return;
		}
		SingletonComponent<ServerConsole>.Instance.input.ClearLine(SingletonComponent<ServerConsole>.Instance.input.statusText.Length);
		for (int i = 0; i < objects.Length; i++)
		{
			if (i % 2 == 0)
			{
				System.Console.ForegroundColor = (ConsoleColor)objects[i];
			}
			else
			{
				System.Console.Write((string)objects[i]);
			}
		}
		if (System.Console.CursorLeft != 0)
		{
			System.Console.CursorTop++;
		}
		SingletonComponent<ServerConsole>.Instance.input.RedrawInputLine();
	}

	private void HandleLog(string message, string stackTrace, LogType type)
	{
		if (message.StartsWith("[CHAT]") || message.StartsWith("[TEAM CHAT]") || message.StartsWith("[CARDS CHAT]"))
		{
			return;
		}
		switch (type)
		{
		case LogType.Warning:
			if (message.StartsWith("HDR RenderTexture format is not") || message.StartsWith("The image effect") || message.StartsWith("Image Effects are not supported on this platform") || message.StartsWith("[AmplifyColor]") || message.StartsWith("Skipping profile frame.") || message.StartsWith("Kinematic body only supports Speculative Continuous collision detection"))
			{
				return;
			}
			System.Console.ForegroundColor = ConsoleColor.Yellow;
			break;
		case LogType.Error:
			System.Console.ForegroundColor = ConsoleColor.Red;
			break;
		case LogType.Exception:
			System.Console.ForegroundColor = ConsoleColor.Red;
			break;
		case LogType.Assert:
			System.Console.ForegroundColor = ConsoleColor.Red;
			break;
		default:
			System.Console.ForegroundColor = ConsoleColor.Gray;
			break;
		}
		if (input != null)
		{
			input.ClearLine(input.statusText.Length);
			System.Console.WriteLine(message);
			input.RedrawInputLine();
		}
	}

	private void Update()
	{
		UpdateStatus();
		input?.Update();
	}

	private void UpdateStatus()
	{
		if (!(nextUpdate > UnityEngine.Time.realtimeSinceStartup) && Network.Net.sv != null && Network.Net.sv.IsConnected())
		{
			nextUpdate = UnityEngine.Time.realtimeSinceStartup + 0.33f;
			if (input != null && input.valid)
			{
				string text = ((long)UnityEngine.Time.realtimeSinceStartup).FormatSeconds();
				string text2 = currentGameTime.ToString("[H:mm]");
				string text3 = " " + text2 + " [" + currentPlayerCount + "/" + maxPlayerCount + "] " + ConVar.Server.hostname + " [" + ConVar.Server.level + "]";
				string text4 = Performance.current.frameRate + "fps " + Performance.current.memoryCollections + "gc " + text;
				string text5 = Network.Net.sv.GetStat(null, BaseNetwork.StatTypeLong.BytesReceived_LastSecond).FormatBytes(shortFormat: true) + "/s in, " + Network.Net.sv.GetStat(null, BaseNetwork.StatTypeLong.BytesSent_LastSecond).FormatBytes(shortFormat: true) + "/s out";
				string text6 = text4.PadLeft(input.lineWidth - 1);
				text6 = text3 + ((text3.Length < text6.Length) ? text6.Substring(text3.Length) : "");
				string text7 = " " + currentEntityCount.ToString("n0") + " ents, " + currentSleeperCount.ToString("n0") + " slprs";
				string text8 = text5.PadLeft(input.lineWidth - 1);
				text8 = text7 + ((text7.Length < text8.Length) ? text8.Substring(text7.Length) : "");
				input.statusText[0] = "";
				input.statusText[1] = text6;
				input.statusText[2] = text8;
			}
		}
	}
}
