using UnityEngine;

public class ExplosionsScaleCurves : MonoBehaviour
{
	public AnimationCurve ScaleCurveX = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	public AnimationCurve ScaleCurveY = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	public AnimationCurve ScaleCurveZ = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	public Vector3 GraphTimeMultiplier = Vector3.one;

	public Vector3 GraphScaleMultiplier = Vector3.one;

	private float startTime;

	private Transform t;

	private float evalX;

	private float evalY;

	private float evalZ;

	private void Awake()
	{
		t = base.transform;
	}

	private void OnEnable()
	{
		startTime = Time.time;
		evalX = 0f;
		evalY = 0f;
		evalZ = 0f;
	}

	private void Update()
	{
		float num = Time.time - startTime;
		if (num <= GraphTimeMultiplier.x)
		{
			evalX = ScaleCurveX.Evaluate(num / GraphTimeMultiplier.x) * GraphScaleMultiplier.x;
		}
		if (num <= GraphTimeMultiplier.y)
		{
			evalY = ScaleCurveY.Evaluate(num / GraphTimeMultiplier.y) * GraphScaleMultiplier.y;
		}
		if (num <= GraphTimeMultiplier.z)
		{
			evalZ = ScaleCurveZ.Evaluate(num / GraphTimeMultiplier.z) * GraphScaleMultiplier.z;
		}
		t.localScale = new Vector3(evalX, evalY, evalZ);
	}
}
