using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
public class FPD_HideOnBoolAttribute : PropertyAttribute
{
	public string BoolVarName = "";

	public bool HideInInspector;

	public FPD_HideOnBoolAttribute(string boolVariableName)
	{
		BoolVarName = boolVariableName;
		HideInInspector = false;
	}

	public FPD_HideOnBoolAttribute(string conditionalSourceField, bool hideInInspector)
	{
		BoolVarName = conditionalSourceField;
		HideInInspector = hideInInspector;
	}
}
