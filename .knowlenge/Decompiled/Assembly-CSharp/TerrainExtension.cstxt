using System;
using Facepunch.Extend;
using UnityEngine;

[RequireComponent(typeof(TerrainMeta))]
public abstract class TerrainExtension : MonoBehaviour
{
	[NonSerialized]
	public bool isInitialized;

	internal Terrain terrain;

	internal TerrainConfig config;

	public void Init(Terrain terrain, TerrainConfig config)
	{
		this.terrain = terrain;
		this.config = config;
	}

	public virtual void Setup()
	{
	}

	public virtual void PostSetup()
	{
	}

	public void LogSize(object obj, ulong size)
	{
		Debug.Log(obj.GetType()?.ToString() + " allocated: " + size.FormatBytes());
	}
}
