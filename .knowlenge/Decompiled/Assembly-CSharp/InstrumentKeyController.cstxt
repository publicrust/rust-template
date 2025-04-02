using System;
using System.Runtime.InteropServices;
using Rust.Instruments;
using UnityEngine;

public class InstrumentKeyController : MonoBehaviour
{
	public enum IKType
	{
		LeftHand,
		RightHand,
		RightFoot
	}

	public enum NoteType
	{
		Regular,
		Sharp
	}

	public enum InstrumentType
	{
		Note,
		Hold
	}

	public enum AnimationSlot
	{
		None,
		One,
		Two,
		Three,
		Four,
		Five,
		Six,
		Seven
	}

	[Serializable]
	public struct KeySet
	{
		public Notes Note;

		public NoteType NoteType;

		public int OctaveShift;

		public override string ToString()
		{
			return string.Format("{0}{1}{2}", Note, (NoteType == NoteType.Sharp) ? "#" : string.Empty, OctaveShift);
		}
	}

	public struct NoteOverride
	{
		public bool Override;

		public KeySet Note;
	}

	[Serializable]
	public struct IKNoteTarget
	{
		public IKType TargetType;

		public int IkIndex;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct NoteBinding
	{
	}

	public const float DEFAULT_NOTE_VELOCITY = 1f;

	public NoteBindingCollection Bindings;

	public NoteBinding[] NoteBindings = new NoteBinding[0];

	public Transform[] NoteSoundPositions;

	public InstrumentIKController IKController;

	public Transform LeftHandProp;

	public Transform RightHandProp;

	public Animator InstrumentAnimator;

	public BaseEntity RPCHandler;

	public uint overrideAchievementId;

	private const string ALL_NOTES_STATNAME = "played_notes";

	public bool PlayedNoteThisFrame { get; private set; }

	public void ProcessServerPlayedNote(BasePlayer forPlayer)
	{
		if (!(forPlayer == null))
		{
			forPlayer.stats.Add(Bindings.NotePlayedStatName, 1, (Stats)5);
			forPlayer.stats.Add("played_notes", 1, (Stats)5);
		}
	}
}
