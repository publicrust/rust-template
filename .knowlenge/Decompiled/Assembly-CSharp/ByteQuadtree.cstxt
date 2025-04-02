using System;
using UnityEngine;

[Serializable]
public sealed class ByteQuadtree
{
	public struct Element
	{
		private ByteQuadtree source;

		private int x;

		private int y;

		private int level;

		public bool IsLeaf => level == 0;

		public bool IsRoot => level == source.levels - 1;

		public int ByteMap => level;

		public uint Value => source.values[level][x, y];

		public Vector2 Coords => new Vector2(x, y);

		public int Depth => source.levels - level - 1;

		public Element Parent
		{
			get
			{
				if (IsRoot)
				{
					throw new Exception("Element is the root and therefore has no parent.");
				}
				return new Element(source, x / 2, y / 2, level + 1);
			}
		}

		public Element Child1
		{
			get
			{
				if (IsLeaf)
				{
					throw new Exception("Element is a leaf and therefore has no children.");
				}
				return new Element(source, x * 2, y * 2, level - 1);
			}
		}

		public Element Child2
		{
			get
			{
				if (IsLeaf)
				{
					throw new Exception("Element is a leaf and therefore has no children.");
				}
				return new Element(source, x * 2 + 1, y * 2, level - 1);
			}
		}

		public Element Child3
		{
			get
			{
				if (IsLeaf)
				{
					throw new Exception("Element is a leaf and therefore has no children.");
				}
				return new Element(source, x * 2, y * 2 + 1, level - 1);
			}
		}

		public Element Child4
		{
			get
			{
				if (IsLeaf)
				{
					throw new Exception("Element is a leaf and therefore has no children.");
				}
				return new Element(source, x * 2 + 1, y * 2 + 1, level - 1);
			}
		}

		public Element MaxChild
		{
			get
			{
				Element child = Child1;
				Element child2 = Child2;
				Element child3 = Child3;
				Element child4 = Child4;
				uint value = child.Value;
				uint value2 = child2.Value;
				uint value3 = child3.Value;
				uint value4 = child4.Value;
				if (value >= value2 && value >= value3 && value >= value4)
				{
					return child;
				}
				if (value2 >= value3 && value2 >= value4)
				{
					return child2;
				}
				if (value3 >= value4)
				{
					return child3;
				}
				return child4;
			}
		}

		public Element RandChild
		{
			get
			{
				Element child = Child1;
				Element child2 = Child2;
				Element child3 = Child3;
				Element child4 = Child4;
				uint value = child.Value;
				uint value2 = child2.Value;
				uint value3 = child3.Value;
				uint value4 = child4.Value;
				float num = value + value2 + value3 + value4;
				float value5 = UnityEngine.Random.value;
				if ((float)value / num >= value5)
				{
					return child;
				}
				if ((float)(value + value2) / num >= value5)
				{
					return child2;
				}
				if ((float)(value + value2 + value3) / num >= value5)
				{
					return child3;
				}
				return child4;
			}
		}

		public Element(ByteQuadtree source, int x, int y, int level)
		{
			this.source = source;
			this.x = x;
			this.y = y;
			this.level = level;
		}
	}

	[SerializeField]
	private int size;

	[SerializeField]
	private int levels;

	[SerializeField]
	private ByteMap[] values;

	public int Size => size;

	public Element Root => new Element(this, 0, 0, levels - 1);

	public void UpdateValues(byte[] baseValues)
	{
		size = Mathf.RoundToInt(Mathf.Sqrt(baseValues.Length));
		levels = Mathf.RoundToInt(Mathf.Max(Mathf.Log(size, 2f), 0f)) + 1;
		values = new ByteMap[levels];
		values[0] = new ByteMap(size, baseValues);
		for (int i = 1; i < levels; i++)
		{
			ByteMap byteMap = values[i - 1];
			ByteMap byteMap2 = (values[i] = CreateLevel(i));
			for (int j = 0; j < byteMap2.Size; j++)
			{
				for (int k = 0; k < byteMap2.Size; k++)
				{
					byteMap2[k, j] = byteMap[2 * k, 2 * j] + byteMap[2 * k + 1, 2 * j] + byteMap[2 * k, 2 * j + 1] + byteMap[2 * k + 1, 2 * j + 1];
				}
			}
		}
	}

	private ByteMap CreateLevel(int level)
	{
		int num = 1 << levels - level - 1;
		int bytes = 1 + (level + 3) / 4;
		return new ByteMap(num, bytes);
	}
}
