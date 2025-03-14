using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TextBuffer
{
	private Queue<string> buffer;

	private StringBuilder builder;

	private string text = string.Empty;

	private bool dirty;

	private int curlines;

	private int maxlines;

	private int curchars;

	private int maxchars;

	public int Count => curlines;

	public TextBuffer(int maxlines, int maxchars = int.MaxValue)
	{
		buffer = new Queue<string>(maxlines + 1);
		builder = new StringBuilder();
		this.maxlines = maxlines;
		this.maxchars = maxchars;
	}

	public void Add(string text)
	{
		foreach (string item in text.SplitToLines())
		{
			buffer.Enqueue(item);
			curlines++;
			curchars += item.Length;
			while (curlines > maxlines || curchars > maxchars)
			{
				Remove();
			}
		}
		dirty = true;
	}

	public void Remove()
	{
		if (buffer.Count != 0)
		{
			string text = buffer.Dequeue();
			curlines--;
			curchars -= text.Length;
		}
	}

	public void Clear()
	{
		buffer.Clear();
		curlines = 0;
		curchars = 0;
		text = string.Empty;
		dirty = true;
	}

	public string Get(int index)
	{
		if (index < 0 || index > buffer.Count - 1)
		{
			return string.Empty;
		}
		return buffer.ElementAt(buffer.Count - 1 - index);
	}

	public override string ToString()
	{
		if (dirty)
		{
			builder.Clear();
			foreach (string item in buffer)
			{
				builder.AppendLine(item);
			}
			text = builder.ToString();
			dirty = false;
		}
		return text;
	}
}
