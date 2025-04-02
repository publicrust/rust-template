using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TmProEmojiRedirector : MonoBehaviour
{
	public struct EmojiSub
	{
		public int targetCharIndex;

		public int targetCharIndexWithRichText;

		public string targetEmoji;

		public RustEmojiLibrary.EmojiSource targetEmojiResult;

		public TMP_CharacterInfo charToReplace;
	}

	public GameObjectRef SpritePrefab;

	public float EmojiScale = 1.5f;

	public bool NonDestructiveChange;

	public bool CanTextHaveLegitimateRichText = true;

	public static void FindEmojiSubstitutions(string text, RustEmojiLibrary library, List<(EmojiSub, int)> foundSubs, bool richText, bool isServer = false, int messageLength = 0)
	{
		EmojiSub item = default(EmojiSub);
		bool flag = false;
		int num = 0;
		int num2 = 0;
		bool flag2 = false;
		int num3 = 0;
		int length = text.Length;
		if (messageLength > 0)
		{
			num3 = length - messageLength;
		}
		foundSubs.Clear();
		for (int i = 0; i < length; i++)
		{
			char c = text[i];
			num2++;
			if (richText)
			{
				if (c == '<')
				{
					bool flag3 = false;
					for (int j = i + 1; j < length && text[j] != '\u200b'; j++)
					{
						if (text[j] == '>')
						{
							flag3 = true;
							break;
						}
						if (text[j] == '<')
						{
							break;
						}
					}
					if (flag3)
					{
						flag2 = true;
						continue;
					}
				}
				if (flag2 && c == '>')
				{
					flag2 = false;
					continue;
				}
				if (flag2)
				{
					continue;
				}
			}
			if (num2 < num3)
			{
				num++;
				continue;
			}
			if (c == ':')
			{
				if (!flag)
				{
					flag = true;
					item.targetCharIndex = num;
					item.targetCharIndexWithRichText = num2 - 1;
				}
				else
				{
					if (library.TryGetEmoji(item.targetEmoji, out item.targetEmojiResult, out var skinVariantIndex, out var _, isServer))
					{
						foundSubs.Add((item, skinVariantIndex));
					}
					item = default(EmojiSub);
					flag = false;
				}
			}
			else if (flag)
			{
				item.targetEmoji += c;
				if (c == ' ')
				{
					item = default(EmojiSub);
					flag = false;
				}
			}
			num++;
		}
	}
}
