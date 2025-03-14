using UnityEngine;

public class LevelInfo : SingletonComponent<LevelInfo>
{
	public string shortName;

	public string displayName;

	[TextArea]
	public string description;

	[Tooltip("A background image to be shown when loading the map")]
	public Texture2D image;

	[Space(10f)]
	[Tooltip("You should incrememnt this version when you make changes to the map that will invalidate old saves")]
	public int version = 1;
}
