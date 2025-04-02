using UnityEngine;

public class ExplosionsFPS : MonoBehaviour
{
	private readonly GUIStyle guiStyleHeader = new GUIStyle();

	private float timeleft;

	private float fps;

	private int frames;

	private void Awake()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		guiStyleHeader.fontSize = 14;
		guiStyleHeader.normal.textColor = new Color(1f, 1f, 1f);
	}

	private void OnGUI()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		GUI.Label(new Rect(0f, 0f, 30f, 30f), "FPS: " + (int)fps, guiStyleHeader);
	}

	private void Update()
	{
		timeleft -= Time.deltaTime;
		frames++;
		if ((double)timeleft <= 0.0)
		{
			fps = frames;
			timeleft = 1f;
			frames = 0;
		}
	}
}
