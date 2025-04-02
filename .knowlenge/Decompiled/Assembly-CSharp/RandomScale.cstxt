using UnityEngine;

public class RandomScale : MonoBehaviour
{
	[SerializeField]
	private bool multiplyByExistingScale = true;

	[SerializeField]
	private Vector3 minScale = Vector3.one * 0.8f;

	[SerializeField]
	private Vector3 maxScale = Vector3.one * 1.2f;

	private void Awake()
	{
		if (multiplyByExistingScale)
		{
			base.transform.localScale *= Random.Range(minScale.x, maxScale.x);
		}
		else
		{
			base.transform.localScale = Vector3.one * Random.Range(minScale.x, maxScale.x);
		}
	}
}
