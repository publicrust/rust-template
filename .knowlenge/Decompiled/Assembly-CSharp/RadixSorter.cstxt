public class RadixSorter
{
	private uint[] histogram;

	private uint[] offset;

	public RadixSorter()
	{
		histogram = new uint[768];
		offset = new uint[768];
	}

	public void SortU8(uint[] values, uint[] remap, uint num)
	{
		for (int i = 0; i < 256; i++)
		{
			histogram[i] = 0u;
		}
		for (uint num2 = 0u; num2 < num; num2++)
		{
			histogram[values[num2] & 0xFF]++;
		}
		offset[0] = 0u;
		for (uint num3 = 0u; num3 < 255; num3++)
		{
			offset[num3 + 1] = offset[num3] + histogram[num3];
		}
		for (uint num4 = 0u; num4 < num; num4++)
		{
			remap[offset[values[num4] & 0xFF]++] = num4;
		}
	}

	public void SortU24(uint[] values, uint[] remap, uint[] remapTemp, uint num)
	{
		for (int i = 0; i < 768; i++)
		{
			histogram[i] = 0u;
		}
		for (uint num2 = 0u; num2 < num; num2++)
		{
			uint num3 = values[num2];
			histogram[num3 & 0xFF]++;
			histogram[256 + ((num3 >> 8) & 0xFF)]++;
			histogram[512 + ((num3 >> 16) & 0xFF)]++;
		}
		offset[0] = (offset[256] = (offset[512] = 0u));
		uint num4 = 0u;
		uint num5 = 256u;
		uint num6 = 512u;
		while (num4 < 255)
		{
			offset[num4 + 1] = offset[num4] + histogram[num4];
			offset[num5 + 1] = offset[num5] + histogram[num5];
			offset[num6 + 1] = offset[num6] + histogram[num6];
			num4++;
			num5++;
			num6++;
		}
		for (uint num7 = 0u; num7 < num; num7++)
		{
			remapTemp[offset[values[num7] & 0xFF]++] = num7;
		}
		for (uint num8 = 0u; num8 < num; num8++)
		{
			uint num9 = remapTemp[num8];
			remap[offset[256 + ((values[num9] >> 8) & 0xFF)]++] = num9;
		}
		for (uint num10 = 0u; num10 < num; num10++)
		{
			uint num9 = remap[num10];
			remapTemp[offset[512 + ((values[num9] >> 16) & 0xFF)]++] = num9;
		}
		for (uint num11 = 0u; num11 < num; num11++)
		{
			remap[num11] = remapTemp[num11];
		}
	}
}
