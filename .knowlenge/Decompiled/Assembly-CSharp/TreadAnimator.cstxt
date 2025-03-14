using System;
using UnityEngine;

public class TreadAnimator : MonoBehaviour, IClientComponent
{
	[Serializable]
	public struct TreadRenderer
	{
		public Renderer Renderer;

		public int leftMaterialIndex;

		public int rightMaterialIndex;
	}

	public Animator mainBodyAnimator;

	public Transform[] wheelBones;

	public Vector3[] vecShocksOffsetPosition;

	public Vector3[] wheelBoneOrigin;

	public float wheelBoneDistMax = 0.26f;

	public TreadRenderer[] treadRenderers;

	public TreadEffects treadEffects;

	public float traceThickness = 0.25f;

	public float heightFudge = 0.13f;

	public bool useWheelYOrigin;

	public Vector2 treadTextureDirection = new Vector2(1f, 0f);

	public bool isMetallic;

	public float angularTreadConstant = 0.05f;

	public float treadConstant = 0.14f;

	public float wheelSpinConstant = 80f;

	public float traceLineMin = 0.55f;

	public float traceLineMax = 0.79f;

	public float maxShockDist = 0.26f;
}
