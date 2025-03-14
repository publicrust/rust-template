using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProgressBar : UIBehaviour
{
	public static ProgressBar Instance;

	private Action<BasePlayer> action;

	public float timeFinished;

	private float timeCounter;

	public GameObject scaleTarget;

	public Image progressField;

	public Image iconField;

	public Text leftField;

	public Text rightField;

	public SoundDefinition clipOpen;

	public SoundDefinition clipCancel;

	private bool isOpen;

	public bool InstanceIsOpen
	{
		get
		{
			if (Instance == this)
			{
				return isOpen;
			}
			return Instance.InstanceIsOpen;
		}
	}
}
