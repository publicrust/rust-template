using UnityEngine;

public class BackgroundColorAttribute : PropertyAttribute
{
	public float r;

	public float g;

	public float b;

	public float a;

	public Color Color => new Color(r, g, b, a);

	public BackgroundColorAttribute()
	{
		r = (g = (b = (a = 1f)));
	}

	public BackgroundColorAttribute(float aR, float aG, float aB, float aA)
	{
		r = aR;
		g = aG;
		b = aB;
		a = aA;
	}
}
