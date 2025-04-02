using UnityEngine;

public class InstrumentViewmodel : MonoBehaviour
{
	public Animator ViewAnimator;

	public bool UpdateA = true;

	public bool UpdateB = true;

	public bool UpdateC = true;

	public bool UpdateD = true;

	public bool UpdateE = true;

	public bool UpdateF = true;

	public bool UpdateG = true;

	public bool UpdateRecentlyPlayed = true;

	public bool UpdatePlayedNoteTrigger;

	public bool UseTriggers;

	private readonly int note_a = Animator.StringToHash("play_A");

	private readonly int note_b = Animator.StringToHash("play_B");

	private readonly int note_c = Animator.StringToHash("play_C");

	private readonly int note_d = Animator.StringToHash("play_D");

	private readonly int note_e = Animator.StringToHash("play_E");

	private readonly int note_f = Animator.StringToHash("play_F");

	private readonly int note_g = Animator.StringToHash("play_G");

	private readonly int recentlyPlayedHash = Animator.StringToHash("recentlyPlayed");

	private readonly int playedNoteHash = Animator.StringToHash("playedNote");

	public void UpdateSlots(InstrumentKeyController.AnimationSlot currentSlot, bool recentlyPlayed, bool playedNoteThisFrame)
	{
		if (!(ViewAnimator == null))
		{
			if (UpdateA)
			{
				UpdateState(note_a, currentSlot == InstrumentKeyController.AnimationSlot.One);
			}
			if (UpdateB)
			{
				UpdateState(note_b, currentSlot == InstrumentKeyController.AnimationSlot.Two);
			}
			if (UpdateC)
			{
				UpdateState(note_c, currentSlot == InstrumentKeyController.AnimationSlot.Three);
			}
			if (UpdateD)
			{
				UpdateState(note_d, currentSlot == InstrumentKeyController.AnimationSlot.Four);
			}
			if (UpdateE)
			{
				UpdateState(note_e, currentSlot == InstrumentKeyController.AnimationSlot.Five);
			}
			if (UpdateF)
			{
				UpdateState(note_f, currentSlot == InstrumentKeyController.AnimationSlot.Six);
			}
			if (UpdateG)
			{
				UpdateState(note_g, currentSlot == InstrumentKeyController.AnimationSlot.Seven);
			}
			if (UpdateRecentlyPlayed)
			{
				ViewAnimator.SetBool(recentlyPlayedHash, recentlyPlayed);
			}
			if (UpdatePlayedNoteTrigger && playedNoteThisFrame)
			{
				ViewAnimator.SetTrigger(playedNoteHash);
			}
		}
	}

	private void UpdateState(int param, bool state)
	{
		if (!UseTriggers)
		{
			ViewAnimator.SetBool(param, state);
		}
		else if (state)
		{
			ViewAnimator.SetTrigger(param);
		}
	}
}
