using System.Collections.Generic;

public class ProcessMonumentNodes : ProceduralComponent
{
	public override void Process(uint seed)
	{
		List<MonumentNode> monumentNodes = SingletonComponent<WorldSetup>.Instance.MonumentNodes;
		if (!World.Cached)
		{
			for (int i = 0; i < monumentNodes.Count; i++)
			{
				monumentNodes[i].Process(ref seed);
			}
		}
		monumentNodes.Clear();
	}
}
