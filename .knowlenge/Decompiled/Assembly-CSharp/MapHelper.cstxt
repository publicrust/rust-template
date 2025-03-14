using System.Text.RegularExpressions;
using UnityEngine;

public static class MapHelper
{
	public static Vector2i? StringToGrid(string text)
	{
		Match match = new Regex("^([a-zA-Z]+)(\\d+)$").Match(text);
		if (!match.Success)
		{
			return null;
		}
		int num = 0;
		string text2 = match.Groups[1].Value.ToLower();
		foreach (char c in text2)
		{
			num = num * 26 + c - 97 + 1;
		}
		num--;
		if (!int.TryParse(match.Groups[2].Value, out var result))
		{
			return null;
		}
		return new Vector2i(num, result);
	}

	public static Vector3 GridToPosition(Vector2i grid)
	{
		float num = 146.28572f;
		int num2 = Mathf.FloorToInt((float)World.Size / num + 0.001f);
		float num3 = World.Size / num2;
		Vector2 vector = new Vector2((float)(0L - (long)World.Size) / 2f, (float)World.Size / 2f);
		Vector2 vector2 = new Vector2((float)grid.x * num3, (float)grid.y * num3);
		return new Vector3(vector.x + vector2.x, 0f, vector.y - vector2.y) + new Vector3(num3 / 2f, 0f, num3 / -2f);
	}

	public static Vector3? StringToPosition(string text)
	{
		Vector2i? vector2i = StringToGrid(text);
		if (!vector2i.HasValue)
		{
			return null;
		}
		return GridToPosition(vector2i.Value);
	}

	public static string PositionToString(Vector3 position)
	{
		return GridToString(PositionToGrid(position));
	}

	public static Vector2i PositionToGrid(Vector3 position)
	{
		float num = 146.28572f;
		int num2 = Mathf.FloorToInt((float)World.Size / num + 0.001f);
		float num3 = World.Size / num2;
		Vector2 vector = new Vector2((float)(0L - (long)World.Size) / 2f, (float)World.Size / 2f);
		Vector2 vector2 = new Vector2(position.x - vector.x, vector.y - position.z);
		int x = Mathf.FloorToInt(vector2.x / num3);
		int y = Mathf.FloorToInt(vector2.y / num3);
		return new Vector2i(x, y);
	}

	public static string GridToString(Vector2i grid)
	{
		grid.x = Mathf.Max(grid.x, 0);
		int num = grid.x + 1;
		string text = "";
		while (num > 0)
		{
			num--;
			text = (char)(65 + num % 26) + text;
			num /= 26;
		}
		return $"{text}{grid.y}";
	}
}
