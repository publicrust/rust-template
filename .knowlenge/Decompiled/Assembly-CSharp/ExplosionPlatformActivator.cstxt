using UnityEngine;

public class ExplosionPlatformActivator : MonoBehaviour
{
	public GameObject Effect;

	public float TimeDelay;

	public float DefaultRepeatTime = 5f;

	public float NearRepeatTime = 3f;

	private float currentTime;

	private float currentRepeatTime;

	private bool canUpdate;

	private void Start()
	{
		currentRepeatTime = DefaultRepeatTime;
		Invoke("Init", TimeDelay);
	}

	private void Init()
	{
		canUpdate = true;
		Effect.SetActive(value: true);
	}

	private void Update()
	{
		if (canUpdate && !(Effect == null))
		{
			currentTime += Time.deltaTime;
			if (currentTime > currentRepeatTime)
			{
				currentTime = 0f;
				Effect.SetActive(value: false);
				Effect.SetActive(value: true);
			}
		}
	}

	private void OnTriggerEnter(Collider coll)
	{
		currentRepeatTime = NearRepeatTime;
	}

	private void OnTriggerExit(Collider other)
	{
		currentRepeatTime = DefaultRepeatTime;
	}
}
