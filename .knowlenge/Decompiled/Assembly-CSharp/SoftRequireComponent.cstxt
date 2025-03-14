using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class SoftRequireComponent : Attribute
{
	public Type m_Type0;

	public Type m_Type1;

	public Type m_Type2;

	public SoftRequireComponent(Type requiredComponent)
	{
		m_Type0 = requiredComponent;
	}

	public SoftRequireComponent(Type requiredComponent, Type requiredComponent2)
	{
		m_Type0 = requiredComponent;
		m_Type1 = requiredComponent2;
	}

	public SoftRequireComponent(Type requiredComponent, Type requiredComponent2, Type requiredComponent3)
	{
		m_Type0 = requiredComponent;
		m_Type1 = requiredComponent2;
		m_Type2 = requiredComponent3;
	}
}
