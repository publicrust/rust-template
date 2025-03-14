using UnityEngine;

public class MeshToggle : MonoBehaviour
{
	public Mesh[] RendererMeshes;

	public Mesh[] ColliderMeshes;

	public void SwitchRenderer(int index)
	{
		if (RendererMeshes.Length != 0)
		{
			MeshFilter component = GetComponent<MeshFilter>();
			if ((bool)component)
			{
				component.sharedMesh = RendererMeshes[Mathf.Clamp(index, 0, RendererMeshes.Length - 1)];
			}
		}
	}

	public void SwitchRenderer(float factor)
	{
		int index = Mathf.RoundToInt(factor * (float)RendererMeshes.Length);
		SwitchRenderer(index);
	}

	public void SwitchCollider(int index)
	{
		if (ColliderMeshes.Length != 0)
		{
			MeshCollider component = GetComponent<MeshCollider>();
			if ((bool)component)
			{
				component.sharedMesh = ColliderMeshes[Mathf.Clamp(index, 0, ColliderMeshes.Length - 1)];
			}
		}
	}

	public void SwitchCollider(float factor)
	{
		int index = Mathf.RoundToInt(factor * (float)ColliderMeshes.Length);
		SwitchCollider(index);
	}

	public void SwitchAll(int index)
	{
		SwitchRenderer(index);
		SwitchCollider(index);
	}

	public void SwitchAll(float factor)
	{
		SwitchRenderer(factor);
		SwitchCollider(factor);
	}
}
