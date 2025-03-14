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

	public static Vector4[] TransmissionTints
	{
		get
		{
			if (profileTexture == null)
			{
				return null;
			}
			return profileTexture.TransmissionTints;
		}
	}

	public int Id
	{
		get
		{
			return id;
		}
		set
		{
			id = value;
		}
	}

	private void OnEnable()
	{
		profileTexture.AddProfile(this);
	}
}
