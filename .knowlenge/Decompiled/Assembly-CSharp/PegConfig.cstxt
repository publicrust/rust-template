using System;
using UnityEngine;

[Serializable]
public class PegConfig
{
	public enum PegType
	{
		Small,
		Large
	}

	public PegType Type;

	public Vector3 VerticalMountLocalRotation;

	public Vector3 VerticalMountLocalOffset;

	public void Init(PegType t, Vector3 localRot, Vector3 localOffset)
	{
		Type = t;
		VerticalMountLocalRotation = localRot;
		VerticalMountLocalOffset = localOffset;
	}
}
