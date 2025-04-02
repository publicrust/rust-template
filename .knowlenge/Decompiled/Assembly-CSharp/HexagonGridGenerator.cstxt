using System;
using System.Collections.Generic;
using UnityEngine;

public class HexagonGridGenerator : BaseEntity
{
	public GameObjectRef[] hexTilePrefabs;

	[Space]
	public int gridRadius = 5;

	public float tileSpacing = 1.5f;

	[Space]
	public float levelCount = 5f;

	public float levelSpacing = 20f;

	private readonly List<HexagonTile> hexTiles = new List<HexagonTile>();

	public static HexagonGridGenerator Instance;

	public override void ServerInit()
	{
		base.ServerInit();
		Instance = this;
		GenerateHexGrid();
	}

	public void GenerateHexGrid()
	{
		for (int num = hexTiles.Count; num > 0; num--)
		{
			hexTiles[num - 1].Kill();
		}
		hexTiles.Clear();
		for (int i = 0; (float)i < levelCount; i++)
		{
			GenerateLevel(base.transform.position + Vector3.up * (levelSpacing * (float)(i + 1)), i);
		}
	}

	private void GenerateLevel(Vector3 basePos, int level)
	{
		float num = tileSpacing * 2f;
		float num2 = Mathf.Sqrt(3f) * tileSpacing;
		for (int i = -gridRadius; i <= gridRadius; i++)
		{
			int num3 = Mathf.Max(-gridRadius, -i - gridRadius);
			int num4 = Mathf.Min(gridRadius, -i + gridRadius);
			for (int j = num3; j <= num4; j++)
			{
				float x = ((float)i + (float)j / 2f) * num;
				float z = (float)j * num2;
				Vector3 pos = basePos + new Vector3(x, 0f, z);
				int num5 = UnityEngine.Random.Range(-5, 6);
				float y = 30f + 180f * (float)num5;
				Quaternion rot = Quaternion.Euler(0f, y, 0f);
				HexagonTile hexagonTile = GameManager.server.CreateEntity(hexTilePrefabs[level].resourcePath, pos, rot) as HexagonTile;
				hexagonTile.Spawn();
				hexTiles.Add(hexagonTile);
			}
		}
	}

	[ServerVar(Help = "<gridSize> 5 <tileSpacing> 1.35")]
	public static void generategrid(ConsoleSystem.Arg args)
	{
		int @int = args.GetInt(0, 5);
		float @float = args.GetFloat(1, 1.35f);
		@int = Math.Clamp(@int, 1, 50);
		@float = Mathf.Clamp(@float, 1.35f, float.PositiveInfinity);
		Instance.gridRadius = @int;
		Instance.tileSpacing = @float;
		Instance.GenerateHexGrid();
	}
}
