using UnityEngine;

public class ScaleTransform : ScaleRenderer
{
	private Vector3 initialScale;

	public override void SetScale_Internal(float scale)
	{
		base.SetScale_Internal(scale);
		myRenderer.transform.localScale = initialScale * scale;
	}

	public override void GatherInitialValues()
	{
		initialScale = myRenderer.transform.localScale;
		base.GatherInitialValues();
	}
}
