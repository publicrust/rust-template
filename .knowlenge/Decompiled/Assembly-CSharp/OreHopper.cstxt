using UnityEngine;

public class OreHopper : PercentFullStorageContainer
{
	[SerializeField]
	private Transform oreOutputMesh;

	private float visualPercentFull;

	private Vector3 _oreScale = new Vector3(1f, 0f, 1f);

	protected override void OnPercentFullChanged(float newPercentFull)
	{
		VisualLerpToOreLevel();
	}

	private void SetVisualOreLevel(float percentFull)
	{
		_oreScale.y = Mathf.Clamp01(percentFull);
		oreOutputMesh.localScale = _oreScale;
		oreOutputMesh.gameObject.SetActive(percentFull > 0f);
		visualPercentFull = percentFull;
	}

	public void VisualLerpToOreLevel()
	{
		if (GetPercentFull() != visualPercentFull)
		{
			InvokeRepeating(OreVisualLerpUpdate, 0f, 0f);
		}
	}

	private void OreVisualLerpUpdate()
	{
		float percentFull = GetPercentFull();
		if (Mathf.Abs(visualPercentFull - percentFull) < 0.005f)
		{
			SetVisualOreLevel(percentFull);
			CancelInvoke(OreVisualLerpUpdate);
		}
		else
		{
			float visualOreLevel = Mathf.Lerp(visualPercentFull, percentFull, Time.deltaTime * 1.5f);
			SetVisualOreLevel(visualOreLevel);
		}
	}

	public override void ServerInit()
	{
		base.ServerInit();
		SetVisualOreLevel(GetPercentFull());
	}
}
