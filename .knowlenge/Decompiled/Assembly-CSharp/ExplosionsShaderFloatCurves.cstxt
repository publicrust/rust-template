using UnityEngine;

public class ExplosionsShaderFloatCurves : MonoBehaviour
{
	public string ShaderProperty = "_BumpAmt";

	public int MaterialID;

	public AnimationCurve FloatPropertyCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	public float GraphTimeMultiplier = 1f;

	public float GraphScaleMultiplier = 1f;

	private bool canUpdate;

	private Material matInstance;

	private int propertyID;

	private float startTime;

	private void Start()
	{
		Material[] materials = ((Component)this).GetComponent<Renderer>().materials;
		if (MaterialID >= materials.Length)
		{
			Debug.Log((object)"ShaderColorGradient: Material ID more than shader materials count.");
		}
		matInstance = materials[MaterialID];
		if (!matInstance.HasProperty(ShaderProperty))
		{
			Debug.Log((object)("ShaderColorGradient: Shader not have \"" + ShaderProperty + "\" property"));
		}
		propertyID = Shader.PropertyToID(ShaderProperty);
	}

	private void OnEnable()
	{
		startTime = Time.time;
		canUpdate = true;
	}

	private void Update()
	{
		float num = Time.time - startTime;
		if (canUpdate)
		{
			float num2 = FloatPropertyCurve.Evaluate(num / GraphTimeMultiplier) * GraphScaleMultiplier;
			matInstance.SetFloat(propertyID, num2);
		}
		if (num >= GraphTimeMultiplier)
		{
			canUpdate = false;
		}
	}
}
