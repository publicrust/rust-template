using System.Collections.Generic;
using UnityEngine;

public class VertexColorAnimator : MonoBehaviour
{
	public List<MeshHolder> animationMeshes;

	public List<float> animationKeyframes;

	public float timeScale = 2f;

	public int mode;

	private float elapsedTime;

	public void initLists()
	{
		animationMeshes = new List<MeshHolder>();
		animationKeyframes = new List<float>();
	}

	public void addMesh(Mesh mesh, float atPosition)
	{
		MeshHolder meshHolder = new MeshHolder();
		meshHolder.setAnimationData(mesh);
		animationMeshes.Add(meshHolder);
		animationKeyframes.Add(atPosition);
	}

	private void Start()
	{
		elapsedTime = 0f;
	}

	public void replaceKeyframe(int frameIndex, Mesh mesh)
	{
		animationMeshes[frameIndex].setAnimationData(mesh);
	}

	public void deleteKeyframe(int frameIndex)
	{
		animationMeshes.RemoveAt(frameIndex);
		animationKeyframes.RemoveAt(frameIndex);
	}

	public void scrobble(float scrobblePos)
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		if (animationMeshes.Count == 0)
		{
			return;
		}
		Color[] array = (Color[])(object)new Color[((Component)this).GetComponent<MeshFilter>().sharedMesh.colors.Length];
		int num = 0;
		for (int i = 0; i < animationKeyframes.Count; i++)
		{
			if (scrobblePos >= animationKeyframes[i])
			{
				num = i;
			}
		}
		if (num >= animationKeyframes.Count - 1)
		{
			((Component)this).GetComponent<VertexColorStream>().setColors(animationMeshes[num]._colors);
			return;
		}
		float num2 = animationKeyframes[num + 1] - animationKeyframes[num];
		float num3 = animationKeyframes[num];
		float num4 = (scrobblePos - num3) / num2;
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = Color.Lerp(animationMeshes[num]._colors[j], animationMeshes[num + 1]._colors[j], num4);
		}
		((Component)this).GetComponent<VertexColorStream>().setColors(array);
	}

	private void Update()
	{
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		if (mode == 0)
		{
			elapsedTime += Time.fixedDeltaTime / timeScale;
		}
		else if (mode == 1)
		{
			elapsedTime += Time.fixedDeltaTime / timeScale;
			if (elapsedTime > 1f)
			{
				elapsedTime = 0f;
			}
		}
		else if (mode == 2)
		{
			if (Mathf.FloorToInt(Time.fixedTime / timeScale) % 2 == 0)
			{
				elapsedTime += Time.fixedDeltaTime / timeScale;
			}
			else
			{
				elapsedTime -= Time.fixedDeltaTime / timeScale;
			}
		}
		Color[] array = (Color[])(object)new Color[((Component)this).GetComponent<MeshFilter>().sharedMesh.colors.Length];
		int num = 0;
		for (int i = 0; i < animationKeyframes.Count; i++)
		{
			if (elapsedTime >= animationKeyframes[i])
			{
				num = i;
			}
		}
		if (num < animationKeyframes.Count - 1)
		{
			float num2 = animationKeyframes[num + 1] - animationKeyframes[num];
			float num3 = animationKeyframes[num];
			float num4 = (elapsedTime - num3) / num2;
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = Color.Lerp(animationMeshes[num]._colors[j], animationMeshes[num + 1]._colors[j], num4);
			}
		}
		else
		{
			array = animationMeshes[num]._colors;
		}
		((Component)this).GetComponent<VertexColorStream>().setColors(array);
	}
}
