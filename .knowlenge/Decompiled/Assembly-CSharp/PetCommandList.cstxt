using System;
using System.Collections.Generic;
using UnityEngine;

public class PetCommandList : PrefabAttribute
{
	[Serializable]
	public struct PetCommandDesc
	{
		public PetCommandType CommandType;

		public Translate.Phrase Title;

		public Translate.Phrase Description;

		public Sprite Icon;

		public int CommandIndex;

		public bool Raycast;

		public int CommandWheelOrder;
	}

	public List<PetCommandDesc> Commands;

	protected override Type GetIndexedType()
	{
		return typeof(PetCommandList);
	}

	public List<PetCommandDesc> GetCommandDescriptions()
	{
		return Commands;
	}
}
