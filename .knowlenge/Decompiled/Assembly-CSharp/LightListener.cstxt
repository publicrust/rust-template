using UnityEngine;

public class LightListener : BaseEntity
{
	public string onMessage = "";

	public string offMessage = "";

	[Tooltip("Must be part of this prefab")]
	public LightGroupAtTime onLights;

	[Tooltip("Must be part of this prefab")]
	public LightGroupAtTime offLights;

	public override void OnEntityMessage(BaseEntity from, string msg)
	{
		base.OnEntityMessage(from, msg);
		if (msg == onMessage)
		{
			SetFlag(Flags.On, b: true);
		}
		else if (msg == offMessage)
		{
			SetFlag(Flags.On, b: false);
		}
	}
}
