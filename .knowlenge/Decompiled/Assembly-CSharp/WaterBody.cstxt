using UnityEngine;

[ExecuteInEditMode]
public class WaterBody : MonoBehaviour
{
	public WaterBodyType Type = WaterBodyType.Lake;

	public Renderer Renderer;

	public Collider[] Triggers;

	public bool IsOcean;

	public Transform Transform { get; private set; }

	private void Awake()
	{
		Transform = base.transform;
	}

	private void OnEnable()
	{
		WaterSystem.RegisterBody(this);
	}

	private void OnDisable()
	{
		WaterSystem.UnregisterBody(this);
	}

	public void OnOceanLevelChanged(float newLevel)
	{
		if (IsOcean)
		{
			Collider[] triggers = Triggers;
			foreach (Collider obj in triggers)
			{
				Vector3 position = obj.transform.position;
				position.y = newLevel;
				obj.transform.position = position;
			}
		}
	}
}
