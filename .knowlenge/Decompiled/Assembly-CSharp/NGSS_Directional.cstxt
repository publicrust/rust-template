using ConVar;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Light))]
public class NGSS_Directional : MonoBehaviour
{
	public enum SAMPLER_COUNT
	{
		SAMPLERS_16,
		SAMPLERS_25,
		SAMPLERS_32,
		SAMPLERS_64
	}

	[Tooltip("Overall softness for both PCF and PCSS shadows.\nRecommended value: 0.01.")]
	[Range(0f, 0.02f)]
	public float PCSS_GLOBAL_SOFTNESS = 0.01f;

	[Tooltip("PCSS softness when shadows is close to caster.\nRecommended value: 0.05.")]
	[Range(0f, 1f)]
	public float PCSS_FILTER_DIR_MIN = 0.05f;

	[Tooltip("PCSS softness when shadows is far from caster.\nRecommended value: 0.25.\nIf too high can lead to visible artifacts when early bailout is enabled.")]
	[Range(0f, 0.5f)]
	public float PCSS_FILTER_DIR_MAX = 0.25f;

	[Tooltip("Amount of banding or noise. Example: 0.0 gives 100 % Banding and 10.0 gives 100 % Noise.")]
	[Range(0f, 10f)]
	public float BANDING_NOISE_AMOUNT = 1f;

	[Tooltip("Recommended values: Mobile = 16, Consoles = 25, Desktop Low = 32, Desktop High = 64")]
	public SAMPLER_COUNT SAMPLERS_COUNT;

	private void Update()
	{
		bool globalSettings = ConVar.Graphics.shadowquality >= 2;
		SetGlobalSettings(globalSettings);
	}

	private void SetGlobalSettings(bool enabled)
	{
		if (enabled)
		{
			Shader.SetGlobalFloat("NGSS_PCSS_GLOBAL_SOFTNESS", PCSS_GLOBAL_SOFTNESS);
			Shader.SetGlobalFloat("NGSS_PCSS_FILTER_DIR_MIN", (PCSS_FILTER_DIR_MIN > PCSS_FILTER_DIR_MAX) ? PCSS_FILTER_DIR_MAX : PCSS_FILTER_DIR_MIN);
			Shader.SetGlobalFloat("NGSS_PCSS_FILTER_DIR_MAX", (PCSS_FILTER_DIR_MAX < PCSS_FILTER_DIR_MIN) ? PCSS_FILTER_DIR_MIN : PCSS_FILTER_DIR_MAX);
			Shader.SetGlobalFloat("NGSS_POISSON_SAMPLING_NOISE_DIR", BANDING_NOISE_AMOUNT);
		}
	}
}
