using UnityEngine;

public class CreateEffect : MonoBehaviour
{
	public GameObjectRef EffectToCreate;

	public void OnEnable()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		Effect.client.Run(EffectToCreate.resourcePath, ((Component)this).transform.position, ((Component)this).transform.up, ((Component)this).transform.forward);
	}
}
