using UnityEngine;

public class RandomParameterNumber : StateMachineBehaviour
{
	public string parameterName;

	public int min;

	public int max;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetInteger(parameterName, Random.Range(min, max));
	}
}
