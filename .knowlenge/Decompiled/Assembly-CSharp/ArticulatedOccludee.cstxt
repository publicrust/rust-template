using System;
using System.Collections.Generic;
using Rust;
using UnityEngine;

public class ArticulatedOccludee : BaseMonoBehaviour
{
	private const float UpdateBoundsFadeStart = 20f;

	private const float UpdateBoundsFadeLength = 1000f;

	private const float UpdateBoundsMaxFrequency = 15f;

	private const float UpdateBoundsMinFrequency = 0.5f;

	private LODGroup lodGroup;

	public List<Collider> colliders = new List<Collider>();

	private OccludeeSphere localOccludee = new OccludeeSphere(-1);

	private List<Renderer> renderers = new List<Renderer>();

	private bool isVisible = true;

	private Action TriggerUpdateVisibilityBoundsDelegate;

	public bool IsVisible => isVisible;

	protected virtual void OnDisable()
	{
		if (!Rust.Application.isQuitting)
		{
			UnregisterFromCulling();
			ClearVisibility();
		}
	}

	private void ClearVisibility()
	{
		if (lodGroup != null)
		{
			lodGroup.localReferencePoint = Vector3.zero;
			lodGroup.RecalculateBounds();
			lodGroup = null;
		}
		if (renderers != null)
		{
			renderers.Clear();
		}
		localOccludee = new OccludeeSphere(-1);
	}

	public void ProcessVisibility(LODGroup lod)
	{
		lodGroup = lod;
		if (lod != null)
		{
			renderers = new List<Renderer>(16);
			LOD[] lODs = lod.GetLODs();
			for (int i = 0; i < lODs.Length; i++)
			{
				Renderer[] array = lODs[i].renderers;
				foreach (Renderer renderer in array)
				{
					if (renderer != null)
					{
						renderers.Add(renderer);
					}
				}
			}
		}
		UpdateCullingBounds();
	}

	private void RegisterForCulling(OcclusionCulling.Sphere sphere, bool visible)
	{
		if (localOccludee.IsRegistered)
		{
			UnregisterFromCulling();
		}
		int num = OcclusionCulling.RegisterOccludee(sphere.position, sphere.radius, visible, 0.25f, isStatic: false, base.gameObject.layer, OnVisibilityChanged);
		if (num >= 0)
		{
			localOccludee = new OccludeeSphere(num, localOccludee.sphere);
			return;
		}
		localOccludee.Invalidate();
		Debug.LogWarning("[OcclusionCulling] Occludee registration failed for " + base.name + ". Too many registered.");
	}

	private void UnregisterFromCulling()
	{
		if (localOccludee.IsRegistered)
		{
			OcclusionCulling.UnregisterOccludee(localOccludee.id);
			localOccludee.Invalidate();
		}
	}

	public void UpdateCullingBounds()
	{
		Vector3 vector = Vector3.zero;
		Vector3 vector2 = Vector3.zero;
		bool flag = false;
		int num = ((renderers != null) ? renderers.Count : 0);
		int num2 = ((colliders != null) ? colliders.Count : 0);
		if (num > 0 && (num2 == 0 || num < num2))
		{
			for (int i = 0; i < renderers.Count; i++)
			{
				if (renderers[i].isVisible)
				{
					Bounds bounds = renderers[i].bounds;
					Vector3 min = bounds.min;
					Vector3 max = bounds.max;
					if (!flag)
					{
						vector = min;
						vector2 = max;
						flag = true;
						continue;
					}
					vector.x = ((vector.x < min.x) ? vector.x : min.x);
					vector.y = ((vector.y < min.y) ? vector.y : min.y);
					vector.z = ((vector.z < min.z) ? vector.z : min.z);
					vector2.x = ((vector2.x > max.x) ? vector2.x : max.x);
					vector2.y = ((vector2.y > max.y) ? vector2.y : max.y);
					vector2.z = ((vector2.z > max.z) ? vector2.z : max.z);
				}
			}
		}
		if (!flag && num2 > 0)
		{
			flag = true;
			vector = colliders[0].bounds.min;
			vector2 = colliders[0].bounds.max;
			for (int j = 1; j < colliders.Count; j++)
			{
				Bounds bounds2 = colliders[j].bounds;
				Vector3 min2 = bounds2.min;
				Vector3 max2 = bounds2.max;
				vector.x = ((vector.x < min2.x) ? vector.x : min2.x);
				vector.y = ((vector.y < min2.y) ? vector.y : min2.y);
				vector.z = ((vector.z < min2.z) ? vector.z : min2.z);
				vector2.x = ((vector2.x > max2.x) ? vector2.x : max2.x);
				vector2.y = ((vector2.y > max2.y) ? vector2.y : max2.y);
				vector2.z = ((vector2.z > max2.z) ? vector2.z : max2.z);
			}
		}
		if (!flag)
		{
			return;
		}
		Vector3 vector3 = vector2 - vector;
		Vector3 position = vector + vector3 * 0.5f;
		float radius = Mathf.Max(Mathf.Max(vector3.x, vector3.y), vector3.z) * 0.5f;
		OcclusionCulling.Sphere sphere = new OcclusionCulling.Sphere(position, radius);
		if (localOccludee.IsRegistered)
		{
			OcclusionCulling.UpdateDynamicOccludee(localOccludee.id, sphere.position, sphere.radius);
			localOccludee.sphere = sphere;
			return;
		}
		bool visible = true;
		if (lodGroup != null)
		{
			visible = lodGroup.enabled;
		}
		RegisterForCulling(sphere, visible);
	}

	protected virtual bool CheckVisibility()
	{
		if (localOccludee.state != null)
		{
			return localOccludee.state.isVisible;
		}
		return true;
	}

	private void ApplyVisibility(bool vis)
	{
		if (lodGroup != null)
		{
			float num = ((!vis) ? 100000 : 0);
			if (num != lodGroup.localReferencePoint.x)
			{
				lodGroup.localReferencePoint = new Vector3(num, num, num);
			}
		}
	}

	protected virtual void OnVisibilityChanged(bool visible)
	{
		if (MainCamera.mainCamera != null && localOccludee.IsRegistered)
		{
			float dist = Vector3.Distance(MainCamera.position, base.transform.position);
			VisUpdateUsingCulling(dist, visible);
			ApplyVisibility(isVisible);
		}
	}

	private void UpdateVisibility(float delay)
	{
	}

	private void VisUpdateUsingCulling(float dist, bool visibility)
	{
	}

	public virtual void TriggerUpdateVisibilityBounds()
	{
		if (base.enabled)
		{
			float sqrMagnitude = (base.transform.position - MainCamera.position).sqrMagnitude;
			float num = 400f;
			float num2;
			if (sqrMagnitude < num)
			{
				num2 = 1f / UnityEngine.Random.Range(5f, 25f);
			}
			else
			{
				float t = Mathf.Clamp01((Mathf.Sqrt(sqrMagnitude) - 20f) * 0.001f);
				float num3 = Mathf.Lerp(1f / 15f, 2f, t);
				num2 = UnityEngine.Random.Range(num3, num3 + 1f / 15f);
			}
			UpdateVisibility(num2);
			ApplyVisibility(isVisible);
			if (TriggerUpdateVisibilityBoundsDelegate == null)
			{
				TriggerUpdateVisibilityBoundsDelegate = TriggerUpdateVisibilityBounds;
			}
			Invoke(TriggerUpdateVisibilityBoundsDelegate, num2);
		}
	}
}
