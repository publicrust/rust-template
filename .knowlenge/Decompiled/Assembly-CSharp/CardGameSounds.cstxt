using System;
using UnityEngine;

public class CardGameSounds : PrefabAttribute
{
	public enum SoundType
	{
		Chips,
		Draw,
		Play,
		Shuffle,
		Win,
		YourTurn,
		Check,
		Hit,
		Stand,
		Bet,
		IncreaseBet,
		DecreaseBet,
		AllIn,
		UIInteract,
		DealerCool,
		DealerHappy,
		DealerLove,
		DealerSad,
		DealerShocked
	}

	public SoundDefinition ChipsSfx;

	public SoundDefinition DrawSfx;

	public SoundDefinition PlaySfx;

	public SoundDefinition ShuffleSfx;

	public SoundDefinition WinSfx;

	public SoundDefinition LoseSfx;

	public SoundDefinition YourTurnSfx;

	public SoundDefinition CheckSfx;

	public SoundDefinition HitSfx;

	public SoundDefinition StandSfx;

	public SoundDefinition BetSfx;

	public SoundDefinition IncreaseBetSfx;

	public SoundDefinition DecreaseBetSfx;

	public SoundDefinition AllInSfx;

	public SoundDefinition UIInteractSfx;

	[Header("Dealer Reactions")]
	public SoundDefinition DealerCoolSfx;

	public SoundDefinition DealerHappySfx;

	public SoundDefinition DealerLoveSfx;

	public SoundDefinition DealerSadSfx;

	public SoundDefinition DealerShockedSfx;

	protected override Type GetIndexedType()
	{
		return typeof(CardGameSounds);
	}

	public void PlaySound(SoundType sound, GameObject forGameObject)
	{
		switch (sound)
		{
		case SoundType.Chips:
			ChipsSfx.Play(forGameObject);
			break;
		case SoundType.Draw:
			DrawSfx.Play(forGameObject);
			break;
		case SoundType.Play:
			PlaySfx.Play(forGameObject);
			break;
		case SoundType.Shuffle:
			ShuffleSfx.Play(forGameObject);
			break;
		case SoundType.Win:
			WinSfx.Play(forGameObject);
			break;
		case SoundType.YourTurn:
			YourTurnSfx.Play(forGameObject);
			break;
		case SoundType.Check:
			CheckSfx.Play(forGameObject);
			break;
		case SoundType.Hit:
			HitSfx.Play(forGameObject);
			break;
		case SoundType.Stand:
			StandSfx.Play(forGameObject);
			break;
		case SoundType.Bet:
			BetSfx.Play(forGameObject);
			break;
		case SoundType.IncreaseBet:
			IncreaseBetSfx.Play(forGameObject);
			break;
		case SoundType.DecreaseBet:
			DecreaseBetSfx.Play(forGameObject);
			break;
		case SoundType.AllIn:
			AllInSfx.Play(forGameObject);
			break;
		case SoundType.UIInteract:
			UIInteractSfx.Play(forGameObject);
			break;
		case SoundType.DealerCool:
			DealerCoolSfx.Play(forGameObject);
			break;
		case SoundType.DealerHappy:
			DealerHappySfx.Play(forGameObject);
			break;
		case SoundType.DealerLove:
			DealerLoveSfx.Play(forGameObject);
			break;
		case SoundType.DealerSad:
			DealerSadSfx.Play(forGameObject);
			break;
		case SoundType.DealerShocked:
			DealerShockedSfx.Play(forGameObject);
			break;
		default:
			throw new ArgumentOutOfRangeException("sound", sound, null);
		}
	}
}
