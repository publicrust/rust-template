using UnityEngine;

public class ExplosionsShaderQueue : MonoBehaviour
{
	public int AddQueue = 1;

	private Renderer rend;

	private void Start()
	{
		rend = GetComponent<Renderer>();
		if (rend != null)
		{
			rend.sharedMaterial.renderQueue += AddQueue;
		}
		else
		{
			Invoke("SetProjectorQueue", 0.1f);
		}
	}

	private void SetProjectorQueue()
	{
		GetComponent<Projector>().material.renderQueue += AddQueue;
	}

	private void OnDisable()
	{
		if (rend != null)
		{
			rend.sharedMaterial.renderQueue = -1;
		}
	}
}
