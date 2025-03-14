using UnityEngine;

public class UIFadeOut : MonoBehaviour
{
	public float secondsToFadeOut = 3f;

	public bool destroyOnFaded = true;

	public CanvasGroup targetGroup;

	public float fadeDelay;

	private float timeStarted;

	private void Start()
	{
		timeStarted = Time.realtimeSinceStartup;
	}

	private void Update()
	{
		float num = timeStarted;
		targetGroup.alpha = Mathf.InverseLerp(num + secondsToFadeOut, num, Time.realtimeSinceStartup - fadeDelay);
		if (destroyOnFaded && Time.realtimeSinceStartup - fadeDelay > timeStarted + secondsToFadeOut)
		{
			GameManager.Destroy(base.gameObject);
		}
	}
}
