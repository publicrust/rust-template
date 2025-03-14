using UnityEngine;

public class CreateEffect : MonoBehaviour
{
	public GameObjectRef EffectToCreate;

	public void OnEnable()
	{
		Effect.client.Run(EffectToCreate.resourcePath, base.transform.position, base.transform.up, base.transform.forward);
	}
}
