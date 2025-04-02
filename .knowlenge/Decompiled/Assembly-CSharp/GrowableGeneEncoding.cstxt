using System.Text;
using ProtoBuf;
using UnityEngine;

public static class GrowableGeneEncoding
{
	public static void EncodeGenesToItem(GrowableEntity sourceGrowable, Item targetItem)
	{
		if (!((Object)(object)sourceGrowable == (Object)null) && sourceGrowable.Genes != null)
		{
			EncodeGenesToItem(EncodeGenesToInt(sourceGrowable.Genes), targetItem);
		}
	}

	public static void EncodeGenesToItem(int genes, Item targetItem)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		if (targetItem != null)
		{
			targetItem.instanceData = new InstanceData
			{
				ShouldPool = false,
				dataInt = genes
			};
		}
	}

	public static int EncodeGenesToInt(GrowableGenes genes)
	{
		int num = 0;
		for (int i = 0; i < genes.Genes.Length; i++)
		{
			num = Set(num, i, (int)genes.Genes[i].Type);
		}
		return num;
	}

	public static int EncodePreviousGenesToInt(GrowableGenes genes)
	{
		int num = 0;
		for (int i = 0; i < genes.Genes.Length; i++)
		{
			num = Set(num, i, (int)genes.Genes[i].PreviousType);
		}
		return num;
	}

	public static void DecodeIntToGenes(int data, GrowableGenes genes)
	{
		for (int i = 0; i < 6; i++)
		{
			genes.Genes[i].Set((GrowableGenetics.GeneType)Get(data, i));
		}
	}

	public static void DecodeIntToPreviousGenes(int data, GrowableGenes genes)
	{
		for (int i = 0; i < 6; i++)
		{
			genes.Genes[i].SetPrevious((GrowableGenetics.GeneType)Get(data, i));
		}
	}

	public static string DecodeIntToGeneString(int data)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < 6; i++)
		{
			stringBuilder.Append(GrowableGene.GetColourCodedDisplayCharacter((GrowableGenetics.GeneType)Get(data, i)));
		}
		return stringBuilder.ToString();
	}

	private static int Set(int storage, int slot, int value)
	{
		int num = slot * 5;
		int num2 = 31 << num;
		return (storage & ~num2) | (value << num);
	}

	private static int Get(int storage, int slot)
	{
		int num = slot * 5;
		int num2 = 31 << num;
		return (storage & num2) >> num;
	}
}
