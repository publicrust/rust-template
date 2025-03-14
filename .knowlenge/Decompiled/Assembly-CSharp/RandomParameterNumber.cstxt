using UnityEngine;

public class RandomParameterNumber : StateMachineBehaviour
{
	public string parameterName;

	public int min;

	public int max;

	public bool preventRepetition;

	public bool isFloat;

	private int last;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		int num = Random.Range(min, max);
		int num2 = 0;
		while (last == num && preventRepetition && num2 < 100)
		{
			num = Random.Range(min, max);
			num2++;
		}
		if (isFloat)
		{
			animator.SetFloat(parameterName, num);
		}
		else
		{
			animator.SetInteger(parameterName, num);
		}
		last = num;
	}
}
