using UnityEngine;

public class LayerCullDistance : MonoBehaviour
{
	public string Layer = "Default";

	public float Distance = 1000f;

	protected void OnEnable()
	{
		Camera component = GetComponent<Camera>();
		float[] layerCullDistances = component.layerCullDistances;
		layerCullDistances[LayerMask.NameToLayer(Layer)] = Distance;
		component.layerCullDistances = layerCullDistances;
	}
}
