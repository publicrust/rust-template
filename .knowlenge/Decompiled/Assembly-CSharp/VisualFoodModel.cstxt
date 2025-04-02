using UnityEngine;

public class VisualFoodModel : MonoBehaviour, IClientComponent
{
	public MeshRenderer[] meshRenderers;

	public Animator animator;

	public bool stopEffectOnEnd;

	public ParticleSystemContainer particleContainer;

	public bool lerpScale;

	public Vector3 startScale;

	public Vector3 endScale;

	public AnimationCurve riseCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	public AnimationCurve colorCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public SoundDefinition cookingSound;
}
