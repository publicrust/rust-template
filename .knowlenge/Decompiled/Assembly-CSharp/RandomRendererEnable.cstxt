using UnityEngine;

public class RandomRendererEnable : MonoBehaviour
{
	public Renderer[] randoms;

	public int EnabledIndex { get; private set; }

	public void OnEnable()
	{
		int num2 = (EnabledIndex = Random.Range(0, randoms.Length));
		randoms[num2].enabled = true;
	}
}
