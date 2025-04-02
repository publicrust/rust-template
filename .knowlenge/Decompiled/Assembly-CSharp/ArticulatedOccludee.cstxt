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
		if (!Application.isQuitting)
		{
			UnregisterFromCulling();
			ClearVisibility();
		}
	}

	private void ClearVisibility()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)lodGroup != (Object)null)
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
		if ((Object)(object)lod != (Object)null)
		{
			renderers = new List<Renderer>(16);
			LOD[] lODs = lod.GetLODs();
			for (int i = 0; i < lODs.Length; i++)
			{
				Renderer[] array = lODs[i].renderers;
				foreach (Renderer val in array)
				{
					if ((Object)(object)val != (Object)null)
					{
						renderers.Add(val);
					}
				}
			}
		}
		UpdateCullingBounds();
	}

	private void RegisterForCulling(OcclusionCulling.Sphere sphere, bool visible)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (localOccludee.IsRegistered)
		{
			UnregisterFromCulling();
		}
		int num = OcclusionCulling.RegisterOccludee(sphere.position, sphere.radius, visible, 0.25f, isStatic: false, ((Component)this).gameObject.layer, OnVisibilityChanged);
		if (num >= 0)
		{
			localOccludee = new OccludeeSphere(num, localOccludee.sphere);
			return;
		}
		localOccludee.Invalidate();
		Debug.LogWarning((object)("[OcclusionCulling] Occludee registration failed for " + ((Object)this).name + ". Too many registered."));
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = Vector3.zero;
		Vector3 val2 = Vector3.zero;
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
					Vector3 min = ((Bounds)(ref bounds)).min;
					Vector3 max = ((Bounds)(ref bounds)).max;
					if (!flag)
					{
						val = min;
						val2 = max;
						flag = true;
						continue;
					}
					val.x = ((val.x < min.x) ? val.x : min.x);
					val.y = ((val.y < min.y) ? val.y : min.y);
					val.z = ((val.z < min.z) ? val.z : min.z);
					val2.x = ((val2.x > max.x) ? val2.x : max.x);
					val2.y = ((val2.y > max.y) ? val2.y : max.y);
					val2.z = ((val2.z > max.z) ? val2.z : max.z);
				}
			}
		}
		if (!flag && num2 > 0)
		{
			flag = true;
			Bounds bounds2 = colliders[0].bounds;
			val = ((Bounds)(ref bounds2)).min;
			bounds2 = colliders[0].bounds;
			val2 = ((Bounds)(ref bounds2)).max;
			for (int j = 1; j < colliders.Count; j++)
			{
				Bounds bounds3 = colliders[j].bounds;
				Vector3 min2 = ((Bounds)(ref bounds3)).min;
				Vector3 max2 = ((Bounds)(ref bounds3)).max;
				val.x = ((val.x < min2.x) ? val.x : min2.x);
				val.y = ((val.y < min2.y) ? val.y : min2.y);
				val.z = ((val.z < min2.z) ? val.z : min2.z);
				val2.x = ((val2.x > max2.x) ? val2.x : max2.x);
				val2.y = ((val2.y > max2.y) ? val2.y : max2.y);
				val2.z = ((val2.z > max2.z) ? val2.z : max2.z);
			}
		}
		if (!flag)
		{
			return;
		}
		Vector3 val3 = val2 - val;
		Vector3 position = val + val3 * 0.5f;
		float radius = Mathf.Max(Mathf.Max(val3.x, val3.y), val3.z) * 0.5f;
		OcclusionCulling.Sphere sphere = new OcclusionCulling.Sphere(position, radius);
		if (localOccludee.IsRegistered)
		{
			OcclusionCulling.UpdateDynamicOccludee(localOccludee.id, sphere.position, sphere.radius);
			localOccludee.sphere = sphere;
			return;
		}
		bool visible = true;
		if ((Object)(object)lodGroup != (Object)null)
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
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)lodGroup != (Object)null)
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
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)MainCamera.mainCamera != (Object)null && localOccludee.IsRegistered)
		{
			float dist = Vector3.Distance(MainCamera.position, ((Component)this).transform.position);
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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (((Behaviour)this).enabled)
		{
			Vector3 val = ((Component)this).transform.position - MainCamera.position;
			float sqrMagnitude = ((Vector3)(ref val)).sqrMagnitude;
			float num = 400f;
			float num2;
			if (sqrMagnitude < num)
			{
				num2 = 1f / Random.Range(5f, 25f);
			}
			else
			{
				float num3 = Mathf.Clamp01((Mathf.Sqrt(sqrMagnitude) - 20f) * 0.001f);
				float num4 = Mathf.Lerp(1f / 15f, 2f, num3);
				num2 = Random.Range(num4, num4 + 1f / 15f);
			}
			UpdateVisibility(num2);
			ApplyVisibility(isVisible);
			if (TriggerUpdateVisibilityBoundsDelegate == null)
			{
				TriggerUpdateVisibilityBoundsDelegate = TriggerUpdateVisibilityBounds;
			}
			((FacepunchBehaviour)this).Invoke(TriggerUpdateVisibilityBoundsDelegate, num2);
		}
	}
}
