using Kino;
using Smaa;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.CinematicEffects;
using UnityStandardAssets.ImageEffects;

public abstract class RustCamera<T> : SingletonComponent<T> where T : MonoBehaviour
{
	[SerializeField]
	private UnityStandardAssets.ImageEffects.DepthOfField dof;

	[SerializeField]
	private AmplifyOcclusionEffect ssao;

	[SerializeField]
	private Kino.Motion motionBlur;

	[SerializeField]
	private TOD_Rays shafts;

	[SerializeField]
	private TonemappingColorGrading tonemappingColorGrading;

	[SerializeField]
	private FXAA fxaa;

	[SerializeField]
	private SMAA smaa;

	[SerializeField]
	private PostProcessLayer post;

	[SerializeField]
	private CC_SharpenAndVignette sharpenAndVignette;

	[SerializeField]
	private SEScreenSpaceShadows contactShadows;

	[SerializeField]
	private VisualizeTexelDensity visualizeTexelDensity;

	[SerializeField]
	private EnvironmentVolumePropertiesCollection environmentVolumeProperties;

	[SerializeField]
	private ColorCorrectionCurves cctvCurves;
}
