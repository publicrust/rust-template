using System.Text;

public static class ClanValidator
{
	private static readonly StringBuilder Builder = new StringBuilder(64);

	public static bool ValidateClanName(string name, out string validated)
	{
		validated = Normalize(name);
		if (!ValidateLength(validated, 3, 32) || !ValidateAlphanumericOnly(validated))
		{
			validated = null;
			return false;
		}
		return true;
	}

	public static bool ValidateRoleName(string name, out string validated)
	{
		return ValidateClanName(name, out validated);
	}

	public static bool ValidateMotd(string motd, out string validated)
	{
		validated = Normalize(motd, 30);
		if (!ValidateLength(validated, 0, 4096))
		{
			validated = null;
			return false;
		}
		return true;
	}

	public static bool ValidatePlayerNote(string note, out string validated)
	{
		validated = Normalize(note, 3);
		if (!ValidateLength(validated, 0, 256))
		{
			validated = null;
			return false;
		}
		return true;
	}

	public static bool ValidateChatMessage(string message, out string validated)
	{
		validated = Normalize(message);
		if (!ValidateLength(validated, 0, 128))
		{
			validated = null;
			return false;
		}
		return true;
	}

	private static string Normalize(string value, int maxLines = 1)
	{
		if (value == null)
		{
			return null;
		}
		value = value.Trim();
		int num = maxLines - 1;
		bool flag = false;
		Builder.Clear();
		for (int i = 0; i < value.Length; i++)
		{
			if (value[i] == '\n' && num > 0)
			{
				num--;
				Builder.Append('\n');
				continue;
			}
			bool flag2 = char.IsSurrogatePair(value, i);
			bool num2 = char.IsWhiteSpace(value, i);
			if (!num2)
			{
				Builder.Append(value[i]);
				if (flag2)
				{
					Builder.Append(value[i + 1]);
				}
			}
			else if (!flag)
			{
				Builder.Append(' ');
			}
			flag = num2;
			if (flag2)
			{
				i++;
			}
		}
		return Builder.ToString().Normalize(NormalizationForm.FormC);
	}

	private static bool ValidateLength(string value, int min, int max)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return false;
		}
		if (value.Length >= min)
		{
			return value.Length <= max;
		}
		return false;
	}

	private static bool ValidateAlphanumericOnly(string value)
	{
		if (value == null)
		{
			return false;
		}
		for (int i = 0; i < value.Length; i++)
		{
			char c = value[i];
			if (c != ' ' && c != '\'' && c != '-' && !char.IsLetterOrDigit(value, i))
			{
				return false;
			}
			if (char.IsSurrogatePair(value, i))
			{
				i++;
			}
		}
		return true;
	}
}
