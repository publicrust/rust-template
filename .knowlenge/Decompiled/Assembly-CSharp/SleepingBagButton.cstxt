using ProtoBuf;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SleepingBagButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public GameObject TimeLockRoot;

	public GameObject LockRoot;

	public GameObject OccupiedRoot;

	public Button ClickButton;

	public TextMeshProUGUI BagName;

	public TextMeshProUGUI LockTime;

	public Image Icon;

	public Sprite SleepingBagSprite;

	public Sprite BedSprite;

	public Sprite BeachTowelSprite;

	public Sprite CamperSprite;

	public Image CircleRim;

	public Image CircleFill;

	public Image Background;

	public GameObject DeleteButton;

	internal RespawnInformation.SpawnOptions spawnOption;

	internal float releaseTime;

	public float timerSeconds => Mathf.Clamp(releaseTime - Time.realtimeSinceStartup, 0f, 216000f);

	public string friendlyName
	{
		get
		{
			if (spawnOption == null || string.IsNullOrEmpty(spawnOption.name))
			{
				return "Null Sleeping Bag";
			}
			return spawnOption.name;
		}
	}

	private void OnEnable()
	{
		if (DeleteButton != null)
		{
			DeleteButton.SetActive(value: false);
		}
	}

	public void Setup(RespawnInformation.SpawnOptions option, UIDeathScreen.RespawnColourScheme colourScheme)
	{
		spawnOption = option;
		switch (option.type)
		{
		case RespawnInformation.SpawnOptions.RespawnType.SleepingBag:
			Icon.sprite = SleepingBagSprite;
			break;
		case RespawnInformation.SpawnOptions.RespawnType.Bed:
			Icon.sprite = BedSprite;
			break;
		case RespawnInformation.SpawnOptions.RespawnType.BeachTowel:
			Icon.sprite = BeachTowelSprite;
			break;
		case RespawnInformation.SpawnOptions.RespawnType.Camper:
			Icon.sprite = CamperSprite;
			break;
		}
		Background.color = colourScheme.BackgroundColour;
		CircleFill.color = colourScheme.CircleFillColour;
		CircleRim.color = colourScheme.CircleRimColour;
		releaseTime = ((option.unlockSeconds > 0f) ? (Time.realtimeSinceStartup + option.unlockSeconds) : 0f);
		UpdateButtonState(option);
		BagName.text = friendlyName;
	}

	private void UpdateButtonState(RespawnInformation.SpawnOptions option)
	{
		bool flag = releaseTime > 0f && releaseTime > Time.realtimeSinceStartup;
		bool occupied = option.occupied;
		LockRoot.SetActive(flag);
		OccupiedRoot.SetActive(occupied);
		TimeLockRoot.SetActive(flag);
		ClickButton.interactable = !occupied && !flag;
	}

	public void Update()
	{
		if (releaseTime != 0f)
		{
			if (releaseTime < Time.realtimeSinceStartup)
			{
				UpdateButtonState(spawnOption);
			}
			else
			{
				LockTime.text = timerSeconds.ToString("N0");
			}
		}
	}

	public void DoSpawn()
	{
		if (spawnOption != null)
		{
			ConsoleSystem.Run(ConsoleSystem.Option.Client, "respawn_sleepingbag", spawnOption.id);
		}
	}

	public void DeleteBag()
	{
		if (spawnOption != null)
		{
			ConsoleSystem.Run(ConsoleSystem.Option.Client, "respawn_sleepingbag_remove", spawnOption.id);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (DeleteButton != null)
		{
			DeleteButton.SetActive(value: true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (DeleteButton != null)
		{
			DeleteButton.SetActive(value: false);
		}
	}
}
