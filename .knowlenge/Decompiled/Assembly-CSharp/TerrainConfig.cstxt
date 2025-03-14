using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Rust/Terrain Config")]
public class TerrainConfig : ScriptableObject
{
	[Serializable]
	public class SplatType
	{
		public string Name = "";

		[FormerlySerializedAs("WarmColor")]
		public Color AridColor = Color.white;

		[FormerlySerializedAs("Color")]
		public Color TemperateColor = Color.white;

		[FormerlySerializedAs("ColdColor")]
		public Color TundraColor = Color.white;

		[FormerlySerializedAs("ColdColor")]
		public Color ArcticColor = Color.white;

		public PhysicMaterial Material;

		public float SplatTiling = 5f;

		[Range(0f, 1f)]
		public float UVMIXMult = 0.15f;

		public float UVMIXStart;

		public float UVMIXDist = 100f;
	}

	public bool CastShadows = true;

	public LayerMask GroundMask = 0;

	public LayerMask WaterMask = 0;

	public PhysicMaterial GenericMaterial;

	public Material Material;

	public Material MarginMaterial;

	public Texture[] AlbedoArrays = new Texture[3];

	public Texture[] NormalArrays = new Texture[3];

	public float HeightMapErrorMin = 5f;

	public float HeightMapErrorMax = 100f;

	public float BaseMapDistanceMin = 100f;

	public float BaseMapDistanceMax = 500f;

	public float ShaderLodMin = 100f;

	public float ShaderLodMax = 600f;

	public SplatType[] Splats = new SplatType[8];

	public Texture AlbedoArray => AlbedoArrays[Mathf.Clamp(QualitySettings.masterTextureLimit, 0, 2)];

	public Texture NormalArray => NormalArrays[Mathf.Clamp(QualitySettings.masterTextureLimit, 0, 2)];

	public PhysicMaterial[] GetPhysicMaterials()
	{
		PhysicMaterial[] array = new PhysicMaterial[Splats.Length];
		for (int i = 0; i < Splats.Length; i++)
		{
			array[i] = Splats[i].Material;
		}
		return array;
	}

	public Color[] GetAridColors()
	{
		Color[] array = new Color[Splats.Length];
		for (int i = 0; i < Splats.Length; i++)
		{
			array[i] = Splats[i].AridColor;
		}
		return array;
	}

	public Color[] GetTemperateColors()
	{
		Color[] array = new Color[Splats.Length];
		for (int i = 0; i < Splats.Length; i++)
		{
			array[i] = Splats[i].TemperateColor;
		}
		return array;
	}

	public Color[] GetTundraColors()
	{
		Color[] array = new Color[Splats.Length];
		for (int i = 0; i < Splats.Length; i++)
		{
			array[i] = Splats[i].TundraColor;
		}
		return array;
	}

	public Color[] GetArcticColors()
	{
		Color[] array = new Color[Splats.Length];
		for (int i = 0; i < Splats.Length; i++)
		{
			array[i] = Splats[i].ArcticColor;
		}
		return array;
	}

	public float[] GetSplatTiling()
	{
		float[] array = new float[Splats.Length];
		for (int i = 0; i < Splats.Length; i++)
		{
			array[i] = Splats[i].SplatTiling;
		}
		return array;
	}

	public float GetMaxSplatTiling()
	{
		float num = float.MinValue;
		for (int i = 0; i < Splats.Length; i++)
		{
			if (Splats[i].SplatTiling > num)
			{
				num = Splats[i].SplatTiling;
			}
		}
		return num;
	}

	public float GetMinSplatTiling()
	{
		float num = float.MaxValue;
		for (int i = 0; i < Splats.Length; i++)
		{
			if (Splats[i].SplatTiling < num)
			{
				num = Splats[i].SplatTiling;
			}
		}
		return num;
	}

	public Vector3[] GetPackedUVMIX()
	{
		Vector3[] array = new Vector3[Splats.Length];
		for (int i = 0; i < Splats.Length; i++)
		{
			array[i] = new Vector3(Splats[i].UVMIXMult, Splats[i].UVMIXStart, Splats[i].UVMIXDist);
		}
		return array;
	}
}
