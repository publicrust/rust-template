using UnityEngine;

public class FlameJet : MonoBehaviour
{
	public LineRenderer line;

	public float tesselation = 0.025f;

	private float length;

	public float maxLength = 2f;

	public float drag;

	private int numSegments;

	private float spacing;

	public bool on;

	public bool autoDisable;

	private Vector3[] lastWorldSegments;

	private Vector3[] currentSegments = new Vector3[0];

	public Color startColor;

	public Color endColor;

	public Color currentColor;

	public bool externalUpdate;

	private void Initialize()
	{
		currentColor = startColor;
		tesselation = 0.1f;
		numSegments = Mathf.CeilToInt(maxLength / tesselation);
		spacing = maxLength / (float)numSegments;
		if (currentSegments.Length != numSegments)
		{
			currentSegments = new Vector3[numSegments];
		}
	}

	private void Awake()
	{
		Initialize();
	}

	public void LateUpdate()
	{
		if (!externalUpdate)
		{
			UpdateLine();
		}
	}

	public void SetOn(bool isOn)
	{
		on = isOn;
	}

	private float curve(float x)
	{
		return x * x;
	}

	public void UpdateLine()
	{
		currentColor.a = Mathf.Lerp(currentColor.a, on ? 1f : 0f, Time.deltaTime * 40f);
		line.SetColors(currentColor, endColor);
		if (lastWorldSegments == null)
		{
			lastWorldSegments = new Vector3[numSegments];
		}
		int num = currentSegments.Length;
		for (int i = 0; i < num; i++)
		{
			float x = 0f;
			float y = 0f;
			if (lastWorldSegments != null && lastWorldSegments[i] != Vector3.zero && i > 0)
			{
				Vector3 a = base.transform.InverseTransformPoint(lastWorldSegments[i]);
				float f = (float)i / (float)currentSegments.Length;
				Vector3 b = Vector3.Lerp(a, Vector3.zero, Time.deltaTime * drag);
				b = Vector3.Lerp(Vector3.zero, b, Mathf.Sqrt(f));
				x = b.x;
				y = b.y;
			}
			if (i == 0)
			{
				x = (y = 0f);
			}
			Vector3 vector = new Vector3(x, y, (float)i * spacing);
			currentSegments[i] = vector;
			lastWorldSegments[i] = base.transform.TransformPoint(vector);
		}
		line.positionCount = numSegments;
		line.SetPositions(currentSegments);
		if (autoDisable && !on && currentColor.a < 0.01f)
		{
			currentColor.a = 0f;
			line.SetColors(currentColor, endColor);
			base.enabled = false;
		}
	}
}
