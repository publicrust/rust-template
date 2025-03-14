using System;
using System.Collections;
using UnityEngine;

internal class UVTextureAnimator : MonoBehaviour
{
	public int Rows = 4;

	public int Columns = 4;

	public float Fps = 20f;

	public int OffsetMat;

	public bool IsLoop = true;

	public float StartDelay;

	private bool isInizialised;

	private int index;

	private int count;

	private int allCount;

	private float deltaFps;

	private bool isVisible;

	private bool isCorutineStarted;

	private Renderer currentRenderer;

	private Material instanceMaterial;

	private void Start()
	{
		currentRenderer = GetComponent<Renderer>();
		InitDefaultVariables();
		isInizialised = true;
		isVisible = true;
		Play();
	}

	private void InitDefaultVariables()
	{
		currentRenderer = GetComponent<Renderer>();
		if (currentRenderer == null)
		{
			throw new Exception("UvTextureAnimator can't get renderer");
		}
		if (!currentRenderer.enabled)
		{
			currentRenderer.enabled = true;
		}
		allCount = 0;
		deltaFps = 1f / Fps;
		count = Rows * Columns;
		index = Columns - 1;
		Vector3 zero = Vector3.zero;
		OffsetMat -= OffsetMat / count * count;
		Vector2 value = new Vector2(1f / (float)Columns, 1f / (float)Rows);
		if (currentRenderer != null)
		{
			instanceMaterial = currentRenderer.material;
			instanceMaterial.SetTextureScale("_MainTex", value);
			instanceMaterial.SetTextureOffset("_MainTex", zero);
		}
	}

	private void Play()
	{
		if (!isCorutineStarted)
		{
			if (StartDelay > 0.0001f)
			{
				Invoke("PlayDelay", StartDelay);
			}
			else
			{
				StartCoroutine(UpdateCorutine());
			}
			isCorutineStarted = true;
		}
	}

	private void PlayDelay()
	{
		StartCoroutine(UpdateCorutine());
	}

	private void OnEnable()
	{
		if (isInizialised)
		{
			InitDefaultVariables();
			isVisible = true;
			Play();
		}
	}

	private void OnDisable()
	{
		isCorutineStarted = false;
		isVisible = false;
		StopAllCoroutines();
		CancelInvoke("PlayDelay");
	}

	private IEnumerator UpdateCorutine()
	{
		while (isVisible && (IsLoop || allCount != count))
		{
			UpdateCorutineFrame();
			if (!IsLoop && allCount == count)
			{
				break;
			}
			yield return new WaitForSeconds(deltaFps);
		}
		isCorutineStarted = false;
		currentRenderer.enabled = false;
	}

	private void UpdateCorutineFrame()
	{
		allCount++;
		index++;
		if (index >= count)
		{
			index = 0;
		}
		Vector2 value = new Vector2((float)index / (float)Columns - (float)(index / Columns), 1f - (float)(index / Columns) / (float)Rows);
		if (currentRenderer != null)
		{
			instanceMaterial.SetTextureOffset("_MainTex", value);
		}
	}

	private void OnDestroy()
	{
		if (instanceMaterial != null)
		{
			UnityEngine.Object.Destroy(instanceMaterial);
			instanceMaterial = null;
		}
	}
}
