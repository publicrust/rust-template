using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class Ragdoll : BaseMonoBehaviour, IPrefabPreProcess
{
	public Transform eyeTransform;

	public Transform centerBone;

	public Rigidbody primaryBody;

	public PhysicMaterial physicMaterial;

	public SpringJoint corpseJoint;

	public Skeleton skeleton;

	public Model model;

	public List<Joint> joints = new List<Joint>();

	public List<CharacterJoint> characterJoints = new List<CharacterJoint>();

	public List<ConfigurableJoint> configurableJoints = new List<ConfigurableJoint>();

	public List<Rigidbody> rigidbodies = new List<Rigidbody>();

	public GameObject GibEffect;

	public void PreProcess(IPrefabProcessor preProcess, GameObject rootObj, string name, bool serverside, bool clientside, bool bundling)
	{
		if (clientside)
		{
			joints.Clear();
			characterJoints.Clear();
			configurableJoints.Clear();
			rigidbodies.Clear();
			GetComponentsInChildren(includeInactive: true, joints);
			GetComponentsInChildren(includeInactive: true, characterJoints);
			GetComponentsInChildren(includeInactive: true, configurableJoints);
			GetComponentsInChildren(includeInactive: true, rigidbodies);
		}
	}
}
