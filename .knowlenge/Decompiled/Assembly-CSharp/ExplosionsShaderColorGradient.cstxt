using UnityEngine;

public class ExplosionsShaderColorGradient : MonoBehaviour
{
	public string ShaderProperty = "_TintColor";

	public int MaterialID;

	public Gradient Color = new Gradient();

	public float TimeMultiplier = 1f;

	private bool canUpdate;

	private Material matInstance;

	private int propertyID;

	private float startTime;

	private Color oldColor;

	private void Start()
	{
		Material[] materials = GetComponent<Renderer>().materials;
		if (MaterialID >= materials.Length)
		{
			Debug.Log("ShaderColorGradient: Material ID more than shader materials count.");
		}
		matInstance = materials[MaterialID];
		if (!matInstance.HasProperty(ShaderProperty))
		{
			Debug.Log("ShaderColorGradient: Shader not have \"" + ShaderProperty + "\" property");
		}
		propertyID = Shader.PropertyToID(ShaderProperty);
		oldColor = matInstance.GetColor(propertyID);
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
			Color color = Color.Evaluate(num / TimeMultiplier);
			matInstance.SetColor(propertyID, color * oldColor);
		}
		if (num >= TimeMultiplier)
		{
			canUpdate = false;
		}
	}
}
