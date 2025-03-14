using UnityEngine;

[ExecuteInEditMode]
public class TOD_Components : MonoBehaviour
{
	public GameObject Space;

	public GameObject Stars;

	public GameObject Sun;

	public GameObject Moon;

	public GameObject Atmosphere;

	public GameObject Clear;

	public GameObject Clouds;

	public GameObject Billboards;

	public GameObject Light;

	public Transform DomeTransform { get; set; }

	public Transform SpaceTransform { get; set; }

	public Transform StarTransform { get; set; }

	public Transform SunTransform { get; set; }

	public Transform MoonTransform { get; set; }

	public Transform AtmosphereTransform { get; set; }

	public Transform ClearTransform { get; set; }

	public Transform CloudTransform { get; set; }

	public Transform BillboardTransform { get; set; }

	public Transform LightTransform { get; set; }

	public Renderer SpaceRenderer { get; set; }

	public Renderer StarRenderer { get; set; }

	public Renderer SunRenderer { get; set; }

	public Renderer MoonRenderer { get; set; }

	public Renderer AtmosphereRenderer { get; set; }

	public Renderer ClearRenderer { get; set; }

	public Renderer CloudRenderer { get; set; }

	public Renderer[] BillboardRenderers { get; set; }

	public MeshFilter SpaceMeshFilter { get; set; }

	public MeshFilter StarMeshFilter { get; set; }

	public MeshFilter SunMeshFilter { get; set; }

	public MeshFilter MoonMeshFilter { get; set; }

	public MeshFilter AtmosphereMeshFilter { get; set; }

	public MeshFilter ClearMeshFilter { get; set; }

	public MeshFilter CloudMeshFilter { get; set; }

	public MeshFilter[] BillboardMeshFilters { get; set; }

	public Material SpaceMaterial { get; set; }

	public Material StarMaterial { get; set; }

	public Material SunMaterial { get; set; }

	public Material MoonMaterial { get; set; }

	public Material AtmosphereMaterial { get; set; }

	public Material ClearMaterial { get; set; }

	public Material CloudMaterial { get; set; }

	public Material[] BillboardMaterials { get; set; }

	public Light LightSource { get; set; }

	public TOD_Sky Sky { get; set; }

	public TOD_Animation Animation { get; set; }

	public TOD_Time Time { get; set; }

	public TOD_Camera Camera { get; set; }

	public TOD_Rays Rays { get; set; }

	public TOD_Scattering Scattering { get; set; }

	public TOD_Shadows Shadows { get; set; }

	public void Initialize()
	{
		DomeTransform = GetComponent<Transform>();
		Sky = GetComponent<TOD_Sky>();
		Animation = GetComponent<TOD_Animation>();
		Time = GetComponent<TOD_Time>();
		if ((bool)Space)
		{
			SpaceTransform = Space.GetComponent<Transform>();
			SpaceRenderer = Space.GetComponent<Renderer>();
			SpaceMeshFilter = Space.GetComponent<MeshFilter>();
			SpaceMaterial = SpaceRenderer.sharedMaterial;
		}
		if ((bool)Stars)
		{
			StarTransform = Stars.GetComponent<Transform>();
			StarRenderer = Stars.GetComponent<Renderer>();
			StarMeshFilter = Stars.GetComponent<MeshFilter>();
			StarMaterial = StarRenderer.sharedMaterial;
		}
		if ((bool)Sun)
		{
			SunTransform = Sun.GetComponent<Transform>();
			SunRenderer = Sun.GetComponent<Renderer>();
			SunMeshFilter = Sun.GetComponent<MeshFilter>();
			SunMaterial = SunRenderer.sharedMaterial;
		}
		if ((bool)Moon)
		{
			MoonTransform = Moon.GetComponent<Transform>();
			MoonRenderer = Moon.GetComponent<Renderer>();
			MoonMeshFilter = Moon.GetComponent<MeshFilter>();
			MoonMaterial = MoonRenderer.sharedMaterial;
		}
		if ((bool)Atmosphere)
		{
			AtmosphereTransform = Atmosphere.GetComponent<Transform>();
			AtmosphereRenderer = Atmosphere.GetComponent<Renderer>();
			AtmosphereMeshFilter = Atmosphere.GetComponent<MeshFilter>();
			AtmosphereMaterial = AtmosphereRenderer.sharedMaterial;
		}
		if ((bool)Clear)
		{
			ClearTransform = Clear.GetComponent<Transform>();
			ClearRenderer = Clear.GetComponent<Renderer>();
			ClearMeshFilter = Clear.GetComponent<MeshFilter>();
			ClearMaterial = ClearRenderer.sharedMaterial;
		}
		if ((bool)Clouds)
		{
			CloudTransform = Clouds.GetComponent<Transform>();
			CloudRenderer = Clouds.GetComponent<Renderer>();
			CloudMeshFilter = Clouds.GetComponent<MeshFilter>();
			CloudMaterial = CloudRenderer.sharedMaterial;
		}
		if ((bool)Billboards)
		{
			BillboardTransform = Billboards.GetComponent<Transform>();
			BillboardRenderers = Billboards.GetComponentsInChildren<Renderer>();
			BillboardMeshFilters = Billboards.GetComponentsInChildren<MeshFilter>();
			BillboardMaterials = new Material[BillboardRenderers.Length];
			for (int i = 0; i < BillboardRenderers.Length; i++)
			{
				BillboardMaterials[i] = BillboardRenderers[i].sharedMaterial;
			}
		}
		if ((bool)Light)
		{
			LightTransform = Light.GetComponent<Transform>();
			LightSource = Light.GetComponent<Light>();
		}
	}
}
