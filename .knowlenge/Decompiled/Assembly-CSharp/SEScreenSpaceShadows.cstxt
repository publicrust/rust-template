using UnityEngine;
using UnityEngine.Rendering;

[AddComponentMenu("Image Effects/Sonic Ether/SE Screen-Space Shadows")]
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class SEScreenSpaceShadows : SingletonComponent<SEScreenSpaceShadows>, IClientComponent
{
	private CommandBuffer blendShadowsCommandBuffer;

	private CommandBuffer renderShadowsCommandBuffer;

	private Camera attachedCamera;

	public Light sun;

	[Range(0f, 1f)]
	public float blendStrength = 1f;

	[Range(0f, 1f)]
	public float accumulation = 0.9f;

	[Range(0.1f, 5f)]
	public float lengthFade = 0.7f;

	[Range(0.01f, 5f)]
	public float range = 0.7f;

	[Range(0f, 1f)]
	public float zThickness = 0.1f;

	[Range(2f, 92f)]
	public int samples = 32;

	[Range(0.5f, 4f)]
	public float nearSampleQuality = 1.5f;

	[Range(0f, 1f)]
	public float traceBias = 0.03f;

	public bool stochasticSampling = true;

	public bool leverageTemporalAA;

	public bool bilateralBlur = true;

	[Range(1f, 2f)]
	public int blurPasses = 1;

	[Range(0.01f, 0.5f)]
	public float blurDepthTolerance = 0.1f;
}
