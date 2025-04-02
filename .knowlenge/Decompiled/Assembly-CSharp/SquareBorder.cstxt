using UnityEngine;
using UnityEngine.UI;

public class SquareBorder : MonoBehaviour
{
	public float Size;

	public Color Color;

	public RectTransform Top;

	public RectTransform Bottom;

	public RectTransform Left;

	public RectTransform Right;

	public Image TopImage;

	public Image BottomImage;

	public Image LeftImage;

	public Image RightImage;

	private float _lastSize;

	private Color _lastColor;

	private void Update()
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		if (_lastSize != Size)
		{
			Top.offsetMin = new Vector2(0f, 0f - Size);
			Bottom.offsetMax = new Vector2(0f, Size);
			Left.offsetMin = new Vector2(0f, Size);
			Left.offsetMax = new Vector2(Size, 0f - Size);
			Right.offsetMin = new Vector2(0f - Size, Size);
			Right.offsetMax = new Vector2(0f, 0f - Size);
			_lastSize = Size;
		}
		if (_lastColor != Color)
		{
			((Graphic)TopImage).color = Color;
			((Graphic)BottomImage).color = Color;
			((Graphic)LeftImage).color = Color;
			((Graphic)RightImage).color = Color;
			_lastColor = Color;
		}
	}
}
