using System;
using Rust.Instruments;
using UnityEngine;

[CreateAssetMenu]
public class NoteBindingCollection : ScriptableObject
{
	[Serializable]
	public struct NoteData
	{
		public SoundDefinition NoteSound;

		public SoundDefinition NoteStartSound;

		public Notes Note;

		public InstrumentKeyController.NoteType Type;

		public int MidiNoteNumber;

		public int NoteOctave;

		[InstrumentIKTarget]
		public InstrumentKeyController.IKNoteTarget NoteIKTarget;

		public InstrumentKeyController.AnimationSlot AnimationSlot;

		public int NoteSoundPositionTarget;

		public string ToNoteString()
		{
			return string.Format("{0}{1}{2}", Note, (Type == InstrumentKeyController.NoteType.Sharp) ? "#" : string.Empty, NoteOctave);
		}
	}

	public NoteData[] BaseBindings;

	public float MinimumNoteTime;

	public float MaximumNoteLength;

	public bool AllowAutoplay = true;

	public float AutoplayLoopDelay = 0.25f;

	public string NotePlayedStatName;

	public string KeyMidiMapShortname = "";

	public bool AllowSustain;

	public bool AllowFullKeyboardInput = true;

	public string InstrumentShortName = "";

	public InstrumentKeyController.InstrumentType NotePlayType;

	public int MaxConcurrentNotes = 3;

	public bool LoopSounds;

	public float SoundFadeInTime;

	public float minimumSoundFadeOutTime = 0.1f;

	public InstrumentKeyController.KeySet PrimaryClickNote;

	public InstrumentKeyController.KeySet SecondaryClickNote = new InstrumentKeyController.KeySet
	{
		Note = Notes.B
	};

	public bool RunInstrumentAnimationController;

	public bool PlayRepeatAnimations = true;

	public float AnimationDeadTime = 1f;

	public float AnimationResetDelay;

	public float RecentlyPlayedThreshold = 1f;

	[Range(0f, 1f)]
	public float CrossfadeNormalizedAnimationTarget;

	public float AnimationCrossfadeDuration = 0.15f;

	public float CrossfadePlayerSpeedMulti = 1f;

	public int DefaultOctave;

	public int ShiftedOctave = 1;

	public bool FindNoteData(Notes note, int octave, InstrumentKeyController.NoteType type, out NoteData data, out int noteIndex)
	{
		for (int i = 0; i < BaseBindings.Length; i++)
		{
			NoteData noteData = BaseBindings[i];
			if (noteData.Note == note && noteData.Type == type && noteData.NoteOctave == octave)
			{
				data = noteData;
				noteIndex = i;
				return true;
			}
		}
		data = default(NoteData);
		noteIndex = -1;
		return false;
	}

	public bool FindNoteDataIndex(Notes note, int octave, InstrumentKeyController.NoteType type, out int noteIndex)
	{
		for (int i = 0; i < BaseBindings.Length; i++)
		{
			NoteData noteData = BaseBindings[i];
			if (noteData.Note == note && noteData.Type == type && noteData.NoteOctave == octave)
			{
				noteIndex = i;
				return true;
			}
		}
		noteIndex = -1;
		return false;
	}
}
