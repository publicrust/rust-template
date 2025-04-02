using UnityEngine;

[CreateAssetMenu(menuName = "Rust/Skin Set")]
public class SkinSet : ScriptableObject
{
	public string Label;

	public Gradient SkinColour;

	public HairSetCollection HairCollection;

	[Header("Models")]
	public GameObjectRef Head;

	public GameObjectRef Torso;

	public GameObjectRef Legs;

	public GameObjectRef Feet;

	public GameObjectRef Hands;

	[Header("Censored Variants")]
	public GameObjectRef CensoredTorso;

	public GameObjectRef CensoredLegs;

	[Header("Materials")]
	public Material HeadMaterial;

	public Material BodyMaterial;

	public Material EyeMaterial;

	internal Color GetSkinColor(float skinNumber)
	{
		return SkinColour.Evaluate(skinNumber);
	}
}
