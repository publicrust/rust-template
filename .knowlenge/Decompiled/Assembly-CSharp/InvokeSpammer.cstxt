using System.Threading;
using UnityEngine;

public class InvokeSpammer : MonoBehaviour
{
	public int InvokeMilliseconds = 1;

	public float RepeatTime = 0.6f;

	private void Start()
	{
		SingletonComponent<InvokeHandler>.Instance.InvokeRepeating(TestInvoke, RepeatTime, RepeatTime);
	}

	private void TestInvoke()
	{
		Thread.Sleep(InvokeMilliseconds);
	}
}
