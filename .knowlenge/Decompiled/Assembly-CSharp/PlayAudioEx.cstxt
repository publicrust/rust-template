using UnityEngine;

public class PlayAudioEx : MonoBehaviour
{
	public float delay;

	private void Start()
	{
	}

	private void OnEnable()
	{
		AudioSource component = GetComponent<AudioSource>();
		if ((bool)component)
		{
			component.PlayDelayed(delay);
		}
	}
}
