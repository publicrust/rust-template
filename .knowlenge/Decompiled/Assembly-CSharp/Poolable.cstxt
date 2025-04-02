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
			if (Object.op_Implicit((Object)(object)((Component)this).GetComponent<CodeLock>()))
			{
				return 200;
			}
			if ((Object)(object)((Component)this).GetComponent<LootPanel>() != (Object)null)
			{
				return 1;
			}
			if (((Component)this).GetComponent<DecorComponent>() != null)
			{
				return 100;
			}
			if ((Object)(object)((Component)this).GetComponent<BuildingBlock>() != (Object)null)
			{
				return 100;
			}
			if ((Object)(object)((Component)this).GetComponent<Door>() != (Object)null)
			{
				if ((bool)((Component)this).GetComponent<Construction>())
				{
					return 100;
				}
				return 1;
			}
			if ((Object)(object)((Component)this).GetComponent<Projectile>() != (Object)null)
			{
				return 100;
			}
			if ((Object)(object)((Component)this).GetComponent<Gib>() != (Object)null)
			{
				return 100;
			}
			if (Object.op_Implicit((Object)(object)((Component)this).GetComponent<UIMapVendingMachineMarker>()))
			{
				return 25;
			}
			if (Object.op_Implicit((Object)(object)((Component)this).GetComponent<UIMapVendingMachineMarkerCluster>()))
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
		behaviours = ((Component)this).gameObject.GetComponentsInChildren(typeof(Behaviour), true).OfType<Behaviour>().ToArray();
		rigidbodies = ((Component)this).gameObject.GetComponentsInChildren<Rigidbody>(true);
		colliders = ((Component)this).gameObject.GetComponentsInChildren<Collider>(true);
		lodgroups = ((Component)this).gameObject.GetComponentsInChildren<LODGroup>(true);
		renderers = ((Component)this).gameObject.GetComponentsInChildren<Renderer>(true);
		particles = ((Component)this).gameObject.GetComponentsInChildren<ParticleSystem>(true);
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
		if ((Object)(object)((Component)this).transform.parent != (Object)null)
		{
			((Component)this).transform.SetParent((Transform)null, false);
		}
		if (Pool.mode <= 1)
		{
			if (((Component)this).gameObject.activeSelf)
			{
				((Component)this).gameObject.SetActive(false);
			}
			return;
		}
		SetBehaviourEnabled(state: false);
		SetComponentEnabled(state: false);
		if (!((Component)this).gameObject.activeSelf)
		{
			((Component)this).gameObject.SetActive(true);
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
					Behaviour val = behaviours[i];
					behaviourStates[i] = val.enabled;
					val.enabled = false;
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
				ParticleSystem val2 = particles[k];
				if (val2.playOnAwake)
				{
					val2.Play();
				}
			}
			for (int l = 0; l < behaviours.Length; l++)
			{
				behaviours[l].enabled = behaviourStates[l];
			}
		}
		catch (Exception ex)
		{
			Debug.LogError((object)("Pooling error: " + ((Object)this).name + " (" + ex.Message + ")"));
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
					Renderer val = renderers[i];
					rendererStates[i] = val.enabled;
					val.enabled = false;
				}
				for (int j = 0; j < lodgroups.Length; j++)
				{
					LODGroup val2 = lodgroups[j];
					lodgroupStates[j] = val2.enabled;
					val2.enabled = false;
				}
				for (int k = 0; k < colliders.Length; k++)
				{
					Collider val3 = colliders[k];
					colliderStates[k] = val3.enabled;
					val3.enabled = false;
				}
				for (int l = 0; l < rigidbodies.Length; l++)
				{
					Rigidbody val4 = rigidbodies[l];
					rigidbodyStates[l] = val4.isKinematic;
					val4.isKinematic = true;
					val4.detectCollisions = false;
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
			Debug.LogError((object)("Pooling error: " + ((Object)this).name + " (" + ex.Message + ")"));
		}
	}
}
