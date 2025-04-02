using UnityEngine;

public class ExplosionsShaderQueue : MonoBehaviour
{
	public int AddQueue = 1;

	private Renderer rend;

	private void Start()
	{
		rend = ((Component)this).GetComponent<Renderer>();
		if ((Object)(object)rend != (Object)null)
		{
			Material sharedMaterial = rend.sharedMaterial;
			sharedMaterial.renderQueue += AddQueue;
		}
		else
		{
			((MonoBehaviour)this).Invoke("SetProjectorQueue", 0.1f);
		}
	}

	private void SetProjectorQueue()
	{
		Material material = ((Component)this).GetComponent<Projector>().material;
		material.renderQueue += AddQueue;
	}

	private void OnDisable()
	{
		if ((Object)(object)rend != (Object)null)
		{
			rend.sharedMaterial.renderQueue = -1;
		}
	}
}
