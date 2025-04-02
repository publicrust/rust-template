using System;
using System.Collections.Generic;
using System.Linq;
using Facepunch;
using UnityEngine;

public class HitboxSystem : MonoBehaviour, IPrefabPreProcess
{
	[Serializable]
	public class HitboxShape
	{
		public Transform bone;

		public HitboxDefinition.Type type;

		public Matrix4x4 localTransform;

		public PhysicMaterial colliderMaterial;

		private Matrix4x4 transform;

		private Matrix4x4 inverseTransform;

		public Matrix4x4 Transform => transform;

		public Vector3 Position => transform.MultiplyPoint(Vector3.zero);

		public Quaternion Rotation => transform.rotation;

		public Vector3 Size { get; private set; }

		public void UpdateTransform()
		{
			using (TimeWarning.New("HitboxSystem.UpdateTransform"))
			{
				transform = bone.localToWorldMatrix * localTransform;
				Size = transform.lossyScale;
				transform = Matrix4x4.TRS(Position, Rotation, Vector3.one);
				inverseTransform = transform.inverse;
			}
		}

		public Vector3 TransformPoint(Vector3 pt)
		{
			return transform.MultiplyPoint(pt);
		}

		public Vector3 InverseTransformPoint(Vector3 pt)
		{
			return inverseTransform.MultiplyPoint(pt);
		}

		public Vector3 TransformDirection(Vector3 pt)
		{
			return transform.MultiplyVector(pt);
		}

		public Vector3 InverseTransformDirection(Vector3 pt)
		{
			return inverseTransform.MultiplyVector(pt);
		}

		public bool Trace(Ray ray, out RaycastHit hit, float forgivness = 0f, float maxDistance = float.PositiveInfinity)
		{
			using (TimeWarning.New("Hitbox.Trace"))
			{
				ray.origin = InverseTransformPoint(ray.origin);
				ray.direction = InverseTransformDirection(ray.direction);
				if (type == HitboxDefinition.Type.BOX)
				{
					if (!new AABB(Vector3.zero, Size).Trace(ray, out hit, forgivness, maxDistance))
					{
						return false;
					}
				}
				else if (!new Capsule(Vector3.zero, Size.x, Size.y * 0.5f).Trace(ray, out hit, forgivness, maxDistance))
				{
					return false;
				}
				hit.point = TransformPoint(hit.point);
				hit.normal = TransformDirection(hit.normal);
				return true;
			}
		}

		public Bounds GetBounds()
		{
			Matrix4x4 matrix4x = Transform;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					matrix4x[i, j] = Mathf.Abs(matrix4x[i, j]);
				}
			}
			Bounds result = default(Bounds);
			result.center = Transform.MultiplyPoint(Vector3.zero);
			result.extents = matrix4x.MultiplyVector(Size);
			return result;
		}
	}

	public List<HitboxShape> hitboxes = new List<HitboxShape>();

	public void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		List<HitboxDefinition> obj = Pool.Get<List<HitboxDefinition>>();
		GetComponentsInChildren(obj);
		if (serverside)
		{
			foreach (HitboxDefinition item2 in obj)
			{
				preProcess?.RemoveComponent(item2);
			}
			preProcess?.RemoveComponent(this);
		}
		if (clientside)
		{
			hitboxes.Clear();
			foreach (HitboxDefinition item3 in obj.OrderBy((HitboxDefinition x) => x.priority))
			{
				HitboxShape item = new HitboxShape
				{
					bone = item3.transform,
					localTransform = item3.LocalMatrix,
					colliderMaterial = item3.physicMaterial,
					type = item3.type
				};
				hitboxes.Add(item);
				preProcess?.RemoveComponent(item3);
			}
		}
		Pool.FreeUnmanaged(ref obj);
	}
}
