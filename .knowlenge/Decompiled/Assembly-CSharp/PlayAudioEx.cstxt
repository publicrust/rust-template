using UnityEngine;

public class PlayAudioEx : MonoBehaviour
{
	public float delay;

	private void Start()
	{
	}

	private void OnEnable()
	{
		AudioSource component = ((Component)this).GetComponent<AudioSource>();
		if (Object.op_Implicit((Object)(object)component))
		{
			component.PlayDelayed(delay);
		}
	}
}
