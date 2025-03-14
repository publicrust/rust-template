using Rust;
using UnityEngine;

public class SubsurfaceProfile : ScriptableObject
{
	private static SubsurfaceProfileTexture profileTexture = new SubsurfaceProfileTexture();

	public SubsurfaceProfileData Data = SubsurfaceProfileData.Default;

	private int id = -1;

	public static Texture2D Texture
	{
		get
		{
			if (profileTexture == null)
			{
				return null;
			}
			return profileTexture.Texture;
		}
	}

	public int Id => id;

	private void OnEnable()
	{
		id = profileTexture.AddProfile(Data, this);
	}

	private void OnDisable()
	{
		if (!Rust.Application.isQuitting)
		{
			profileTexture.RemoveProfile(id);
		}
	}

	public void Update()
	{
		profileTexture.UpdateProfile(id, Data);
	}
}
