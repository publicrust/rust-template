using UnityEngine;

public class PreloadedCassetteContent : ScriptableObject
{
	public enum PreloadType
	{
		Short,
		Medium,
		Long
	}

	public SoundDefinition[] ShortTapeContent;

	public SoundDefinition[] MediumTapeContent;

	public SoundDefinition[] LongTapeContent;

	public SoundDefinition GetSoundContent(int index, PreloadType type)
	{
		return type switch
		{
			PreloadType.Short => GetDefinition(index, ShortTapeContent), 
			PreloadType.Medium => GetDefinition(index, MediumTapeContent), 
			PreloadType.Long => GetDefinition(index, LongTapeContent), 
			_ => null, 
		};
	}

	private SoundDefinition GetDefinition(int index, SoundDefinition[] array)
	{
		index = Mathf.Clamp(index, 0, array.Length);
		return array[index];
	}

	public uint GetSoundContentId(SoundDefinition def)
	{
		uint num = 0u;
		SoundDefinition[] shortTapeContent = ShortTapeContent;
		for (int i = 0; i < shortTapeContent.Length; i++)
		{
			if (shortTapeContent[i] == def)
			{
				return num;
			}
			num++;
		}
		shortTapeContent = MediumTapeContent;
		for (int i = 0; i < shortTapeContent.Length; i++)
		{
			if (shortTapeContent[i] == def)
			{
				return num;
			}
			num++;
		}
		shortTapeContent = LongTapeContent;
		for (int i = 0; i < shortTapeContent.Length; i++)
		{
			if (shortTapeContent[i] == def)
			{
				return num;
			}
			num++;
		}
		return num;
	}

	public SoundDefinition GetSoundContent(uint id)
	{
		int num = 0;
		SoundDefinition[] shortTapeContent = ShortTapeContent;
		foreach (SoundDefinition result in shortTapeContent)
		{
			if (num++ == id)
			{
				return result;
			}
		}
		shortTapeContent = MediumTapeContent;
		foreach (SoundDefinition result2 in shortTapeContent)
		{
			if (num++ == id)
			{
				return result2;
			}
		}
		shortTapeContent = LongTapeContent;
		foreach (SoundDefinition result3 in shortTapeContent)
		{
			if (num++ == id)
			{
				return result3;
			}
		}
		return null;
	}
}
