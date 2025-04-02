using System;
using UnityEngine;
using UnityEngine.UI;

public class GameStat : MonoBehaviour
{
	[Serializable]
	public struct Stat
	{
		public string statName;

		public string statTitle;
	}

	public float refreshTime = 5f;

	public Text title;

	public Text globalStat;

	public Text localStat;

	private long globalValue;

	private long localValue;

	private float secondsSinceRefresh;

	private float secondsUntilUpdate;

	private float secondsUntilChange;

	public Stat[] stats;
}
