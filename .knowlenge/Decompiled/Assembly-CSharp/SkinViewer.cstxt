using System;
using Facepunch;
using UnityEngine;
using UnityEngine.UI;

public class SkinViewer : FacepunchBehaviour
{
	[Serializable]
	public class SkinViewItem
	{
		public RawImage target;

		public ItemDefinition itemDef;

		public ulong skinID;
	}

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private Transform positionParent;

	[SerializeField]
	private Transform modelParent;

	[SerializeField]
	private GameObject[] lights;

	[SerializeField]
	private SkinSetCollection skin;

	[SerializeField]
	private float rotateResetSpeed = 200f;

	[SerializeField]
	private float dragSpeed = 0.33f;

	[SerializeField]
	private bool autoSpin;

	[SerializeField]
	private float timeoutSeconds = 15f;

	[SerializeField]
	private Skeleton skinViewerSkeleton;
}
