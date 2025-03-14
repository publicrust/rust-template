using UnityEngine;

public class GenerateDecorTopology : ProceduralComponent
{
	public bool KeepExisting = true;

	public override void Process(uint seed)
	{
		TerrainTopologyMap topomap = TerrainMeta.TopologyMap;
		int topores = topomap.res;
		Parallel.For(0, topores, delegate(int z)
		{
			for (int i = 0; i < topores; i++)
			{
				if (topomap.GetTopology(i, z, 4194306))
				{
					topomap.AddTopology(i, z, 512);
				}
				else if (!KeepExisting)
				{
					topomap.RemoveTopology(i, z, 512);
				}
			}
		});
	}
}
