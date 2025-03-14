using UnityEngine;

public class RandomParameterNumberFloat : StateMachineBehaviour
{
	public string parameterName;

	public int min;

	public int max;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (!string.IsNullOrEmpty(parameterName))
		{
			animator.SetFloat(parameterName, Mathf.Floor(Random.Range(min, (float)max + 0.5f)));
		}
	}
}
