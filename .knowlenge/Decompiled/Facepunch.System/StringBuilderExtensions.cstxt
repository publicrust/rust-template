using System.Text;

public static class StringBuilderExtensions
{
	public static StringBuilder QuoteSafe(this StringBuilder builder, string value)
	{
		builder.Append('"');
		int num = 0;
		for (int i = 0; i < value.Length; i++)
		{
			if (value[i] == '"')
			{
				int num2 = i - num;
				if (num2 > 0)
				{
					builder.Append(value, num, num2);
				}
				builder.Append("\\\"");
				num = i + 1;
			}
		}
		if (num < value.Length)
		{
			builder.Append(value, num, value.Length - num);
		}
		builder.Append('"');
		return builder;
	}
}
