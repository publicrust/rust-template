using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class FPSText : MonoBehaviour
{
	public Text text;

	private Stopwatch fpsTimer = Stopwatch.StartNew();

	protected void Update()
	{
		if (!(fpsTimer.Elapsed.TotalSeconds < 0.5))
		{
			this.text.enabled = true;
			fpsTimer.Reset();
			fpsTimer.Start();
			string text = Performance.current.frameRate + " FPS";
			this.text.text = text;
		}
	}
}
