using UnityEngine;

public class CargoNotifier : MonoBehaviour, IServerComponent
{
	[SerializeField]
	private BasePath cargoPath;

	private void Start()
	{
		CargoShip.RegisterHarbor(cargoPath, base.transform.parent.transform);
	}
}
