using System;
using UnityEngine;

public class ElevatorButton : MonoBehaviour, IClientComponent
{
	[Flags]
	public enum ElevatorOption
	{
		GoUp = 1,
		GoUpExpress = 2,
		GoDown = 4,
		GoDownExpress = 8
	}

	public ElevatorOption AvailableActions;

	public Collider AttachedCollider;
}
