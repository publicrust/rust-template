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
			TopImage.color = Color;
			BottomImage.color = Color;
			LeftImage.color = Color;
			RightImage.color = Color;
			_lastColor = Color;
		}
	}
}
