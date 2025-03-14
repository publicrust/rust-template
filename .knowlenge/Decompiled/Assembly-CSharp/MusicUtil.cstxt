using UnityEngine;

public class MusicUtil
{
	public const float OneSixteenth = 0.0625f;

	public static double BeatsToSeconds(float tempo, float beats)
	{
		return 60.0 / (double)tempo * (double)beats;
	}

	public static double BarsToSeconds(float tempo, float bars)
	{
		return BeatsToSeconds(tempo, bars * 4f);
	}

	public static int SecondsToSamples(double seconds)
	{
		return SecondsToSamples(seconds, UnityEngine.AudioSettings.outputSampleRate);
	}

	public static int SecondsToSamples(double seconds, int sampleRate)
	{
		return (int)((double)sampleRate * seconds);
	}

	public static int SecondsToSamples(float seconds)
	{
		return SecondsToSamples(seconds, UnityEngine.AudioSettings.outputSampleRate);
	}

	public static int SecondsToSamples(float seconds, int sampleRate)
	{
		return (int)((float)sampleRate * seconds);
	}

	public static int BarsToSamples(float tempo, float bars, int sampleRate)
	{
		return SecondsToSamples(BarsToSeconds(tempo, bars), sampleRate);
	}

	public static int BarsToSamples(float tempo, float bars)
	{
		return SecondsToSamples(BarsToSeconds(tempo, bars));
	}

	public static int BeatsToSamples(float tempo, float beats)
	{
		return SecondsToSamples(BeatsToSeconds(tempo, beats));
	}

	public static float SecondsToBeats(float tempo, double seconds)
	{
		return tempo / 60f * (float)seconds;
	}

	public static float SecondsToBars(float tempo, double seconds)
	{
		return SecondsToBeats(tempo, seconds) / 4f;
	}

	public static float Quantize(float position, float gridSize)
	{
		return Mathf.Round(position / gridSize) * gridSize;
	}

	public static float FlooredQuantize(float position, float gridSize)
	{
		return Mathf.Floor(position / gridSize) * gridSize;
	}
}
