using System.Linq;
using System.Text;
using UnityEngine;

public class GrowableGenes
{
	public GrowableGene[] Genes;

	private static GrowableGenetics.GeneWeighting[] baseWeights = new GrowableGenetics.GeneWeighting[6];

	private static GrowableGenetics.GeneWeighting[] slotWeights = new GrowableGenetics.GeneWeighting[6];

	public GrowableGenes()
	{
		Clear();
	}

	private void Clear()
	{
		Genes = new GrowableGene[6];
		for (int i = 0; i < 6; i++)
		{
			Genes[i] = new GrowableGene();
		}
	}

	public void GenerateRandom(GrowableEntity growable)
	{
		if (!(growable == null) && !(growable.Properties.Genes == null))
		{
			CalculateBaseWeights(growable.Properties.Genes);
			for (int i = 0; i < 6; i++)
			{
				CalculateSlotWeights(growable.Properties.Genes, i);
				Genes[i].Set(PickWeightedGeneType(), firstSet: true);
			}
		}
	}

	private void CalculateBaseWeights(GrowableGeneProperties properties)
	{
		int num = 0;
		GrowableGeneProperties.GeneWeight[] weights = properties.Weights;
		for (int i = 0; i < weights.Length; i++)
		{
			GrowableGeneProperties.GeneWeight geneWeight = weights[i];
			baseWeights[num].GeneType = (slotWeights[num].GeneType = (GrowableGenetics.GeneType)num);
			baseWeights[num].Weighting = geneWeight.BaseWeight;
			num++;
		}
	}

	private void CalculateSlotWeights(GrowableGeneProperties properties, int slot)
	{
		int num = 0;
		GrowableGeneProperties.GeneWeight[] weights = properties.Weights;
		for (int i = 0; i < weights.Length; i++)
		{
			GrowableGeneProperties.GeneWeight geneWeight = weights[i];
			slotWeights[num].Weighting = baseWeights[num].Weighting + geneWeight.SlotWeights[slot];
			num++;
		}
	}

	private GrowableGenetics.GeneType PickWeightedGeneType()
	{
		IOrderedEnumerable<GrowableGenetics.GeneWeighting> orderedEnumerable = slotWeights.OrderBy((GrowableGenetics.GeneWeighting w) => w.Weighting);
		float num = 0f;
		foreach (GrowableGenetics.GeneWeighting item in orderedEnumerable)
		{
			num += item.Weighting;
		}
		GrowableGenetics.GeneType result = GrowableGenetics.GeneType.Empty;
		float num2 = Random.Range(0f, num);
		float num3 = 0f;
		foreach (GrowableGenetics.GeneWeighting item2 in orderedEnumerable)
		{
			num3 += item2.Weighting;
			if (num2 < num3)
			{
				result = item2.GeneType;
				break;
			}
		}
		return result;
	}

	public int GetGeneTypeCount(GrowableGenetics.GeneType geneType)
	{
		int num = 0;
		GrowableGene[] genes = Genes;
		for (int i = 0; i < genes.Length; i++)
		{
			if (genes[i].Type == geneType)
			{
				num++;
			}
		}
		return num;
	}

	public int GetPositiveGeneCount()
	{
		int num = 0;
		GrowableGene[] genes = Genes;
		for (int i = 0; i < genes.Length; i++)
		{
			if (genes[i].IsPositive())
			{
				num++;
			}
		}
		return num;
	}

	public int GetNegativeGeneCount()
	{
		int num = 0;
		GrowableGene[] genes = Genes;
		for (int i = 0; i < genes.Length; i++)
		{
			if (!genes[i].IsPositive())
			{
				num++;
			}
		}
		return num;
	}

	public void Save(BaseNetworkable.SaveInfo info)
	{
		info.msg.growableEntity.genes = GrowableGeneEncoding.EncodeGenesToInt(this);
		info.msg.growableEntity.previousGenes = GrowableGeneEncoding.EncodePreviousGenesToInt(this);
	}

	public void Load(BaseNetworkable.LoadInfo info)
	{
		if (info.msg.growableEntity != null)
		{
			GrowableGeneEncoding.DecodeIntToGenes(info.msg.growableEntity.genes, this);
			GrowableGeneEncoding.DecodeIntToPreviousGenes(info.msg.growableEntity.previousGenes, this);
		}
	}

	public void DebugPrint()
	{
		Debug.Log(GetDisplayString(previousGenes: false));
	}

	private string GetDisplayString(bool previousGenes)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < 6; i++)
		{
			stringBuilder.Append(GrowableGene.GetDisplayCharacter(previousGenes ? Genes[i].PreviousType : Genes[i].Type));
		}
		return stringBuilder.ToString();
	}
}
