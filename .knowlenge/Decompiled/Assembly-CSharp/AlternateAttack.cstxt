using UnityEngine;

public class AlternateAttack : StateMachineBehaviour
{
	public bool random;

	public bool dontIncrement;

	public string[] targetTransitions;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (random)
		{
			string text = targetTransitions[Random.Range(0, targetTransitions.Length)];
			animator.Play(text, layerIndex, 0f);
			return;
		}
		int integer = animator.GetInteger("lastAttack");
		string text2 = targetTransitions[integer % targetTransitions.Length];
		animator.Play(text2, layerIndex, 0f);
		if (!dontIncrement)
		{
			animator.SetInteger("lastAttack", integer + 1);
		}
	}
}
