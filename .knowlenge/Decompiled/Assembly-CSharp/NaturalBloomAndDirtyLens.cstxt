using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Natural Bloom and Dirty Lens")]
public class NaturalBloomAndDirtyLens : MonoBehaviour
{
	public Shader shader;

	public Texture2D lensDirtTexture;

	public float range = 10000f;

	public float cutoff = 1f;

	[Range(0f, 1f)]
	public float bloomIntensity = 0.05f;

	[Range(0f, 1f)]
	public float lensDirtIntensity = 0.05f;

	[Range(0f, 4f)]
	public float spread = 1f;

	[Range(0f, 4f)]
	public int iterations = 1;

	[Range(1f, 10f)]
	public int mips = 6;

	public float[] mipWeights = new float[6] { 0.5f, 0.6f, 0.6f, 0.45f, 0.35f, 0.23f };

	public bool highPrecision;

	public bool downscaleSource;

	public bool debug;

	public bool temporalFilter;

	[Range(0.01f, 1f)]
	public float temporalFilterWeight = 0.75f;
}
