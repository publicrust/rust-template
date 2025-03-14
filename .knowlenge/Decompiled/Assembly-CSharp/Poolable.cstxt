using System;
using System.Linq;
using ConVar;
using UnityEngine;

public class Poolable : MonoBehaviour, IClientComponent, IPrefabPostProcess
{
	[HideInInspector]
	public uint prefabID;

	[HideInInspector]
	public Behaviour[] behaviours;

	[HideInInspector]
	public Rigidbody[] rigidbodies;

	[HideInInspector]
	public Collider[] colliders;

	[HideInInspector]
	public LODGroup[] lodgroups;

	[HideInInspector]
	public Renderer[] renderers;

	[HideInInspector]
	public ParticleSystem[] particles;

	[HideInInspector]
	public bool[] behaviourStates;

	[HideInInspector]
	public bool[] rigidbodyStates;

	[HideInInspector]
	public bool[] colliderStates;

	[HideInInspector]
	public bool[] lodgroupStates;

	[HideInInspector]
	public bool[] rendererStates;

	public int ClientCount
	{
		get
		{
			if ((bool)GetComponent<CodeLock>())
			{
				return 200;
			}
			if (GetComponent<LootPanel>() != null)
			{
				return 1;
			}
			if (GetComponent<DecorComponent>() != null)
			{
				return 100;
			}
			if (GetComponent<BuildingBlock>() != null)
			{
				return 100;
			}
			if (GetComponent<Door>() != null)
			{
				if ((bool)GetComponent<Construction>())
				{
					return 100;
				}
				return 1;
			}
			if (GetComponent<Projectile>() != null)
			{
				return 100;
			}
			if (GetComponent<Gib>() != null)
			{
				return 100;
			}
			if ((bool)GetComponent<UIMapVendingMachineMarker>())
			{
				return 25;
			}
			if ((bool)GetComponent<UIMapVendingMachineMarkerCluster>())
			{
				return 25;
			}
			return 1;
		}
	}

	public int ServerCount => 0;

	public void PostProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		if (!bundling)
		{
			Initialize(StringPool.Get(name));
		}
	}

	public void Initialize(uint id)
	{
		prefabID = id;
		behaviours = base.gameObject.GetComponentsInChildren(typeof(Behaviour), includeInactive: true).OfType<Behaviour>().ToArray();
		rigidbodies = base.gameObject.GetComponentsInChildren<Rigidbody>(includeInactive: true);
		colliders = base.gameObject.GetComponentsInChildren<Collider>(includeInactive: true);
		lodgroups = base.gameObject.GetComponentsInChildren<LODGroup>(includeInactive: true);
		renderers = base.gameObject.GetComponentsInChildren<Renderer>(includeInactive: true);
		particles = base.gameObject.GetComponentsInChildren<ParticleSystem>(includeInactive: true);
		if (behaviours.Length == 0)
		{
			behaviours = Array.Empty<Behaviour>();
		}
		if (rigidbodies.Length == 0)
		{
			rigidbodies = Array.Empty<Rigidbody>();
		}
		if (colliders.Length == 0)
		{
			colliders = Array.Empty<Collider>();
		}
		if (lodgroups.Length == 0)
		{
			lodgroups = Array.Empty<LODGroup>();
		}
		if (renderers.Length == 0)
		{
			renderers = Array.Empty<Renderer>();
		}
		if (particles.Length == 0)
		{
			particles = Array.Empty<ParticleSystem>();
		}
		behaviourStates = ArrayEx.New<bool>(behaviours.Length);
		rigidbodyStates = ArrayEx.New<bool>(rigidbodies.Length);
		colliderStates = ArrayEx.New<bool>(colliders.Length);
		lodgroupStates = ArrayEx.New<bool>(lodgroups.Length);
		rendererStates = ArrayEx.New<bool>(renderers.Length);
	}

	public void EnterPool()
	{
		if (base.transform.parent != null)
		{
			base.transform.SetParent(null, worldPositionStays: false);
		}
		if (Pool.mode <= 1)
		{
			if (base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(value: false);
			}
			return;
		}
		SetBehaviourEnabled(state: false);
		SetComponentEnabled(state: false);
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
		}
	}

	public void LeavePool()
	{
		if (Pool.mode > 1)
		{
			SetComponentEnabled(state: true);
		}
	}

	public void SetBehaviourEnabled(bool state)
	{
		try
		{
			if (!state)
			{
				for (int i = 0; i < behaviours.Length; i++)
				{
					Behaviour behaviour = behaviours[i];
					behaviourStates[i] = behaviour.enabled;
					behaviour.enabled = false;
				}
				for (int j = 0; j < particles.Length; j++)
				{
					ParticleSystem obj = particles[j];
					obj.Stop();
					obj.Clear();
				}
				return;
			}
			for (int k = 0; k < particles.Length; k++)
			{
				ParticleSystem particleSystem = particles[k];
				if (particleSystem.playOnAwake)
				{
					particleSystem.Play();
				}
			}
			for (int l = 0; l < behaviours.Length; l++)
			{
				behaviours[l].enabled = behaviourStates[l];
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Pooling error: " + base.name + " (" + ex.Message + ")");
		}
	}

	public void SetComponentEnabled(bool state)
	{
		try
		{
			if (!state)
			{
				for (int i = 0; i < renderers.Length; i++)
				{
					Renderer renderer = renderers[i];
					rendererStates[i] = renderer.enabled;
					renderer.enabled = false;
				}
				for (int j = 0; j < lodgroups.Length; j++)
				{
					LODGroup lODGroup = lodgroups[j];
					lodgroupStates[j] = lODGroup.enabled;
					lODGroup.enabled = false;
				}
				for (int k = 0; k < colliders.Length; k++)
				{
					Collider collider = colliders[k];
					colliderStates[k] = collider.enabled;
					collider.enabled = false;
				}
				for (int l = 0; l < rigidbodies.Length; l++)
				{
					Rigidbody rigidbody = rigidbodies[l];
					rigidbodyStates[l] = rigidbody.isKinematic;
					rigidbody.isKinematic = true;
					rigidbody.detectCollisions = false;
				}
			}
			else
			{
				for (int m = 0; m < renderers.Length; m++)
				{
					renderers[m].enabled = rendererStates[m];
				}
				for (int n = 0; n < lodgroups.Length; n++)
				{
					lodgroups[n].enabled = lodgroupStates[n];
				}
				for (int num = 0; num < colliders.Length; num++)
				{
					colliders[num].enabled = colliderStates[num];
				}
				for (int num2 = 0; num2 < rigidbodies.Length; num2++)
				{
					Rigidbody obj = rigidbodies[num2];
					obj.isKinematic = rigidbodyStates[num2];
					obj.detectCollisions = true;
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Pooling error: " + base.name + " (" + ex.Message + ")");
		}
	}
}
