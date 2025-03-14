using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreationGibSpawner : BaseMonoBehaviour
{
	[Serializable]
	public class GibReplacement
	{
		public GameObject oldGib;

		public GameObject newGib;
	}

	[Serializable]
	public class EffectMaterialPair
	{
		public PhysicMaterial material;

		public GameObjectRef effect;
	}

	[Serializable]
	public struct ConditionalGibSource
	{
		public GameObject source;

		public Vector3 pos;

		public Quaternion rot;
	}

	private GameObject gibSource;

	public GameObject gibsInstance;

	public float startTime;

	public float duration = 1f;

	public float buildScaleAdditionalAmount = 0.5f;

	[Tooltip("Entire object will be scaled on xyz during duration by this curve")]
	public AnimationCurve scaleCurve;

	[Tooltip("Object will be pushed out along transform.forward/right/up based on build direction by this amount")]
	public AnimationCurve buildCurve;

	[Tooltip("Additional scaling to apply to object based on build direction")]
	public AnimationCurve buildScaleCurve;

	public AnimationCurve xCurve;

	public AnimationCurve yCurve;

	public AnimationCurve zCurve;

	public Vector3[] spawnPositions;

	public GameObject[] particles;

	public float[] gibProgress;

	public PhysicMaterial physMaterial;

	public List<Transform> gibs;

	public bool started;

	public GameObjectRef placeEffect;

	public GameObject smokeEffect;

	public float effectSpacing = 0.2f;

	public bool invert;

	public Vector3 buildDirection;

	[Horizontal(1, 0)]
	public GibReplacement[] GibReplacements;

	public EffectMaterialPair[] effectLookup;

	private float startDelay;

	public List<ConditionalGibSource> conditionalGibSources = new List<ConditionalGibSource>();

	private float nextEffectTime = float.NegativeInfinity;

	public GameObjectRef GetEffectForMaterial(PhysicMaterial mat)
	{
		EffectMaterialPair[] array = effectLookup;
		foreach (EffectMaterialPair effectMaterialPair in array)
		{
			if (effectMaterialPair.material == mat)
			{
				return effectMaterialPair.effect;
			}
		}
		return effectLookup[0].effect;
	}

	public void SetDelay(float newDelay)
	{
		startDelay = newDelay;
	}

	public void FinishSpawn()
	{
		if (startDelay == 0f)
		{
			Init();
		}
		else
		{
			Invoke(Init, startDelay);
		}
	}

	public float GetProgress(float delay)
	{
		if (!started)
		{
			return 0f;
		}
		if (duration == 0f)
		{
			return 1f;
		}
		return Mathf.Clamp01((Time.time - (startTime + delay)) / duration);
	}

	public void AddConditionalGibSource(GameObject cGibSource, Vector3 pos, Quaternion rot)
	{
		Debug.Log("Adding conditional gib source");
		ConditionalGibSource item = default(ConditionalGibSource);
		item.source = cGibSource;
		item.pos = pos;
		item.rot = rot;
		conditionalGibSources.Add(item);
	}

	public void SetGibSource(GameObject newGibSource)
	{
		GameObject gameObject = newGibSource;
		for (int i = 0; i < GibReplacements.Length; i++)
		{
			if (GibReplacements[i].oldGib == newGibSource)
			{
				gameObject = GibReplacements[i].newGib;
				break;
			}
		}
		gibSource = gameObject;
	}

	private int SortsGibs(Transform a, Transform b)
	{
		MeshRenderer component = a.GetComponent<MeshRenderer>();
		MeshRenderer component2 = b.GetComponent<MeshRenderer>();
		if (!invert)
		{
			float num = ((component == null) ? a.localPosition.y : component.bounds.center.y);
			float value = ((component2 == null) ? b.localPosition.y : component2.bounds.center.y);
			return num.CompareTo(value);
		}
		float value2 = ((component == null) ? a.localPosition.y : component.bounds.center.y);
		return ((component2 == null) ? b.localPosition.y : component2.bounds.center.y).CompareTo(value2);
	}

	public void Init()
	{
		started = true;
		startTime = Time.time;
		gibsInstance = UnityEngine.Object.Instantiate(gibSource, base.transform.position, base.transform.rotation);
		List<Transform> list = gibsInstance.GetComponentsInChildren<Transform>().ToList();
		list.Remove(gibsInstance.transform);
		list.Sort(SortsGibs);
		gibs = list;
		spawnPositions = new Vector3[gibs.Count];
		gibProgress = new float[gibs.Count];
		particles = new GameObject[gibs.Count];
		for (int i = 0; i < gibs.Count; i++)
		{
			Transform transform = gibs[i];
			spawnPositions[i] = transform.localPosition;
			gibProgress[i] = 0f;
			particles[i] = null;
			transform.localScale = Vector3.one * scaleCurve.Evaluate(0f);
			_ = spawnPositions[i].x;
			_ = 0f;
			transform.transform.position += base.transform.right * GetPushDir(spawnPositions[i], transform) * buildCurve.Evaluate(0f) * buildDirection.x;
			transform.transform.position += base.transform.up * yCurve.Evaluate(0f);
			transform.transform.position += base.transform.forward * zCurve.Evaluate(0f);
		}
		Invoke(DestroyMe, duration + 0.05f);
	}

	public float GetPushDir(Vector3 spawnPos, Transform theGib)
	{
		if (!(spawnPos.x >= 0f))
		{
			return 1f;
		}
		return -1f;
	}

	public void DestroyMe()
	{
		UnityEngine.Object.Destroy(gibsInstance);
	}

	public float GetStartDelay(Transform gib)
	{
		return 0f;
	}

	public void Update()
	{
		if (!started)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		int num = Mathf.CeilToInt((float)gibs.Count / 10f);
		for (int i = 0; i < gibs.Count; i++)
		{
			Transform transform = gibs[i];
			if (transform == base.transform)
			{
				continue;
			}
			if (deltaTime <= 0f)
			{
				break;
			}
			float num2 = 0.33f;
			float num3 = num2 / ((float)gibs.Count * num2) * (duration - num2);
			float num4 = (float)i * num3;
			if (Time.time - startTime < num4)
			{
				continue;
			}
			MeshFilter component = transform.GetComponent<MeshFilter>();
			int seed = UnityEngine.Random.seed;
			UnityEngine.Random.seed = i + gibs.Count;
			bool num5 = num <= 1 || UnityEngine.Random.Range(0, num) == 0;
			UnityEngine.Random.seed = seed;
			if (num5 && particles[i] == null && component != null && component.sharedMesh != null)
			{
				if (component.sharedMesh.bounds.size.magnitude == 0f)
				{
					continue;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate(smokeEffect);
				gameObject.transform.SetParent(transform);
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localRotation = Quaternion.identity;
				ParticleSystem component2 = gameObject.GetComponent<ParticleSystem>();
				MeshRenderer component3 = component.GetComponent<MeshRenderer>();
				ParticleSystem.ShapeModule shape = component2.shape;
				shape.shapeType = ParticleSystemShapeType.Box;
				shape.boxThickness = component3.bounds.extents;
				particles[i] = gameObject;
			}
			float num6 = Mathf.Clamp01(gibProgress[i] / num2);
			float num7 = Mathf.Clamp01((num6 + Time.deltaTime) / num2);
			gibProgress[i] += Time.deltaTime;
			float num8 = scaleCurve.Evaluate(num7);
			transform.transform.localScale = new Vector3(num8, num8, num8);
			transform.transform.localScale += buildDirection * buildScaleCurve.Evaluate(num7) * buildScaleAdditionalAmount;
			transform.transform.localPosition = spawnPositions[i];
			transform.transform.position += base.transform.right * GetPushDir(spawnPositions[i], transform) * buildCurve.Evaluate(num7) * buildDirection.x;
			transform.transform.position += base.transform.up * buildCurve.Evaluate(num7) * buildDirection.y;
			transform.transform.position += base.transform.forward * buildCurve.Evaluate(num7) * buildDirection.z;
			if (num7 >= 1f && num7 > num6 && Time.time > nextEffectTime)
			{
				nextEffectTime = Time.time + effectSpacing;
				if (particles[i] != null)
				{
					particles[i].GetComponent<ParticleSystem>();
					particles[i].transform.SetParent(null, worldPositionStays: true);
					OnParentDestroyingEx.BroadcastOnParentDestroying(particles[i]);
				}
			}
		}
	}
}
