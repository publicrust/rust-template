using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class MeshPaintController : MonoBehaviour, IClientComponent
{
	public enum Tool
	{
		Brush,
		Eraser,
		ColorPicker
	}

	public enum RotateMode
	{
		None,
		Movement,
		Random
	}

	public Camera pickerCamera;

	public Tool currentTool;

	public Texture2D brushTexture;

	public Vector2 brushScale = new Vector2(8f, 8f);

	public Color brushColor = Color.white;

	public float brushSpacing = 2f;

	public float brushSpacingFactor = 0.25f;

	public RawImage brushImage;

	public float brushPreviewScaleMultiplier = 1f;

	public Texture2D stampTexture;

	public RotateMode brushRotation;

	public bool applyDefaults;

	public Texture2D defaltBrushTexture;

	public float defaultBrushSize = 16f;

	public Color defaultBrushColor = Color.black;

	public float defaultBrushAlpha = 0.5f;

	public float maxBrushScale = 32f;

	public RustButton UndoButton;

	public RustButton RedoButton;

	public GameObject BackgroundBlocker;

	private Vector3 lastPosition;
}
