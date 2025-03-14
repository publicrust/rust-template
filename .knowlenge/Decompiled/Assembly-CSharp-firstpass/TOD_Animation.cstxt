using System;
using UnityEngine;

public class TOD_Animation : MonoBehaviour
{
	[Tooltip("How much to move the clouds when the camera moves.")]
	[TOD_Min(0f)]
	public float CameraMovement = 1f;

	[Tooltip("Wind direction in degrees.")]
	[TOD_Range(0f, 360f)]
	public float WindDegrees;

	[Tooltip("Speed of the wind that is acting on the clouds.")]
	[TOD_Min(0f)]
	public float WindSpeed = 1f;

	private TOD_Sky sky;

	public Vector3 CloudUV { get; set; }

	public Vector3 OffsetUV
	{
		get
		{
			Vector3 vector = base.transform.position * (CameraMovement * 0.0001f);
			return Quaternion.Euler(0f, 0f - base.transform.rotation.eulerAngles.y, 0f) * vector;
		}
	}

	protected void Start()
	{
		sky = GetComponent<TOD_Sky>();
		CloudUV = new Vector3(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
	}

	public void Update()
	{
		float num = Mathf.Sin(MathF.PI / 180f * WindDegrees);
		float num2 = Mathf.Cos(MathF.PI / 180f * WindDegrees);
		float num3 = 0.001f * Time.deltaTime;
		float num4 = WindSpeed * num3;
		float x = CloudUV.x;
		float y = CloudUV.y;
		float z = CloudUV.z;
		y += num3 * 0.1f;
		x -= num4 * num;
		z -= num4 * num2;
		x -= Mathf.Floor(x);
		y -= Mathf.Floor(y);
		z -= Mathf.Floor(z);
		CloudUV = new Vector3(x, y, z);
		sky.Components.BillboardTransform.localRotation = Quaternion.Euler(0f, y * 360f, 0f);
	}
}
