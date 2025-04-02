public class GrowableGene
{
	public GrowableGenetics.GeneType Type { get; private set; }

	public GrowableGenetics.GeneType PreviousType { get; private set; }

	public void Set(GrowableGenetics.GeneType geneType, bool firstSet = false)
	{
		if (firstSet)
		{
			SetPrevious(geneType);
		}
		else
		{
			SetPrevious(Type);
		}
		Type = geneType;
	}

	public void SetPrevious(GrowableGenetics.GeneType type)
	{
		PreviousType = type;
	}

	public string GetDisplayCharacter()
	{
		return GetDisplayCharacter(Type);
	}

	public static string GetDisplayCharacter(GrowableGenetics.GeneType type)
	{
		return type switch
		{
			GrowableGenetics.GeneType.Empty => "X", 
			GrowableGenetics.GeneType.GrowthSpeed => "G", 
			GrowableGenetics.GeneType.Hardiness => "H", 
			GrowableGenetics.GeneType.WaterRequirement => "W", 
			GrowableGenetics.GeneType.Yield => "Y", 
			_ => "U", 
		};
	}

	public string GetColourCodedDisplayCharacter()
	{
		return GetColourCodedDisplayCharacter(Type);
	}

	public static string GetColourCodedDisplayCharacter(GrowableGenetics.GeneType type)
	{
		return "<color=" + (IsPositive(type) ? "#60891B>" : "#AA4734>") + GetDisplayCharacter(type) + "</color>";
	}

	public static bool IsPositive(GrowableGenetics.GeneType type)
	{
		return type switch
		{
			GrowableGenetics.GeneType.Empty => false, 
			GrowableGenetics.GeneType.GrowthSpeed => true, 
			GrowableGenetics.GeneType.Hardiness => true, 
			GrowableGenetics.GeneType.WaterRequirement => false, 
			GrowableGenetics.GeneType.Yield => true, 
			_ => false, 
		};
	}

	public bool IsPositive()
	{
		return IsPositive(Type);
	}
}
