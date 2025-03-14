using System.Collections.Generic;
using UnityEngine;

public class ShoutcastStreamer : MonoBehaviour, IClientComponent
{
	public string Host = "http://listen.57fm.com:80/rcxmas";

	public AudioSource Source;

	public static RadioPlaylist[] BuiltinRadios;

	public static Dictionary<string, string> ParsedLocalRadioList;

	public static void CheckBuiltInRadios()
	{
		if (BuiltinRadios == null)
		{
			BuiltinRadios = FileSystem.LoadAll<RadioPlaylist>("assets/prefabs/voiceaudio/boombox/sound/builtinplaylists");
			ParsedLocalRadioList = new Dictionary<string, string>();
			RadioPlaylist[] builtinRadios = BuiltinRadios;
			foreach (RadioPlaylist radioPlaylist in builtinRadios)
			{
				ParsedLocalRadioList.Add(radioPlaylist.LocalName, radioPlaylist.Url);
			}
		}
	}
}
