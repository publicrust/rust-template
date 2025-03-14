using UnityEngine;

public class HolosightReticlePositioning : MonoBehaviour
{
	public IronsightAimPoint aimPoint;

	public RectTransform rectTransform => base.transform as RectTransform;

	private void Update()
	{
		if (MainCamera.isValid)
		{
			UpdatePosition(MainCamera.mainCamera);
		}
	}

	private void UpdatePosition(Camera cam)
	{
		Vector3 position = aimPoint.targetPoint.transform.position;
		Vector2 localPoint = RectTransformUtility.WorldToScreenPoint(cam, position);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, localPoint, cam, out localPoint);
		localPoint.x /= (rectTransform.parent as RectTransform).rect.width * 0.5f;
		localPoint.y /= (rectTransform.parent as RectTransform).rect.height * 0.5f;
		rectTransform.anchoredPosition = localPoint;
	}
}
