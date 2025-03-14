using System;
using UnityEngine;

public class ImpostorAsset : ScriptableObject
{
	[Serializable]
	public class TextureEntry
	{
		public string name;

		public Texture2D texture;

		public TextureEntry(string name, Texture2D texture)
		{
			this.name = name;
			this.texture = texture;
		}
	}

	public TextureEntry[] textures;

	public Vector2 size;

	public Vector2 pivot;

	public Mesh mesh;

	public Texture2D FindTexture(string name)
	{
		TextureEntry[] array = textures;
		foreach (TextureEntry textureEntry in array)
		{
			if (textureEntry.name == name)
			{
				return textureEntry.texture;
			}
		}
		return null;
	}
}
