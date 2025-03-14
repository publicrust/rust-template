using UnityEngine;

public class UIFadeOut : MonoBehaviour
{
	public float secondsToFadeOut = 3f;

	public bool destroyOnFaded = true;

	public CanvasGroup targetGroup;

	private float timeStarted;

	private void Start()
	{
		timeStarted = Time.realtimeSinceStartup;
	}

	private void Update()
	{
		targetGroup.alpha = Mathf.InverseLerp(timeStarted + secondsToFadeOut, timeStarted, Time.realtimeSinceStartup);
		if (destroyOnFaded && Time.realtimeSinceStartup > timeStarted + secondsToFadeOut)
		{
			GameManager.Destroy(base.gameObject);
		}
	}
}
